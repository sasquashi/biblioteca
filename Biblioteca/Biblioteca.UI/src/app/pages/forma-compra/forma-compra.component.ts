import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormaCompraService } from '../../services/forma-compra.service';
import { FormaCompra } from '../../models/forma-compra';
import { BaseComponent } from '../../shared/component/base.component';

@Component({
  selector: 'app-forma-compra',
  templateUrl: './forma-compra.component.html',
  styleUrls: ['./forma-compra.component.scss'],
})
export class FormaCompraComponent extends BaseComponent<FormaCompra> {
  constructor(service: FormaCompraService, router: Router) {
    super(service, router, 'forma de compra');
    this.selectedItem = { codFC: 0, descricao: '' };
  }
  override ngOnInit(): void {
    this.resetForm();
  }
}
