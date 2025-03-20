import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './../shared/service/base.service';
import { Venda } from '../models/venda';

@Injectable({
  providedIn: 'root'
})
export class VendaService extends BaseService<Venda> {
  constructor(http: HttpClient) {
    super(http, 'Venda');
  }
}