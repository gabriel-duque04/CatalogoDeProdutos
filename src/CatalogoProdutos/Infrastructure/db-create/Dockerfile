FROM mcr.microsoft.com/mssql/server:2022-latest

# Configurações de Licença e Senha
ENV ACCEPT_EULA=Y
ENV MSSQL_SA_PASSWORD='CatalogoDeProdutos2304!#'

# Copia o script SQL para dentro do container
COPY setup.sql /setup.sql

EXPOSE 1433

# O TRUQUE: Caminho atualizado do sqlcmd (tools18) e a flag -C para confiar no certificado
CMD /bin/bash -c "/opt/mssql/bin/sqlservr & sleep 30 && /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P 'CatalogoDeProdutos2304!#' -i /setup.sql -C && wait"