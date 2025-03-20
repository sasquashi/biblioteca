import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './../shared/service/base.service';
import { Livro } from '../models/livro';

@Injectable({
  providedIn: 'root',
})
export class LivroService extends BaseService<Livro> {
  constructor(http: HttpClient) {
    super(http, 'Livro');
  }
}
