IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE TABLE [accountStatus] (
        [accountStatusID] int NOT NULL IDENTITY,
        [accountStatus] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_accountStatus] PRIMARY KEY ([accountStatusID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE TABLE [bloodGroups] (
        [BloodGroupID] int NOT NULL IDENTITY,
        [BloodGroup] nvarchar(5) NOT NULL,
        CONSTRAINT [PK_bloodGroups] PRIMARY KEY ([BloodGroupID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE TABLE [city] (
        [CityID] int NOT NULL IDENTITY,
        [City] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_city] PRIMARY KEY ([CityID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE TABLE [Gender] (
        [GenderID] int NOT NULL IDENTITY,
        [Gender] nvarchar(10) NOT NULL,
        CONSTRAINT [PK_Gender] PRIMARY KEY ([GenderID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE TABLE [institutionType] (
        [InstitutionTypeID] int NOT NULL IDENTITY,
        [InstituitonType] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_institutionType] PRIMARY KEY ([InstitutionTypeID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE TABLE [requestType] (
        [RequestTypeID] int NOT NULL IDENTITY,
        [RequestType] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_requestType] PRIMARY KEY ([RequestTypeID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE TABLE [userType] (
        [UserTypeID] int NOT NULL IDENTITY,
        [UserType] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_userType] PRIMARY KEY ([UserTypeID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE TABLE [request] (
        [RequestID] int NOT NULL IDENTITY,
        [RequestDate] date NOT NULL,
        [MemberName] nvarchar(max) NULL,
        [UserTypeID] int NULL,
        [Quantity] nvarchar(max) NULL,
        [Contact] nvarchar(max) NULL,
        [CityID] int NULL,
        [RequestTypeID] int NULL,
        [BloodGroupID] int NULL,
        CONSTRAINT [PK_request] PRIMARY KEY ([RequestID]),
        CONSTRAINT [FK_request_bloodGroups_BloodGroupID] FOREIGN KEY ([BloodGroupID]) REFERENCES [bloodGroups] ([BloodGroupID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_request_city_CityID] FOREIGN KEY ([CityID]) REFERENCES [city] ([CityID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_request_requestType_RequestTypeID] FOREIGN KEY ([RequestTypeID]) REFERENCES [requestType] ([RequestTypeID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_request_userType_UserTypeID] FOREIGN KEY ([UserTypeID]) REFERENCES [userType] ([UserTypeID]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE TABLE [user] (
        [UserID] int NOT NULL IDENTITY,
        [UserName] nvarchar(50) NOT NULL,
        [Password] nvarchar(50) NOT NULL,
        [EmailAddress] nvarchar(50) NOT NULL,
        [AccountStatusID] int NOT NULL,
        [UserTypeID] int NULL,
        CONSTRAINT [PK_user] PRIMARY KEY ([UserID]),
        CONSTRAINT [FK_user_accountStatus_AccountStatusID] FOREIGN KEY ([AccountStatusID]) REFERENCES [accountStatus] ([accountStatusID]) ON DELETE CASCADE,
        CONSTRAINT [FK_user_userType_UserTypeID] FOREIGN KEY ([UserTypeID]) REFERENCES [userType] ([UserTypeID]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE TABLE [donor] (
        [DonorID] int NOT NULL IDENTITY,
        [FullName] nvarchar(150) NOT NULL,
        [BloodGroupID] int NOT NULL,
        [LastDonationDate] date NOT NULL,
        [Adhaar] nvarchar(17) NOT NULL,
        [Location] nvarchar(300) NOT NULL,
        [ContactNo] nvarchar(15) NOT NULL,
        [CityID] int NOT NULL,
        [UserID] int NULL,
        [GenderID] int NOT NULL,
        CONSTRAINT [PK_donor] PRIMARY KEY ([DonorID]),
        CONSTRAINT [FK_donor_bloodGroups_BloodGroupID] FOREIGN KEY ([BloodGroupID]) REFERENCES [bloodGroups] ([BloodGroupID]) ON DELETE CASCADE,
        CONSTRAINT [FK_donor_city_CityID] FOREIGN KEY ([CityID]) REFERENCES [city] ([CityID]) ON DELETE CASCADE,
        CONSTRAINT [FK_donor_Gender_GenderID] FOREIGN KEY ([GenderID]) REFERENCES [Gender] ([GenderID]) ON DELETE CASCADE,
        CONSTRAINT [FK_donor_user_UserID] FOREIGN KEY ([UserID]) REFERENCES [user] ([UserID]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE TABLE [institution] (
        [InstitutionID] int NOT NULL IDENTITY,
        [InstitutionName] nvarchar(50) NOT NULL,
        [InstitutionTypeID] int NOT NULL,
        [Address] nvarchar(50) NOT NULL,
        [PhoneNo] nvarchar(50) NOT NULL,
        [Website] nvarchar(50) NOT NULL,
        [Email] nvarchar(50) NOT NULL,
        [Location] nvarchar(50) NOT NULL,
        [CityID] int NOT NULL,
        [UserID] int NOT NULL,
        [InstituionTypeID] int NULL,
        CONSTRAINT [PK_institution] PRIMARY KEY ([InstitutionID]),
        CONSTRAINT [FK_institution_city_CityID] FOREIGN KEY ([CityID]) REFERENCES [city] ([CityID]) ON DELETE CASCADE,
        CONSTRAINT [FK_institution_institutionType_InstituionTypeID] FOREIGN KEY ([InstituionTypeID]) REFERENCES [institutionType] ([InstitutionTypeID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_institution_user_UserID] FOREIGN KEY ([UserID]) REFERENCES [user] ([UserID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE TABLE [seeker] (
        [SeekerID] int NOT NULL IDENTITY,
        [FullName] nvarchar(50) NULL,
        [Age] int NOT NULL,
        [ContactNo] nvarchar(50) NULL,
        [Adhaar] nvarchar(50) NULL,
        [RegistrationDate] date NOT NULL,
        [BloodGroupID] int NOT NULL,
        [CityID] int NOT NULL,
        [GenderID] int NOT NULL,
        [UserID] int NULL,
        CONSTRAINT [PK_seeker] PRIMARY KEY ([SeekerID]),
        CONSTRAINT [FK_seeker_bloodGroups_BloodGroupID] FOREIGN KEY ([BloodGroupID]) REFERENCES [bloodGroups] ([BloodGroupID]) ON DELETE CASCADE,
        CONSTRAINT [FK_seeker_city_CityID] FOREIGN KEY ([CityID]) REFERENCES [city] ([CityID]) ON DELETE CASCADE,
        CONSTRAINT [FK_seeker_Gender_GenderID] FOREIGN KEY ([GenderID]) REFERENCES [Gender] ([GenderID]) ON DELETE CASCADE,
        CONSTRAINT [FK_seeker_user_UserID] FOREIGN KEY ([UserID]) REFERENCES [user] ([UserID]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE TABLE [bloodStock] (
        [BloodStockID] int NOT NULL IDENTITY,
        [BloodGroupID] int NOT NULL,
        [InstitutionID] int NOT NULL,
        [Quantity] int NOT NULL,
        [Status] bit NOT NULL,
        [Description] nvarchar(150) NOT NULL,
        CONSTRAINT [PK_bloodStock] PRIMARY KEY ([BloodStockID]),
        CONSTRAINT [FK_bloodStock_bloodGroups_BloodGroupID] FOREIGN KEY ([BloodGroupID]) REFERENCES [bloodGroups] ([BloodGroupID]) ON DELETE CASCADE,
        CONSTRAINT [FK_bloodStock_institution_InstitutionID] FOREIGN KEY ([InstitutionID]) REFERENCES [institution] ([InstitutionID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GenderID', N'Gender') AND [object_id] = OBJECT_ID(N'[Gender]'))
        SET IDENTITY_INSERT [Gender] ON;
    EXEC(N'INSERT INTO [Gender] ([GenderID], [Gender])
    VALUES (3, N''Others''),
    (2, N''Female''),
    (1, N''Male'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GenderID', N'Gender') AND [object_id] = OBJECT_ID(N'[Gender]'))
        SET IDENTITY_INSERT [Gender] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'accountStatusID', N'accountStatus') AND [object_id] = OBJECT_ID(N'[accountStatus]'))
        SET IDENTITY_INSERT [accountStatus] ON;
    EXEC(N'INSERT INTO [accountStatus] ([accountStatusID], [accountStatus])
    VALUES (1, N''Pending''),
    (2, N''Approved''),
    (3, N''Denied''),
    (4, N''Open''),
    (5, N''Closed'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'accountStatusID', N'accountStatus') AND [object_id] = OBJECT_ID(N'[accountStatus]'))
        SET IDENTITY_INSERT [accountStatus] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BloodGroupID', N'BloodGroup') AND [object_id] = OBJECT_ID(N'[bloodGroups]'))
        SET IDENTITY_INSERT [bloodGroups] ON;
    EXEC(N'INSERT INTO [bloodGroups] ([BloodGroupID], [BloodGroup])
    VALUES (1, N''AB+''),
    (2, N''B+''),
    (3, N''O+''),
    (4, N''A-''),
    (5, N''B-''),
    (6, N''A+'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BloodGroupID', N'BloodGroup') AND [object_id] = OBJECT_ID(N'[bloodGroups]'))
        SET IDENTITY_INSERT [bloodGroups] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CityID', N'City') AND [object_id] = OBJECT_ID(N'[city]'))
        SET IDENTITY_INSERT [city] ON;
    EXEC(N'INSERT INTO [city] ([CityID], [City])
    VALUES (7, N''Indore''),
    (6, N''Nagpur''),
    (2, N''Mumbai''),
    (4, N''Bhopal''),
    (3, N''Nashik''),
    (1, N''Pune''),
    (5, N''Ahmedabad'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CityID', N'City') AND [object_id] = OBJECT_ID(N'[city]'))
        SET IDENTITY_INSERT [city] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RequestTypeID', N'RequestType') AND [object_id] = OBJECT_ID(N'[requestType]'))
        SET IDENTITY_INSERT [requestType] ON;
    EXEC(N'INSERT INTO [requestType] ([RequestTypeID], [RequestType])
    VALUES (1, N''Seeker''),
    (2, N''Institution'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RequestTypeID', N'RequestType') AND [object_id] = OBJECT_ID(N'[requestType]'))
        SET IDENTITY_INSERT [requestType] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserTypeID', N'UserType') AND [object_id] = OBJECT_ID(N'[userType]'))
        SET IDENTITY_INSERT [userType] ON;
    EXEC(N'INSERT INTO [userType] ([UserTypeID], [UserType])
    VALUES (2, N''Seeker''),
    (1, N''Donor''),
    (3, N''Institution'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserTypeID', N'UserType') AND [object_id] = OBJECT_ID(N'[userType]'))
        SET IDENTITY_INSERT [userType] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_bloodStock_BloodGroupID] ON [bloodStock] ([BloodGroupID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_bloodStock_InstitutionID] ON [bloodStock] ([InstitutionID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_donor_BloodGroupID] ON [donor] ([BloodGroupID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_donor_CityID] ON [donor] ([CityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_donor_GenderID] ON [donor] ([GenderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_donor_UserID] ON [donor] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_institution_CityID] ON [institution] ([CityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_institution_InstituionTypeID] ON [institution] ([InstituionTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_institution_UserID] ON [institution] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_request_BloodGroupID] ON [request] ([BloodGroupID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_request_CityID] ON [request] ([CityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_request_RequestTypeID] ON [request] ([RequestTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_request_UserTypeID] ON [request] ([UserTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_seeker_BloodGroupID] ON [seeker] ([BloodGroupID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_seeker_CityID] ON [seeker] ([CityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_seeker_GenderID] ON [seeker] ([GenderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_seeker_UserID] ON [seeker] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_user_AccountStatusID] ON [user] ([AccountStatusID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    CREATE INDEX [IX_user_UserTypeID] ON [user] ([UserTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220630180835_Initials')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220630180835_Initials', N'5.0.17');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220703073245_final')
BEGIN
    EXEC(N'UPDATE [userType] SET [UserType] = N''Admin''
    WHERE [UserTypeID] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220703073245_final')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220703073245_final', N'5.0.17');
END;
GO

COMMIT;
GO

