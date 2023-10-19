use "Pw3-2C-IslaTesoro"

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoriaTesoro]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[CategoriaTesoro] (
        Id INT IDENTITY (1, 1) NOT NULL,
        Nombre VARCHAR (100) NOT NULL,
        TesoroID INT NULL, -- Permite valores nulos
        CONSTRAINT [PK_CategoriaTesoro] PRIMARY KEY CLUSTERED (Id ASC),
        CONSTRAINT [FK_CategoriaTesoro_Tesoro] FOREIGN KEY (TesoroID) REFERENCES [dbo].[Tesoro] (Id)
    );
END