import { Component } from '@angular/core';
import { BaseComponent } from '../../shared/component/base.component';
import { Router } from '@angular/router';
import { FormaPagamentoService } from '../../services/forma-pagamento.service';
import { FormaPagamento } from '../../models/forma-pagamento';

@Component({
  selector: 'app-forma-pagamento',
  templateUrl: './forma-pagamento.component.html',
  styleUrls: ['./forma-pagamento.component.scss'],
})
export class FormaPagamentoComponent extends BaseComponent<FormaPagamento> {
  constructor(service: FormaPagamentoService, router: Router) {
    super(service, router, 'forma de pagamento');
    this.selectedItem = { codFP: 0, descricao: '' };
  }
  override ngOnInit(): void {
    this.resetForm();
  }
}
