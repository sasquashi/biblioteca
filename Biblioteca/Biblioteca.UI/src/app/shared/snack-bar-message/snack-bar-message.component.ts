import { Component, Inject } from '@angular/core';
import { MatSnackBar, MatSnackBarRef, MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';

@Component({
  selector: 'app-snack-bar-message',
  templateUrl: './snack-bar-message.component.html',
  styleUrls: ['./snack-bar-message.component.css'],
})
export class SnackBarMessageComponent {
  private static snackBar: MatSnackBar | null = null;

  static tipo: string;
  constructor(
    public snackBarRef: MatSnackBarRef<SnackBarMessageComponent>,
    @Inject(MAT_SNACK_BAR_DATA) public data: { message: string; type: 'success' | 'warning' | 'error' }
  ) {
    console.log('Data recebida:', this.data);
  }

  static setSnackBar(snackBar: MatSnackBar): void {
    this.snackBar = snackBar;
  }

  static show(message: string, type: 'success' | 'warning' | 'error'): void {
    this.tipo = type;
    if (this.snackBar) {
      console.log('Abrindo SnackBar com type:', type);
      this.snackBar.openFromComponent(SnackBarMessageComponent, {
        data: { message: message, type: type },
        duration: 2000,
        horizontalPosition: 'end',
        verticalPosition: 'top',
        panelClass: [`snack-${type}`],
      });
    } else {
      console.error('SnackBar não inicializado. Injete o MatSnackBar primeiro.');
    }
  }
}