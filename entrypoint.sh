#!/bin/bash

# Espera até que o banco de dados esteja pronto antes de iniciar a API
dockerize -wait tcp://db:3306 -timeout 1m

# Inicia a aplicação
exec dotnet BankApplication.API.dll
