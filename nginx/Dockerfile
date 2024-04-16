# Estágio 1: Instalar o Nginx
FROM nginx:latest

# Copiar o arquivo de configuração customizado do nginx
RUN rm /etc/nginx/conf.d/default.conf
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expor as portas
EXPOSE 80
EXPOSE 443

# CMD para iniciar o nginx
CMD ["nginx", "-g", "daemon off;"]
