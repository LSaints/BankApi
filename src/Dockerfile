# Utiliza a imagem oficial do SDK do .NET 7 para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia os arquivos do projeto e restaura as dependências
COPY src/ .

# Restaura as dependências e compila a aplicação
RUN dotnet restore "BankApplication.API/BankApplication.API.csproj"
RUN dotnet build "BankApplication.API/BankApplication.API.csproj" -c Release -o /app/build

# Publica a aplicação
RUN dotnet publish "BankApplication.API/BankApplication.API.csproj" -c Release -o /app/publish

# Cria uma imagem de tempo de execução leve para a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expõe a porta 8080 para acesso à API
EXPOSE 8080

# Define o comando de inicialização da aplicação
ENTRYPOINT ["dotnet", "BankApplication.API.dll"]