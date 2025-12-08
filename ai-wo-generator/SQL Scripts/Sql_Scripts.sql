-- On Nov 22, 2025
CREATE TABLE [dbo].[Users] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Email] NVARCHAR(256) NOT NULL UNIQUE,
    [PasswordHash] NVARCHAR(256) NOT NULL,
    [FullName] NVARCHAR(200) NULL,
    [Role] NVARCHAR(50) NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);

-- Updated on Dec 7, 2025
-- Create userStatistics table
CREATE TABLE UserStatistics (
    UserId INT NOT NULL,
    DateOfBirth DATE NOT NULL,
    WeightInLbs DECIMAL(5,2) NOT NULL,
    HeightInInches DECIMAL(5,2) NOT NULL,
    BiologicalSex NVARCHAR(50) NOT NULL,
    ExperienceLevel NVARCHAR(100) NULL,
    Profession NVARCHAR(200) NULL,
    ChronicPhysicalLimitations NVARCHAR(MAX) NULL,
    MedicalIssues NVARCHAR(MAX) NULL,
    CreatedAt DATETIME2(7) NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2(7) NOT NULL DEFAULT GETUTCDATE(),
    
    -- Primary Key
    CONSTRAINT PK_userStatistics PRIMARY KEY (UserId),
    
    -- Foreign Key to Users table
    CONSTRAINT FK_userStatistics_Users FOREIGN KEY (UserId)
        REFERENCES Users(Id)
        ON DELETE CASCADE,
    
    -- Check constraints for data validation
    CONSTRAINT CK_userStatistics_WeightInLbs CHECK (WeightInLbs > 0 AND WeightInLbs < 1500),
    CONSTRAINT CK_userStatistics_HeightInInches CHECK (HeightInInches > 0 AND HeightInInches < 120),
    CONSTRAINT CK_userStatistics_DateOfBirth CHECK (DateOfBirth <= CAST(GETUTCDATE() AS DATE))
);
GO

  
