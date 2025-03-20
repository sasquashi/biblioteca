import { Directive, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BaseService } from '../../shared/service/base.service';

@Directive()
export abstract class BaseComponent<T> implements OnInit {
  items: T[] = [];
  selectedItem: T | null = null;
  isEdit = false;

  constructor(
    protected service: BaseService<T>,
    protected router: Router,
    protected routePrefix: string
  ) {}

  ngOnInit(): void {
    this.loadItems();
  }

  loadItems(): void {
    this.service.getAll().subscribe({
      next: (data) => (this.items = data),
      error: (err) =>
        console.error(`Erro ao carregar ${this.routePrefix}:`, err),
    });
  }

  editItem(id: number): void {
    this.service.getById(id).subscribe({
      next: (data) => {
        this.selectedItem = data;
        this.isEdit = true;
      },
      error: (err) => console.error('Erro ao carregar item:', err),
    });
  }

  deleteItem(id: number): void {
    if (confirm(`Tem certeza que deseja excluir este ${this.routePrefix}?`)) {
      this.service.delete(id).subscribe({
        next: () => this.loadItems(),
        error: (err) =>
          console.error(`Erro ao excluir ${this.routePrefix}:`, err),
      });
    }
  }

  saveItem(item: T): void {
    if (this.isEdit) {
      const id =
        (item as any).codL ||
        (item as any).codAu ||
        (item as any).codAs ||
        (item as any).codV ||
        (item as any).codFC ||
        (item as any).codFP;
      this.service.update(id, item).subscribe({
        next: () => this.resetForm(),
        error: (err) =>
          console.error(`Erro ao atualizar ${this.routePrefix}:`, err),
      });
    } else {
      this.service.add(item).subscribe({
        next: () => this.resetForm(),
        error: (err) =>
          console.error(`Erro ao adicionar ${this.routePrefix}:`, err),
      });
    }
  }

  resetForm(): void {
    this.selectedItem = null;
    this.isEdit = false;
    this.loadItems();
  }
}
