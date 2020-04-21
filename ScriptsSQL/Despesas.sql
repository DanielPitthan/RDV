create table TipoDespesa
(
	Id int identity not null,
	Descricao varchar(max) not null,
	DataInclusao datetime2,
	Ativo bit,
	constraint PK_TipoDespesa_Id Primary Key (Id)	
)

go

alter table TipoDespesa add constraint DF_TipoDespesaDataInclusao default getdate() for DataInclusao 
go
alter table TipoDespesa add constraint DF_TipoDespesaAtivo default 1 for Ativo 
go 

create index Ix_TipoDespesa_001 on TipoDespesa (Ativo)
go
create index Ix_TipoDespesa_002 on TipoDespesa (DataInclusao)

go


create table DespesaHeader
(
	Id int identity not null,
	DataInclusao datetime2,
	Ativo bit not null,
	Descricao  varchar(max) not null,
	Total Decimal(14,2),
	Aprovado bit not null,	
	Motivo varchar(max),
	UsuarioInclusaoId int not null,
	UsuarioAprovacaoId int,	
	DataAprovacao datetime2,

	constraint PK_DespesaHeader_Id Primary Key (Id)	
)
go
create index Ix_DespesaHeader_001 on DespesaHeader (Ativo,DataInclusao,UsuarioInclusaoId) include (DataAprovacao)
go
create index Ix_DespesaHeader_002 on DespesaHeader (UsuarioInclusaoId,Ativo,DataInclusao) include (DataAprovacao)

create table Despesa
(
	Id int identity not null,
	DataInclusao datetime2,
	Ativo bit not null,
	Descricao  varchar(max) not null,
	Valor Decimal(14,2),
	Aprovado bit not null,
	TipoDespesaId int,
	CentroCustoId int,
	Motivo varchar(max),
	UsuarioInclusaoId int not null,
	UsuarioAprovacaoId int,	
	DataAprovacao datetime2,
	DespesaHeaderId int ,
	constraint PK_Despesa_Id Primary Key (Id)	
)
go

create index Ix_Despesa_001 on Despesa (Ativo)
go
create index Ix_Despesa_002 on Despesa (Ativo,DataInclusao,TipoDespesaId)
go
create index Ix_Despesa_003 on Despesa (Ativo,DataInclusao,CentroCustoId)
go
create index Ix_Despesa_004 on Despesa (Ativo,UsuarioInclusaoId)
go
alter table Despesa add constraint DF_Despesa_DataInclusao default getdate()for DataInclusao
go
alter table Despesa add constraint DF_Despesa_Ativo default 1 for Ativo
go 
alter table Despesa add constraint DF_Despesa_Aprovado default 0  for Aprovado
go 

/*Foring Keys*/


alter table Despesa add constraint FK_DespesaDespesaHeaderId Foreign Key (DespesaHeaderId) References DespesaHeader (Id)
	on delete cascade 
	on  update cascade
go
alter table Despesa add constraint FK_DespesaUsuarioInclusaoId Foreign Key (UsuarioInclusaoId) References Usuario (Id)
go
alter table Despesa add constraint FK_DespesaUsuarioAprovacaoId Foreign Key (UsuarioAprovacaoId) References Usuario (Id)
go
alter table Despesa add constraint FK_DespesaTipoDespesaId Foreign Key (TipoDespesaId) References TipoDespesa (Id)
go
alter table Despesa drop constraint FK_DespesaTipoDespesaId
go

alter table DespesaHeader add constraint FK_DespesaHeaderUsuarioInclusaoId Foreign Key (UsuarioInclusaoId) References Usuario (Id)
go
alter table DespesaHeader add constraint FK_DespesaHeaderUsuarioAprovacaoId Foreign Key (UsuarioAprovacaoId) References Usuario (Id)