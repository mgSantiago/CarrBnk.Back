# CarrBnk

O projeto CarrBnk é um exemplo de código criado para validação técnica, ele é constituído dos três microsserviços abaixo

- CarrBnk.Authentication
- CarrBnk.Financial
- CarrBnk.Financial.Report

Todos eles foram construídos utilizando conhecimento prévio em Arquitetura Hexagonal e Clean Architecture, estes projetos foram feitos com apenas três camadas, tendo uma camada App de entrada, uma camada Core para lógica de negócios e entidades e uma camada final de Infra contendo os adaptadores necessários para cada projeto. A camada Core foi reduzida de duas para uma camada, pois o intuito do projeto é ser microsserviço, sendo assim, a complexidade arquitetural foi reduzida.

Todos os projetos estão incluídos no mesmo repositório apenas para facilitar a validação, porém, em um projeto real, cada microsserviço teria seu repositório separado.

# Tecnologias Utilizadas

- .Net 6;
- MongoDb;
- Redis; 
- RabbitMq;

# Boas Práticas Práticas/Padrões Utilizados

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

#### Interações do usuário

![](https://msantiago-public-bucket.s3.amazonaws.com/arch-carrbnk.drawio.png)

#### Interações entre serviços

![](https://msantiago-public-bucket.s3.amazonaws.com/arch-carrbnk-interactions.drawio.png)

# Testes Unitários

Todos os projetos tem 100% de cobertura das linhas de testes unitários em cima da lógica de negócio, esta lógica se encontra na camada Core de cada projeto nas pastas "Entities", "UseCase" e "UseCase\Validators"

Cada microsserviço tem seu próprio projeto de teste, se tivessemos os três repositórios separados como dito anteriormente, cada projeto de teste ficaria com seu respectivo responsável.

# Preparação

Para fazer com que o projeto execute, é importante subir o docker-compose.yml localizado na raiz do projeto com o comando abaixo

```bash
docker-compose up -d
```

Com o docker compose inicializado, todos os projetos já estão aptos a rodar, com seu visual studio preferido com o [.Net 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) instalado na máquina.

## Autenticação

Todos os projetos tem uma ou mais chamadas autenticadas, para obter o token de autenticação, é necessário rodar o projeto CarrBnk.Authentication e  fazer a seguinte chamada:

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

# Outras Informações

Este projeto deve ser considerado como uma versão Alfa, pois tem bastante possibilidade de evolução, ele foi feito da melhor forma possível no tempo disponível, em caso de alguma dúvida ou evolução, a discussão sempre será bem vinda.