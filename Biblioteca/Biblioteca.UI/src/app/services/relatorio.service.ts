// src/app/shared/service/relatorio.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RelatorioService {
  protected apiUrl = 'https://localhost:44392/api/relatorio';

  constructor(private http: HttpClient) {}

  getRelatorioLivrosPorAutor(): Observable<Blob> {
    return this.http.get(`${this.apiUrl}/livros-por-autor`, {
      responseType: 'blob',
    });
  }
}
