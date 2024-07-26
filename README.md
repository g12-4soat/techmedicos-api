<p dir="auto"><img src="https://github.com/g12-4soat/techmedicos-iac/blob/main/docs/Imagem/logo-techmedicos.png" alt="TECHMEDICOS" title="TECHMEDICOS" align="right" height="60" style="max-width: 100%;"></p>

# Tech Medicos API
Projeto Hackaton

Repositório dedicado ao projeto de API do Hackaton da FIAP - Turma 4SOAT.

# Descrição

Este projeto faz parte do curso de pós-graduação em Arquitetura de Software oferecido pela FIAP. Temos como objetivo a implementação de uma aplicação monolítica que servirá como um Produto Mínimo Viável (MVP) para um cliente específico. O projeto busca criar uma solução que aborde uma série de funcionalidades essenciais em um único sistema coeso, com o intuito de demonstrar o potencial de um produto completo, antes de avançar para um desenvolvimento mais complexo e robusto. A aplicação será projetada para incluir funcionalidades essenciais que cubram as necessidades básicas do cliente, proporcionando uma plataforma eficiente para o gerenciamento de consultas médicas com gestão de prontuários compartilhado.

# Documentação

<h4 tabindex="-1" dir="auto" data-react-autofocus="true">Stack</h4>

<p>
  <a target="_blank" rel="noopener noreferrer nofollow" href="https://camo.githubusercontent.com/71ae40a5c68bd66e1cb3813f84a5b71dd3c270c8f2506143d33be1c23f0b0783/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f2e4e45542d3531324244343f7374796c653d666f722d7468652d6261646765266c6f676f3d646f746e6574266c6f676f436f6c6f723d7768697465"><img src="https://camo.githubusercontent.com/71ae40a5c68bd66e1cb3813f84a5b71dd3c270c8f2506143d33be1c23f0b0783/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f2e4e45542d3531324244343f7374796c653d666f722d7468652d6261646765266c6f676f3d646f746e6574266c6f676f436f6c6f723d7768697465" data-canonical-src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&amp;logo=dotnet&amp;logoColor=white" style="max-width: 100%;"></a>
  <a target="_blank" rel="noopener noreferrer nofollow" href="https://camo.githubusercontent.com/ffd9b9f100120fd49ebdbe8064adec834a0927f7be93551d12804c85fb92a298/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f432532332d3233393132303f7374796c653d666f722d7468652d6261646765266c6f676f3d637368617270266c6f676f436f6c6f723d7768697465"><img src="https://camo.githubusercontent.com/ffd9b9f100120fd49ebdbe8064adec834a0927f7be93551d12804c85fb92a298/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f432532332d3233393132303f7374796c653d666f722d7468652d6261646765266c6f676f3d637368617270266c6f676f436f6c6f723d7768697465" data-canonical-src="https://img.shields.io/badge/CSHARP-6A5ACD.svg?style=for-the-badge&amp;logo=csharp&amp;logoColor=white" style="max-width: 100%;"></a>
</p>

<details>
  <summary>Como executar o projeto?</summary>
  
## Executando o Projeto
O procedimento para executar o projeto é simples e leva poucos passos: 

1. Clone o repositório: _[https://github.com/g12-4soat/techmedicos-iac](https://github.com/g12-4soat/techmedicos-iac.git)_
 
2. Abra a pasta via linha de comando no diretório escolhido no **passo 1**. _Ex.: c:\> cd “c:/techmedicos-iac”_

## Via Kubernetes
Da raiz do repositório, entre no diretório ./k8s (onde se encontram todos os manifestos .yaml para execução no kubernetes), dê um duplo clique no arquivo "apply-all.sh" ou execute o seguinte comando no terminal:

### Windows
> PS c:\techmedicos-infra-k8s\k8s> sh apply-all.sh

### Unix Systems (Linux distros | MacOS)
> exec apply-all.sh

## Postman 
Para importar as collections do postman, basta acessar os links a seguir:
- Collection: https://github.com/g12-4soat/techmedicos-docs/blob/main/collections/Tech%20Medicos%20Hackaton%20API.postman_collection.json
- Local Environment: https://github.com/g12-4soat/techmedicos-docs/blob/main/collections/Tech%20Medicos%20Hackaton%20Auth.postman_collection.json

> Quando uma nova instância do API Gateway é criada, uma nova URL é gerada, exigindo a atualização manual da URL na Enviroment do Postman.
  ---

</details>

<details>
  <summary>Versões</summary>

## Software
- C-Sharp - 12.0
- .NET - 8.0
</details>

---

## Pipeline Status
| Pipeline | Status |
| --- | --- | 
| Pipeline techmedicos-api | [![Pipeline techmedicos-api](https://github.com/g12-4soat/techmedicos-api/actions/workflows/pipeline-cicd.yml/badge.svg)](https://github.com/g12-4soat/techmedicos-api/actions/workflows/pipeline-cicd.yml)

---
