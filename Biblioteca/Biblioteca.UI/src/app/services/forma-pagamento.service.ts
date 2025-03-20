import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './../shared/service/base.service';
import { FormaPagamento } from '../models/forma-pagamento';

@Injectable({
  providedIn: 'root'
})
export class FormaPagamentoService extends BaseService<FormaPagamento> {
  constructor(http: HttpClient) {
    super(http, 'FormaPagamento');
  }
}