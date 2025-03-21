import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-rounting.module';
import { HomeComponent } from './pages/home/home.component';
import { AssuntoComponent } from './pages/assunto/assunto.component';
import { AutorComponent } from './pages/autor/autor.component';
import { LivroComponent } from './pages/livro/livro.component';
import { FormaCompraComponent } from './pages/forma-compra/forma-compra.component';
import { FormaPagamentoComponent } from './pages/forma-pagamento/forma-pagamento.component';
import { VendaComponent } from './pages/venda/venda.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { SnackBarMessageComponent } from './shared/snack-bar-message/snack-bar-message.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
declarations: [
    AppComponent,
    HomeComponent,
    AssuntoComponent,
    AutorComponent,
    LivroComponent,
    FormaPagamentoComponent,
    FormaCompraComponent,
    VendaComponent,
    SnackBarMessageComponent
],
imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    MatSnackBarModule
],
providers: [
    provideAnimationsAsync()
  ],
bootstrap: [AppComponent]
})

export class AppModule { }