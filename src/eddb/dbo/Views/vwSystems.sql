CREATE VIEW [dbo].[vwSystems] AS
	SELECT *,'eddb1' as DatabaseName FROM [eddb1].[dbo].[tblEDSystemsWithCoordinates]
	UNION ALL 
	SELECT *,'eddb2' as DatabaseName FROM [eddb2].[dbo].[tblEDSystemsWithCoordinates]
	UNION ALL 
	SELECT *,'eddb3' as DatabaseName FROM [eddb3].[dbo].[tblEDSystemsWithCoordinates]
	UNION ALL 
	SELECT *,'eddb4' as DatabaseName FROM [eddb4].[dbo].[tblEDSystemsWithCoordinates]
GO