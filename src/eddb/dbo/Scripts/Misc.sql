select count(*) from tblEDSystemsWithCoordinates

SELECT TOP 10 [Date], DATENAME(dw, [Date]), COUNT(Date) FROM tblEDSystemsWithCoordinates GROUP BY [Date] ORDER BY COUNT([Date]) DESC

select top 1 max([Date]) from tblEDSystemsWithCoordinates

-- truncate table [dbo].[tblEDSystemsWithCoordinates]
-- truncate table [dbo].[tblSystemsProgress]

-- truncate table [dbo].[tblSystemsProgress]
-- truncate table [dbo].[tblEDSystemsWithCoordinates]

ALTER DATABASE eddb
SET RECOVERY SIMPLE
GO
DBCC SHRINKFILE (eddb, 1)
GO

CREATE INDEX [IX_tblEDSystemsWithCoordinates_Id] ON [dbo].[tblEDSystemsWithCoordinates] ([Id])
GO

CREATE INDEX [IX_tblEDSystemsWithCoordinates_Name] ON [dbo].[tblEDSystemsWithCoordinates] ([Name])
GO

CREATE INDEX [IX_tblEDSystemsWithCoordinates_X] ON [dbo].[tblEDSystemsWithCoordinates] ([X])
GO

CREATE INDEX [IX_tblEDSystemsWithCoordinates_Y] ON [dbo].[tblEDSystemsWithCoordinates] ([Y])
GO

CREATE INDEX [IX_tblEDSystemsWithCoordinates_Z] ON [dbo].[tblEDSystemsWithCoordinates] ([Z])
GO