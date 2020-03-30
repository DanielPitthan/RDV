/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cnpj] [nvarchar](14) NOT NULL,
	[NomeFantasia] [nvarchar](50) NULL,
	[RazaoSocial] [nvarchar](50) NOT NULL,
	[Ativa] [bit] NOT NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpresaRegra]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresaRegra](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Regra] [nvarchar](255) NOT NULL,
	[Valor] [nvarchar](max) NOT NULL,
	[EmpresaId] [int] NOT NULL,
 CONSTRAINT [PK_EmpresaRegra] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].UserClaims(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NOT NULL,
	[ClaimValue] [nvarchar](max) NOT NULL,
	[UsuarioId] [int] NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserToken]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserToken](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Token] [nvarchar](max) NULL,
	[Expiration] [datetime2](7) NULL,
	[Issuer] [nvarchar](max) NULL,
	[Audience] [nvarchar](max) NULL,
	[UsuarioId] [int] NULL,
 CONSTRAINT [PK_UserToken] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AspNetUsersId] [nvarchar](max) NULL,
	[Ativo] [bit] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[UserTokenId] [int] NULL,
	[EmpresaId] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Empresa] ADD  DEFAULT ((0)) FOR [Ativa]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[EmpresaRegra]  WITH CHECK ADD  CONSTRAINT [FK_EmpresaRegra_Empresa_EmpresaId] FOREIGN KEY([EmpresaId])
REFERENCES [dbo].[Empresa] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmpresaRegra] CHECK CONSTRAINT [FK_EmpresaRegra_Empresa_EmpresaId]
GO
ALTER TABLE [dbo].UserClaims  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].UserClaims CHECK CONSTRAINT [FK_UserClaims_Usuario_UsuarioId]
GO
ALTER TABLE [dbo].[UserToken]  WITH CHECK ADD  CONSTRAINT [FK_UserToken_Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserToken] CHECK CONSTRAINT [FK_UserToken_Usuario_UsuarioId]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Empresa_EmpresaId] FOREIGN KEY([EmpresaId])
REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Empresa_EmpresaId]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_UserToken_UserTokenId] FOREIGN KEY([UserTokenId])
REFERENCES [dbo].[UserToken] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_UserToken_UserTokenId]
GO
/****** Object:  StoredProcedure [dbo].[ups_FindUsuarioByToken]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ups_FindUsuarioByToken](				
		@Token			varchar(Max)		
)
As
Begin
	select u.* 
	from UserToken as t
		join Usuario as u on u.Id=t.UsuarioId		
	where t.Token =@Token
end

GO
/****** Object:  StoredProcedure [dbo].[ups_GetAllClaimsByType]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


------------------------------------
-- Localiza o usuário vinculado a ClaimType 
------------------------------------

create procedure [dbo].[ups_GetAllClaimsByType](				
		@ClaimType	varchar(Max),
		@Result		int out,
		@MessageError nvarchar(Max) out
)
As
Begin
	set @Result = 0
	Begin transaction 

	Begin Try
		select *
			from UserClaims as  r
			Join Usuario as u  on u.Id =r.UsuarioId
			where 
				r.ClaimType = @ClaimType
	end try
	begin catch
		Set @MessageError = ERROR_MESSAGE() 		
		IF @@TRANCOUNT > 0  
		Begin
		    ROLLBACK TRANSACTION;  
			set @Result = 0
		End
	end catch	
	IF @@TRANCOUNT > 0  
	Begin 
		set @Result = 1
		set @MessageError =''
		COMMIT TRANSACTION;  
	End
end

GO
/****** Object:  StoredProcedure [dbo].[ups_GetAllClaimsByUsuario]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ups_GetAllClaimsByUsuario](				
		@UsuarioId	varchar(Max)
)
As
Begin
	select r.*
	from UserClaims as  r
	Join Usuario as u  on u.Id =r.UsuarioId
	where 
		r.UsuarioId = @UsuarioId
	
End
GO
/****** Object:  StoredProcedure [dbo].[usp_UsarioInsert]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


------------------------------------------
--Faz o insert no Usuários 
------------------------------------------
create procedure [dbo].[usp_UsarioInsert](	
	@UserInfoId		int,
	@UserTokenId	int,
	@AspNetUsersId	nvarchar(Max),
	@Ativo			bit,
	@Result			int out,
	@MessageError nvarchar(Max) out

)
as


Begin 
	Begin Transaction
	Begin Try
		insert into Usuario(UserTokenId,AspNetUsersId,Ativo) values
			(@UserTokenId,@AspNetUsersId,@Ativo)
	End Try
	Begin Catch	
		Set @MessageError = ERROR_MESSAGE() 
		
		IF @@TRANCOUNT>0  
		Begin 
			ROLLBACK TRANSACTION;  
			set @Result = 0;
		End
	End Catch	
	IF @@TRANCOUNT > 0  
	Begin 		
		COMMIT TRANSACTION;  
		set @MessageError=''
		set @Result = 1
	end
End



GO
/****** Object:  StoredProcedure [dbo].[usp_UserClaimsDelete]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--------------------------------------
-- Faz a exclusão de Uma Claim pelo Id
-- do usuário e o seu tipo e valor 
--------------------------------------
create procedure [dbo].[usp_UserClaimsDelete](		
		@UserId	    int,
		@ClaimType	varchar(Max),
		@ClaimValue varchar(Max),
		@Result		int out,
		@MessageError nvarchar(Max) out
)
As
Begin
	set @Result = 0
	Begin transaction 

	Begin Try
		Delete UserClaims 
		where 
			UsuarioId =@UserId 
			and ClaimType=@ClaimType and ClaimValue = @ClaimValue
	end try
	begin catch
		Set @MessageError = ERROR_MESSAGE() 		
		IF @@TRANCOUNT > 0  
		Begin
		    ROLLBACK TRANSACTION;  
			set @Result = 0
		End
	end catch	
	IF @@TRANCOUNT > 0  
	Begin 
		set @Result = 1
		set @MessageError =''
		COMMIT TRANSACTION;  
	End
end

GO
/****** Object:  StoredProcedure [dbo].[usp_UserClaimsInsert]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------
--insert dos UserClaims
------------------------------------------
create procedure [dbo].[usp_UserClaimsInsert](
		@ClaimType	nvarchar(Max),
		@ClaimValue	nvarchar(Max),		
		@UserId			int,
		@Result		int out,
		@MessageError nvarchar(Max) out
)
As
Begin
	Begin Transaction
	Begin Try
		Insert into UserClaims (ClaimType,ClaimValue,UsuarioId) values
		(@ClaimType,@ClaimValue	, @UserId)
	End try
	Begin Catch	
		Set @MessageError = ERROR_MESSAGE() 
		
		IF @@TRANCOUNT>0  
		Begin 
			ROLLBACK TRANSACTION;  
			set @Result = 0;
		End
	End Catch	
	IF @@TRANCOUNT > 0  
	Begin 		
		COMMIT TRANSACTION;  
		set @MessageError=''
		set @Result = 1
	end
end
GO
/****** Object:  StoredProcedure [dbo].[usp_UserClaimsUpdate]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*********************************************
**
** BLOCO: CRIA PROCEDURES 
**
**********************************************/


------------------------------------------
--Atualiza o UserClaims
------------------------------------------
create procedure [dbo].[usp_UserClaimsUpdate](
		@Id			Int,
		@ClaimType	nvarchar(Max),
		@ClaimValue	nvarchar(Max),
		@UserId	int,
		@Result		int out,
		@MessageError nvarchar(Max) out
)
As
Begin

	set @Result = 0
	Begin transaction 

	Begin Try		
		Update UserClaims  
			set ClaimType=@ClaimType,
				ClaimValue=@ClaimValue,
				UsuarioId=@UserId
		where Id=@Id
	end try
	begin catch
		Set @MessageError = ERROR_MESSAGE() 		
		IF @@TRANCOUNT > 0  
		Begin
		    ROLLBACK TRANSACTION;  
			set @Result = 0
		End
	end catch	
	IF @@TRANCOUNT > 0  
	Begin 
		set @Result = 1
		set @MessageError =''
		COMMIT TRANSACTION;  
	End
end

GO
/****** Object:  StoredProcedure [dbo].[usp_UserInfoInsert]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


------------------------------------------
--Faz o insert do User Info
------------------------------------------
create procedure [dbo].[usp_UserInfoInsert](
		@Email		nvarchar(Max),
		@Password	nvarchar(Max),
		@Result		int out,
		@MessageError nvarchar(Max) out
)
as
begin 
	Begin Transaction
	Begin Try
		insert into UserInfo (Email,Password) values
		(@Email,@Password)
	End try
	Begin Catch	
		Set @MessageError = ERROR_MESSAGE() 
		
		IF @@TRANCOUNT>0  
		Begin 
			ROLLBACK TRANSACTION;  
			set @Result = 0;
		End
	End Catch	
	IF @@TRANCOUNT > 0  
	Begin 		
		COMMIT TRANSACTION;  
		set @MessageError=''
		set @Result = 1
	end
end
GO
/****** Object:  StoredProcedure [dbo].[usp_UserTokenInsert]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


------------------------------------------
--Faz o insert dos Tokens
------------------------------------------
create procedure [dbo].[usp_UserTokenInsert](
	@Token		nvarchar(Max),
	@Expiration	datetime2,
	@Audience	nvarchar(Max),
	@Issuer		nvarchar(Max),
	@Result		int out,
	@MessageError nvarchar(Max) out

)
as
begin 
	Begin Transaction
	Begin Try
		insert into UserToken(Token,Expiration,Audience,Issuer)	values 
		(@Token,@Expiration,@Audience,@Issuer)
	End Try
	Begin Catch	
		Set @MessageError = ERROR_MESSAGE() 
		
		IF @@TRANCOUNT>0  
		Begin 
			ROLLBACK TRANSACTION;  
			set @Result = 0;
		End
	End Catch	
	IF @@TRANCOUNT > 0  
	Begin 		
		COMMIT TRANSACTION;  
		set @MessageError=''
		set @Result = 1
	end
	
End
GO
/****** Object:  StoredProcedure [dbo].[usp_UserTokenUpdate]    Script Date: 27/06/2019 14:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------
--Atauliza o UserToken 
------------------------------------------
create procedure [dbo].[usp_UserTokenUpdate](
	@Id			int,
	@Token		nvarchar(Max),
	@Expiration	datetime2,
	@Audience	nvarchar(Max),
	@Issuer		nvarchar(Max),
	@Result		int out,
	@MessageError nvarchar(Max) out
	
)	
	AS
Begin 	
	set @Result = 0	
	Begin transaction 
	begin try	
		Update UserToken 
			set Token=@Token,
				Expiration = @Expiration,
				Audience = @Audience,
				Issuer = @Issuer
		where Id=@Id
	end try 
	begin catch		
		
		Set @MessageError = ERROR_MESSAGE() 
		
		IF @@TRANCOUNT>0  
		Begin 
			ROLLBACK TRANSACTION;  
			set @Result = 0;
		End
	end catch	
	IF @@TRANCOUNT > 0  
	Begin 		
		COMMIT TRANSACTION;  
		set @MessageError=''
		set @Result = 1
	end
End

GO
alter table UserClaims add Ativo bit not null default 07
go
alter table Empresa add Filial Varchar(4) not null 
go
create index Ix_Empresa_001 on Empresa (Filial,Cnpj) include (Ativa)
go
create index Ix_Empresa_002 on Empresa (RazaoSocial) include (Filial)
go 
create index Ix_Empresa_003 on Empresa (Ativa) include (Filial)

go

alter table Empresa add [IE] [nvarchar](255) NULL
go
alter table Empresa add [UF] [nvarchar](255) NULL
go
alter table Empresa add [Centralizadora] [bit] NULL
go
alter table Empresa add [DescricaoResumida] [nvarchar](255) NULL
go 

Alter table Usuario add [Nome] [nvarchar](255) NULL
go
Alter table Usuario add [DataCriacao] [datetime2](7) NULL
go
Alter table Usuario add [IsAdmin] [bit] NULL
go
Alter table Usuario add [LastAcess] [datetime2](7) NULL
go
alter table Usuario add constraint DF_DataCriacao default getdate() for DataCriacao 
go

alter table UserClaims add Ativo bit not null default 1