CREATE DATABASE [Pw3-2c-IslaTesoro]
GO
USE [Pw3-2c-IslaTesoro]
GO

/****** Object:  Table [dbo].[Tesoro]    Script Date: 10/11/2023 8:18:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tesoro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[ImagenRuta] [nvarchar](300) NULL,
 CONSTRAINT [PK_Tesoro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Ubicacion]    Script Date: 10/11/2023 8:18:58 PM ******/
CREATE TABLE [dbo].[Ubicacion](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Ubicacion] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO