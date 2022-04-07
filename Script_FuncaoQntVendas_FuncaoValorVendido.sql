USE WSTowers;
GO

--Funcao calcular vendas por regiao

SELECT COUNT(vendas.id) FROM regiao
LEFT JOIN estado
ON regiao.id = estado.Regiao
LEFT JOIN cidade
ON estado.id = cidade.Estado
LEFT JOIN participante
ON cidade.id = participante.cidade
INNER JOIN vendas
ON participante.id = vendas.participante
WHERE regiao.id = 5;


CREATE FUNCTION CalcularQntVendas(@IdRegiaoCalculo INT)
RETURNS INT
AS BEGIN
DECLARE @QntVendas INT

SET @QntVendas = (
	SELECT COUNT(vendas.id) AS QntVendas FROM regiao
	LEFT JOIN estado
	ON regiao.id = estado.Regiao
	LEFT JOIN cidade
	ON estado.id = cidade.Estado
	LEFT JOIN participante
	ON cidade.id = participante.cidade
	INNER JOIN vendas
	ON participante.id = vendas.participante
	WHERE regiao.id = @IdRegiaoCalculo
)

RETURN(@QntVendas)
END;
GO

SELECT dbo.CalcularQntVendas(5);
GO

--Funcao calcular valor vendido por regiao

SELECT SUM(produto.valor) FROM regiao
LEFT JOIN estado
ON regiao.id = estado.Regiao
LEFT JOIN cidade
ON estado.id = cidade.Estado
LEFT JOIN participante
ON cidade.id = participante.cidade
INNER JOIN vendas
ON participante.id = vendas.participante
LEFT JOIN produto
ON vendas.produto = produto.id
WHERE regiao.id = 4;
GO

CREATE FUNCTION CalcularValorVendido(@IdRegiaoCalculo INT)
RETURNS INT
AS BEGIN
DECLARE @ValorVendido INT

SET @ValorVendido = (
	SELECT SUM(produto.valor) AS ValorVendido FROM regiao
	LEFT JOIN estado
	ON regiao.id = estado.Regiao
	LEFT JOIN cidade
	ON estado.id = cidade.Estado
	LEFT JOIN participante
	ON cidade.id = participante.cidade
	INNER JOIN vendas
	ON participante.id = vendas.participante
	LEFT JOIN produto
	ON vendas.produto = produto.id
	WHERE regiao.id = @IdRegiaoCalculo
)

RETURN(@ValorVendido)
END;
GO

SELECT dbo.CalcularValorVendido(4);
GO

--Adicionando as funcoes a tabela regiao

ALTER TABLE regiao
ADD QntVendas AS dbo.CalcularQntVendas(regiao.id);
GO

ALTER TABLE regiao
ADD ValorVendido AS dbo.CalcularValorVendido(regiao.id);
GO

SELECT * FROM regiao;
GO