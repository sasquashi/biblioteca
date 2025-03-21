import { Component } from '@angular/core';
import { BaseComponent } from '../../shared/component/base.component';
import { Router } from '@angular/router';
import { FormaPagamentoService } from '../../services/forma-pagamento.service';
import { FormaPagamento } from '../../models/forma-pagamento';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
  selector: 'app-forma-pagamento',
  templateUrl: './forma-pagamento.component.html',
  styleUrls: ['./forma-pagamento.component.css'],
})
export class FormaPagamentoComponent extends BaseComponent<FormaPagamento> {
  constructor(
    service: FormaPagamentoService, 
    router: Router,
    snackBar: MatSnackBar) {
    super(service, router, 'forma de pagamento', snackBar);
    this.selectedItem = { codFP: 0, descricao: '' };
  }
  override ngOnInit(): void {
    this.resetForm();
  }
}
