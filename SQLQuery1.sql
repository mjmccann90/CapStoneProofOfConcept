USE [master]
GO
IF db_id('CapStoneProofOfConcept') IS NULL
  CREATE DATABASE [CapStoneProofOfConcept]
GO
USE [CapStoneProofOfConcept]
GO

DROP TABLE IF EXISTS [UserProfile];


CREATE TABLE [UserProfile] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [PersonalityType] nvarchar(255)
)
GO

SET IDENTITY_INSERT [UserProfile] ON
INSERT INTO [UserProfile]
  ([Id], [Name], [Email], [PersonalityType])
VALUES 
  (1, 'Oliver Hardy', 'olie@email.com', 'ENFJ');
INSERT INTO [UserProfile]
  ([Id], [Name], [Email], [PersonalityType])
VALUES 
  (2, 'Stan Laurel', 'stan@email.com', 'ENTJ');
SET IDENTITY_INSERT [UserProfile] OFF
