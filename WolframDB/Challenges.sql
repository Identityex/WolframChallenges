CREATE TABLE [dbo].[Challenges]
(
	[challenge_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] VARCHAR(100) NULL, 
    [description] VARCHAR(MAX) NULL, 
    [challenge_type_id] INT NULL, 
    [challenge_status_id] INT NULL, 
    CONSTRAINT [FK_Challenges_ToChallengeStatuses] FOREIGN KEY (challenge_status_id) REFERENCES ChallengeStatuses(challenge_status_id),
    CONSTRAINT [FK_Challenges_ToChallengeTypes] FOREIGN KEY (challenge_type_id) REFERENCES ChallengeTypes(challenge_type_id),
)
