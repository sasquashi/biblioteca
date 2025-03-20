import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AssuntoComponent } from './pages/assunto/assunto.component';
import { AutorComponent } from './pages/autor/autor.component';
import { LivroComponent } from './pages/livro/livro.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'assuntos', component: AssuntoComponent },
  { path: 'autores', component: AutorComponent },
  { path: 'livros', component: LivroComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
