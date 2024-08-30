#!/bin/bash

/opt/mssql/bin/sqlservr &

for i in {60..1}; do
  echo "Esperando $i segundos..."
  sleep 1
done

echo "Ya voy a ejecutar esta vayna"

# Ejecutar el script SQL después del retraso
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -C -i /var/opt/mssql/scripts/init.sql

for i in {10..1}; do
  echo "Esperando $i segundos..."
  sleep 1
done

tail -f /dev/null
