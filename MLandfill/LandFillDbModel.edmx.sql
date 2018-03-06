
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/03/2018 14:23:56
-- Generated from EDMX file: E:\GIT\GitRepository\MLandFill\MLandfill\LandFillDbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LandFillNRL];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__WASTE_APP__SUB_I__431N6F928]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblWasteApproval] DROP CONSTRAINT [FK__WASTE_APP__SUB_I__431N6F928];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_tblLandFillWasteDockets_tblWasteApproval]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblLandFillWasteDockets] DROP CONSTRAINT [FK_tblLandFillWasteDockets_tblWasteApproval];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWasteApprovalNew_tblGenerator]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblWasteApproval] DROP CONSTRAINT [FK_tblWasteApprovalNew_tblGenerator];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWasteApprovalNew_tblGeneratorLocations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblWasteApproval] DROP CONSTRAINT [FK_tblWasteApprovalNew_tblGeneratorLocations];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[tblConsultants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblConsultants];
GO
IF OBJECT_ID(N'[dbo].[tblConsultContacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblConsultContacts];
GO
IF OBJECT_ID(N'[dbo].[tblGeneratorContacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblGeneratorContacts];
GO
IF OBJECT_ID(N'[dbo].[tblGeneratorLocations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblGeneratorLocations];
GO
IF OBJECT_ID(N'[dbo].[tblGenerators]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblGenerators];
GO
IF OBJECT_ID(N'[dbo].[tblInterestCharges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblInterestCharges];
GO
IF OBJECT_ID(N'[dbo].[tblLandFillWasteDockets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblLandFillWasteDockets];
GO
IF OBJECT_ID(N'[dbo].[tblSubstances]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSubstances];
GO
IF OBJECT_ID(N'[dbo].[tblTruckCompanies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTruckCompanies];
GO
IF OBJECT_ID(N'[dbo].[tblWasteApproval]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblWasteApproval];
GO
IF OBJECT_ID(N'[dbo].[tblWasteDescriptionCodes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblWasteDescriptionCodes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tblChangeLogs'
CREATE TABLE [dbo].[tblChangeLogs] (
    [logId] int  NOT NULL,
    [FormID] int  NULL,
    [TableId] int  NULL,
    [ActivityID] int  NULL,
    [OldValue] varchar(250)  NULL,
    [NewValue] varchar(250)  NULL,
    [PerformedBy] varchar(200)  NULL
);
GO

-- Creating table 'tblConsultants'
CREATE TABLE [dbo].[tblConsultants] (
    [ConsultantId] int IDENTITY(1,1) NOT NULL,
    [ConsultantName] nvarchar(max)  NULL,
    [ConsultantAddr] nvarchar(max)  NULL,
    [ConsultantCity] nvarchar(max)  NULL,
    [ConsultantProv] nvarchar(max)  NULL,
    [ConsultantPostal] nvarchar(max)  NULL,
    [ConsultantPhone] nvarchar(max)  NULL,
    [ConsultantNotes] nvarchar(max)  NULL
);
GO

-- Creating table 'tblConsultContacts'
CREATE TABLE [dbo].[tblConsultContacts] (
    [ConsultantContactId] int IDENTITY(1,1) NOT NULL,
    [ConsultantContactConsultId] int  NOT NULL,
    [ConsultantContactName] nvarchar(max)  NULL,
    [ConsultantContactPhone] nvarchar(max)  NULL
);
GO

-- Creating table 'tblGeneratorContacts'
CREATE TABLE [dbo].[tblGeneratorContacts] (
    [GenerContactId] int IDENTITY(1,1) NOT NULL,
    [GenerContactGenerId] int  NOT NULL,
    [GenerContactName] nvarchar(max)  NULL,
    [GenerContactPhone] nvarchar(max)  NULL,
    [GenerContactCell] nvarchar(max)  NULL,
    [GenerContactFax] nvarchar(max)  NULL
);
GO

-- Creating table 'tblGeneratorLocations'
CREATE TABLE [dbo].[tblGeneratorLocations] (
    [GenerLocationId] int IDENTITY(1,1) NOT NULL,
    [GenerLocationGenID] int  NOT NULL,
    [GenerLocationLsd] nvarchar(max)  NULL
);
GO

-- Creating table 'tblGenerators'
CREATE TABLE [dbo].[tblGenerators] (
    [GeneratorId] int IDENTITY(1,1) NOT NULL,
    [GeneratorName] nvarchar(max)  NULL,
    [GenaratorAddr] nvarchar(max)  NULL,
    [GeneratorCity] nvarchar(max)  NULL,
    [GeneratorProv] nvarchar(max)  NULL,
    [GeneratorPostal] nvarchar(max)  NULL,
    [GeneratorPhone] nvarchar(max)  NULL,
    [GeneratorComments] nvarchar(max)  NULL,
    [GeneratorExcldInterest] bit  NOT NULL
);
GO

-- Creating table 'tblInterestCharges'
CREATE TABLE [dbo].[tblInterestCharges] (
    [IntAmount] int IDENTITY(1,1) NOT NULL,
    [IntDaysOverdue] int  NOT NULL
);
GO

-- Creating table 'tblInvoiceesDds'
CREATE TABLE [dbo].[tblInvoiceesDds] (
    [InvoiceeID] int IDENTITY(1,1) NOT NULL,
    [InvoiceeName] varchar(75)  NULL
);
GO

-- Creating table 'tblLandFillWasteDockets'
CREATE TABLE [dbo].[tblLandFillWasteDockets] (
    [DocketId] int IDENTITY(1,1) NOT NULL,
    [DocketNo] varchar(30)  NULL,
    [WasteApprovalCode] varchar(100)  NULL,
    [InvoiceeId] int  NULL,
    [TurckCompanyId] int  NULL,
    [DriverName] varchar(50)  NULL,
    [DestinatedFor] varchar(20)  NULL,
    [ScaleTicket] varchar(30)  NULL,
    [Gross] decimal(20,4)  NULL,
    [Tare] decimal(20,4)  NULL,
    [Net] decimal(20,4)  NULL,
    [Cell] varchar(30)  NULL,
    [Grid] varchar(30)  NULL,
    [GridNo] varchar(30)  NULL,
    [Elevation] varchar(30)  NULL,
    [DateReceived] datetime  NULL,
    [Memo] varchar(max)  NULL,
    [InvoiceNo] varchar(50)  NULL,
    [LoadReceivingDate] datetime  NULL,
    [WasteApprovalId] int  NULL,
    [ReceivedDate] datetime  NULL,
    [LogEntryTimeStamp] datetime  NULL,
    [InvoiceNumber] int  NULL
);
GO

-- Creating table 'tblSubstances'
CREATE TABLE [dbo].[tblSubstances] (
    [SubstanceId] int IDENTITY(1,1) NOT NULL,
    [SubstanceName] nvarchar(max)  NULL,
    [SubstanceCode] nvarchar(max)  NULL
);
GO

-- Creating table 'tblTruckCompanies'
CREATE TABLE [dbo].[tblTruckCompanies] (
    [TruckCompId] int IDENTITY(1,1) NOT NULL,
    [TruckCompName] nvarchar(max)  NULL,
    [TruckCompAddr] nvarchar(max)  NULL,
    [TruckCompCity] nvarchar(max)  NULL,
    [TruckCompProv] nvarchar(max)  NULL,
    [TruckCompPostal] nvarchar(max)  NULL,
    [TruckCompPhone] nvarchar(max)  NULL
);
GO

-- Creating table 'tblWasteDescriptionCodes'
CREATE TABLE [dbo].[tblWasteDescriptionCodes] (
    [WasteDescriptionId] int IDENTITY(1,1) NOT NULL,
    [WasteDescription] nvarchar(max)  NULL,
    [WasteDescriptionCode] nvarchar(max)  NULL,
    [WasteDescriptionInvoice] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL,
    [User_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [UserId] nvarchar(128)  NOT NULL,
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [Discriminator] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'tblWasteApproval1'
CREATE TABLE [dbo].[tblWasteApproval1] (
    [WApApprovalId] int IDENTITY(1,1) NOT NULL,
    [WApApprovalcode] varchar(100)  NULL,
    [WApGeneratorId] int  NULL,
    [WApWasteDescrip] varchar(100)  NULL,
    [WApSubId] int  NULL,
    [WApLocationId] int  NULL,
    [WApCreateDate] datetime  NULL,
    [WApGenContactId] int  NULL,
    [WApExpiryDate] datetime  NULL,
    [WApRate] decimal(19,4)  NULL,
    [WApComments] varchar(max)  NULL,
    [WApExtQuantity] float  NULL,
    [WApApproved] bit  NULL,
    [WApMailMerge] bit  NULL,
    [WApJobNo] varchar(30)  NULL,
    [WApAfeNo] varchar(100)  NULL,
    [WApPoNo] varchar(50)  NULL,
    [WApConsultantId] int  NULL,
    [WApConContactID] int  NULL,
    [WApAdcApproved] bit  NULL,
    [WApInvoicee] int  NULL,
    [WApWasteDescriptionMailMerge] varchar(100)  NULL,
    [WApMinCharge] bit  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles1'
CREATE TABLE [dbo].[AspNetUserRoles1] (
    [AspNetRoles1_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers1_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [logId] in table 'tblChangeLogs'
ALTER TABLE [dbo].[tblChangeLogs]
ADD CONSTRAINT [PK_tblChangeLogs]
    PRIMARY KEY CLUSTERED ([logId] ASC);
GO

-- Creating primary key on [ConsultantId] in table 'tblConsultants'
ALTER TABLE [dbo].[tblConsultants]
ADD CONSTRAINT [PK_tblConsultants]
    PRIMARY KEY CLUSTERED ([ConsultantId] ASC);
GO

-- Creating primary key on [ConsultantContactId] in table 'tblConsultContacts'
ALTER TABLE [dbo].[tblConsultContacts]
ADD CONSTRAINT [PK_tblConsultContacts]
    PRIMARY KEY CLUSTERED ([ConsultantContactId] ASC);
GO

-- Creating primary key on [GenerContactId] in table 'tblGeneratorContacts'
ALTER TABLE [dbo].[tblGeneratorContacts]
ADD CONSTRAINT [PK_tblGeneratorContacts]
    PRIMARY KEY CLUSTERED ([GenerContactId] ASC);
GO

-- Creating primary key on [GenerLocationId] in table 'tblGeneratorLocations'
ALTER TABLE [dbo].[tblGeneratorLocations]
ADD CONSTRAINT [PK_tblGeneratorLocations]
    PRIMARY KEY CLUSTERED ([GenerLocationId] ASC);
GO

-- Creating primary key on [GeneratorId] in table 'tblGenerators'
ALTER TABLE [dbo].[tblGenerators]
ADD CONSTRAINT [PK_tblGenerators]
    PRIMARY KEY CLUSTERED ([GeneratorId] ASC);
GO

-- Creating primary key on [IntAmount] in table 'tblInterestCharges'
ALTER TABLE [dbo].[tblInterestCharges]
ADD CONSTRAINT [PK_tblInterestCharges]
    PRIMARY KEY CLUSTERED ([IntAmount] ASC);
GO

-- Creating primary key on [InvoiceeID] in table 'tblInvoiceesDds'
ALTER TABLE [dbo].[tblInvoiceesDds]
ADD CONSTRAINT [PK_tblInvoiceesDds]
    PRIMARY KEY CLUSTERED ([InvoiceeID] ASC);
GO

-- Creating primary key on [DocketId] in table 'tblLandFillWasteDockets'
ALTER TABLE [dbo].[tblLandFillWasteDockets]
ADD CONSTRAINT [PK_tblLandFillWasteDockets]
    PRIMARY KEY CLUSTERED ([DocketId] ASC);
GO

-- Creating primary key on [SubstanceId] in table 'tblSubstances'
ALTER TABLE [dbo].[tblSubstances]
ADD CONSTRAINT [PK_tblSubstances]
    PRIMARY KEY CLUSTERED ([SubstanceId] ASC);
GO

-- Creating primary key on [TruckCompId] in table 'tblTruckCompanies'
ALTER TABLE [dbo].[tblTruckCompanies]
ADD CONSTRAINT [PK_tblTruckCompanies]
    PRIMARY KEY CLUSTERED ([TruckCompId] ASC);
GO

-- Creating primary key on [WasteDescriptionId] in table 'tblWasteDescriptionCodes'
ALTER TABLE [dbo].[tblWasteDescriptionCodes]
ADD CONSTRAINT [PK_tblWasteDescriptionCodes]
    PRIMARY KEY CLUSTERED ([WasteDescriptionId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId], [LoginProvider], [ProviderKey] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([UserId], [LoginProvider], [ProviderKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [WApApprovalId] in table 'tblWasteApproval1'
ALTER TABLE [dbo].[tblWasteApproval1]
ADD CONSTRAINT [PK_tblWasteApproval1]
    PRIMARY KEY CLUSTERED ([WApApprovalId] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- Creating primary key on [AspNetRoles1_Id], [AspNetUsers1_Id] in table 'AspNetUserRoles1'
ALTER TABLE [dbo].[AspNetUserRoles1]
ADD CONSTRAINT [PK_AspNetUserRoles1]
    PRIMARY KEY CLUSTERED ([AspNetRoles1_Id], [AspNetUsers1_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TurckCompanyId] in table 'tblLandFillWasteDockets'
ALTER TABLE [dbo].[tblLandFillWasteDockets]
ADD CONSTRAINT [FK_tblLandFillWasteDockets_tblTruckCompanies]
    FOREIGN KEY ([TurckCompanyId])
    REFERENCES [dbo].[tblTruckCompanies]
        ([TruckCompId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblLandFillWasteDockets_tblTruckCompanies'
CREATE INDEX [IX_FK_tblLandFillWasteDockets_tblTruckCompanies]
ON [dbo].[tblLandFillWasteDockets]
    ([TurckCompanyId]);
GO

-- Creating foreign key on [User_Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]
ON [dbo].[AspNetUserClaims]
    ([User_Id]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRole]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUser]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUser'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUser]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [AspNetRoles1_Id] in table 'AspNetUserRoles1'
ALTER TABLE [dbo].[AspNetUserRoles1]
ADD CONSTRAINT [FK_AspNetUserRoles1_AspNetRole]
    FOREIGN KEY ([AspNetRoles1_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers1_Id] in table 'AspNetUserRoles1'
ALTER TABLE [dbo].[AspNetUserRoles1]
ADD CONSTRAINT [FK_AspNetUserRoles1_AspNetUser]
    FOREIGN KEY ([AspNetUsers1_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles1_AspNetUser'
CREATE INDEX [IX_FK_AspNetUserRoles1_AspNetUser]
ON [dbo].[AspNetUserRoles1]
    ([AspNetUsers1_Id]);
GO

-- Creating foreign key on [WApLocationId] in table 'tblWasteApproval1'
ALTER TABLE [dbo].[tblWasteApproval1]
ADD CONSTRAINT [FK_tblWasteApprovalNew_tblGeneratorLocations1]
    FOREIGN KEY ([WApLocationId])
    REFERENCES [dbo].[tblGeneratorLocations]
        ([GenerLocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWasteApprovalNew_tblGeneratorLocations1'
CREATE INDEX [IX_FK_tblWasteApprovalNew_tblGeneratorLocations1]
ON [dbo].[tblWasteApproval1]
    ([WApLocationId]);
GO

-- Creating foreign key on [WApGeneratorId] in table 'tblWasteApproval1'
ALTER TABLE [dbo].[tblWasteApproval1]
ADD CONSTRAINT [FK_tblWasteApprovalNew_tblGenerator1]
    FOREIGN KEY ([WApGeneratorId])
    REFERENCES [dbo].[tblGenerators]
        ([GeneratorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWasteApprovalNew_tblGenerator1'
CREATE INDEX [IX_FK_tblWasteApprovalNew_tblGenerator1]
ON [dbo].[tblWasteApproval1]
    ([WApGeneratorId]);
GO

-- Creating foreign key on [WasteApprovalId] in table 'tblLandFillWasteDockets'
ALTER TABLE [dbo].[tblLandFillWasteDockets]
ADD CONSTRAINT [FK_tblLandFillWasteDockets_tblWasteApproval1]
    FOREIGN KEY ([WasteApprovalId])
    REFERENCES [dbo].[tblWasteApproval1]
        ([WApApprovalId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblLandFillWasteDockets_tblWasteApproval1'
CREATE INDEX [IX_FK_tblLandFillWasteDockets_tblWasteApproval1]
ON [dbo].[tblLandFillWasteDockets]
    ([WasteApprovalId]);
GO

-- Creating foreign key on [WApSubId] in table 'tblWasteApproval1'
ALTER TABLE [dbo].[tblWasteApproval1]
ADD CONSTRAINT [FK__WASTE_APP__SUB_I__431N6F9281]
    FOREIGN KEY ([WApSubId])
    REFERENCES [dbo].[tblSubstances]
        ([SubstanceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__WASTE_APP__SUB_I__431N6F9281'
CREATE INDEX [IX_FK__WASTE_APP__SUB_I__431N6F9281]
ON [dbo].[tblWasteApproval1]
    ([WApSubId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------