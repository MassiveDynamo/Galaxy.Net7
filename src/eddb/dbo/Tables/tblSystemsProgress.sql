CREATE TABLE [dbo].[tblSystemsProgress] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [FileName]      VARCHAR (250) NOT NULL,
    [RowsProcessed] BIGINT        NOT NULL,
    [Date]          DATETIME      DEFAULT GETDATE() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

