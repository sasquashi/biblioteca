import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AssuntoComponent } from './pages/assunto/assunto.component';
import { AutorComponent } from './pages/autor/autor.component';
import { LivroComponent } from './pages/livro/livro.component';
import { VendaComponent } from './pages/venda/venda.component';
import { FormaCompraComponent } from './pages/forma-compra/forma-compra.component';
import { FormaPagamentoComponent } from './pages/forma-pagamento/forma-pagamento.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'assuntos', component: AssuntoComponent },
  { path: 'autores', component: AutorComponent },
  { path: 'livros', component: LivroComponent },
  { path: 'vendas', component: VendaComponent },
  { path: 'formas-compra', component: FormaCompraComponent },
  { path: 'formas-pagamento', component: FormaPagamentoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
