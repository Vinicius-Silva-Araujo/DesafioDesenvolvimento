# DesafioDesenvolvimento
Criando aplicação Crud

* EntityFrameworkCore
* EntityFrameworkCore.Design
* EntityFrameworkCore.SqlServer
* EntityFrameworkCore.Tools
* AspNetCore.Authentication
* AspNetCore.JwtBearer
* Swashbuckle.AspNetCore
* AutoMapper
* Microsoft.AspNetCore.Mvc
  

  
  ![Swagger](https://github.com/Vinicius-Silva-Araujo/fioDesenvolvimento/assets/129880603/d410f503-e161-4665-97f5-46b774701cc6)

# Desafio 2
 
  Uma consulta que traga as informações de contas a pagar e contas pagas, sendo que ele precisa do número do processo
  de pagamento, nome do fornecedor, data de vencimento, data de pagamento, valor líquido e
  o um identificador se é conta a pagar ou paga.

### Query da consulta 
SELECT p.nome, 'Contas pagas' as Origem, cPagas.*, + cPagas.acrescimo - cPagas.desconto as valor
FROM Pessoa p
INNER JOIN contas_pagas cPagas ON cPagas.codigo_fornecedor = p.codigo

UNION

SELECT p.nome, 'Contas a Pagar' as Origem, cPagar.*, + cPagar.acressimo - cPagar.desconto as valor
FROM Pessoa p
INNER JOIN contas_a_pagar cPagar ON cPagar.codigo_fornecedor = p.codigo

  ![image](https://github.com/vini-Baba-Yaga/DesafioDesenvolvimento/assets/129880603/02ab3e36-90b3-4e01-9340-9d6dcfabca98)


  
