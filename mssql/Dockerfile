FROM mcr.microsoft.com/mssql/server:2019-latest

ENV ACCEPT_EULA=Y\
    SA_PASSWORD="Password!23"

EXPOSE 1433

COPY entrypoint.sh /usr/src/app/
COPY initDB.sql /usr/src/app/

USER root
RUN chmod +x /usr/src/app/entrypoint.sh

ENTRYPOINT ["/usr/src/app/entrypoint.sh"]

USER mssql