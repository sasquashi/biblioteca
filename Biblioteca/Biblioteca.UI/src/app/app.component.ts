import { Component } from '@angular/core';
import { RelatorioService } from './services/relatorio.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'Biblioteca.UI';

  constructor(private relatorioService: RelatorioService) {}

  generateRelatorioLivrosPorAutor(): void {
    this.relatorioService.getRelatorioLivrosPorAutor().subscribe({
      next: (blob) => {
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = 'RelatorioLivrosPorAutor.pdf';
        a.click();
        window.URL.revokeObjectURL(url);
      },
      error: (err) => console.error('Erro ao gerar relatório:', err),
    });
  }
}
