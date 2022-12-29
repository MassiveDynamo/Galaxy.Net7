-- select * from [dbo].[tblEDSystemsWithCoordinates] where [Name] = 'Sol'

-- select * from [dbo].[tblEDSystemsWithCoordinates] where [X] < 300 and [X] > -300 and [z] < 300 and [z] > -300 and [y] < 300 and [y] > -300


select MAX([x]) as MaxX from [dbo].[tblEDSystemsWithCoordinates] 
select MAX([y]) as MaxY from [dbo].[tblEDSystemsWithCoordinates] 
select MAX([z]) as MaxZ from [dbo].[tblEDSystemsWithCoordinates] 
select MIN([x]) as MinX from [dbo].[tblEDSystemsWithCoordinates] 
select MIN([y]) as MinY from [dbo].[tblEDSystemsWithCoordinates] 
select MIN([z]) as MinZ from [dbo].[tblEDSystemsWithCoordinates] 

select * from [dbo].[tblEDSystemsWithCoordinates]  where [y] = 39518.34375

select * from [dbo].[tblEDSystemsWithCoordinates]  where Id64 is null