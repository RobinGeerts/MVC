/*USE [DogRescue]*/

/*
*  LET op: Data voor enkel associatie-entiteit: MANY to MANY  / veel op veel
*/

SET IDENTITY_INSERT[dbo].[HondEigenaar] ON
INSERT INTO [dbo].[HondEigenaar] ([HondEigenaarId], [EigenaarId], [HondId]) VALUES (1, 1, 2)
INSERT INTO [dbo].[HondEigenaar] ([HondEigenaarId], [EigenaarId], [HondId]) VALUES (2, 1, 3)
INSERT INTO [dbo].[HondEigenaar] ([HondEigenaarId], [EigenaarId], [HondId]) VALUES (3, 2, 2)
SET IDENTITY_INSERT [dbo].[HondEigenaar] OFF