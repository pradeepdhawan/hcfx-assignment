USE [ContactDB]
GO

/****** Object: Table [dbo].[Contacts] Script Date: 19/08/2021 21:03:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contacts] (
    [ContactId]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (100) NOT NULL,
    [LastName]    NVARCHAR (100) NOT NULL,
    [DateOfBirth] DATETIME2 (7)  NOT NULL,
    [Email]       NVARCHAR (450) NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Contacts_Email]
    ON [dbo].[Contacts]([Email] ASC);


GO
ALTER TABLE [dbo].[Contacts]
    ADD CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED ([ContactId] ASC);


