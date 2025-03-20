import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './../shared/service/base.service';
import { FormaCompra } from '../models/forma-compra';

@Injectable({
  providedIn: 'root'
})
export class FormaCompraService extends BaseService<FormaCompra> {
  constructor(http: HttpClient) {
    super(http, 'FormaCompra');
  }
}