import { Component } from '@angular/core';
import { BaseComponent } from '../../shared/component/base.component';
import { Assunto } from '../../models/assunto';
import { Router } from '@angular/router';
import { AssuntoService } from '../../services/assunto.service';

@Component({
  selector: 'app-assunto',
  templateUrl: './assunto.component.html',
  styleUrls: ['./assunto.component.scss'],
})
export class AssuntoComponent extends BaseComponent<Assunto> {
  constructor(service: AssuntoService, router: Router) {
    super(service, router, 'assunto');
    this.selectedItem = { codAs: 0, descricao: '' };
  }
  override ngOnInit(): void {
    this.resetForm();
  }
}
