--------------------------------------------------------------------------------------
-- Para atender ao DESAFIO criei esse arquivo para ir versionando os scripts
-- de banco de dados que acho que serão interessantes para a codificação.
--------------------------------------------------------------------------------------

CREATE DATABASE Biblioteca;
GO

USE Biblioteca;
GO

-- Tabela de Livros, fiz alguns ajustes que acredito que seriam melhores
CREATE TABLE Livro (
    CodL INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(40) NOT NULL,
    Editora VARCHAR(40) NOT NULL,
    Edicao INT NOT NULL,
    AnoPublicacao CHAR(4) NOT NULL,
    Valor DECIMAL(10,2) NOT NULL CHECK (Valor >= 0), -- Valor do livro
	DataCadastro DATETIME NOT NULL
	-- POR SER MAIS SIMPLES NÃO IREI COLOCAR, PORÉM PODERIA TER AQUI DATAATUALIZAÇÃO E CASO TIVESSE PERFIS DE CADSATRO, 
	-- PODERIA TER ID DA PESSOA QUE CADASTROU E O PERFIL DE QUEM ATUALIZOU ENTRE OUTROS.
);
GO

-- Tabela de Autores
CREATE TABLE Autor (
    CodAu INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(40) NOT NULL
);
GO

-- Tabela de Assuntos
CREATE TABLE Assunto (
    CodAs INT IDENTITY(1,1) PRIMARY KEY,
    Descricao VARCHAR(20) NOT NULL
);
GO

-- Relacionamento Livro-Autor
CREATE TABLE Livro_Autor (
    Livro_CodL INT NOT NULL,
    Autor_CodAu INT NOT NULL,
    PRIMARY KEY (Livro_CodL, Autor_CodAu),
    FOREIGN KEY (Livro_CodL) REFERENCES Livro(CodL) ON DELETE CASCADE,
    FOREIGN KEY (Autor_CodAu) REFERENCES Autor(CodAu) ON DELETE CASCADE
);
GO

-- Índices para otimizar buscas
CREATE INDEX Livro_Autor_FKIndex1 ON Livro_Autor(Livro_CodL);
CREATE INDEX Livro_Autor_FKIndex2 ON Livro_Autor(Autor_CodAu);
GO

-- Relacionamento Livro-Assunto
CREATE TABLE Livro_Assunto (
    Livro_CodL INT NOT NULL,
    Assunto_CodAs INT NOT NULL,
    PRIMARY KEY (Livro_CodL, Assunto_CodAs),
    FOREIGN KEY (Livro_CodL) REFERENCES Livro(CodL) ON DELETE CASCADE,
    FOREIGN KEY (Assunto_CodAs) REFERENCES Assunto(CodAs) ON DELETE CASCADE
);
GO

-- Índices para otimizar buscas
CREATE INDEX Livro_Assunto_FKIndex1 ON Livro_Assunto(Livro_CodL);
CREATE INDEX Livro_Assunto_FKIndex2 ON Livro_Assunto(Assunto_CodAs);
GO

-- Tabela de Formas de Compra (Balcão, Internet, etc.)
CREATE TABLE FormaCompra (
    CodFC INT IDENTITY(1,1) PRIMARY KEY,
    Descricao VARCHAR(30) NOT NULL UNIQUE
);
GO

-- Tabela de Formas de Pagamento (Pix, Cartão, Dinheiro, etc.)
CREATE TABLE FormaPagamento (
    CodFP INT IDENTITY(1,1) PRIMARY KEY,
    Descricao VARCHAR(30) NOT NULL UNIQUE
);
GO


-- Inserindo dados na tabela de Formas de Compra
INSERT INTO FormaCompra (Descricao) VALUES 
('Balcão'),
('Internet'),
('Evento'),
('Self-service');
GO

-- Inserindo dados na tabela de Formas de Pagamento
INSERT INTO FormaPagamento (Descricao) VALUES 
('Pix'),
('Cartão'),
('Dinheiro'),
('Cartão de Crédito'),
('Cartão de Débito');
GO


-- Tabela de Vendas
CREATE TABLE Venda (
    CodV INT IDENTITY(1,1) PRIMARY KEY,
    CodFC INT NOT NULL, -- Forma de Compra
    CodL INT NOT NULL,  -- Livro vendido
    ValorLivro DECIMAL(10,2) NOT NULL CHECK (ValorLivro >= 0), -- Preço do livro no momento da venda
    TeveDesconto BIT NOT NULL DEFAULT 0, -- Indica se teve desconto
    ValorFinal DECIMAL(10,2) NOT NULL CHECK (ValorFinal > 0), -- Valor final a ser considerado na venda após desconto
    DataVenda DATETIME NOT NULL DEFAULT GETDATE(),
    CodFP INT NOT NULL, -- Forma de Pagamento
    FOREIGN KEY (CodFC) REFERENCES FormaCompra(CodFC),
    FOREIGN KEY (CodL) REFERENCES Livro(CodL),
    FOREIGN KEY (CodFP) REFERENCES FormaPagamento(CodFP)
);
GO

-- View para Relatório por Autor
CREATE VIEW vw_RelatorioLivros AS
SELECT 
    A.Nome AS Autor,
    L.Titulo,
    L.Editora,
    L.Edicao,
    L.AnoPublicacao,
    S.Descricao AS Assunto
FROM Livro L
JOIN Livro_Autor LA ON L.CodL = LA.Livro_CodL
JOIN Autor A ON LA.Autor_CodAu = A.CodAu
JOIN Livro_Assunto LS ON L.CodL = LS.Livro_CodL
JOIN Assunto S ON LS.Assunto_CodAs = S.CodAs;
GO


-- Índices para melhorar performance
CREATE INDEX IDX_Livro_Titulo ON Livro(Titulo);
CREATE INDEX IDX_Livro_Editora ON Livro(Editora);
CREATE INDEX IDX_Livro_AnoPublicacao ON Livro(AnoPublicacao);

CREATE INDEX IDX_Autor_Nome ON Autor(Nome);

CREATE INDEX IDX_Assunto_Descricao ON Assunto(Descricao);

CREATE INDEX IDX_FormaCompra_Descricao ON FormaCompra(Descricao);
CREATE INDEX IDX_FormaPagamento_Descricao ON FormaPagamento(Descricao);

CREATE INDEX IDX_Venda_DataVenda ON Venda(DataVenda);
CREATE INDEX IDX_Venda_CodFC ON Venda(CodFC);
CREATE INDEX IDX_Venda_CodFP ON Venda(CodFP);
CREATE INDEX IDX_Venda_CodL ON Venda(CodL);

-- Tabela de Histórico de Vendas (Registro de mudanças em vendas)
CREATE TABLE HistoricoVenda (
    CodHV INT IDENTITY(1,1) PRIMARY KEY,
    CodV INT NOT NULL,
    CodFC INT NOT NULL,
    CodL INT NOT NULL,
    ValorLivro DECIMAL(10,2) NOT NULL,
    TeveDesconto BIT NOT NULL,
    ValorFinal DECIMAL(10,2) NOT NULL,
    DataVenda DATETIME NOT NULL,
    CodFP INT NOT NULL,
    DataModificacao DATETIME DEFAULT GETDATE(), -- Momento da alteração
    UsuarioModificacao VARCHAR(50) NOT NULL -- Usuário responsável
);
GO

-- Índices para otimizar buscas no histórico de vendas
CREATE INDEX IDX_HistoricoVenda_CodV ON HistoricoVenda(CodV);
CREATE INDEX IDX_HistoricoVenda_DataModificacao ON HistoricoVenda(DataModificacao);

-- Tabela de Histórico de Ações (Registro de CRUDs importantes)
CREATE TABLE HistoricoAcao (
    CodHA INT IDENTITY(1,1) PRIMARY KEY,
    TabelaAfetada VARCHAR(50) NOT NULL,
    TipoAcao VARCHAR(10) NOT NULL CHECK (TipoAcao IN ('INSERT', 'UPDATE', 'DELETE')),
    DescricaoAcao VARCHAR(255) NOT NULL,
    DataAcao DATETIME DEFAULT GETDATE(),
    UsuarioAcao VARCHAR(50) NOT NULL
);
GO

-- Índices para melhorar performance no histórico de ações
CREATE INDEX IDX_HistoricoAcao_Tabela ON HistoricoAcao(TabelaAfetada);
CREATE INDEX IDX_HistoricoAcao_Data ON HistoricoAcao(DataAcao);
