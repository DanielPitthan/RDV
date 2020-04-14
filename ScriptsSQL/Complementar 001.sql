
go 
Alter table Usuario Add Cpf nvarchar(11) null
go 
Alter Table Usuario Add IsLogged bit not null default 0
go
Alter Table Usuario Add ExpirationDateLogged datetime2 null 

