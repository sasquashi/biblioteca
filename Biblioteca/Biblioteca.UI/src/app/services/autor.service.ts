import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './../shared/service/base.service';
import { Autor } from '../models/autor';

@Injectable({
  providedIn: 'root'
})

export class AutorService extends BaseService<Autor> {
  constructor(http: HttpClient) {
    super(http, 'Autor');
  }
}
