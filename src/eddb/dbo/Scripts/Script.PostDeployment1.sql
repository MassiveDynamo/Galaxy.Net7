/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [eddb]
ALTER DATABASE eddb1
SET RECOVERY SIMPLE
GO
DBCC SHRINKFILE (eddb1, 1)
GO

/* ALTER TABLE [dbo].[tblEDSystemsWithCoordinates] REBUILD PARTITION = ALL
WITH
(DATA_COMPRESSION = ROW
)

GO */
