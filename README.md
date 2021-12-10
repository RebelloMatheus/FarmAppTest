# FarmAppTest




## Não tem SQL Server instalado?

# Sugestão, criar no docker

1. Crie um arquivo docker-compose.yml e cole o código a baixo:

```
version: "3.8"

services:
  sql:
    image: luizcarlosfaria/mssql-server-linux:2019-latest
    environment: {
      "ACCEPT_EULA" : "Y",
      "SA_PASSWORD" : "MINHA_SENHA_FORTE",
      "MSSQL_DATABASE" : "FarmApp",
      "MSSQL_DATABASE_COLLATE" : "SQL_Latin1_General_CP1_CI_AI",
      "MSSQL_USER" : "FarmApp",
      "MSSQL_PASSWORD" : "MINHA_SENHA_FORTE",
    }
    ports: 
      - 1433:1433
    volumes: 
      - "./scripts/:/docker-entrypoint-initdb.d/"
    container_name: mssqlFarmApp
 
```

2. Rode o comando no PowerShell

```PowerShell

docker-compose up -d

```

3. Para desfazer o container

```PowerShell

docker-compose down

```

## Documentação dos Endpoint
![image](https://user-images.githubusercontent.com/28796027/145511501-9fcc8185-aabe-4b3f-9431-20b155d6a33b.png)



## Ainda tem perguntas ou sugestão de melhoria?

Sinta-se à vontade em abrir um [issue](https://github.com/RebelloMatheus/FarmAppTest/issues) ou [Pull Request](https://github.com/RebelloMatheus/FarmAppTest/pulls).

