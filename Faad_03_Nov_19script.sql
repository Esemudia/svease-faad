USE [master]
GO
/****** Object:  Database [faad]    Script Date: 11/3/2019 6:51:14 PM ******/
CREATE DATABASE [faad]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'faad', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\faad.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'faad_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\faad_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [faad] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [faad].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [faad] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [faad] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [faad] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [faad] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [faad] SET ARITHABORT OFF 
GO
ALTER DATABASE [faad] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [faad] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [faad] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [faad] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [faad] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [faad] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [faad] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [faad] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [faad] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [faad] SET  DISABLE_BROKER 
GO
ALTER DATABASE [faad] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [faad] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [faad] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [faad] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [faad] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [faad] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [faad] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [faad] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [faad] SET  MULTI_USER 
GO
ALTER DATABASE [faad] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [faad] SET DB_CHAINING OFF 
GO
ALTER DATABASE [faad] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [faad] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [faad]
GO
/****** Object:  Table [dbo].[ATL]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ATL](
	[atlID] [int] IDENTITY(1,1) NOT NULL,
	[po] [varchar](50) NULL,
	[customerID] [varchar](10) NULL,
	[salesRep] [int] NULL,
	[productDensity] [float] NULL,
	[atlDate] [datetime] NULL,
	[tanks_id] [int] NULL,
	[staff_id] [int] NULL,
	[vehicleNumber] [varchar](50) NULL,
	[comments] [text] NULL,
 CONSTRAINT [PK_atl] PRIMARY KEY CLUSTERED 
(
	[atlID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bankInfo]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bankInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[refID] [varchar](50) NULL,
	[BankName] [varbinary](50) NULL,
	[accountNumber] [nchar](10) NULL,
	[accountType] [nchar](10) NULL,
	[currency] [nchar](10) NULL,
 CONSTRAINT [PK_bankInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[costCenter]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[costCenter](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CostCenterID] [varchar](50) NULL,
	[CostCenter] [varchar](50) NULL,
	[adress] [text] NULL,
	[contactPhone] [varchar](50) NULL,
	[emailAddress] [varchar](50) NULL,
	[state] [varchar](50) NULL,
	[lga] [varchar](50) NULL,
	[logo] [varchar](50) NULL,
 CONSTRAINT [PK_costCenter] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customerID] [varchar](10) NOT NULL,
	[customerName] [varchar](50) NULL,
	[companyName] [varchar](50) NULL,
	[address] [text] NULL,
	[city] [varchar](50) NULL,
	[state] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[emailID] [varchar](50) NULL,
	[dateCreated] [timestamp] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[customerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[customer_job_status]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer_job_status](
	[id] [int] NOT NULL,
	[job_no] [text] NOT NULL,
	[volume_received] [text] NOT NULL,
	[customer_id] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[customers]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [nvarchar](max) NOT NULL,
	[customer_name] [nvarchar](max) NOT NULL,
	[address] [nvarchar](100) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[date_created] [datetime] NOT NULL,
	[companyName] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DailyStock]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyStock](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tankName] [nvarchar](50) NULL,
	[productName] [nvarchar](50) NULL,
	[openingStock] [nvarchar](50) NULL,
	[closingStock] [nvarchar](50) NULL,
	[LiftedStock] [nvarchar](50) NULL,
	[date] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dipping]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dipping](
	[DippingID] [int] IDENTITY(1,1) NOT NULL,
	[po_req] [varchar](50) NULL,
	[tankID] [int] NULL,
	[productType] [varchar](50) NULL,
	[ProductQty] [float] NULL,
	[waterQuantity] [float] NULL,
	[readingDate] [datetime] NULL,
	[recordBy] [varchar](50) NULL,
 CONSTRAINT [PK_Dipping] PRIMARY KEY CLUSTERED 
(
	[DippingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drivers](
	[driversID] [int] IDENTITY(1,1) NOT NULL,
	[fullName] [varchar](70) NULL,
	[address] [text] NULL,
	[phoneNumber] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[licenseIssueDate] [date] NULL,
	[driversLicenseExpDate] [date] NULL,
	[vehicle_id] [int] NULL,
 CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED 
(
	[driversID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[faadmenu]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[faadmenu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[menuid] [int] NOT NULL,
	[link] [varchar](50) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[parentid] [int] NOT NULL,
	[installed] [int] NOT NULL,
	[enabled] [int] NOT NULL,
 CONSTRAINT [PK_faadmenu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[job_cycle]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[job_cycle](
	[id] [int] NOT NULL,
	[job_no] [nvarchar](max) NOT NULL,
	[volume_b4_lift] [nvarchar](50) NOT NULL,
	[volume_after_lift] [nvarchar](50) NOT NULL,
	[actual_volume_lift] [nvarchar](50) NOT NULL,
	[empty_tank] [nvarchar](50) NOT NULL,
	[customer_id] [nvarchar](50) NOT NULL,
	[product_id] [nvarchar](50) NOT NULL,
	[total_price] [nvarchar](50) NOT NULL,
	[job_status] [nvarchar](50) NOT NULL,
	[lift_date] [nvarchar](50) NOT NULL,
	[vehicle_no] [nvarchar](50) NOT NULL,
	[satff_id] [nvarchar](50) NOT NULL,
	[tank_id] [nvarchar](50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderTbl]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderTbl](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customerName] [nvarchar](50) NULL,
	[product] [nvarchar](50) NULL,
	[orderby] [nvarchar](50) NULL,
	[quantity] [nvarchar](50) NULL,
	[date] [datetime] NULL,
	[orderNumber] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permit]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permit](
	[permidid] [int] IDENTITY(1,1) NOT NULL,
	[DriverNAme] [varchar](50) NULL,
	[truckLiscencePlate] [varchar](50) NULL,
	[staffID] [int] NULL,
	[truckCapacity] [float] NULL,
	[statusOfTruck] [text] NULL,
	[authorizedBy] [int] NULL,
	[transactionDate] [date] NULL,
	[poNumber] [varchar](50) NULL,
	[authorizedDate] [datetime] NULL,
	[computerName] [varchar](50) NULL,
	[permitType] [varchar](50) NULL,
 CONSTRAINT [PK_Permit] PRIMARY KEY CLUSTERED 
(
	[permidid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[product]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[product_type] [varchar](50) NULL,
	[productName] [varchar](50) NULL,
	[unitPrice] [float] NULL,
	[createdDate] [date] NULL,
	[dateModified] [date] NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[purchaseOrder]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchaseOrder](
	[pi_id] [int] IDENTITY(1,1) NOT NULL,
	[po_number] [varchar](50) NOT NULL,
	[customerID] [varchar](10) NOT NULL,
	[salesRep] [int] NOT NULL,
	[deliveryAddress] [text] NOT NULL,
	[remarks] [text] NOT NULL,
	[computerName] [varchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[poDate] [datetime] NOT NULL,
	[costCenterID] [varchar](50) NULL,
	[total_amount] [float] NULL,
	[statusCode] [nchar](10) NULL,
	[status] [varchar](50) NULL,
	[statusCode2] [char](10) NULL,
	[invoiceNo] [varchar](50) NULL,
	[closedBy] [int] NULL,
	[invoiceDate] [date] NULL,
	[closedDate] [datetime] NULL,
	[QuotationID] [varchar](50) NULL,
	[vat] [float] NULL,
	[witholding] [float] NULL,
	[NCD] [float] NULL,
	[Qty] [float] NULL,
	[uprice] [float] NULL,
	[product_ID] [int] NULL,
	[subTotal] [float] NULL,
	[quoteNo] [varchar](50) NULL,
 CONSTRAINT [PK_purchaseOrder] PRIMARY KEY CLUSTERED 
(
	[po_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[quotation]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[quotation](
	[pi_id] [int] IDENTITY(1,1) NOT NULL,
	[quoteNo] [varchar](50) NOT NULL,
	[customerID] [varchar](10) NOT NULL,
	[remarks] [text] NOT NULL,
	[computerName] [varchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[costCenterID] [varchar](50) NULL,
	[total_amount] [float] NULL,
	[statusCode] [nchar](10) NULL,
	[status] [varchar](50) NULL,
	[statusCode2] [char](10) NULL,
	[qtDate] [datetime] NOT NULL,
	[vat] [float] NULL,
	[witholding] [float] NULL,
	[ncd] [float] NULL,
 CONSTRAINT [PK_quotation] PRIMARY KEY CLUSTERED 
(
	[quoteNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[quotationDetails]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[quotationDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[quoteNo] [varchar](50) NOT NULL,
	[product_id] [int] NULL,
	[amount_ltr] [float] NULL,
	[quantity] [float] NULL,
	[statusCode] [nchar](10) NULL,
	[status] [varchar](50) NULL,
	[statusCode2] [char](10) NULL,
	[qtDate] [datetime] NOT NULL,
	[vat] [float] NULL,
	[witholding] [float] NULL,
	[NCD] [float] NULL,
	[total_amount] [float] NULL,
 CONSTRAINT [PK_quotationDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[releaseNote]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[releaseNote](
	[realeaseID] [int] IDENTITY(1,1) NOT NULL,
	[po] [varchar](50) NULL,
	[customerID] [varchar](10) NULL,
	[salesRep] [varchar](50) NULL,
	[productDensity] [float] NULL,
	[vehicle_id] [int] NULL,
	[relDate] [datetime] NULL,
	[tanks_id] [int] NULL,
	[atlID] [int] NULL,
	[totalizerReading] [float] NULL,
	[dippingChart] [float] NULL,
	[variance] [float] NULL,
	[quntityLoaded] [float] NULL,
	[comment] [text] NULL,
	[staff_id] [int] NULL,
 CONSTRAINT [PK_releaseNote] PRIMARY KEY CLUSTERED 
(
	[realeaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[requisition]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[requisition](
	[ri_id] [int] IDENTITY(1,1) NOT NULL,
	[req_number] [varchar](50) NOT NULL,
	[vendorID] [varchar](10) NOT NULL,
	[salesRep] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[Qty] [float] NOT NULL,
	[amount_ltr] [float] NOT NULL,
	[deliveryAddress] [text] NOT NULL,
	[remarks] [text] NOT NULL,
	[computerName] [varchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[reqDate] [datetime] NOT NULL,
	[costCenterID] [varchar](50) NULL,
	[total_amount] [float] NULL,
 CONSTRAINT [PK_req] PRIMARY KEY CLUSTERED 
(
	[req_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[staff]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[staff](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[staff_type] [varchar](50) NOT NULL,
	[staff_name] [varchar](50) NOT NULL,
	[staff_address] [text] NOT NULL,
	[staff_email] [varchar](50) NULL,
	[staff_phone] [varchar](50) NOT NULL,
	[staff_password] [varchar](50) NOT NULL,
	[dateadded] [datetime] NULL,
	[status] [varchar](50) NULL,
	[accesscontrol] [int] NOT NULL,
 CONSTRAINT [PK_staff] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StaffId] [nchar](10) NULL,
	[fname] [nvarchar](50) NULL,
	[lname] [nvarchar](50) NULL,
	[dname] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](max) NULL,
	[userlevel] [nvarchar](50) NULL,
	[status] [nvarchar](50) NULL,
	[Position] [nvarchar](50) NULL,
	[date] [date] NULL,
	[email] [nvarchar](50) NULL,
	[address] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stocks]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stocks](
	[stockid] [int] IDENTITY(1,1) NOT NULL,
	[tankid] [int] NULL,
	[producttype] [text] NULL,
	[Quantity] [float] NULL,
	[po_req] [varchar](50) NULL,
	[stock_status] [nchar](10) NULL,
	[stock_date] [datetime] NULL,
	[recordedBy] [varchar](50) NULL,
 CONSTRAINT [PK_stocks] PRIMARY KEY CLUSTERED 
(
	[stockid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[suppliers]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[suppliers](
	[supplier_id] [int] NOT NULL,
	[product_id] [nvarchar](50) NOT NULL,
	[date_supplied] [nvarchar](50) NOT NULL,
	[quantity] [nvarchar](50) NOT NULL,
	[supplied_by] [nvarchar](50) NOT NULL,
	[supply_price] [nvarchar](50) NOT NULL,
	[dateSupplied] [date] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tank]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tank](
	[tanks_id] [int] IDENTITY(1,1) NOT NULL,
	[product_type] [nvarchar](50) NOT NULL,
	[capacity] [nvarchar](50) NOT NULL,
	[volume_in_tank] [nvarchar](50) NULL,
	[date] [date] NULL,
	[tankName] [nvarchar](50) NOT NULL,
	[costCenter] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tank] PRIMARY KEY CLUSTERED 
(
	[tanks_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tanks]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tanks](
	[tankid] [int] IDENTITY(1,1) NOT NULL,
	[tankName] [varchar](50) NULL,
	[capacity] [float] NULL,
	[productType] [text] NULL,
 CONSTRAINT [PK_tanks] PRIMARY KEY CLUSTERED 
(
	[tankid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[vehicle]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehicle](
	[vehicle_id] [int] NOT NULL,
	[vehicle_number] [nvarchar](50) NOT NULL,
	[vehicle_capacity] [nvarchar](50) NOT NULL,
	[description] [text] NULL,
	[dateOfPurchase] [date] NULL,
	[amount] [float] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[vehicleAccount]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehicleAccount](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[vehicle_id] [int] NULL,
	[facility] [varchar](100) NULL,
	[Description] [text] NULL,
	[last_facility_date] [date] NULL,
	[next_facility_date] [date] NULL,
	[entryDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendor](
	[vendorID] [varchar](10) NOT NULL,
	[vendorName] [varchar](50) NULL,
	[companyName] [varchar](50) NULL,
	[address] [text] NULL,
	[city] [varchar](50) NULL,
	[state] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[emailID] [varchar](50) NULL,
	[dateCreated] [timestamp] NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[vendorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[watertest]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[watertest](
	[testID] [int] IDENTITY(1,1) NOT NULL,
	[permitID] [int] NULL,
	[po_Req_number] [varchar](50) NULL,
	[testChecklist] [text] NULL,
	[checklistSatus] [char](10) NULL,
	[testType] [varchar](50) NULL,
	[testedBy] [int] NULL,
	[testDate] [date] NULL,
	[createdDate] [datetime] NULL,
	[createdBy] [varchar](50) NULL,
 CONSTRAINT [PK_waterTest] PRIMARY KEY CLUSTERED 
(
	[testID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[vwPO]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwPO]
AS
SELECT        p.po_number, p.po_number + ' - ' + c.companyName + ' [' + CONVERT(varchar, p.poDate) + ']' AS poCompany, p.customerID, c.companyName, p.salesRep, s.staff_name, pr.productName, p.deliveryAddress, p.remarks, 
                         p.total_amount, p.statusCode, p.status, p.costCenterID, cs.CostCenter, p.poDate, s.id, pr.product_id AS Expr1, p.AGO_ID, p.AGO_Qty, p.AGO_uprice, p.DPK_ID, p.DPK_Qty, p.DPK_uprice, p.PMS_ID, p.PMS_Qty, p.PMS_uprice, 
                         p.subTotal, p.quoteNo
FROM            dbo.purchaseOrder AS p CROSS JOIN
                         dbo.customers AS c CROSS JOIN
                         dbo.staff AS s CROSS JOIN
                         dbo.product AS pr CROSS JOIN
                         dbo.costCenter AS cs

GO
/****** Object:  View [dbo].[vwQuotation]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwQuotation]
AS
SELECT        dbo.quotationDetails.quoteNo, dbo.quotation.customerID AS CustomerID, dbo.customers.customer_name, dbo.quotation.costCenterID, dbo.quotationDetails.product_id, dbo.product.productName, dbo.quotationDetails.amount_ltr, 
                         dbo.quotationDetails.quantity, dbo.quotationDetails.vat, dbo.quotationDetails.witholding, dbo.quotationDetails.NCD, dbo.quotationDetails.total_amount, dbo.quotation.qtDate
FROM            dbo.quotation INNER JOIN
                         dbo.quotationDetails ON dbo.quotation.quoteNo = dbo.quotationDetails.quoteNo INNER JOIN
                         dbo.product ON dbo.quotationDetails.product_id = dbo.product.product_id INNER JOIN
                         dbo.customers ON dbo.quotation.customerID = dbo.customers.customer_id

GO
SET IDENTITY_INSERT [dbo].[ATL] ON 

INSERT [dbo].[ATL] ([atlID], [po], [customerID], [salesRep], [productDensity], [atlDate], [tanks_id], [staff_id], [vehicleNumber], [comments]) VALUES (10, N'P44510359', N'975228', 9, 0, CAST(N'2019-08-04T15:57:29.470' AS DateTime), 1, 2, N'011', N'test remark')
INSERT [dbo].[ATL] ([atlID], [po], [customerID], [salesRep], [productDensity], [atlDate], [tanks_id], [staff_id], [vehicleNumber], [comments]) VALUES (11, N'P44510359', N'975228', 9, 0, CAST(N'2019-08-04T15:57:30.043' AS DateTime), 1, 2, N'011', N'test remark')
INSERT [dbo].[ATL] ([atlID], [po], [customerID], [salesRep], [productDensity], [atlDate], [tanks_id], [staff_id], [vehicleNumber], [comments]) VALUES (12, N'P44510359', N'975228', 9, 0, CAST(N'2019-08-05T06:08:12.660' AS DateTime), 1, 2, N'011', N'ggggg')
INSERT [dbo].[ATL] ([atlID], [po], [customerID], [salesRep], [productDensity], [atlDate], [tanks_id], [staff_id], [vehicleNumber], [comments]) VALUES (13, N'P44510359', N'975228', 9, 0, CAST(N'2019-08-05T06:08:13.330' AS DateTime), 1, 2, N'011', N'ggggg')
SET IDENTITY_INSERT [dbo].[ATL] OFF
SET IDENTITY_INSERT [dbo].[costCenter] ON 

INSERT [dbo].[costCenter] ([id], [CostCenterID], [CostCenter], [adress], [contactPhone], [emailAddress], [state], [lga], [logo]) VALUES (1, N'0123456', N'FAAD', N'GRA PHC', N'08035529398', N'jonathan@faad.com', N'rivers', N'phc', N'faad-logo.png')
INSERT [dbo].[costCenter] ([id], [CostCenterID], [CostCenter], [adress], [contactPhone], [emailAddress], [state], [lga], [logo]) VALUES (2, N'87362', N'Jojja', N'No. 10 Onwuchekwa Avenue
Elelenwo', N'08035529398', N'ogechi.ataisi@gmail.com', N'Rivers', N'Port Harcourt', NULL)
INSERT [dbo].[costCenter] ([id], [CostCenterID], [CostCenter], [adress], [contactPhone], [emailAddress], [state], [lga], [logo]) VALUES (3, N'94959', N'Dex online', N'No. 10 Onwuchekwa Avenue
Elelenwo', N'08037607280', N'ogechi.ataisi@gmail.com', N'Rivers', N'Port Harcourt', NULL)
INSERT [dbo].[costCenter] ([id], [CostCenterID], [CostCenter], [adress], [contactPhone], [emailAddress], [state], [lga], [logo]) VALUES (4, N'87160', N'Heiress', N'1 stanley wogu street, off st. michael by chinda,', N'08037607280', N'ogechi.ataisi@gmail.com', N'None (International)', N'portharcourt', NULL)
SET IDENTITY_INSERT [dbo].[costCenter] OFF
INSERT [dbo].[Customer] ([customerID], [customerName], [companyName], [address], [city], [state], [phone], [emailID]) VALUES (N'100100', N'Atinu Jason', N'NDPR', N'44 East west road', N'Portharcourt', N'Rivers', N'08035529398', N'jottaisi@yahoo.com')
SET IDENTITY_INSERT [dbo].[customers] ON 

INSERT [dbo].[customers] ([id], [customer_id], [customer_name], [address], [email], [password], [date_created], [companyName], [phone]) VALUES (1008, N'58784', N'Ogechi Ataisi', N'No. 10 Onwuchekwa Avenue
Elelenwo', N'ogechi.ataisi@gmail.com', N'123456', CAST(N'2019-09-08T17:24:09.277' AS DateTime), N'NDPR', N'8037607280')
INSERT [dbo].[customers] ([id], [customer_id], [customer_name], [address], [email], [password], [date_created], [companyName], [phone]) VALUES (1015, N'57972', N'jason Ataisi', N'No. 10 Onwuchekwa Avenue
Elelenwo', N'jonathan.ataisi@gmail.com', N'123456', CAST(N'2019-09-19T15:52:29.767' AS DateTime), N'NDWestern', N'8037607280')
SET IDENTITY_INSERT [dbo].[customers] OFF
INSERT [dbo].[job_cycle] ([id], [job_no], [volume_b4_lift], [volume_after_lift], [actual_volume_lift], [empty_tank], [customer_id], [product_id], [total_price], [job_status], [lift_date], [vehicle_no], [satff_id], [tank_id]) VALUES (0, N'63a18248', N'1', N'2', N'52', N'232', N'Peter Obi', N'Fuel', N'9000', N'Recieved', N'2019-02-01', N'011', N'0', N'1')
INSERT [dbo].[job_cycle] ([id], [job_no], [volume_b4_lift], [volume_after_lift], [actual_volume_lift], [empty_tank], [customer_id], [product_id], [total_price], [job_status], [lift_date], [vehicle_no], [satff_id], [tank_id]) VALUES (0, N'e25691a', N'1', N'2', N'52', N'232', N'Peter Obi', N'Fuel', N'9000', N'Recieved', N'2019-02-01', N'011', N'Ojukwu', N'1')
SET IDENTITY_INSERT [dbo].[OrderTbl] ON 

INSERT [dbo].[OrderTbl] ([id], [customerName], [product], [orderby], [quantity], [date], [orderNumber]) VALUES (1, N'Restopoint oil', N'PMS', N'paul@gmail.com', N'10000', CAST(N'2019-04-04T16:17:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[OrderTbl] OFF
SET IDENTITY_INSERT [dbo].[product] ON 

INSERT [dbo].[product] ([product_id], [product_type], [productName], [unitPrice], [createdDate], [dateModified]) VALUES (1, N'PMS', N'PMS', 145, NULL, NULL)
INSERT [dbo].[product] ([product_id], [product_type], [productName], [unitPrice], [createdDate], [dateModified]) VALUES (2, N'AGO', N'AGO', 200, NULL, NULL)
INSERT [dbo].[product] ([product_id], [product_type], [productName], [unitPrice], [createdDate], [dateModified]) VALUES (3, N'DPK', N'DPK', 200, NULL, NULL)
SET IDENTITY_INSERT [dbo].[product] OFF
SET IDENTITY_INSERT [dbo].[purchaseOrder] ON 

INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (54, N'P16391505', N'975228', 9, N'text address', N'just reemark', N'172.27.93.225', N'koko.otu-efa@faad-ng.com', CAST(N'2019-09-04T09:08:59.787' AS DateTime), N'0123456', 101000, N'AA        ', N'Awaiting Approval', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1000, 100, 2, NULL, NULL)
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (56, N'P18257400', N'975228', 9, N'text address', N'just reemark', N'172.27.93.225', N'koko.otu-efa@faad-ng.com', CAST(N'2019-09-04T09:11:20.830' AS DateTime), N'0123456', 101000, N'AA        ', N'Awaiting Approval', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1000, 100, 2, NULL, NULL)
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (60, N'P24131565', N'975228', -1, N'58  nnbjn', N'jhfyhj nggh', N'172.27.93.225', N'koko.otu-efa@faad-ng.com', CAST(N'2019-09-04T09:33:55.503' AS DateTime), N'0123456', 424000, N'AA        ', N'Awaiting Approval', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4000, 100, 2, NULL, N'Q67085267,2')
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (61, N'P37791912', N'975228', 9, N'testings', N'test rmks', N'172.27.93.225', N'koko.otu-efa@faad-ng.com', CAST(N'2019-09-05T20:34:57.627' AS DateTime), N'0123456', 303000, N'AA        ', N'Awaiting Approval', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3000, 100, 2, NULL, N'Q67085267')
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (58, N'P38692556', N'975228', 9, N'25 jjj', N'kjhh', N'172.27.93.225', N'koko.otu-efa@faad-ng.com', CAST(N'2019-09-04T09:12:48.237' AS DateTime), N'0123456', 424000, N'AA        ', N'Awaiting Approval', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4000, 100, 2, NULL, NULL)
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (48, N'P44510359', N'975228', 9, N'Odili Road, PHC ', N'', N'172.27.93.225', N'koko@faad.com', CAST(N'2019-07-27T16:07:10.343' AS DateTime), N'0123456', 39538, N'RELC      ', N'Release Noted Created', NULL, NULL, NULL, NULL, NULL, NULL, 0, 39165, 373, 120, 190, 1, 39538, N'Q32259832')
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (62, N'P51660980', N'975228', 9, N'testings', N'test rmks', N'172.27.93.225', N'koko.otu-efa@faad-ng.com', CAST(N'2019-09-05T20:35:49.680' AS DateTime), N'0123456', 303000, N'AA        ', N'Awaiting Approval', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3000, 100, 2, NULL, N'Q67085267')
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (59, N'P62699974', N'975228', -1, N'58  nnbjn', N'jhfyhj nggh', N'172.27.93.225', N'koko.otu-efa@faad-ng.com', CAST(N'2019-09-04T09:33:55.030' AS DateTime), N'0123456', 424000, N'AA        ', N'Awaiting Approval', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4000, 100, 2, NULL, N'Q67085267,2')
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (63, N'P6586', N'58784', 9, N'Some Address ', N'test', N'172.27.93.225', N'koko.otu-efa@faad-ng.com', CAST(N'2019-11-03T16:22:51.247' AS DateTime), N'0123456', 53318, N'RELC      ', N'Release Note Created', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 503, 100, 2, NULL, N'Q/Ogec/28/10/19/5531')
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (52, N'P67157387', N'975228', 9, N'test add', N'', N'172.27.93.225', N'andy.osakwe@faad-ng.com', CAST(N'2019-08-03T13:17:53.680' AS DateTime), N'0123456', 52920000, N'ATL       ', N'Approve This Purchase Order', NULL, NULL, NULL, NULL, NULL, NULL, 0, 52920000, 0, 8400, 6000, 1, 52920000, N'Q11051642')
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (50, N'P73421036', N'975228', 9, N'test address', N'test remark', N'172.27.93.225', N'koko@faad.com', CAST(N'2019-07-29T09:55:58.310' AS DateTime), N'0123456', 2120, N'AA        ', N'Awaiting Account Approval', NULL, NULL, NULL, NULL, NULL, NULL, 0, 100, 20, 100, 10, 0, 2000, N'Q49130522')
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (44, N'P85091248', N'975228', 9, N'test aaddress', N'remark', N'172.27.93.225', N'koko@faad.com', CAST(N'2019-06-29T20:21:54.987' AS DateTime), N'0123456', 1960364, N'AA        ', N'Awaiting Account Approval', NULL, NULL, NULL, NULL, NULL, NULL, 0, 92470, 18494, 5622, 200, 1, 1849400, NULL)
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (57, N'P85603073', N'975228', 9, N'25 jjj', N'kjhh', N'172.27.93.225', N'koko.otu-efa@faad-ng.com', CAST(N'2019-09-04T09:12:47.703' AS DateTime), N'0123456', 424000, N'AA        ', N'Awaiting Approval', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4000, 100, 2, NULL, NULL)
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (53, N'P86296525', N'975228', -1, N'test add', N'test remarks Ella', N'172.27.93.225', N'koko.otu-efa@faad-ng.com', CAST(N'2019-08-03T13:11:23.400' AS DateTime), N'0123456', 52920000, N'AA        ', N'Awaiting Account Approval', NULL, NULL, NULL, NULL, NULL, NULL, 0, 2520000, 0, 8400, 6000, 0, 50400000, N'Q11051642')
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (55, N'P87189769', N'975228', 9, N'text address', N'just reemark', N'172.27.93.225', N'koko.otu-efa@faad-ng.com', CAST(N'2019-09-04T09:09:44.233' AS DateTime), N'0123456', 101000, N'AA        ', N'Awaiting Approval', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1000, 100, 2, NULL, NULL)
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (51, N'P92560175', N'975228', 9, N'test address', N'test remark', N'172.27.93.225', N'koko@faad.com', CAST(N'2019-07-29T09:55:58.793' AS DateTime), N'0123456', 2120, N'AA        ', N'Awaiting Account Approval', NULL, NULL, NULL, NULL, NULL, NULL, 0, 100, 20, 100, 10, 0, 2000, N'Q49130522')
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (49, N'P95064507', N'975228', 9, N'Odili Road, PHC', N'Drop Ago At Odili Road', N'172.27.93.225', N'koko@faad.com', CAST(N'2019-06-30T10:40:25.987' AS DateTime), N'0123456', 39538, N'AA        ', N'Awaiting Account Approval', NULL, NULL, NULL, NULL, NULL, NULL, 0, 1865, 373, 120, 190, 1, 37300, N'Q32259832')
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (43, N'PO33564872', N'897640', 9, N'del add phc', N'remk', N'172.27.93.225', N'koko@faad.com', CAST(N'2019-05-29T17:49:56.287' AS DateTime), N'0123456', 28066500, N'A         ', N'Approved', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (40, N'PO64729512', N'975228', 9, N'test delivery address', N'test remark', N'172.27.93.225', N'koko@faad.com', CAST(N'2019-05-29T07:51:53.193' AS DateTime), N'0123456', 6756750, N'A         ', N'Awaiting GM''s Approval', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (41, N'PO69142825', N'975228', 9, N'test delivery address', N'test remark', N'172.27.93.225', N'koko@faad.com', CAST(N'2019-05-29T07:51:53.400' AS DateTime), N'0123456', 6756750, N'ATL       ', N'ATL Created', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[purchaseOrder] ([pi_id], [po_number], [customerID], [salesRep], [deliveryAddress], [remarks], [computerName], [username], [poDate], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [invoiceNo], [closedBy], [invoiceDate], [closedDate], [QuotationID], [vat], [witholding], [NCD], [Qty], [uprice], [product_ID], [subTotal], [quoteNo]) VALUES (42, N'PO85286594', N'897640', 9, N'del add phc', N'remk', N'172.27.93.225', N'koko@faad.com', CAST(N'2019-05-29T17:49:55.663' AS DateTime), N'0123456', 28066500, N'A         ', N'Awaiting Approval', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[purchaseOrder] OFF
SET IDENTITY_INSERT [dbo].[quotation] ON 

INSERT [dbo].[quotation] ([pi_id], [quoteNo], [customerID], [remarks], [computerName], [username], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [qtDate], [vat], [witholding], [ncd]) VALUES (1026, N'Q/Ogec/08/09/19/7771', N'78028', N'test remark', N'172.27.93.225', N'koko.otu-efa@faad-ng.com', N'0123456', 525000, NULL, N'Qt', NULL, CAST(N'2019-09-08T14:37:19.110' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[quotation] ([pi_id], [quoteNo], [customerID], [remarks], [computerName], [username], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [qtDate], [vat], [witholding], [ncd]) VALUES (1027, N'Q/Ogec/20/09/19/1019', N'58784', N'test remark', N'172.27.93.225', N'koko.otu-efa@faad-ng.com', N'0123456', 525000, NULL, N'Qt', NULL, CAST(N'2019-09-20T18:01:11.420' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[quotation] ([pi_id], [quoteNo], [customerID], [remarks], [computerName], [username], [costCenterID], [total_amount], [statusCode], [status], [statusCode2], [qtDate], [vat], [witholding], [ncd]) VALUES (1028, N'Q/Ogec/28/10/19/5531', N'58784', N'43', N'172.27.93.225', N'koko.otu-efa@faad-ng.com', N'0123456', 535474.8, NULL, N'Qt', NULL, CAST(N'2019-10-28T10:36:41.040' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[quotation] OFF
SET IDENTITY_INSERT [dbo].[quotationDetails] ON 

INSERT [dbo].[quotationDetails] ([id], [quoteNo], [product_id], [amount_ltr], [quantity], [statusCode], [status], [statusCode2], [qtDate], [vat], [witholding], [NCD], [total_amount]) VALUES (1033, N'Q/Ogec/08/09/19/7771', 2, 100, 5000, NULL, N'Qt', NULL, CAST(N'2019-09-08T14:37:19.147' AS DateTime), 0, 0, 0, 525000)
INSERT [dbo].[quotationDetails] ([id], [quoteNo], [product_id], [amount_ltr], [quantity], [statusCode], [status], [statusCode2], [qtDate], [vat], [witholding], [NCD], [total_amount]) VALUES (1034, N'Q/Ogec/20/09/19/1019', 2, 100, 5000, NULL, N'Qt', NULL, CAST(N'2019-09-20T18:01:11.517' AS DateTime), 0, 0, 0, 525000)
INSERT [dbo].[quotationDetails] ([id], [quoteNo], [product_id], [amount_ltr], [quantity], [statusCode], [status], [statusCode2], [qtDate], [vat], [witholding], [NCD], [total_amount]) VALUES (1035, N'Q/Ogec/28/10/19/5531', 2, 100, 4497, NULL, N'Qt', NULL, CAST(N'2019-10-28T10:36:41.077' AS DateTime), 0, 0, 0, 525000)
INSERT [dbo].[quotationDetails] ([id], [quoteNo], [product_id], [amount_ltr], [quantity], [statusCode], [status], [statusCode2], [qtDate], [vat], [witholding], [NCD], [total_amount]) VALUES (1036, N'Q/Ogec/28/10/19/5531', 3, 232, 43, NULL, N'Qt', NULL, CAST(N'2019-10-28T10:36:41.087' AS DateTime), 0, 0, 0, 10474.8)
SET IDENTITY_INSERT [dbo].[quotationDetails] OFF
SET IDENTITY_INSERT [dbo].[staff] ON 

INSERT [dbo].[staff] ([id], [staff_type], [staff_name], [staff_address], [staff_email], [staff_phone], [staff_password], [dateadded], [status], [accesscontrol]) VALUES (1, N'Driver', N'Ikechukwu Ojukwu', N'phc', N'ojukwu@faad.com', N'12345678901', N'123456', CAST(N'2019-05-27T00:00:00.000' AS DateTime), N'1', 1)
INSERT [dbo].[staff] ([id], [staff_type], [staff_name], [staff_address], [staff_email], [staff_phone], [staff_password], [dateadded], [status], [accesscontrol]) VALUES (8, N'Customer Care Rep', N'Christain Osaruchi', N'phc', N'customercare@faad-ng.com', N'23456789000', N'123456', CAST(N'2019-05-27T00:00:00.000' AS DateTime), N'0', 0)
INSERT [dbo].[staff] ([id], [staff_type], [staff_name], [staff_address], [staff_email], [staff_phone], [staff_password], [dateadded], [status], [accesscontrol]) VALUES (9, N'Marketer', N'Samuel Buddy', N'phc', N'sam@faad.com', N'12345678900', N'123456', CAST(N'2019-05-27T00:00:00.000' AS DateTime), N'3', 3)
INSERT [dbo].[staff] ([id], [staff_type], [staff_name], [staff_address], [staff_email], [staff_phone], [staff_password], [dateadded], [status], [accesscontrol]) VALUES (10, N'GM', N'Ms. Koko', N'phc', N'koko.otu-efa@faad-ng.com', N'12345678900', N'123456', CAST(N'2019-05-27T00:00:00.000' AS DateTime), N'4', 4)
INSERT [dbo].[staff] ([id], [staff_type], [staff_name], [staff_address], [staff_email], [staff_phone], [staff_password], [dateadded], [status], [accesscontrol]) VALUES (11, N'Accountant', N'Mr Andy', N'phc', N'andy.osakwe@faad-ng.com', N'12345678900', N'123456', CAST(N'2019-05-27T00:00:00.000' AS DateTime), N'5', 5)
INSERT [dbo].[staff] ([id], [staff_type], [staff_name], [staff_address], [staff_email], [staff_phone], [staff_password], [dateadded], [status], [accesscontrol]) VALUES (13, N'Admin Support', N'Sara Ik', N'phc', N'tpadminsupport@faad-ng.com', N'12345678900', N'123456', CAST(N'2019-05-27T00:00:00.000' AS DateTime), N'6', 6)
INSERT [dbo].[staff] ([id], [staff_type], [staff_name], [staff_address], [staff_email], [staff_phone], [staff_password], [dateadded], [status], [accesscontrol]) VALUES (14, N'Surveyor', N'Mr Jack', N'phc', N'surveyor@faad-ng.com', N'12345678900', N'123456', CAST(N'2019-05-27T00:00:00.000' AS DateTime), N'7', 7)
INSERT [dbo].[staff] ([id], [staff_type], [staff_name], [staff_address], [staff_email], [staff_phone], [staff_password], [dateadded], [status], [accesscontrol]) VALUES (15, N' Security ', N'John Doe', N'phc', N'security@faad-ng.com', N'12345678900', N'123456', CAST(N'2019-05-27T00:00:00.000' AS DateTime), N'8', 8)
INSERT [dbo].[staff] ([id], [staff_type], [staff_name], [staff_address], [staff_email], [staff_phone], [staff_password], [dateadded], [status], [accesscontrol]) VALUES (18, N'MD', N'Ms Kiki', N'phc', N'kiki.korubo@faad-ng.com', N'12345678900', N'123456', CAST(N'2019-05-27T00:00:00.000' AS DateTime), N'4', 4)
INSERT [dbo].[staff] ([id], [staff_type], [staff_name], [staff_address], [staff_email], [staff_phone], [staff_password], [dateadded], [status], [accesscontrol]) VALUES (19, N'Facility Manager', N'Mr Ifeanyi', N'phc', N'facility.administrator@faad-ng.com', N'12345678900', N'123456', CAST(N'2019-05-27T00:00:00.000' AS DateTime), N'7', 7)
INSERT [dbo].[staff] ([id], [staff_type], [staff_name], [staff_address], [staff_email], [staff_phone], [staff_password], [dateadded], [status], [accesscontrol]) VALUES (20, N'System Admin', N'Smart Esther', N'phc', N'smart@faad.com', N'12345678900', N'123456', CAST(N'2019-05-27T00:00:00.000' AS DateTime), N'9', 9)
SET IDENTITY_INSERT [dbo].[staff] OFF
SET IDENTITY_INSERT [dbo].[Staffs] ON 

INSERT [dbo].[Staffs] ([id], [StaffId], [fname], [lname], [dname], [phone], [username], [password], [userlevel], [status], [Position], [date], [email], [address]) VALUES (3, N'808388    ', N'okpako', N'james', N'james okpako', N'08162663152', N'okpako', N'124741419202559817597229149321486119410014824814827', N'2', N'1', N'Admintrator', CAST(N'2019-03-25' AS Date), N'esemudia@yahoo.com', NULL)
SET IDENTITY_INSERT [dbo].[Staffs] OFF
INSERT [dbo].[suppliers] ([supplier_id], [product_id], [date_supplied], [quantity], [supplied_by], [supply_price], [dateSupplied]) VALUES (1, N'Kerosine', N'2019-02-16', N'20', N'Jovick Limited', N'20000', NULL)
INSERT [dbo].[suppliers] ([supplier_id], [product_id], [date_supplied], [quantity], [supplied_by], [supply_price], [dateSupplied]) VALUES (479517, N'PMS', N'2019-03-30', N'400000', N'forte oil', N'93', CAST(N'2019-03-29' AS Date))
SET IDENTITY_INSERT [dbo].[tank] ON 

INSERT [dbo].[tank] ([tanks_id], [product_type], [capacity], [volume_in_tank], [date], [tankName], [costCenter]) VALUES (1, N'AGO', N'1000000', N'50000', CAST(N'2019-05-05' AS Date), N'Tank1', N'0123456')
SET IDENTITY_INSERT [dbo].[tank] OFF
INSERT [dbo].[vehicle] ([vehicle_id], [vehicle_number], [vehicle_capacity], [description], [dateOfPurchase], [amount]) VALUES (1, N'011', N'3000', NULL, NULL, NULL)
/****** Object:  Index [unq_ATL]    Script Date: 11/3/2019 6:51:14 PM ******/
ALTER TABLE [dbo].[ATL] ADD  CONSTRAINT [unq_ATL] UNIQUE NONCLUSTERED 
(
	[atlID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[accessControl]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[accessControl]  
   @in_uname nvarchar(50)
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT  accesscontrol AS accessControl, staff.staff_name,staff.staff_email, staff.staff_phone
      FROM staff
      WHERE staff.staff_email = @in_uname

   END


GO
/****** Object:  StoredProcedure [dbo].[ChangePassword]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangePassword]
   @password nvarchar(100),
   @email nvarchar(50)

AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 declare @dates NVARCHAR(20);
	 
	set @dates=dateadd(HOUR, 0, CURRENT_TIMESTAMP);
	
	update staff
	set staff_password=@password
	 where staff_email=@email	
   END
GO
/****** Object:  StoredProcedure [dbo].[existCustID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[existCustID]  
   @incustid nvarchar(50)
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT count_big(*) AS counts
      FROM customers
      WHERE customers.customer_id = @incustid

   END


GO
/****** Object:  StoredProcedure [dbo].[existCustName]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[existCustName]  
   @incompanyName nvarchar(50)
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT count_big(*) AS counts
      FROM customers
      WHERE companyName = @incompanyName

   END


GO
/****** Object:  StoredProcedure [dbo].[existCustName2]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[existCustName2]  
   @incompanyName nvarchar(50),
   @inemail nvarchar(50)
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT count_big(*) AS counts
      FROM customers
      WHERE companyName = @incompanyName and email=@inemail

   END


GO
/****** Object:  StoredProcedure [dbo].[existsAtl]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[existsAtl]  
   @po nvarchar(50)
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT count_big(*) AS counts
      FROM ATL
      WHERE po = @po

   END


GO
/****** Object:  StoredProcedure [dbo].[existsupid]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[existsupid]  
   @insupid nvarchar(50)
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT count_big(*) AS counts
      FROM suppliers
      WHERE suppliers.supplier_id = @insupid

   END


GO
/****** Object:  StoredProcedure [dbo].[existuser]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[existuser]  
   @in_uname nvarchar(50)
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT count_big(*) AS counts
      FROM staff
      WHERE staff.staff_email = @in_uname

   END


GO
/****** Object:  StoredProcedure [dbo].[existuserpwd]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[existuserpwd]  
   @in_uname nvarchar(11),
   @in_pwd nvarchar(100)
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT count_big(*) AS counts
      FROM staff
      WHERE staff.staff_email = @in_uname AND staff.staff_password = @in_pwd

   END

GO
/****** Object:  StoredProcedure [dbo].[getAllATL]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[getAllATL]

-- @ID nvarchar(6)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

	  SELECT atlid,po,customerid,salesrep,productdensity,atlDate,tanks_id,staff_id,vehicleNumber,comments
FROM
(SELECT ATL.*,
ROW_NUMBER() OVER (PARTITION BY po ORDER BY atlDate DESC) AS SN
FROM ATL) AS t
WHERE SN = 1
ORDER BY atlDate
    --  SELECT *
	 --  FROM ATL 
	   --where realeaseid = @id
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getAllCostCenters]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[getAllCostCenters]
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM costcenter
	 
   END


GO
/****** Object:  StoredProcedure [dbo].[getAllCustomer]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getAllCustomer]
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT customer_id, customer_name,companyName
	   FROM customers order by customer_name
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getAllCustomers]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[getAllCustomers]
AS 
   BEGIN
      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM customers order by customer_name
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getAllpo]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getAllpo]
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM purchaseOrder
	   order by poDate desc
	 
   END


GO
/****** Object:  StoredProcedure [dbo].[getAllProduct]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getAllProduct]
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM product order by productName
	 
   END


GO
/****** Object:  StoredProcedure [dbo].[getAllQuote]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getAllQuote]
	@in_costCenter nvarchar(20)
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM quotation
	   where costCenterID=@in_costCenter
	   and status='qt'
	   order by pi_id desc
	 
   END


GO
/****** Object:  StoredProcedure [dbo].[getAllQuoteByQN]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getAllQuoteByQN]

 @QuoteNo nvarchar(20)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM quotation 
	   where quoteNo  = @QuoteNo
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getAllQuoteDetails]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getAllQuoteDetails]

 @QuoteNo nvarchar(20)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM quotationDetails 
	   where quoteNo  = @QuoteNo
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getAllQuoteDetailsByID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getAllQuoteDetailsByID]

 @id nvarchar(20)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM quotationDetails 
	   where id  = @id
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getAllReleaseNote]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getAllReleaseNote]

-- @ID nvarchar(6)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM releaseNote 
	   --where realeaseid = @id
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getAllrequisiton]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[getAllrequisiton]
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM requisition
	 
   END


GO
/****** Object:  StoredProcedure [dbo].[getAllStaffs]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[getAllStaffs]
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON 
SELECT        *
FROM            dbo.staff
	 
   END


GO
/****** Object:  StoredProcedure [dbo].[getAllTank]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getAllTank]
	@in_cs nvarchar(10)
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON 
      SELECT  tanks_id,product_type,volume_in_tank,capacity,tankName,tankName+' (Type('+product_type+') Capacity('+capacity+') Avilable Qty('+volume_in_tank+')' as tankDesc
	   FROM tank
	   where costCenter=@in_cs
	 
   END


GO
/****** Object:  StoredProcedure [dbo].[getAllTrucks]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getAllTrucks]
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT vehicle_id,vehicle_number,vehicle_capacity, vehicle_number+' - Capacity ('+vehicle_capacity+')' as capacity,description,dateOfPurchase,amount
	   FROM vehicle
	 
   END


GO
/****** Object:  StoredProcedure [dbo].[getATLByID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getATLByID]

 @ID nvarchar(6)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM ATL 
	   where atlID = @id
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getATLByPO]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getATLByPO]

 @po nvarchar(20)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM ATL 
	   where po  = @po
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getATLPO_drop]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getATLPO_drop]
 @in_poNo nvarchar(20),
  @statusCode nvarchar(6)
AS 	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	    if @in_poNo = '' 
	   begin
   select po_number, (po_number+' ('+quoteNo+') -'+ (select companyName from customers where customer_id=customerID)+' '+CONVERT(nvarchar,poDate)) as drpPO ,
   quoteNo,customerID, (select companyName from customers where customer_id=customerID) as customer,
poDate, (select staff_name from staff where id=purchaseOrder.salesRep) as SalesRep,deliveryAddress,costCenterID,
total_amount,subTotal,status,statusCode,vat,witholding,NCD,product_ID,(select productName from product where product_id=purchaseOrder.product_ID) as productNAme,
uprice,qty,
quoteNo,costcenterid,(select costCenter from costCenter where CostCenterID=purchaseOrder.costcenterid) as costcenter
from purchaseOrder where statusCode = @statusCode
	end  
	  else if @statusCode <> '' and @in_poNo<>''
	  begin
 select po_number, (po_number+' ('+quoteNo+') -'+ (select companyName from customers where customer_id=customerID)+' '+CONVERT(nvarchar,poDate)) as drpPO ,
   quoteNo,customerID, (select companyName from customers where customer_id=customerID) as companyName,
poDate, salesRep,(select staff_name from staff where id=purchaseOrder.salesRep) as staff_name,deliveryAddress,costCenterID,
total_amount,subTotal,status,statusCode,vat,witholding,NCD,product_ID,(select productName from product where product_id=purchaseOrder.product_ID) as productNAme,
uprice,qty,
quoteNo,costcenterid,(select costCenter from costCenter where CostCenterID=purchaseOrder.costcenterid) as costcenter
from purchaseOrder where po_number=@in_poNo and statusCode = @statusCode
	  end
   END
GO
/****** Object:  StoredProcedure [dbo].[getCompanyName]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getCompanyName]

 @name nvarchar(50)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT companyName
	   FROM customers where customer_name = @name
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getCostCenterByID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[getCostCenterByID]

 @ID nvarchar(20)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM costcenter where CostCenterID = @id
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getCostCenterByID2]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getCostCenterByID2]

 @ID nvarchar(6)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM costcenter where ID = @id
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getCostCenterByName]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getCostCenterByName]

 @name nvarchar(50)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM costcenter where costcenter = @name
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getCustomerByID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[getCustomerByID]

 @ID nvarchar(50)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM customers where customer_ID = @ID
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getCustomerByQuoteID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getCustomerByQuoteID]

 @ID nvarchar(50)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM quotation where quoteNo = @ID
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getorder]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[getorder]
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT customerName as CustomerName, product as Product,quantity as Quantity ,orderby as ORDERBY
	   FROM OrderTbl
	 
   END


GO
/****** Object:  StoredProcedure [dbo].[getPO_number_statusByPonumber]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[getPO_number_statusByPonumber]

 @in_ID nvarchar(50)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

       select po_number,statuscode from purchaseOrder
   where pi_id = @in_ID
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getPOByID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getPOByID]

 @ID nvarchar(6)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM purchaseOrder where pi_id = @id
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getPoLike]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getPoLike]

 @po nvarchar(20)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT po_number
	   FROM purchaseOrder 
	  where statusCode='AGM' and po_number like '%'+@po
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getPos]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[getPos]
 @in_poNo nvarchar(20),
  @statusCode nvarchar(6)
AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

	   if @statusCode = '' and @in_poNo=''
	   begin
      SELECT * FROM vwpo 
	  end
	  else if @statusCode <> '' and @in_poNo<>''
	  begin
      SELECT * FROM vwpo 
	  where statusCode=@statusCode and po_number=@in_poNo
	  end
	  else if @statusCode <> '' and @in_poNo=''
	  begin
      SELECT * FROM vwpo 
	  where statusCode=@statusCode
	  end
	  else if @statusCode = '' and @in_poNo<>''
	  begin
      SELECT * FROM vwpo 
	  where po_number=@in_poNo
	  end
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getProductByID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getProductByID]

 @ID nvarchar(50)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM product where product_id = @ID
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getQtByQtNo]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getQtByQtNo]

 @quotation nvarchar(15)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM quotationDetails where quoteNo = @quotation
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getQtByQtNo1]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[getQtByQtNo1]

 @quotation nvarchar(30), @productID nvarchar(4)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM quotationDetails where quoteNo = @quotation and product_id=@productID
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getQuotationByID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getQuotationByID]

 @ID nvarchar(6)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM quotation where pi_id = @id
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getQuotationDetailsByID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[getQuotationDetailsByID]

 @ID nvarchar(30)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM vwQuotation where quoteNo = @id
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getQuotePO]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[getQuotePO]

 @costCenterID nvarchar(20)
AS 
   BEGIN
      SET  XACT_ABORT  ON
      SET  NOCOUNT  ON	  
select  distinct 
quoteno+' - ('+customer_name +' - '+productName+' - '+ CONVERT(varchar, qtdate, 25)+')' as quoteID,quoteno+','+
CONVERT(varchar, product_ID, 25) as quotationID, 
qtDate from vwQuotation
order by qtdate desc
						 	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getReleaseNoteByID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getReleaseNoteByID]

 @ID nvarchar(6)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM releaseNote where realeaseid = @id
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getRelPO_drop]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getRelPO_drop]
 @in_poNo nvarchar(20),
  @statusCode nvarchar(6)
AS 	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	    if @in_poNo = '' 
	   begin
   select po_number, (po_number+' ('+quoteNo+') -'+ (select companyName from customers where customer_id=customerID)+' '+CONVERT(nvarchar,poDate)) as drpPO ,
   quoteNo,customerID, (select companyName from customers where customer_id=customerID) as customer,
poDate, (select staff_name from staff where id=purchaseOrder.salesRep) as SalesRep,deliveryAddress,costCenterID,
total_amount,subTotal,status,statusCode,vat,witholding,NCD,product_ID,(select productName from product where product_id=purchaseOrder.product_ID) as productNAme,
uprice,qty,
quoteNo,costcenterid,(select costCenter from costCenter where CostCenterID=purchaseOrder.costcenterid) as costcenter
from purchaseOrder where statusCode = @statusCode order by podate desc
	end  
	  else if @statusCode <> '' and @in_poNo<>''
	  begin
 select po_number, (po_number+' ('+quoteNo+') -'+ (select companyName from customers where customer_id=customerID)+' '+CONVERT(nvarchar,poDate)) as drpPO ,
   quoteNo,customerID, (select companyName from customers where customer_id=customerID) as companyName,
poDate, salesRep,(select staff_name from staff where id=purchaseOrder.salesRep) as staff_name,deliveryAddress,costCenterID,
total_amount,subTotal,status,statusCode,vat,witholding,NCD,product_ID,(select productName from product where product_id=purchaseOrder.product_ID) as productNAme,
uprice,qty,
quoteNo,costcenterid,(select costCenter from costCenter where CostCenterID=purchaseOrder.costcenterid) as costcenter
from purchaseOrder where po_number=@in_poNo  order by podate desc
	  end
   END
GO
/****** Object:  StoredProcedure [dbo].[getRequisitionByID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getRequisitionByID]

 @ID nvarchar(6)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM requisition where ri_id = @id
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getStaffByID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[getStaffByID]

 @ID nvarchar(50)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM staff where id = @ID
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getStaffByType]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[getStaffByType]
	@in_stafftype nvarchar(20)
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON 
SELECT        *
FROM            dbo.staff
where staff_type=@in_stafftype
	 
   END


GO
/****** Object:  StoredProcedure [dbo].[getStaffLogin]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getStaffLogin]

 @emailID nvarchar(50),
 @pwd nvarchar(50)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM staff 
	   where 
	   staff_email = @emailID and staff_password=@pwd
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getTank]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getTank]

-- @ID nvarchar(6)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM tank 
	 --  where atlID = @id
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getTankByID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getTankByID]

 @ID nvarchar(6)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM tank 
	  where tanks_id = @id
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getTankByType]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[getTankByType]
 @cs nvarchar(20),
 @prodType nvarchar(20)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM tank 
	  where costCenter=@cs and product_type = @prodType
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getTankNameByID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[getTankNameByID]

 @ID nvarchar(6)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM tank 
	  where tanks_id = @id
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getTanksByCS]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getTanksByCS]

 @CS nvarchar(50)

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM tank 
	   where costCenter = @cs
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[getTanksByCSByID]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[getTanksByCSByID]

 @CS nvarchar(50),
 @ID int

AS 
	
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON

      SELECT *
	   FROM tank 
	   where costCenter = @cs
	   and tanks_id=@id
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[InsertAtl]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertAtl]

	@in_atlid nvarchar(10),
	@in_po_number nvarchar(50),	@in_customerID nvarchar(10),
	@in_salesRep int,	@in_product_dens float,
	@in_vehicle_id nvarchar(50),	@in_tank_id int,
	@in_comment nvarchar(500),	@in_staff_id int

AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 if @in_atlid=''
	 begin
	INSERT ATL(
          po,customerID, salesRep, productDensity,vehicleNumber,tanks_id,comments,staff_id,atlDate
		  )
         VALUES (
	@in_po_number,	@in_customerID,	@in_salesRep,
	@in_product_dens,	@in_vehicle_id,	@in_tank_id,
	@in_comment,@in_staff_id,getdate()
	)
	end
	else
	begin
	update ATL set 
	 productDensity=@in_product_dens,
	 vehicleNumber=@in_vehicle_id,
	atlDate=getdate()
	end
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[InsertCostCenter]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCostCenter]

	@in_CostCenterID nvarchar(50),
	@in_CostCenter nvarchar(50),
	@in_adress nvarchar(50),
	@in_contactPhone nvarchar(50),
	@in_emailAddress nvarchar(50),
	/****** @in_logo image, ******/
	@in_state nvarchar(50),
	@in_lga nvarchar(50)

AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	INSERT CostCenter(
         CostCenterID,CostCenter, adress, contactPhone,emailAddress,/******logo,******/state,lga)
         VALUES (
	@in_CostCenterID,
	@in_CostCenter,
	@in_adress,
	@in_contactPhone,
	@in_emailAddress,
	/******@in_logo,******/
	@in_state,
	@in_lga)
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCustomer]
	@in_savetype nvarchar(6),
	@in_custid nvarchar(6),
	@in_customername nvarchar(50),	@in_customerAdd nvarchar(100),
	@in_email nvarchar(50),	
	@in_companyName nvarchar(50),	@in_phone nvarchar(15)

AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 if @in_savetype='Update'
	begin
	update customers set 
	 customer_name=@in_customername,
	 address=@in_customerAdd,
	 email=@in_email,
	 companyName=@in_companyName,
	 phone=@in_phone
	 where email=@in_email
	end
	else
	 begin
	INSERT customers(
          customer_id,customer_name,address,email,password,companyName,phone,date_created
		  )
         VALUES (
	@in_custid,	@in_customername,	@in_customerAdd,
	@in_email,	'123456',	@in_companyName,
	@in_phone,getdate()
	)
	end
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[insertDailyStock]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[insertDailyStock]  

	@intankName nvarchar(30),
   @inproductName nvarchar(30),
   @inopening nvarchar(30),
   @inclosing nvarchar(50),
   @inlifted nvarchar(30)
	 
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	   declare @dates NVARCHAR(20);
	 
	set @dates=dateadd(HOUR, 0, CURRENT_TIMESTAMP);

      INSERT DailyStock(
         tankName,productName, openingStock, closingStock, LiftedStock,date)
         VALUES (
		
	@intankName,
   @inproductName,
   @inopening,
   @inclosing,
   @inlifted,
	@dates)
   END

GO
/****** Object:  StoredProcedure [dbo].[InsertOrderTbl]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertOrderTbl]

	@in_custname nvarchar(50),
	@in_product nvarchar(50),
	@in_comname nvarchar(50),
	@in_quantity nvarchar(50),
	@in_orderNumber nvarchar(50)

AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
      declare @dates NVARCHAR(20);
	 
	set @dates=dateadd(HOUR, 0, CURRENT_TIMESTAMP);
	INSERT OrderTbl(
         customerName,product, orderby, quantity,date,orderNumber)
         VALUES (
	@in_custname,
	@in_product,
	@in_comname,
	@in_quantity,
	@dates,
	@in_orderNumber)
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[InsertPO]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertPO]

	@in_po_number nvarchar(50),
	@in_customerID nvarchar(50),
	@in_salesRep int,
	@in_product_id int,
	@in_quantity float,
	@in_amount_ltr float,
	@in_total_amount float,
	@in_deliveryAddress nvarchar(200),
	@in_remark nvarchar(500),
	@in_computerName nvarchar(500),
	@in_userrName nvarchar(50),
	@in_costCID nvarchar(50),
	@in_quoteNo nvarchar(50)
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	INSERT purchaseOrder(
          po_number,customerID, salesRep, product_id,Qty,uprice,total_amount,deliveryAddress,remarks,computerName,
		 username,costCenterID,poDate,statusCode,status,quoteNo)
         VALUES (
	@in_po_number,
	@in_customerID,
	@in_salesRep,
	@in_product_id,
	@in_quantity,
	@in_amount_ltr,
	@in_total_amount,
	@in_deliveryAddress,
	@in_remark,
	@in_computerName,
	@in_userrName,
	@in_costCID,
	getdate(),
	'AA',
	'Awaiting Approval',
	@in_quoteNo
	)
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[InsertPONew]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertPONew]

	@in_po_number nvarchar(50),
	@in_customerID nvarchar(50),
	@in_salesRep int,
	@in_AGO_ID int,
	@in_AGO_Qty float,
	@in_AGO_uprice float,
	@in_DPK_ID int,
	@in_DPK_Qty float,
	@in_DPK_uprice float,
	@in_PMS_ID int,
	@in_PMS_Qty float,
	@in_PMS_uprice float,
	@in_vat float,
	@in_witholding float,
	@in_NCD float,
	@in_subTotal float,
	@in_total_amount float,
	@in_deliveryAddress nvarchar(200),
	@in_remark nvarchar(500),
	@in_computerName nvarchar(500),
	@in_userrName nvarchar(50),
	@in_costCID nvarchar(50),
	@in_quoteNo nvarchar(50)


AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	INSERT purchaseOrder(
          po_number,customerID, salesRep,AGO_ID,AGO_Qty,AGO_uprice,DPK_ID,DPK_Qty,DPK_uprice,PMS_ID,PMS_Qty,PMS_uprice,
		  vat,witholding,NCD,subTotal,total_amount,deliveryAddress,remarks,computerName,
		 username,costCenterID,poDate,statusCode,status,quoteNo)
         VALUES (
	@in_po_number,
	@in_customerID,
	@in_salesRep,
	@in_AGO_ID,
	@in_AGO_Qty,
	@in_AGO_uprice,
	@in_DPK_ID,
	@in_DPK_Qty,
	@in_DPK_uprice,
	@in_PMS_ID,
	@in_PMS_Qty,
	@in_PMS_uprice,
	@in_vat,
	@in_witholding,
	@in_NCD,
	@in_subTotal,
	@in_total_amount,
	@in_deliveryAddress,
	@in_remark,
	@in_computerName,
	@in_userrName,
	@in_costCID,
	getdate(),
	'AA',
	'Awaiting Account Approval',
	@in_quoteNo
	)
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[InsertQuote]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[InsertQuote]

	@in_QuoteNo nvarchar(50),
	@in_customerID nvarchar(50),
	@in_remark nvarchar(500),
	@in_computerName nvarchar(500),
	@in_userrName nvarchar(50),
	@in_costCID nvarchar(50),
	@in_total_amount float


AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	INSERT quotation(
          quoteNo,customerID, remarks,computerName, username,costCenterID,total_amount,status,qtDate)
         VALUES (
	@in_QuoteNo,
	@in_customerID,
	@in_remark,
	@in_computerName,
	@in_userrName,
	@in_costCID,
	@in_total_amount,
	'Qt',
	getdate()
	)
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[InsertQuoteDetails]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertQuoteDetails]

	@in_QuoteNo nvarchar(50),
	@in_product_id nvarchar(10),
	@in_amount_ltr float,
	@in_quantity float,
	@in_vat float,
	@in_witholding float,
	@in_NCD float,
	@in_total_amount float

AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	INSERT quotationDetails(
          quoteNo,product_id, amount_ltr,quantity, vat,witholding,NCD,total_amount,status,qtDate)
         VALUES (
	@in_QuoteNo,
	@in_product_id,
	@in_amount_ltr,
	@in_quantity,
	@in_vat,
	@in_witholding,
	@in_NCD,
	@in_total_amount,
	'Qt',
	getdate()
	)
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[InsertReleaseNote]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[InsertReleaseNote]

	@in_po_number nvarchar(50),	@in_customerID nvarchar(50),
	@in_salesRep int,	@in_product_dens float,
	@in_vehicle_id int,	@in_tank_id int,
	@in_atlID int,	@in_totalizer float,
	@in_dipping float,	@in_variance float,
	@in_quantity_loaded float,	@in_comment text,	@in_staff_id int

AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	INSERT releasenote(
          po,customerID, salesRep, productDensity,vehicle_id,tanks_id,atlID,totalizerReading,dippingChart,variance,
		 quntityLoaded,comment,staff_id,relDate)
         VALUES (
	@in_po_number,	@in_customerID,	@in_salesRep,
	@in_product_dens,	@in_vehicle_id,	@in_tank_id,
	@in_atlID,	@in_totalizer,	@in_dipping,
	@in_variance,	@in_quantity_loaded,	@in_comment,
	@in_staff_id,getdate()
	)
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[InsertRequisition]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[InsertRequisition]

	@in_req_number nvarchar(50),
	@in_vendorID nvarchar(50),
	@in_salesRep int,
	@in_product_id int,
	@in_quantity float,
	@in_amount_ltr float,
	@in_total_amount float,
	@in_deliveryAddress nvarchar(200),
	@in_remark nvarchar(500),
	@in_computerName nvarchar(500),
	@in_userrName nvarchar(50),
	@in_costCID nvarchar(50)


AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	INSERT requisition(
         req_number,vendorID, salesRep, product_id,Qty,amount_ltr,total_amount,deliveryAddress,remarks,computerName,
		 username,costCenterID,reqDate)
         VALUES (
	@in_req_number,
	@in_vendorID,
	@in_salesRep,
	@in_product_id,
	@in_quantity,
	@in_amount_ltr,
	@in_total_amount,
	@in_deliveryAddress,
	@in_remark,
	@in_computerName,
	@in_userrName,
	@in_costCID,
	getdate()
	)
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[insertstaff]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertstaff]
   @in_savetype nvarchar(10),
   @in_staff_type nvarchar(30),
   @in_staff_name nvarchar(50),
   @in_staff_phone nvarchar(50),
   @in_staff_password nvarchar(100),
   @in_staff_email nvarchar(50),
   @in_accesscontrol nvarchar (30),
   @in_status nvarchar(11),
   @in_staff_address nvarchar(max)

AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 declare @dates NVARCHAR(20);
	 
	set @dates=dateadd(HOUR, 0, CURRENT_TIMESTAMP);
	
	 if @in_savetype='Update'
	begin
	update staff
	set staff_type=@in_staff_type,
	 staff_name=@in_staff_name,
	 staff_phone=@in_staff_phone, 
	 staff_address=@in_staff_address
	 where staff_email=@in_staff_email
	end
	else
	begin
      INSERT staff(
         staff_type, staff_name, staff_phone, staff_password, staff_email, accesscontrol,status, staff_address)
         VALUES (
   @in_staff_type, 
   @in_staff_name, 
   @in_staff_phone, 
   @in_staff_password, 
   @in_staff_email,
   @in_accesscontrol,
   @in_status,
   @in_staff_address)
   end
   END
GO
/****** Object:  StoredProcedure [dbo].[insertSupply]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[insertSupply]  

	@in_supid nvarchar(30),
   @in_prod nvarchar(30),
   @in_datesup nvarchar(30),
   @in_quantity nvarchar(50),
   @in_supby nvarchar(30),
    @in_price nvarchar(30)
	 
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	   declare @dates NVARCHAR(20);
	 
	set @dates=dateadd(HOUR, 0, CURRENT_TIMESTAMP);

      INSERT suppliers(
         supplier_id,product_id, date_supplied, quantity, supplied_by,supply_price,dateSupplied)
         VALUES (
		
	@in_supid,
   @in_prod,
   @in_datesup,
   @in_quantity,
   @in_supby,
    @in_price,
	@dates
			)
   END


GO
/****** Object:  StoredProcedure [dbo].[RegisterCustomer]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegisterCustomer]  

	@in_Customerid nvarchar(30),
   @in_CompanyName nvarchar(30),
   @in_customer_name nvarchar(30),
   @in_address nvarchar(50),
   @in_email nvarchar(30),
    @in_password nvarchar(max),
	 @in_phone nvarchar(30)
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	   declare @dates NVARCHAR(20);
	 
	set @dates=dateadd(HOUR, 0, CURRENT_TIMESTAMP);

      INSERT customers(
         customer_id,customer_name, address, email, password,date_created, companyName,phone)
         VALUES (
		 @in_Customerid ,
   @in_customer_name,
   @in_address ,
   @in_email,
    @in_password,
	@dates,
   @in_CompanyName,
	 @in_phone
			)
   END

GO
/****** Object:  StoredProcedure [dbo].[RegisterStaff]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegisterStaff]  

	@in_staffid nvarchar(30),
   @in_fname nvarchar(30),
   @in_lname nvarchar(30),
   @in_dname nvarchar(60),
   @in_phone nvarchar(50),
   @in_username nvarchar(11),
   @in_password nvarchar(100),
   @in_email nvarchar(50),
   @in_position nvarchar(11),
   @in_userlvl int,
   @in_status nvarchar(11),
   @in_address nvarchar(max)
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	   declare @dates NVARCHAR(20);
	 
	set @dates=dateadd(HOUR, 0, CURRENT_TIMESTAMP);

      INSERT staffs(
         staffid,fname, lname, dname, phone, username, password, userlevel,status,position,date, email,address)
         VALUES (
			@in_staffid,
            @in_fname, 
            @in_lname, 
            @in_dname, 
            @in_phone, 
            @in_username,
            @in_password, 
            @in_userlvl, 
            @in_status, 
            @in_position,
			@dates,
            @in_email,
			 @in_address)
   END


GO
/****** Object:  StoredProcedure [dbo].[updateQuote]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[updateQuote]

	@in_QuoteNo nvarchar(50),
	@in_customerID nvarchar(50),
	@in_remark nvarchar(500),
	@in_computerName nvarchar(500),
	@in_userrName nvarchar(50),
	@in_costCID nvarchar(50),
	@in_total_amount float


AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 update quotation
	 set remarks=@in_remark,
	 computerName=@in_computerName,
	  username=@in_userrName,
	  total_amount=@in_total_amount,
	  qtDate=getdate()
	  where QuoteNo=@in_QuoteNo
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[updCostCenter]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updCostCenter]

	@in_ID int,
	@in_CostCenter nvarchar(50),
	@in_adress nvarchar(50),
	@in_contactPhone nvarchar(50),
	@in_emailAddress nvarchar(50),
	/******@in_logo image,******/
	@in_state nvarchar(50),
	@in_lga nvarchar(50)

AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	update CostCenter
	set
	CostCenter=@in_CostCenter,
	 adress=@in_adress,
	  contactPhone=@in_contactPhone,
	  emailAddress=@in_emailAddress,
	  /******logo=@in_logo,******/
	  state=@in_state,
	  lga=@in_lga
	  where id=@in_ID
	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[updPO]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[updPO]

	@in_po_number nvarchar(50),
	@in_customerID nvarchar(50),
	@in_salesRep int,
	@in_product_id int,
	@in_quantity float,
	@in_amount_ltr float,
	@in_total_amount float,
	@in_deliveryAddress nvarchar(200),
	@in_remark nvarchar(500),
	@in_computerName nvarchar(500),
	@in_userrName nvarchar(50),
	@in_costCID nvarchar(50)


AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	update purchaseOrder
	set
	customerID=@in_customerID,
    salesRep=@in_salesRep,
	product_id=@in_product_id,
	Qty=@in_quantity,
	amount_ltr=@in_amount_ltr,
	total_amount=@in_total_amount,
	deliveryAddress=@in_deliveryAddress,
	remarks=@in_remark,
	computerName=@in_computerName,
	username=@in_userrName,
	costCenterID=@in_costCID,
	poDate=getdate()
	where 
	po_number=@in_po_number
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[updPO_stats]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updPO_stats]

	@in_po_number nvarchar(50),
	@in_statusCode nvarchar(50),
	@in_status nvarchar(50)


AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	update purchaseOrder
	set
	statusCode=@in_statusCode,
    status=@in_status
	where 
	po_number=@in_po_number
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[updPO_status]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updPO_status]

	@in_po_number nvarchar(50),
	@in_statusCode nvarchar(50),
	@in_status nvarchar(50),
	@in_remarks nvarchar(50)


AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	update purchaseOrder
	set
	statusCode=@in_statusCode,
    status=@in_status,
    remarks=@in_remarks
	where 
	po_number=@in_po_number
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[updPO_status2]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[updPO_status2]

	@in_po_number nvarchar(50),
	@in_statusCode nvarchar(50),
	@in_status nvarchar(50),
	@in_remarks nvarchar(50)


AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	update purchaseOrder
	set
	statusCode='AGM',
    status='Awaiting General Manager Approval',
    remarks=@in_remarks
	where 
	po_number=@in_po_number
	and statusCode='AA'
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[updPO_statusATL]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[updPO_statusATL]

	@in_po_number nvarchar(50)


AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	update purchaseOrder
	set
	statusCode='ATL',
    status='ATL Created'
	where 
	po_number=@in_po_number
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[updPONew]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[updPONew]

	@in_po_number nvarchar(50),
	@in_customerID nvarchar(50),
	@in_salesRep int,
	@in_AGO_ID int,
	@in_AGO_Qty float,
	@in_AGO_uprice float,
	@in_DPK_ID int,
	@in_DPK_Qty float,
	@in_DPK_uprice float,
	@in_PMS_ID int,
	@in_PMS_Qty float,
	@in_PMS_uprice float,
	@in_vat float,
	@in_witholding float,
	@in_NCD float,
	@in_subTotal float,
	@in_total_amount float,
	@in_deliveryAddress nvarchar(200),
	@in_remark nvarchar(500),
	@in_computerName nvarchar(500),
	@in_userrName nvarchar(50),
	@in_costCID nvarchar(50)
	
AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	update purchaseOrder
	set
	customerID=@in_customerID,
    salesRep=@in_salesRep,
	AGO_ID=@in_AGO_ID,
	AGO_Qty=@in_AGO_Qty,
	AGO_uprice=@in_AGO_uprice,
	DPK_ID=@in_DPK_ID,
	DPK_Qty=@in_DPK_Qty,
	DPK_uprice=@in_DPK_uprice,
	PMS_ID=@in_PMS_ID,
	PMS_Qty=@in_PMS_Qty,
	PMS_uprice=@in_PMS_uprice,
    vat=@in_vat,
	witholding=@in_witholding,
	NCD=@in_NCD,
	subTotal=@in_total_amount,
	total_amount=@in_total_amount,
	deliveryAddress=@in_deliveryAddress,
	remarks=@in_remark,
	computerName=@in_computerName,
	username=@in_userrName,
	costCenterID=@in_costCID,
	poDate=getdate()
	where 
	po_number=@in_po_number
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[UpdQuote]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[UpdQuote]

	@in_QuoteNo nvarchar(50),
	@in_customerID nvarchar(50),
	@in_remark nvarchar(500),
	@in_computerName nvarchar(500),
	@in_userrName nvarchar(50),
	@in_costCID nvarchar(50),
	@in_total_amount float


AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	update quotation
	set
	quoteNo=@in_QuoteNo,customerID=@in_customerID, remarks=@in_remark, username=@in_userrName,total_amount=@in_total_amount,qtDate=getdate()
	where quoteNo=@in_QuoteNo	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[updQuoteDetails]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updQuoteDetails]

	@in_QuoteNo nvarchar(50),
	@in_product_id nvarchar(10),
	@in_amount_ltr float,
	@in_quantity float,
	@in_vat float,
	@in_witholding float,
	@in_NCD float,
	@in_total_amount float

AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	update quotationDetails
	set
    quoteNo=@in_QuoteNo,
	product_id=@in_product_id,
	amount_ltr=@in_amount_ltr,
	quantity=@in_quantity,
	vat=@in_vat,
	witholding=@in_witholding,
	NCD=@in_NCD,
	total_amount=@in_total_amount
	where
	quoteNo=@in_QuoteNo and product_id=@in_product_id	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[updQuoteDetails_backup]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[updQuoteDetails_backup]

	@in_id nvarchar(10),
	@in_amount_ltr float,
	@in_quantity float,
	@in_vat float,
	@in_witholding float,
	@in_NCD float,
	@in_total_amount float

AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	update quotationDetails
	set
	amount_ltr=@in_amount_ltr,
	quantity=@in_quantity, 
	vat=@in_vat,
	witholding=@in_witholding,
	NCD=@in_NCD,
	total_amount=@in_total_amount,
	status='Qt',
	qtDate=getdate()
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[updQuoteDetailsQty]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[updQuoteDetailsQty]

	@in_QuoteNo nvarchar(50),
	@in_product_id nvarchar(10),
	@in_quantity float

AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	update quotationDetails
	set
	quantity=@in_quantity
	where
	quoteNo=@in_QuoteNo and product_id=@in_product_id	
   END
	 

GO
/****** Object:  StoredProcedure [dbo].[updRequisition]    Script Date: 11/3/2019 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[updRequisition]

	@in_req_number nvarchar(50),
	@in_vendorID nvarchar(50),
	@in_salesRep int,
	@in_product_id int,
	@in_quantity float,
	@in_amount_ltr float,
	@in_total_amount float,
	@in_deliveryAddress nvarchar(200),
	@in_remark nvarchar(500),
	@in_computerName nvarchar(500),
	@in_userrName nvarchar(50),
	@in_costCID nvarchar(50)


AS 
   BEGIN

      SET  XACT_ABORT  ON

      SET  NOCOUNT  ON
	 
	update requisition
	set
	vendorID=@in_vendorID,
    salesRep=@in_salesRep,
	product_id=@in_product_id,
	Qty=@in_quantity,
	amount_ltr=@in_amount_ltr,
	total_amount=@in_total_amount,
	deliveryAddress=@in_deliveryAddress,
	remarks=@in_remark,
	computerName=@in_computerName,
	username=@in_userrName,
	costCenterID=@in_costCID,
	reqDate=getdate()
	where 
	req_number=@in_req_number
   END
	 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'get staff ID information' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permit', @level2type=N'COLUMN',@level2name=N'authorizedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1.Grant truck access to faad loading yard. 2. truck release from faad premises ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permit', @level2type=N'COLUMN',@level2name=N'permitType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'staff_id link to staff Tablle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'purchaseOrder', @level2type=N'COLUMN',@level2name=N'salesRep'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'staff_id link to staff Tablle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'requisition', @level2type=N'COLUMN',@level2name=N'salesRep'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[62] 4[11] 2[15] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -96
         Left = -276
      End
      Begin Tables = 
         Begin Table = "p"
            Begin Extent = 
               Top = 115
               Left = 317
               Bottom = 451
               Right = 490
            End
            DisplayFlags = 280
            TopColumn = 17
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 89
               Left = 557
               Bottom = 345
               Right = 731
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "s"
            Begin Extent = 
               Top = 204
               Left = 933
               Bottom = 432
               Right = 1117
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "pr"
            Begin Extent = 
               Top = 185
               Left = 720
               Bottom = 356
               Right = 890
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cs"
            Begin Extent = 
               Top = 169
               Left = 82
               Bottom = 384
               Right = 252
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 19
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
        ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwPO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2085
         Alias = 1815
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwPO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwPO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "quotation"
            Begin Extent = 
               Top = 0
               Left = 294
               Bottom = 237
               Right = 467
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "quotationDetails"
            Begin Extent = 
               Top = 0
               Left = 514
               Bottom = 227
               Right = 684
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "product"
            Begin Extent = 
               Top = 7
               Left = 755
               Bottom = 137
               Right = 925
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "customers"
            Begin Extent = 
               Top = 59
               Left = 60
               Bottom = 238
               Right = 234
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2355
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwQuotation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwQuotation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwQuotation'
GO
USE [master]
GO
ALTER DATABASE [faad] SET  READ_WRITE 
GO
