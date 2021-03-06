USE [Teleperizia]
GO
/****** Object:  Table [dbo].[Assicurati]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assicurati](
	[ID_Assicurato] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Cognome] [varchar](50) NOT NULL,
	[DataNascita] [date] NULL,
	[Email] [varchar](80) NULL,
	[CodiceFiscale] [varchar](30) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ASSICURATO] PRIMARY KEY CLUSTERED 
(
	[ID_Assicurato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assicurazioni]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assicurazioni](
	[Denominazione] [varchar](100) NOT NULL,
	[Email] [varchar](80) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[NumeroVerde] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ASSICURAZIONE] PRIMARY KEY CLUSTERED 
(
	[Denominazione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria_Sinistri]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria_Sinistri](
	[Appellativo] [varchar](30) NOT NULL,
	[Descrizione] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_CATEGORIA_SINISTRO] PRIMARY KEY CLUSTERED 
(
	[Appellativo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documenti]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documenti](
	[ID_Documento] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Estensione] [varchar](30) NOT NULL,
	[Dimensione] [real] NOT NULL,
	[Directory] [varchar](200) NOT NULL,
	[Tipo] [varchar](100) NOT NULL,
	[ID_Assicurato] [int] NOT NULL,
	[Incarico] [int] NOT NULL,
 CONSTRAINT [PK_DOCUMENTO] PRIMARY KEY CLUSTERED 
(
	[ID_Documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Incarichi]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incarichi](
	[ID_Incarico] [int] IDENTITY(1,1) NOT NULL,
	[ID_Sinistro] [int] NULL,
	[Stato] [varchar](50) NOT NULL,
	[Supervisore] [int] NOT NULL,
	[Perito] [int] NOT NULL,
 CONSTRAINT [PK_INCARICO] PRIMARY KEY CLUSTERED 
(
	[ID_Incarico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Luoghi]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luoghi](
	[ID_Luogo] [int] IDENTITY(1,1) NOT NULL,
	[Provincia] [varchar](2) NOT NULL,
	[Via] [varchar](100) NOT NULL,
	[NumeroCivico] [varchar](10) NOT NULL,
	[CAP] [varchar](10) NOT NULL,
	[Comune] [varchar](50) NOT NULL,
	[Citta] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LUOGO] PRIMARY KEY CLUSTERED 
(
	[ID_Luogo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Media]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Media](
	[NumeroMedia] [int] IDENTITY(1,1) NOT NULL,
	[NumeroPerizia] [int] NOT NULL,
	[Incarico] [int] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Estensione] [varchar](30) NOT NULL,
	[Dimensione] [real] NOT NULL,
	[Directory] [varchar](200) NOT NULL,
	[Tipo] [varchar](30) NOT NULL,
	[Metadati] [varchar](500) NOT NULL,
 CONSTRAINT [PK_MEDIA] PRIMARY KEY CLUSTERED 
(
	[NumeroMedia] ASC,
	[NumeroPerizia] ASC,
	[Incarico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Periti]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periti](
	[ID_Perito] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Cognome] [varchar](50) NOT NULL,
	[DataNascita] [date] NOT NULL,
	[Email] [varchar](80) NULL,
	[CodiceFiscale] [varchar](30) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[StudioPeritale] [int] NOT NULL,
 CONSTRAINT [PK_PERITO] PRIMARY KEY CLUSTERED 
(
	[ID_Perito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Polizze]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Polizze](
	[Numero] [int] IDENTITY(1,1) NOT NULL,
	[Assicurazione] [varchar](100) NOT NULL,
	[Assicurato] [int] NOT NULL,
	[Scadenza] [date] NOT NULL,
	[Costo] [money] NOT NULL,
	[Massimale] [money] NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_POLIZZE] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC,
	[Assicurazione] ASC,
	[Assicurato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sinistri]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sinistri](
	[ID_Sinistro] [int] IDENTITY(1,1) NOT NULL,
	[Assicurazione] [varchar](100) NOT NULL,
	[Descrizione] [varchar](1000) NULL,
	[Data] [date] NOT NULL,
	[Categoria] [varchar](30) NOT NULL,
	[Luogo] [int] NOT NULL,
	[StudioPeritale] [int] NULL,
	[Assicurato] [int] NOT NULL,
 CONSTRAINT [PK_SINISTRO] PRIMARY KEY CLUSTERED 
(
	[ID_Sinistro] ASC,
	[Assicurazione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Studi_Peritali]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Studi_Peritali](
	[ID_Studio] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Email] [varchar](80) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[Luogo] [int] NOT NULL,
 CONSTRAINT [PK_STUDIO_PERITALE] PRIMARY KEY CLUSTERED 
(
	[ID_Studio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supervisori]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supervisori](
	[ID_Supervisore] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Cognome] [varchar](50) NOT NULL,
	[DataNascita] [date] NOT NULL,
	[Email] [varchar](80) NULL,
	[CodiceFiscale] [varchar](30) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[StudioPeritale] [int] NOT NULL,
 CONSTRAINT [PK_SUPERVISORE] PRIMARY KEY CLUSTERED 
(
	[ID_Supervisore] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Polizze]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Polizze](
	[Tipo] [varchar](50) NOT NULL,
	[Descrizione] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_TIPO_POLIZZA] PRIMARY KEY CLUSTERED 
(
	[Tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Video_Perizie]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Video_Perizie](
	[NumeroPerizia] [int] IDENTITY(1,1) NOT NULL,
	[Incarico] [int] NOT NULL,
	[Durata] [real] NOT NULL,
	[Data] [date] NOT NULL,
 CONSTRAINT [PK_VIDEO_PERIZIA] PRIMARY KEY CLUSTERED 
(
	[NumeroPerizia] ASC,
	[Incarico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Documenti]  WITH CHECK ADD  CONSTRAINT [FASCICOLI] FOREIGN KEY([Incarico])
REFERENCES [dbo].[Incarichi] ([ID_Incarico])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documenti] CHECK CONSTRAINT [FASCICOLI]
GO
ALTER TABLE [dbo].[Incarichi]  WITH CHECK ADD  CONSTRAINT [ASSEGNAZIONI] FOREIGN KEY([Supervisore])
REFERENCES [dbo].[Supervisori] ([ID_Supervisore])
GO
ALTER TABLE [dbo].[Incarichi] CHECK CONSTRAINT [ASSEGNAZIONI]
GO
ALTER TABLE [dbo].[Incarichi]  WITH CHECK ADD  CONSTRAINT [RICEZIONI] FOREIGN KEY([Perito])
REFERENCES [dbo].[Periti] ([ID_Perito])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Incarichi] CHECK CONSTRAINT [RICEZIONI]
GO
ALTER TABLE [dbo].[Media]  WITH CHECK ADD  CONSTRAINT [ALLEGATI] FOREIGN KEY([NumeroPerizia], [Incarico])
REFERENCES [dbo].[Video_Perizie] ([NumeroPerizia], [Incarico])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Media] CHECK CONSTRAINT [ALLEGATI]
GO
ALTER TABLE [dbo].[Periti]  WITH CHECK ADD  CONSTRAINT [ASSUNZIONI] FOREIGN KEY([StudioPeritale])
REFERENCES [dbo].[Studi_Peritali] ([ID_Studio])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Periti] CHECK CONSTRAINT [ASSUNZIONI]
GO
ALTER TABLE [dbo].[Polizze]  WITH CHECK ADD  CONSTRAINT [EROGAZIONI] FOREIGN KEY([Assicurazione])
REFERENCES [dbo].[Assicurazioni] ([Denominazione])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Polizze] CHECK CONSTRAINT [EROGAZIONI]
GO
ALTER TABLE [dbo].[Polizze]  WITH CHECK ADD  CONSTRAINT [SPECIFICAZIONI] FOREIGN KEY([Tipo])
REFERENCES [dbo].[Tipo_Polizze] ([Tipo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Polizze] CHECK CONSTRAINT [SPECIFICAZIONI]
GO
ALTER TABLE [dbo].[Polizze]  WITH CHECK ADD  CONSTRAINT [STIPULAZIONI] FOREIGN KEY([Assicurato])
REFERENCES [dbo].[Assicurati] ([ID_Assicurato])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Polizze] CHECK CONSTRAINT [STIPULAZIONI]
GO
ALTER TABLE [dbo].[Sinistri]  WITH CHECK ADD  CONSTRAINT [AVVENIMENTI] FOREIGN KEY([Luogo])
REFERENCES [dbo].[Luoghi] ([ID_Luogo])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Sinistri] CHECK CONSTRAINT [AVVENIMENTI]
GO
ALTER TABLE [dbo].[Sinistri]  WITH CHECK ADD  CONSTRAINT [CATEGORIZZAZIONI] FOREIGN KEY([Categoria])
REFERENCES [dbo].[Categoria_Sinistri] ([Appellativo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sinistri] CHECK CONSTRAINT [CATEGORIZZAZIONI]
GO
ALTER TABLE [dbo].[Sinistri]  WITH CHECK ADD  CONSTRAINT [COINVOLGIMENTI] FOREIGN KEY([Assicurato])
REFERENCES [dbo].[Assicurati] ([ID_Assicurato])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sinistri] CHECK CONSTRAINT [COINVOLGIMENTI]
GO
ALTER TABLE [dbo].[Sinistri]  WITH CHECK ADD  CONSTRAINT [DELEGAZIONI] FOREIGN KEY([StudioPeritale])
REFERENCES [dbo].[Studi_Peritali] ([ID_Studio])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Sinistri] CHECK CONSTRAINT [DELEGAZIONI]
GO
ALTER TABLE [dbo].[Sinistri]  WITH CHECK ADD  CONSTRAINT [GENERAZIONI] FOREIGN KEY([Assicurazione])
REFERENCES [dbo].[Assicurazioni] ([Denominazione])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sinistri] CHECK CONSTRAINT [GENERAZIONI]
GO
ALTER TABLE [dbo].[Studi_Peritali]  WITH CHECK ADD  CONSTRAINT [RESIDENZE] FOREIGN KEY([Luogo])
REFERENCES [dbo].[Luoghi] ([ID_Luogo])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Studi_Peritali] CHECK CONSTRAINT [RESIDENZE]
GO
ALTER TABLE [dbo].[Supervisori]  WITH CHECK ADD  CONSTRAINT [SUPERVISIONI] FOREIGN KEY([StudioPeritale])
REFERENCES [dbo].[Studi_Peritali] ([ID_Studio])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Supervisori] CHECK CONSTRAINT [SUPERVISIONI]
GO
ALTER TABLE [dbo].[Video_Perizie]  WITH CHECK ADD  CONSTRAINT [ANNESSIONI] FOREIGN KEY([Incarico])
REFERENCES [dbo].[Incarichi] ([ID_Incarico])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Video_Perizie] CHECK CONSTRAINT [ANNESSIONI]
GO
