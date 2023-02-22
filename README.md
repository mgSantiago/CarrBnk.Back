# CarrBnk

O projeto CarrBnk � um exemplo de c�digo criado para valida��o t�cnica, ele � constitu�do dos tr�s microsservi�os abaixo

- CarrBnk.Authentication
- CarrBnk.Financial
- CarrBnk.Financial.Report

Todos eles foram constru�dos utilizando conhecimento pr�vio em Arquitetura Hexagonal e Clean Architecture, estes projetos foram feitos com apenas tr�s camadas, tendo uma camada App de entrada, uma camada Core para l�gica de neg�cios e entidades e uma camada final de Infra contendo os adaptadores necess�rios para cada projeto. A camada Core foi reduzida de duas para uma camada, pois o intuito do projeto � ser microsservi�o, sendo assim, a complexidade arquitetural foi reduzida.

Todos os projetos est�o inclu�dos no mesmo reposit�rio apenas para facilitar a valida��o, por�m, em um projeto real, cada microsservi�o teria seu reposit�rio separado.

# Tecnologias Utilizadas

- .Net 6;
- MongoDb;
- Redis; 
- RabbitMq;

# Boas Pr�ticas Pr�ticas/Padr�es Utilizados

- SOLID
- DDD
- MicroServices
- Notification Pattern com Fail Fast Validation
- Singleton Pattern
- Factory Pattern
- Facade Pattern
- Iterator Pattern
- Mediator Pattern
- Observer Pattern
- Messaging Pattern
- Repository Pattern

# Desenhos Arquiteturais

#### Intera��es do usu�rio

![](https://msantiago-public-bucket.s3.amazonaws.com/arch-carrbnk.drawio.png)

#### Intera��es entre servi�os

![](https://msantiago-public-bucket.s3.amazonaws.com/arch-carrbnk-interactions.drawio.png)

# Testes Unit�rios

Todos os projetos tem 100% de cobertura das linhas de testes unit�rios em cima da l�gica de neg�cio, esta l�gica se encontra na camada Core de cada projeto nas pastas "Entities", "UseCase" e "UseCase\Validators"

Cada microsservi�o tem seu pr�prio projeto de teste, se tivessemos os tr�s reposit�rios separados como dito anteriormente, cada projeto de teste ficaria com seu respectivo respons�vel.

# Prepara��o

Para fazer com que o projeto execute, � importante subir o docker-compose.yml localizado na raiz do projeto com o comando abaixo

```bash
docker-compose up -d
```

Com o docker compose inicializado, todos os projetos j� est�o aptos a rodar, com seu visual studio preferido com o [.Net 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) instalado na m�quina.

## Autentica��o

Todos os projetos tem uma ou mais chamadas autenticadas, para obter o token de autentica��o, � necess�rio rodar o projeto CarrBnk.Authentication e  fazer a seguinte chamada:

#### *[POST] /api/v1/authentication/login* 

```javascript
{ 
   UserName = "teste" 
   Password = "passwd"
}
```

# Rotas

## CarrBnk.Authentication
#### **[POST] /api/v1/authentication/login**

Request:

```javascript
{ 
   string userName, 
   string password 
}
```

Response:

>Status 200

```javascript
{ 
   string username, 
   string role, 
   string token 
}
```

>Status 400

## CarrBnk.Financial
### **[POST] /api/v1/transactions**

Request:

```javascript
{ 
   number value, 
   int financialPostingType [1=in,2=out], 
   string description 
}
```

Response:

> Status 200
>
```javascript
{
   string username, 
   string role, 
   string token 
}
```

>Status 400

>Status 500



### **[PUT] /api/v1/transactions**

Request:

```javascript
{
   string code, 
   number value, 
   number financialPostingType[1=in,2=out],
   string description 
}
```

Response:

> Status 200
>
```javascript
{  
   bool 
}
```

>Status 400

>Status 500

## CarrBnk.Financial.Report

### **[GET] /api/v1/transactions-report**

Request:

```javascript
{ 
   date date 
}
```

Response:

> Status 200
> 
```javascript
{ 
   number dailyConsolidation, 
   number cashInFlowMovementsCount, 
   number cashOutFlowMovementsCount, 
   number totalMovements 
} 
```

>Status 400

>Status 500

# Auxiliares Opcionais 

## RabbitMq

> http://localhost:15672/#/

**Login:** gest

**Senha:** gest

## MongoDb

> http://localhost:8081/

**Login:** root

**Senha:** mongopasswd

## Redis GUI
```bash
choco install another-redis-desktop-manager
```

# Outras Informa��es

Este projeto deve ser considerado como uma vers�o Alfa, pois tem bastante possibilidade de evolu��o, ele foi feito da melhor forma poss�vel no tempo dispon�vel, em caso de alguma d�vida ou evolu��o, a discuss�o sempre ser� bem vinda.