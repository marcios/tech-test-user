create database [UserTestDb]
go


USE [UserTestDb]
GO
/****** Object:  Table [dbo].[Escolaridade]    Script Date: 07/08/2023 09:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escolaridade](
	[Id] [int] NOT NULL,
	[Descricao] [varchar](255) NULL,
 CONSTRAINT [PK_Escolaridade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistoricoEscolar]    Script Date: 07/08/2023 09:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoricoEscolar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Formato] [varchar](255) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[ArquivoBase64] [text] NULL,
 CONSTRAINT [PK_HistoricoEscolar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 07/08/2023 09:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[SobreNome] [varchar](255) NULL,
	[Email] [varchar](255) NOT NULL,
	[DataNascimento] [date] NOT NULL,
	[EscolaridadeId] [int] NULL,
	[HistoricoEscolarId] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Escolaridade] FOREIGN KEY([EscolaridadeId])
REFERENCES [dbo].[Escolaridade] ([Id])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Escolaridade]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_HistoricoEscolar] FOREIGN KEY([HistoricoEscolarId])
REFERENCES [dbo].[HistoricoEscolar] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_HistoricoEscolar]
GO
