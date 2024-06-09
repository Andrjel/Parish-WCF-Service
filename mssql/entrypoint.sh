#!/bin/bash
# Configure SQL Server
/opt/mssql/bin/mssql-conf set network.tcpport 1433
# Start SQL Server
/opt/mssql/bin/sqlservr &
pid="$!"
# Wait for SQL Server to start
# This loop will check if SQL Server is up every 2 seconds, for a 90 seconds timeout
echo "Waiting for SQL Server to start..."
for i in {1..60}; do
    if /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "Password!23" -Q "SELECT 1" &>/dev/null; then
        echo "SQL Server is up!"
        break
    else
        echo "Waiting for SQL Server to start... ($i)"
        sleep 2
    fi
done
# If SQL Server is not up after 120 seconds, exit with an error
if ! /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "Password!23" -Q "SELECT 1" &>/dev/null; then
    echo "SQL Server did not start in time. Exiting."
    exit 1
fi
# Run the setup script to create the database and schema
echo "Running initialization script..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "Password!23" -i /usr/src/app/initDB.sql
echo "Initialization script completed."
wait