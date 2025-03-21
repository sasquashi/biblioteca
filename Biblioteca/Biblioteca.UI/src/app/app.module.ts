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

@NgModule({
declarations: [
    AppComponent,
    HomeComponent,
    AssuntoComponent,
    AutorComponent,
    LivroComponent,
    FormaPagamentoComponent,
    FormaCompraComponent,
    VendaComponent
],
imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
],
providers: [],
bootstrap: [AppComponent]
})

export class AppModule { }