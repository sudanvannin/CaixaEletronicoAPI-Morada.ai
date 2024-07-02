# Caixa Eletrônico API

## Descrição

Esta API simula o funcionamento de um caixa eletrônico. Ela recebe um valor de saque desejado e retorna a quantidade de cédulas de cada valor necessárias para compor esse saque, utilizando a menor quantidade de cédulas possível. As cédulas consideradas são: 100, 50, 20, 10, 5 e 2.

## Funcionalidades

- Calcula a menor quantidade de cédulas necessárias para um valor de saque dado.
- Valida a entrada para garantir que é um número inteiro positivo.
- Limita o valor máximo de saque para 100000.
- Utiliza cache para melhorar a performance em requisições repetidas.
- Documentação e teste de API utilizando Swagger.

## Endpoints

### POST /api/saque

#### Request

- **URL:** `/api/saque`
- **Método:** `POST`
- **Headers:** `Content-Type: application/json`
- **Body (JSON):**
  ```json
  {
    "valor": 380
  }
#### Response

- **Status Code:** `200 OK`
- **Body (JSON):**
  ```json
  {
    "100": 3,
    "50": 1,
    "20": 1,
    "10": 1,
    "5": 0,
    "2": 0
  }
# Mensagens de Erro da Caixa Eletrônico API

## Descrição

Este documento descreve as mensagens de erro retornadas pela API do Caixa Eletrônico. A API valida a entrada para garantir que o valor do saque seja um número inteiro positivo e dentro de um limite permitido.

## Mensagens de Erro

### Valor Não Numérico ou Inválido

- **Status Code:** `400 Bad Request`
- **Mensagem de Erro:** `Valor de saque deve ser um número inteiro positivo.`
- **Descrição:** Esta mensagem é retornada quando o valor fornecido para saque não é um número inteiro positivo. Isso inclui entradas como letras, caracteres especiais ou valores negativos.

### Valor de Saque Negativo

- **Status Code:** `400 Bad Request`
- **Mensagem de Erro:** `Valor de saque deve ser um número inteiro positivo.`
- **Descrição:** Esta mensagem é retornada quando o valor de saque fornecido é negativo. A API exige que o valor de saque seja um número inteiro positivo.

### Valor de Saque Acima do Limite

- **Status Code:** `400 Bad Request`
- **Mensagem de Erro:** `Valor de saque não pode exceder 100000.`
- **Descrição:** Esta mensagem é retornada quando o valor de saque fornecido excede o limite máximo permitido de 100000. A API tem um limite para evitar valores de saque excessivamente altos.


## Instalação e Execução

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/sudanvannin/CaixaEletronicoAPI-Morada.ai.git
   cd caixaeletronicoapi
2. **Instale as dependências:
   ```bash
   dotnet restore
3. **Compile e execute o projeto:**
   ```bash
   dotnet build
   dotnet run
4. **Acesse a API**
   - **A aplicação estará disponível em https://localhost:5001 ou http://localhost:5000**
5. **Acesse o SwaggerUI**
   - **A documentação da API estará disponível em https://localhost:5001/swagger ou http://localhost:5000/swagger**

## Estrutura do Projeto

- **Controllers:**
  - `SaqueController.cs`: "Gerencia as requisições de saque."
- **Models:**
  - `SaqueRequest.cs`: "Modelo para a requisição de saque."
  - `SaqueResponse.cs`: "Modelo para a resposta de saque."
- **Services:**
  - `SaqueService.cs`: "Lógica de negócio para calcular a quantidade de cédulas."
- **Program.cs:**
  - "Configura a aplicação e inicia o servidor."
- **Startup.cs:**
  - "Configura os serviços e o pipeline de middleware."
# Desafios do Projeto

Durante o desenvolvimento da Caixa Eletrônico API, enfrentei vários desafios interessantes, que abordei da seguinte maneira:

### 1. Validação de Entradas

**Desafio:**
Garantir que o valor inserido pelo usuário seja um número inteiro positivo e dentro de um intervalo permitido, além de lidar com entradas inválidas como letras e caracteres especiais.

**Solução:**
Implementei validações no modelo `SaqueRequest` e no controlador `SaqueController` para garantir que apenas valores válidos sejam processados. Além disso, incluí mensagens de erro padronizadas para orientar o usuário sobre entradas inválidas.

### 2. Eficiência na Distribuição de Cédulas

**Desafio:**
Desenvolver um algoritmo eficiente que sempre retorne a menor quantidade de cédulas possíveis para um valor de saque dado.

**Solução:**
Criei um serviço (`SaqueService`) que utiliza um algoritmo guloso para calcular a quantidade mínima de cédulas necessárias. Testei extensivamente este algoritmo para garantir sua precisão e eficiência.

### 3. Cache para Melhorar Performance

**Desafio:**
Reduzir o tempo de processamento para valores de saque que são solicitados repetidamente.

**Solução:**
Implementei um mecanismo de cache no `SaqueService` para armazenar e reutilizar os resultados de saques já calculados. Isso melhorou significativamente a performance em requisições repetidas.
