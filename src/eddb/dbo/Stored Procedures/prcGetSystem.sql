

CREATE PROCEDURE [dbo].[prcGetSystem] 
	@SystemName varchar(43) = 'Sol'
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [dbo].[vwSystems].[Id], 
		[dbo].[vwSystems].[Id64], 
		[dbo].[vwSystems].[Name], 
		[dbo].[vwSystems].[X],  
		[dbo].[vwSystems].[Y], 
		[dbo].[vwSystems].[Z], 
		[dbo].[vwSystems].[Date] 
	FROM [dbo].[vwSystems] 
	WHERE [dbo].[vwSystems].[Name] = @SystemName
END
GO


