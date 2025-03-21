import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormaCompraService } from '../../services/forma-compra.service';
import { FormaCompra } from '../../models/forma-compra';
import { BaseComponent } from '../../shared/component/base.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-forma-compra',
  templateUrl: './forma-compra.component.html',
  styleUrls: ['./forma-compra.component.css'],
})
export class FormaCompraComponent extends BaseComponent<FormaCompra> {
  constructor(
    service: FormaCompraService,
    router: Router,
    snackBar: MatSnackBar
  ) {
    super(service, router, 'forma de compra', snackBar, ['descricao']);
    this.selectedItem = { codFC: 0, descricao: '' };
  }
  override ngOnInit(): void {
    this.resetForm();
  }
}
