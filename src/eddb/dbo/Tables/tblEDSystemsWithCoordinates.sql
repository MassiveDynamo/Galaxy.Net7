CREATE TABLE [dbo].[tblEDSystemsWithCoordinates] (
    [Id]   INT             NOT NULL,
    [Id64] BIGINT          NULL,
    [Name] VARCHAR(43)    NOT NULL,
    [X]    FLOAT NOT NULL,
    [Y]    FLOAT NOT NULL,
    [Z]    FLOAT NOT NULL,
    [Date] SMALLDATETIME   NOT NULL
);


GO
CREATE UNIQUE INDEX [IX_tblEDSystemsWithCoordinates_Id]
    ON [dbo].[tblEDSystemsWithCoordinates]([Id] ASC)
    WITH (IGNORE_DUP_KEY = ON) ON [PRIMARY]


GO
CREATE UNIQUE INDEX [IX_tblEDSystemsWithCoordinates_Name]
    ON [dbo].[tblEDSystemsWithCoordinates]([Name] ASC)
    WITH (IGNORE_DUP_KEY = ON) ON [PRIMARY]

GO

CREATE NONCLUSTERED INDEX [IX_tblEDSystemsWithCoordinates_X] ON [dbo].[tblEDSystemsWithCoordinates] ([X])
GO

CREATE NONCLUSTERED INDEX [IX_tblEDSystemsWithCoordinates_Y] ON [dbo].[tblEDSystemsWithCoordinates] ([Y])
GO

CREATE NONCLUSTERED INDEX [IX_tblEDSystemsWithCoordinates_Z] ON [dbo].[tblEDSystemsWithCoordinates] ([Z])
GO
