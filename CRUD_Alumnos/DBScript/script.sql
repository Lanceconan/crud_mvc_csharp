/***

Crear una Base de datos llamada testDataBase como sugerencia

***/

USE [testDataBase]
GO

/****** Object:  Table [dbo].[paciente]    Script Date: 10-12-2018 18:05:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[paciente](
	[id] [bigint] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[peso] [decimal](2, 2) NOT NULL,
	[altura] [decimal](2, 2) NOT NULL,
 CONSTRAINT [PK_paciente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [testDataBase]
GO

/****** Object:  Table [dbo].[enfermedad]    Script Date: 11-12-2018 14:51:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[enfermedad](
	[id] [bigint] NOT NULL,
	[Enfermedad] [varchar](50) NOT NULL,
	[Descripción] [text] NOT NULL,
 CONSTRAINT [PK_enfermedad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [testDataBase]
GO

/****** Object:  Table [dbo].[pacienteEnfermedad]    Script Date: 11-12-2018 14:52:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[pacienteEnfermedad](
	[id] [bigint] NOT NULL,
	[idPaciente] [bigint] NOT NULL,
	[idEnfermedad] [bigint] NOT NULL,
 CONSTRAINT [PK_pacienteEnfermedad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[pacienteEnfermedad]  WITH CHECK ADD  CONSTRAINT [FK_pacienteEnfermedad_enfermedad] FOREIGN KEY([idEnfermedad])
REFERENCES [dbo].[enfermedad] ([id])
GO

ALTER TABLE [dbo].[pacienteEnfermedad] CHECK CONSTRAINT [FK_pacienteEnfermedad_enfermedad]
GO

ALTER TABLE [dbo].[pacienteEnfermedad]  WITH CHECK ADD  CONSTRAINT [FK_pacienteEnfermedad_pacienteEnfermedad] FOREIGN KEY([idEnfermedad])
REFERENCES [dbo].[paciente] ([id])
GO

ALTER TABLE [dbo].[pacienteEnfermedad] CHECK CONSTRAINT [FK_pacienteEnfermedad_pacienteEnfermedad]
GO



