﻿IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.DOCUMENTS'))
BEGIN
	IF EXISTS (SELECT 1 FROM sys.columns WHERE Name = N'FILE_SIZE' AND Object_ID = Object_ID(N'dbo.DOCUMENTS'))
	BEGIN
		ALTER TABLE DOCUMENTS ALTER COLUMN FILE_SIZE NUMERIC (34, 8) NULL
	END
END
GO