CREATE TABLE [dbo].[ChallengeTypes]
(
	[challenge_type_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [type] VARCHAR(50) NULL, 
    [description] VARCHAR(MAX) NULL
)
