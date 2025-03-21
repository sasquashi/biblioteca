import { Component } from '@angular/core';
import { BaseComponent } from '../../shared/component/base.component';
import { Livro } from '../../models/livro';
import { Autor } from '../../models/autor';
import { Assunto } from '../../models/assunto';
import { LivroService } from '../../services/livro.service';
import { Router } from '@angular/router';
import { AutorService } from '../../services/autor.service';
import { AssuntoService } from '../../services/assunto.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-livro',
  templateUrl: './livro.component.html',
  styleUrl: './livro.component.css',
})
export class LivroComponent extends BaseComponent<Livro> {
  autores: Autor[] = [];
  assuntos: Assunto[] = [];

  constructor(
    service: LivroService,
    router: Router,
    private autorService: AutorService,
    private assuntoService: AssuntoService,
    snackBar: MatSnackBar
  ) {
    super(service, router, 'livro', snackBar, ['titulo','editora','edicao', 'anoPublicacao', 'valor', 'autorIds', 'assuntoIds']);
    this.selectedItem = {
      codL: 0,
      titulo: '',
      editora: '',
      edicao: 0,
      anoPublicacao: '',
      valor: 0,
      dataCadastro: new Date().toISOString().split('T')[0],
      autorIds: [],
      assuntoIds: [],
    };
  }

  override ngOnInit(): void {
    super.ngOnInit();
    this.loadAutores();
    this.loadAssuntos();
    this.resetForm();
  }

  loadAutores(): void {
    this.autorService
      .getAll()
      .subscribe({ next: (data) => (this.autores = data) });
  }

  loadAssuntos(): void {
    this.assuntoService
      .getAll()
      .subscribe({ next: (data) => (this.assuntos = data) });
  }

  addNewItem(): void {
    this.selectedItem = { 
      codL: 0, 
      titulo: '', 
      editora: '', 
      edicao: 0, 
      anoPublicacao: '', 
      valor: 0, 
      dataCadastro: new Date().toISOString().split('T')[0], // Data atual
      autorIds: [], 
      assuntoIds: [] 
    };
    this.isEdit = false;
  }
}
