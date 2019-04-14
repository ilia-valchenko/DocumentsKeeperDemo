﻿IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.FIELD_VALUES'))
BEGIN
	CREATE TABLE [dbo].[FIELD_VALUES] (
    [FIELD_VALUE_GUID] NVARCHAR (32)   NOT NULL,
    [FIELD_GUID]       NVARCHAR (32)   NOT NULL,
    [DOCUMENT_GUID]    NVARCHAR (32)   NOT NULL,
    [TEXT_VALUE]       NVARCHAR (1000) NULL,
    [BOOLEAN_VALUE]    BIT             NULL,
    [DATETIME_VALUE]   DATETIME        NULL,
    [NUMERIC_VALUE]    INT             NULL,
    [RESOURCE_STATUS]  NVARCHAR (3)    DEFAULT ('ACT') NOT NULL,
    [CREATED_DATE]     DATETIME        DEFAULT (getutcdate()) NULL,
    [MODIFIED_DATE]    DATETIME        DEFAULT (getutcdate()) NULL,
    PRIMARY KEY CLUSTERED ([FIELD_VALUE_GUID] ASC),
    FOREIGN KEY ([FIELD_GUID]) REFERENCES [dbo].[FIELDS] ([FIELD_GUID]));
END
GO