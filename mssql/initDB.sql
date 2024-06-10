USE master;
GO

IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'ParishDB')
BEGIN
    CREATE DATABASE ParishDB;
END
GO

USE ParishDB;
GO

CREATE TABLE Parish (
    Id CHAR(36) NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Street NVARCHAR(255) NOT NULL,
	City NVARCHAR(100) NOT NULL,
    CONSTRAINT Parish_pk PRIMARY KEY (Id)
);

INSERT INTO Parish (Id, Name, Street, City) VALUES 
    ('ae460af8-2ce6-4d14-b286-79509643eef0', N'Parafia Rzymskokatlicka pw. Nawiedzenia NMP Mielecin', N'ul. Główna 26', N'Mielęcin'),
    (NEWID(), N'Parafia pw. Wniebowzięcia NMP', N'ul. Tadeusza Kościuszki 29', N'Lipiany'),
	(NEWID(), N'Parafia Rzymsko-Katolicka pw. św. Otton', N'ul. Dąbrowskiego 13', N'Pyrzyce');
