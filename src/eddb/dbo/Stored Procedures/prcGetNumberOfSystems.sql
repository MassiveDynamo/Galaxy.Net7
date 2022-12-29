CREATE PROCEDURE [dbo].[prcGetNumberOfSystems]
AS
DECLARE	@RowCount int
	SELECT @RowCount = COUNT (*) from [dbo].[tblEDSystemsWithCoordinates]

RETURN @RowCount
