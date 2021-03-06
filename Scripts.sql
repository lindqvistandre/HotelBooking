USE [master]
GO
/****** Object:  Database [HotelBooking]    Script Date: 10/1/2021 10:50:01 AM ******/
CREATE DATABASE [HotelBooking]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelBooking', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HotelBooking.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelBooking_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HotelBooking_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HotelBooking] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelBooking].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelBooking] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelBooking] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelBooking] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelBooking] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelBooking] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelBooking] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotelBooking] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelBooking] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelBooking] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelBooking] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelBooking] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelBooking] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelBooking] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelBooking] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelBooking] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HotelBooking] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelBooking] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelBooking] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelBooking] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelBooking] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelBooking] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelBooking] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelBooking] SET RECOVERY FULL 
GO
ALTER DATABASE [HotelBooking] SET  MULTI_USER 
GO
ALTER DATABASE [HotelBooking] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelBooking] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelBooking] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelBooking] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelBooking] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HotelBooking', N'ON'
GO
ALTER DATABASE [HotelBooking] SET QUERY_STORE = OFF
GO
USE [HotelBooking]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 10/1/2021 10:50:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NULL,
	[HotelId] [int] NULL,
	[StartDate] [date] NULL,
	[BookingDays] [int] NULL,
	[CustomerId] [int] NULL,
	[TotalCharges] [float] NULL,
	[EndDate] [date] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 10/1/2021 10:50:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[FullName] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Extra]    Script Date: 10/1/2021 10:50:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Extra](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExtraDescription] [varchar](max) NULL,
	[HotelId] [int] NULL,
 CONSTRAINT [PK_Extra] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelInfo]    Script Date: 10/1/2021 10:50:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelName] [varchar](50) NULL,
	[Rating] [float] NULL,
	[City] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[NumberOfRooms] [int] NULL,
	[HasPrizes] [bit] NULL,
	[IsAvailable] [bit] NULL,
 CONSTRAINT [PK_HotelInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 10/1/2021 10:50:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelId] [int] NULL,
	[IsAvailable] [bit] NULL,
	[AvailableDate] [date] NULL,
	[Size] [varchar](50) NULL,
	[PricePerNight] [float] NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Username], [Password], [Gender], [FullName], [Contact], [Email]) VALUES (1, N'b', N'123', N'System.Windows.Controls.ComboBoxItem: Male', N'Blj', N'2343434', N'blj@gmail.com')
INSERT [dbo].[Customer] ([Id], [Username], [Password], [Gender], [FullName], [Contact], [Email]) VALUES (2, N's', N'123', N'System.Windows.Controls.ComboBoxItem: Male', N'sss', N'123', N'email')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Extra] ON 

INSERT [dbo].[Extra] ([Id], [ExtraDescription], [HotelId]) VALUES (1, N'transport back/forth to the hotell', 1)
INSERT [dbo].[Extra] ([Id], [ExtraDescription], [HotelId]) VALUES (2, N'pool access', 2)
INSERT [dbo].[Extra] ([Id], [ExtraDescription], [HotelId]) VALUES (3, N'breakfast', 3)
SET IDENTITY_INSERT [dbo].[Extra] OFF
GO
SET IDENTITY_INSERT [dbo].[HotelInfo] ON 

INSERT [dbo].[HotelInfo] ([Id], [HotelName], [Rating], [City], [Country], [NumberOfRooms], [HasPrizes], [IsAvailable]) VALUES (1, N'Mariot', 4.5, N'New York', N'USA', 100, 1, 1)
INSERT [dbo].[HotelInfo] ([Id], [HotelName], [Rating], [City], [Country], [NumberOfRooms], [HasPrizes], [IsAvailable]) VALUES (2, N'Dubae Hotel', 4.4, N'LA', N'USA', 200, 1, 1)
INSERT [dbo].[HotelInfo] ([Id], [HotelName], [Rating], [City], [Country], [NumberOfRooms], [HasPrizes], [IsAvailable]) VALUES (3, N'Hotel 2', 4, N'CAL', N'USA', 500, 1, 1)
SET IDENTITY_INSERT [dbo].[HotelInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([Id], [HotelId], [IsAvailable], [AvailableDate], [Size], [PricePerNight]) VALUES (1, 1, 1, CAST(N'2021-01-10' AS Date), N'Small', 100)
INSERT [dbo].[Room] ([Id], [HotelId], [IsAvailable], [AvailableDate], [Size], [PricePerNight]) VALUES (2, 1, 1, CAST(N'2021-01-10' AS Date), N'Medium', 200)
INSERT [dbo].[Room] ([Id], [HotelId], [IsAvailable], [AvailableDate], [Size], [PricePerNight]) VALUES (3, 1, 1, CAST(N'2021-01-10' AS Date), N'Large', 300)
INSERT [dbo].[Room] ([Id], [HotelId], [IsAvailable], [AvailableDate], [Size], [PricePerNight]) VALUES (4, 2, 1, CAST(N'2021-01-10' AS Date), N'Small', 200)
INSERT [dbo].[Room] ([Id], [HotelId], [IsAvailable], [AvailableDate], [Size], [PricePerNight]) VALUES (5, 2, 1, CAST(N'2021-01-10' AS Date), N'Medium', 300)
INSERT [dbo].[Room] ([Id], [HotelId], [IsAvailable], [AvailableDate], [Size], [PricePerNight]) VALUES (6, 2, 1, CAST(N'2021-01-10' AS Date), N'Large', 400)
INSERT [dbo].[Room] ([Id], [HotelId], [IsAvailable], [AvailableDate], [Size], [PricePerNight]) VALUES (7, 3, 1, CAST(N'2021-01-10' AS Date), N'Small', 200)
INSERT [dbo].[Room] ([Id], [HotelId], [IsAvailable], [AvailableDate], [Size], [PricePerNight]) VALUES (8, 3, 1, CAST(N'2021-01-10' AS Date), N'Medium', 300)
INSERT [dbo].[Room] ([Id], [HotelId], [IsAvailable], [AvailableDate], [Size], [PricePerNight]) VALUES (9, 3, 1, CAST(N'2021-01-10' AS Date), N'Large', 400)
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Customer]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_HotelInfo] FOREIGN KEY([HotelId])
REFERENCES [dbo].[HotelInfo] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_HotelInfo]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Room]
GO
ALTER TABLE [dbo].[Extra]  WITH CHECK ADD  CONSTRAINT [FK_Extra_HotelInfo] FOREIGN KEY([HotelId])
REFERENCES [dbo].[HotelInfo] ([Id])
GO
ALTER TABLE [dbo].[Extra] CHECK CONSTRAINT [FK_Extra_HotelInfo]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_HotelInfo] FOREIGN KEY([HotelId])
REFERENCES [dbo].[HotelInfo] ([Id])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_HotelInfo]
GO
USE [master]
GO
ALTER DATABASE [HotelBooking] SET  READ_WRITE 
GO
