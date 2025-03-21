import { Component } from '@angular/core';
import { BaseComponent } from '../../shared/component/base.component';
import { Assunto } from '../../models/assunto';
import { Router } from '@angular/router';
import { AssuntoService } from '../../services/assunto.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-assunto',
  templateUrl: './assunto.component.html',
  styleUrls: ['./assunto.component.css'],
})
export class AssuntoComponent extends BaseComponent<Assunto> {
  constructor(
    service: AssuntoService, 
    router: Router,
    snackBar: MatSnackBar
    ) {
    super(service, router, 'assunto', snackBar);
    this.selectedItem = { codAs: 0, descricao: '' };
  }
  override ngOnInit(): void {
    this.resetForm();
  }
}
