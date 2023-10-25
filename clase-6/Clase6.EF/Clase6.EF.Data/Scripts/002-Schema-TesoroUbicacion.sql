GO
ALTER TABLE dbo.Tesoro ADD
	IdUbicacion int NULL
GO
ALTER TABLE dbo.Tesoro ADD CONSTRAINT
	FK_Tesoro_Ubicacion FOREIGN KEY
	(
	IdUbicacion
	) REFERENCES dbo.Ubicacion
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 