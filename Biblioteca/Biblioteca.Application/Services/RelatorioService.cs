using jsreport.AspNetCore;
using jsreport.Types;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Biblioteca.Domain.Interfaces;
using System.Data;

namespace Biblioteca.Application.Services
{
    public class RelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepository;
        private readonly IJsReportMVCService _jsReportService;

        public RelatorioService(IRelatorioRepository relatorioRepository, IJsReportMVCService jsReportService)
        {
            _relatorioRepository = relatorioRepository;
            _jsReportService = jsReportService;
        }

        public async Task<byte[]> GenerateRelatorioLivrosPorAutorAsync()
        {
            var dataTable = await _relatorioRepository.GetLivrosPorAutorAsync();

            var htmlTemplate = @"
                <h1>Relatório de Livros por Autor</h1>
                {{#each data}}
                    <h2>{{this.Autor}}</h2>
                    <table border='1'>
                        <thead>
                            <tr>
                                <th>Título</th>
                                <th>Editora</th>
                                <th>Edição</th>
                                <th>Ano</th>
                                <th>Assunto</th>
                            </tr>
                        </thead>
                        <tbody>
                            {{#each this.Livros}}
                                <tr>
                                    <td>{{Titulo}}</td>
                                    <td>{{Editora}}</td>
                                    <td>{{Edicao}}</td>
                                    <td>{{AnoPublicacao}}</td>
                                    <td>{{Assunto}}</td>
                                </tr>
                            {{/each}}
                        </tbody>
                    </table>
                {{/each}}
            ";

            // Agrupar dados por autor
            var groupedData = dataTable.AsEnumerable()
                .GroupBy(row => row["Autor"].ToString())
                .Select(g => new
                {
                    Autor = g.Key,
                    Livros = g.Select(row => new
                    {
                        Titulo = row["Titulo"].ToString(),
                        Editora = row["Editora"].ToString(),
                        Edicao = row["Edicao"].ToString(),
                        AnoPublicacao = row["AnoPublicacao"].ToString(),
                        Assunto = row["Assunto"].ToString()
                    }).ToList()
                });

            var report = await _jsReportService.RenderAsync(new RenderRequest
            {
                Template = new Template
                {
                    Content = htmlTemplate,
                    Engine = Engine.Handlebars,
                    Recipe = Recipe.ChromePdf
                },
                Data = new { data = groupedData }
            });

            using (var memoryStream = new MemoryStream())
            {
                report.Content.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}