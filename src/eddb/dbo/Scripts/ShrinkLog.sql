﻿ 
ALTER DATABASE eddb1
SET RECOVERY SIMPLE
GO
DBCC SHRINKFILE (eddb1, 1)
GO
