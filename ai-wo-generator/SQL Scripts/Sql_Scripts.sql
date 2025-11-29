-- On Nov 22, 2025
CREATE TABLE [dbo].[Users] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Email] NVARCHAR(256) NOT NULL UNIQUE,
    [PasswordHash] NVARCHAR(256) NOT NULL,
    [FullName] NVARCHAR(200) NULL,
    [Role] NVARCHAR(50) NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);

-- On Nov 28, 2025
CREATE TABLE UserStatistics (
    UserId INT NOT NULL PRIMARY KEY,       
    HeightInInches DECIMAL(5,2) NULL,            
    WeightInPounds DECIMAL(5,2) NULL,            
    Gender VARCHAR(10) NULL,               
    DateOfBirth DATE NULL,                 
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 DEFAULT GETDATE(),
    
    CONSTRAINT FK_UserStatistics_User FOREIGN KEY (UserId)
        REFERENCES Users(Id)
        ON DELETE CASCADE
);

-- Adding an index on UserId for faster lookups
CREATE INDEX IX_UserStatistics_UserId ON UserStatistics(UserId);