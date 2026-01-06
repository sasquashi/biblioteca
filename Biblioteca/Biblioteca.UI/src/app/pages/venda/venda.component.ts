import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { VendaService } from '../../services/venda.service';
import { Venda } from '../../models/venda';
import { BaseComponent } from '../../shared/component/base.component';
import { LivroService } from '../../services/livro.service';
import { FormaCompraService } from '../../services/forma-compra.service';
import { FormaPagamentoService } from '../../services/forma-pagamento.service';
import { Livro } from '../../models/livro';
import { FormaCompra } from '../../models/forma-compra';
import { FormaPagamento } from '../../models/forma-pagamento';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackBarMessageComponent } from '../../shared/snack-bar-message/snack-bar-message.component';

@Component({
  selector: 'app-venda',
  templateUrl: './venda.component.html',
  styleUrls: ['./venda.component.css'],
})
export class VendaComponent extends BaseComponent<Venda> {
  livros: Livro[] = [];
  formasCompra: FormaCompra[] = [];
  formasPagamento: FormaPagamento[] = [];

  constructor(
    service: VendaService,
    router: Router,
    private livroService: LivroService,
    private formaCompraService: FormaCompraService,
    private formaPagamentoService: FormaPagamentoService,
    snackBar: MatSnackBar
  ) {
    super(service, router, 'venda', snackBar, ['codFP', 'codFC', 'codL', 'valorLivro', 'teveDesconto', 'valorFinal', 'valorFinal']);
    this.selectedItem = {
      codV: 0,
      codFC: 0,
      codL: 0,
      valorLivro: 0,
      teveDesconto: undefined,
      valorFinal: 0,
      dataVenda: new Date().toISOString(),
      codFP: 0,
    };
  }

  override ngOnInit(): void {
    super.ngOnInit();
    this.loadLivros();
    this.loadFormasCompra();
    this.loadFormasPagamento();
    this.resetForm();
  }

  loadLivros(): void {
    this.livroService
      .getAll()
      .subscribe({ next: (data) => (this.livros = data) });
  }

  loadFormasCompra(): void {
    this.formaCompraService
      .getAll()
      .subscribe({ next: (data) => (this.formasCompra = data) });
  }

  loadFormasPagamento(): void {
    this.formaPagamentoService
      .getAll()
      .subscribe({ next: (data) => (this.formasPagamento = data) });
  }

  getLivroTitulo(codL: number): string {
    const livro = this.livros.find((l) => l.codL === codL);
    return livro ? livro.titulo : `Livro ${codL}`;
  }

  getFormaCompraDescricao(codFC: number): string {
    const forma = this.formasCompra.find((fc) => fc.codFC === codFC);
    return forma ? forma.descricao : `Forma ${codFC}`;
  }

  getFormaPagamentoDescricao(codFP: number): string {
    const forma = this.formasPagamento.find((fp) => fp.codFP === codFP);
    return forma ? forma.descricao : `Forma ${codFP}`;
  }

  addNewItem(): void {
    this.selectedItem = {
      codV: 0,
      codFC: 0,
      codL: 0,
      valorLivro: 0,
      teveDesconto: undefined,
      valorFinal: 0,
      dataVenda: new Date().toISOString(),
      codFP: 0,
    };
    this.isEdit = false;
  }

  isFormValid(): boolean {
    if (!this.selectedItem) {
      return false;
    }
    return (
      this.selectedItem.codFC > 0 &&
      this.selectedItem.codL > 0 &&
      this.selectedItem.codFP > 0 &&
      this.selectedItem.valorLivro > 0 &&
      this.selectedItem.valorFinal > 0
    );
  }

  override saveItem(item: Venda): void {
    if (!this.isFormValid()) {
      return;
    }
    this.isLoading = true;
    if (this.isEdit) {
      this.service.update(item.codV, item).subscribe({
        next: () => {
          this.isLoading = false;
          SnackBarMessageComponent.show(
            this.routePrefix + ' atualizado com sucesso',
            'success'
          );
          this.resetForm();
        },
        error: (err) => {
          console.error(`Erro ao atualizar ${this.routePrefix}:`, err);
          this.isLoading = false;
        },
      });
    } else {
      const { codV, ...itemWithoutId } = item;
      this.service.add(itemWithoutId as Venda).subscribe({
        next: () => {
          this.isLoading = false;
          SnackBarMessageComponent.show(
            this.routePrefix + ' cadastrado com sucesso',
            'success'
          );
          this.resetForm();
        },
        error: (err) => {
          console.error(`Erro ao adicionar ${this.routePrefix}:`, err);
          this.isLoading = false;
        },
      });
    }
  }
}
