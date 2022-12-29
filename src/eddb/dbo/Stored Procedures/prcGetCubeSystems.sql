

CREATE PROCEDURE [dbo].[prcGetCubeSystems] 
	@SystemName varchar(43) = 'Sol',
	@Size int = 10
AS
BEGIN
	SET NOCOUNT ON;

  
  DECLARE @Name varchar(43),  @X float,  @Y float, @Z float,  @Id int,  @Id64 bigint, @Date smalldatetime
  
	SELECT TOP 1 
		@Id = [dbo].[vwSystems].[Id], 
		@Id64 = [dbo].[vwSystems].[Id64], 
		@Name = [dbo].[vwSystems].[Name], 
		@X = [dbo].[vwSystems].[X],  
		@Y = [dbo].[vwSystems].[Y], 
		@Z = [dbo].[vwSystems].[Z], 
		@Date = [dbo].[vwSystems].[Date] 
	FROM [dbo].[vwSystems] 
	WHERE [dbo].[vwSystems].[Name] = @SystemName

	SELECT * FROM [dbo].[vwSystems] WHERE [dbo].[vwSystems].[X] > @X - (@Size / 2) AND [dbo].[vwSystems].[X] < @X + (@Size / 2)
		AND
			[dbo].[vwSystems].[Y] > @Y - (@Size / 2) AND [dbo].[vwSystems].[Y] < @Y + (@Size / 2)
		AND
			[dbo].[vwSystems].[Z] > @Z - (@Size / 2) AND [dbo].[vwSystems].[Z] < @Z + (@Size / 2)

	RETURN  @Id
END
GO


