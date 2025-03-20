import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './../shared/service/base.service';
import { Assunto } from '../models/assunto';

@Injectable({
  providedIn: 'root'
})
export class AssuntoService extends BaseService<Assunto> {
  constructor(http: HttpClient) {
    super(http, 'Assunto');
  }
}