CREATE TABLE [dbo].[File] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [FileName]  NVARCHAR (MAX)  NULL,
    [Tittle]    NCHAR (10)      NULL,
    [ImageData] VARBINARY (MAX) NULL,
    CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED ([Id] ASC)
);

