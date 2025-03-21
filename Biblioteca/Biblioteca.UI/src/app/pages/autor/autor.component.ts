import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AutorService } from '../../services/autor.service';
import { Autor } from '../../models/autor';
import { BaseComponent } from '../../shared/component/base.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-autor',
  templateUrl: './autor.component.html',
  styleUrls: ['./autor.component.css'],
})
export class AutorComponent extends BaseComponent<Autor> {
  constructor(
    service: AutorService, 
    router: Router, 
    snackBar: MatSnackBar
  ) {
    super(service, router, 'autor', snackBar, ['nome']);
    this.selectedItem = { codAu: 0, nome: '' };
  }

  override ngOnInit(): void {
    this.resetForm();
  }
}
