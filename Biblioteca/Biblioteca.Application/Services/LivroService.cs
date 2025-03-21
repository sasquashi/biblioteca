﻿using Biblioteca.Application.DTOs;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Services
{
    public class LivroService : BaseService<Livro, LivroDTO>
    {
        public LivroService(
            ILivroRepository livroRepository, 
            HistoricoAcaoService historicoAcaoService,
            HistoricoVendaService historicoVendaService)
            : base(livroRepository, historicoAcaoService, historicoVendaService)
        { }

        protected override LivroDTO MapToDto(Livro livro)
        {
            if (livro == null) return null;
            return new LivroDTO
            {
                CodL = livro.CodL,
                Titulo = livro.Titulo,
                Editora = livro.Editora,
                Edicao = livro.Edicao,
                AnoPublicacao = livro.AnoPublicacao,
                Valor = livro.Valor,
                DataCadastro = livro.DataCadastro,
                AutorIds = livro.LivroAutores.Select(la => la.Autor_CodAu).ToList(),
                AssuntoIds = livro.LivroAssuntos.Select(la => la.Assunto_CodAs).ToList()
            };
        }

        protected override Livro MapToEntity(LivroDTO dto)
        {
            return new Livro
            {
                Titulo = dto.Titulo,
                Editora = dto.Editora,
                Edicao = dto.Edicao,
                AnoPublicacao = dto.AnoPublicacao,
                Valor = dto.Valor,
                DataCadastro = DateTime.Now,
                LivroAutores = dto.AutorIds.Select(id => new LivroAutor { Autor_CodAu = id }).ToList(),
                LivroAssuntos = dto.AssuntoIds.Select(id => new LivroAssunto { Assunto_CodAs = id }).ToList()
            };
        }

        protected override void UpdateEntity(Livro livro, LivroDTO dto)
        {
            livro.Titulo = dto.Titulo;
            livro.Editora = dto.Editora;
            livro.Edicao = dto.Edicao;
            livro.AnoPublicacao = dto.AnoPublicacao;
            livro.Valor = dto.Valor;
        }

        protected override int GetIdFromDto(LivroDTO dto)
        {
            return dto.CodL;
        }
    }
}
