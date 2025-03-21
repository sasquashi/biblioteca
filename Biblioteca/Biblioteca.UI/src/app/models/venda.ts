export interface Venda {
  codV: number;
  codFC: number;
  codL: number;
  valorLivro: number;
  teveDesconto?: boolean;
  valorFinal: number;
  dataVenda: string;
  codFP: number;
}
