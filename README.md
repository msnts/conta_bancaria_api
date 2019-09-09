# API - Conta Bancaria
API Restful que implementa as regras de negocio de  uma conta bancaria

## Banco de Dados
Execute o comando de execução das migrations

> dotnet ef database update

## Resources
* Listas contas

GET https://localhost:5001/api/contas
* Cadastrar uma nova conta

POST https://localhost:5001/api/contas

* Atualizar uma conta

PUT https://localhost:5001/api/contas/1

Body:
```javascript
{
	"id":1,
	"saldo": 20
}
```

* Excluir uma conta

DELETE https://localhost:5001/api/contas/1

* Executar um deposito

POST https://localhost:5001/api/contas/1/depositos

Body:
```javascript
{
	"contaId":1,
	"valor": 20
}
```

* Executar um saque

POST https://localhost:5001/api/contas/1/saques

Body:
```javascript
{
	"contaId":1,
	"valor": 20
}
```

* Executar uma transferencia

POST https://localhost:5001/api/contas/1/transferencias

Body:
```javascript
{
	"ContaOrigemId":1,
	"ContaDestinoId":2,
	"valor": 100
}
```