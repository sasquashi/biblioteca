import { Directive, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BaseService } from '../../shared/service/base.service';
import { SnackBarMessageComponent } from '../snack-bar-message/snack-bar-message.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Directive()
export abstract class BaseComponent<T> implements OnInit {
  items: T[] = [];
  selectedItem: T | null = null;
  isEdit = false;
  isLoading = false;
  validationErrors: string[] = [];

  constructor(
    protected service: BaseService<T>,
    protected router: Router,
    protected routePrefix: string,
    private snackBar: MatSnackBar,
    protected requiredFields: string[] = []
  ) {
    SnackBarMessageComponent.setSnackBar(this.snackBar);
  }

  ngOnInit(): void {
    this.loadItems();
  }

  loadItems(): void {
    this.isLoading = true;
    this.service.getAll().subscribe({
      next: (data) => {
        this.items = data.sort((a, b) => {
          const idField = this.getIdField(this.routePrefix);
          const idA = (a as any)[idField];
          const idB = (b as any)[idField];
          return idB - idA;
        });
        this.isLoading = false;
      },
      error: (err) => {
        console.error(`Erro ao carregar ${this.routePrefix}:`, err);
        this.isLoading = false;
      },
    });
  }

  editItem(id: number): void {
    this.isLoading = true;
    this.service.getById(id).subscribe({
      next: (data) => {
        this.selectedItem = data;
        this.isEdit = true;
        this.isLoading = false;
        this.validationErrors = [];
      },
      error: (err) => {
        console.error('Erro ao carregar item:', err);
        this.isLoading = false;
      },
    });
  }

  deleteItem(id: number): void {
    if (confirm(`Tem certeza que deseja excluir este ${this.routePrefix}?`)) {
      this.isLoading = true;
      this.service.delete(id).subscribe({
        next: () => {
          this.isLoading = false;
          this.loadItems();
          SnackBarMessageComponent.show(
            this.routePrefix + ' excluído com sucesso',
            'error'
          );
        },
        error: (err) => {
          console.error(`Erro ao excluir ${this.routePrefix}:`, err);
          this.isLoading = false;
        },
      });
    }
  }

  saveItem(item: T): void {
    if (this.informarCamposObrigatorios(item) > 0) {
      return;
    }

    const idField = this.getIdField(this.routePrefix);
    const id = (item as any)[idField];

    if (this.isEdit) {
      this.isLoading = true;
      this.service.update(id, item).subscribe({
        next: () => {
          SnackBarMessageComponent.show(
            this.routePrefix + ' atualizado com sucesso',
            'warning'
          );
          this.resetForm();
          this.isLoading = false;
        },
        error: (err) => {
          console.error(`Erro ao atualizar ${this.routePrefix}:`, err);
          this.isLoading = false;
        },
      });
    } else {
      this.service.add(item).subscribe({
        next: () => {
          this.isLoading = false;
          SnackBarMessageComponent.show(
            this.routePrefix + ' cadastrado com sucesso',
            'success'
          );
          this.resetForm();
        },
        error: (err) => {
          console.error(`Erro ao adicionar ${this.routePrefix}:`, err);
          this.isLoading = false;
        },
      });
    }
  }

  resetForm(): void {
    this.selectedItem = null;
    this.isEdit = false;
    this.loadItems();
  }

  private getIdField(routePrefix: string): string {
    const idFields: { [key: string]: string } = {
      livro: 'codL',
      autor: 'codAu',
      assunto: 'codAs',
      venda: 'codV',
      'forma de compra': 'codFC',
      'forma de pagamento': 'codFP',
    };
    return idFields[routePrefix];
  }

  informarCamposObrigatorios(item: T): number {
    let retorno = 0;
    this.validationErrors = this.validateItem(item);
    if (this.validationErrors.length > 0) {
      SnackBarMessageComponent.show(
        'Por favor, preencha os campos obrigatórios',
        'error'
      );
      retorno = this.validationErrors.length;
    }
    return retorno;
  }

  private validateItem(item: T): string[] {
    const errors: string[] = [];
    if (!item) return ['Item não pode ser nulo'];

    this.requiredFields.forEach((field) => {
      const value = (item as any)[field];
      if (
        value === null ||
        value === undefined ||
        value === '' ||
        value === 0 ||
        (Array.isArray(value) && value.length === 0)
      ) {
        errors.push(field);
      }
    });
    return errors;
  }
}
