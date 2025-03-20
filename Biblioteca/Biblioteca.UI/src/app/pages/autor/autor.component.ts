import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AutorService } from '../../services/autor.service';
import { Autor } from '../../models/autor';
import { BaseComponent } from '../../shared/component/base.component';

@Component({
  selector: 'app-autor',
  templateUrl: './autor.component.html',
  styleUrls: ['./autor.component.scss']
})
export class AutorComponent extends BaseComponent<Autor> {
  constructor(service: AutorService, router: Router) {
    super(service, router, 'autor');
    this.selectedItem = { codAu: 0, nome: '' };
  }

  override ngOnInit(): void {
    this.resetForm();
  }
}