import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export abstract class BaseService<T> {
  protected apiUrl = 'https://localhost:44392/api';

  constructor(protected http: HttpClient, protected endpoint: string) {}

  getAll(): Observable<T[]> {
    return this.http.get<T[]>(`${this.apiUrl}/${this.endpoint}`);
  }

  getById(id: number): Observable<T> {
    return this.http.get<T>(`${this.apiUrl}/${this.endpoint}/${id}`);
  }

  add(item: T): Observable<T> {
    return this.http.post<T>(`${this.apiUrl}/${this.endpoint}`, item);
  }

  update(id: number, item: T): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${this.endpoint}/${id}`, item);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${this.endpoint}/${id}`);
  }
}
