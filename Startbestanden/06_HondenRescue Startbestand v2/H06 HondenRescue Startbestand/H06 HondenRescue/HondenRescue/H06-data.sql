/*USE [DogRescue]*/

SET IDENTITY_INSERT [dbo].[Eigenaar] ON
INSERT INTO [dbo].[Eigenaar] ([EigenaarId], [Familienaam], [Voornaam]) VALUES (1, N'LIEFOGEN', N'Jef')
INSERT INTO [dbo].[Eigenaar] ([EigenaarId], [Familienaam], [Voornaam]) VALUES (2, N'HOEFKENS', N'Dries')
INSERT INTO [dbo].[Eigenaar] ([EigenaarId], [Familienaam], [Voornaam]) VALUES (3, N'DEWEIYER', N'Brenda')
SET IDENTITY_INSERT [dbo].[Eigenaar] OFF

SET IDENTITY_INSERT [dbo].[Hond] ON
INSERT INTO [dbo].[Hond] ([HondId], [Naam], [Geboortedatum], [Geslacht], [Opmerkingen], [EigenaarId], [FotoNaam], [Gechipt]) VALUES (1, N'Oscar', N'2016-03-21 00:00:00', 1, N'Deze hond werd gered op het eiland Tasmanië.', 3, '1.jpg', 1)
INSERT INTO [dbo].[Hond] ([HondId], [Naam], [Geboortedatum], [Geslacht], [Opmerkingen], [EigenaarId], [FotoNaam], [Gechipt]) VALUES (2, N'Dezzer', N'2012-12-04 00:00:00', 0, N'Deze hond werd gered door Team 6.', 2, '2.jpg', 1)
INSERT INTO [dbo].[Hond] ([HondId], [Naam], [Geboortedatum], [Geslacht], [Opmerkingen], [EigenaarId], [FotoNaam], [Gechipt]) VALUES (3, N'Snuffer', N'2020-07-08 00:00:00', 1, N'Onbekende gegevens.', 1, '3.jpg', 0)
SET IDENTITY_INSERT [dbo].[Hond] OFF