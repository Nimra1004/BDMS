CREATE DATABASE[SELAB]
USE [SELAB]


GO

/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/10/2018 1:16:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
GO

/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12/10/2018 1:16:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


GO

/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/10/2018 1:16:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/10/2018 1:16:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO


GO

/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/10/2018 1:16:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO


GO

/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/10/2018 1:16:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO

ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO

GO
CREATE TABLE dbo.RegisteredUser
(
R_ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
R_Email nvarchar(256) NOT NULL,
R_Name nvarchar(256) NOT NULL,
R_Gender nvarchar (256) NOT NULL,
R_BloodGroup nvarchar (256) NOT NULL,
R_Contact nvarchar (256) NOT NULL,
R_Dateofbirth datetime NOT NULL,
R_City nvarchar(256) NOT NULL,
R_Address nvarchar (256) NOT NULL,
R_AddedOn datetime NOT NULL,
CONSTRAINT UserEmail UNIQUE(R_Email),
CONSTRAINT UserContact UNIQUE(R_Contact),
FK_R_ID nvarchar(128) UNIQUE FOREIGN KEY REFERENCES dbo.AspNetUsers(Id) NOT NULL,
);
GO
CREATE TABLE dbo.Donor
(
D_ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
D_NoDonations int NULL,
D_candonate nvarchar NULL,
FK_donor_ID nvarchar(128) UNIQUE FOREIGN KEY REFERENCES dbo.AspNetUsers(Id) NOT NULL,
);
GO

CREATE TABLE [dbo].[GoogleMap](  
    [ID] [int] IDENTITY(1,1) NOT NULL,  
    [CityName] [nvarchar](50) NULL,  
    [Latitude] [numeric](18, 0) NULL,  
    [Longitude] [numeric](18, 0) NULL,  
    [Description] [nvarchar](100) NULL,  
 CONSTRAINT [PK_GoogleMap] PRIMARY KEY CLUSTERED   
(  
    [ID] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  
  
GO  
  
CREATE procedure [dbo].[spAddNewLocation]  
(  
@CityName nvarchar(50),  
@Latitude numeric(18, 0),  
@Longitude numeric(18, 0),  
@Description nvarchar(100)  
)  
as  
begin  
insert into [dbo].[GoogleMap](CityName,Latitude,Longitude,Description)  
values(@CityName,@Latitude,@Longitude,@Description)  
end  
GO
CREATE procedure [dbo].[spGetMap]  
as  
begin  
select CityName,Latitude,Longitude,Description from [dbo].[GoogleMap]  
end  
GO

CREATE TABLE dbo.Donation
(
DonationsID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
Donatdate datetime NOT NULL,
Place int FOREIGN KEY REFERENCES dbo.GoogleMap([ID])NOT NULL,
FK_Donation_ID nvarchar(128) FOREIGN KEY REFERENCES dbo.AspNetUsers(Id) NOT NULL,
);
GO

CREATE TABLE dbo.PostRequest
(
Request_ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
BloodGroup nvarchar (256) NOT NULL,
Address int FOREIGN KEY REFERENCES dbo.GoogleMap([ID])NOT NULL,
Status nvarchar(256) DEFAULT 'Decline' NOT NULL,
FK_ID nvarchar(128) FOREIGN KEY REFERENCES dbo.AspNetUsers(Id) NOT NULL,
);
GO
CREATE TABLE dbo.Feedback
(
ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
Name nvarchar(50) NOT NULL,
Email nvarchar (256) NOT NULL,
Message nvarchar (256) NOT NULL,
FK_ID nvarchar(128) FOREIGN KEY REFERENCES dbo.AspNetUsers(Id) NOT NULL,
);
GO

