CREATE TABLE [dbo].[ChallengeStatuses]
(
	[challenge_status_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [status] VARCHAR(50) NULL, 
    [description] VARCHAR(MAX) NULL
)
