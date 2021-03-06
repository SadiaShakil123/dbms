USE [master]
GO
/****** Object:  Database [Hospital Management System]    Script Date: 4/28/2018 4:46:10 PM ******/
CREATE DATABASE [Hospital Management System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hospital Management System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Hospital Management System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Hospital Management System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Hospital Management System_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Hospital Management System] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hospital Management System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hospital Management System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hospital Management System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hospital Management System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hospital Management System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hospital Management System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hospital Management System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Hospital Management System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hospital Management System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hospital Management System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hospital Management System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hospital Management System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hospital Management System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hospital Management System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hospital Management System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hospital Management System] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Hospital Management System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hospital Management System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hospital Management System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hospital Management System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hospital Management System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hospital Management System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hospital Management System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hospital Management System] SET RECOVERY FULL 
GO
ALTER DATABASE [Hospital Management System] SET  MULTI_USER 
GO
ALTER DATABASE [Hospital Management System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hospital Management System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hospital Management System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hospital Management System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Hospital Management System] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Hospital Management System', N'ON'
GO
ALTER DATABASE [Hospital Management System] SET QUERY_STORE = OFF
GO
USE [Hospital Management System]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Hospital Management System]
GO
/****** Object:  Table [dbo].[Accessibility]    Script Date: 4/28/2018 4:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accessibility](
	[Access_Id] [int] IDENTITY(1,1) NOT NULL,
	[Functionality] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Access_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 4/28/2018 4:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admit_Patient]    Script Date: 4/28/2018 4:46:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admit_Patient](
	[InP_Id] [int] IDENTITY(1,1) NOT NULL,
	[Patient_Id] [int] NOT NULL,
	[R_Id] [int] NOT NULL,
	[Date_Of_Adm] [datetime] NOT NULL,
	[Date_Of_Dis] [datetime] NOT NULL,
	[B_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[InP_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bed]    Script Date: 4/28/2018 4:46:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bed](
	[Bed_Id] [int] IDENTITY(1,1) NOT NULL,
	[Room_Id] [int] NOT NULL,
	[Bed_Status] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Bed_Id] ASC,
	[Room_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 4/28/2018 4:46:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[B_Id] [int] IDENTITY(1,1) NOT NULL,
	[Patient_Id] [int] NOT NULL,
	[B_Amount] [int] NOT NULL,
	[B_Date] [datetime] NOT NULL,
	[No_of_Days] [int] NOT NULL,
	[Med_Charges] [int] NOT NULL,
	[D_Age] [int] NOT NULL,
	[Room_Charges] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[B_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 4/28/2018 4:46:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Dpt_id] [int] IDENTITY(1,1) NOT NULL,
	[Dpt_Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Dpt_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doc_Pay]    Script Date: 4/28/2018 4:46:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doc_Pay](
	[Pay_Id] [int] IDENTITY(1,1) NOT NULL,
	[Pay_date] [datetime] NOT NULL,
	[Doctor_Id] [int] NOT NULL,
	[pay_status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Pay_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 4/28/2018 4:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[D_Id] [int] IDENTITY(1,1) NOT NULL,
	[D_Name] [varchar](100) NOT NULL,
	[D_Gender] [varchar](100) NOT NULL,
	[D_Age] [int] NOT NULL,
	[D_CNIC] [varchar](100) NOT NULL,
	[D_DeptID] [int] NOT NULL,
	[D_Salary] [int] NOT NULL,
	[D_Specialization] [varchar](100) NOT NULL,
	[Brnch_Id] [int] NOT NULL,
	[Hos_City] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[D_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[doctor_admitPatient]    Script Date: 4/28/2018 4:46:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doctor_admitPatient](
	[doc_Id] [int] NOT NULL,
	[pat_Id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoctorAttendance]    Script Date: 4/28/2018 4:46:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorAttendance](
	[Attendance_Id] [int] IDENTITY(1,1) NOT NULL,
	[Doctor_Id] [int] NOT NULL,
	[D_Date] [date] NOT NULL,
	[Status_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Attendance_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[H_User]    Script Date: 4/28/2018 4:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[H_User](
	[U_Id] [int] IDENTITY(1,1) NOT NULL,
	[U_Name] [varchar](100) NOT NULL,
	[U_Gender] [varchar](100) NOT NULL,
	[U_Age] [int] NOT NULL,
	[U_CNIC] [varchar](100) NOT NULL,
	[U_Salary] [int] NOT NULL,
	[Access_Id] [int] NOT NULL,
	[U_Type] [varchar](100) NOT NULL,
	[U_LoginId] [varchar](100) NOT NULL,
	[U_Password] [varchar](100) NOT NULL,
	[Brnch_Id] [int] NOT NULL,
	[Hos_City] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[U_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hospital]    Script Date: 4/28/2018 4:46:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hospital](
	[Branch_Id] [int] IDENTITY(1,1) NOT NULL,
	[H_City] [varchar](100) NOT NULL,
	[H_Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Branch_Id] ASC,
	[H_City] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicine]    Script Date: 4/28/2018 4:46:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicine](
	[Med_Id] [int] IDENTITY(1,1) NOT NULL,
	[Med_Name] [varchar](100) NOT NULL,
	[MCost_Per_Unit] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Med_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OutPatient]    Script Date: 4/28/2018 4:46:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutPatient](
	[OP_Id] [int] IDENTITY(1,1) NOT NULL,
	[Patient_Id] [int] NOT NULL,
	[O_Date] [datetime] NOT NULL,
	[Doctor_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OP_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[P_Status]    Script Date: 4/28/2018 4:46:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[P_Status](
	[PayStatusId] [int] IDENTITY(1,1) NOT NULL,
	[pStatusValue] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PayStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 4/28/2018 4:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[P_Id] [int] IDENTITY(1,1) NOT NULL,
	[P_Name] [varchar](100) NOT NULL,
	[P_Gender] [varchar](100) NOT NULL,
	[P_Age] [int] NOT NULL,
	[P_CNIC] [varchar](100) NOT NULL,
	[Dpt_Id] [int] NULL,
	[Brnch_Id] [int] NOT NULL,
	[Hos_City] [varchar](100) NOT NULL,
 CONSTRAINT [PK__Patient__A3420A5700A69169] PRIMARY KEY CLUSTERED 
(
	[P_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescription]    Script Date: 4/28/2018 4:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescription](
	[Prcpt_Id] [int] IDENTITY(1,1) NOT NULL,
	[Patient_Id] [int] NOT NULL,
	[Doctor_Id] [int] NOT NULL,
	[Medicine_Id] [int] NOT NULL,
	[Total_Items] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Prcpt_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 4/28/2018 4:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Room_Id] [int] IDENTITY(1,1) NOT NULL,
	[RType_Name] [varchar](100) NOT NULL,
	[Charges_per_day] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Room_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sStatus]    Script Date: 4/28/2018 4:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sStatus](
	[Status_Id] [int] IDENTITY(1,1) NOT NULL,
	[Status_Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Status_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 4/28/2018 4:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[S_Id] [int] IDENTITY(1,1) NOT NULL,
	[S_Name] [varchar](100) NOT NULL,
	[S_Gender] [varchar](100) NOT NULL,
	[S_Age] [int] NOT NULL,
	[S_CNIC] [varchar](100) NOT NULL,
	[S_Salary] [int] NOT NULL,
	[Brnch_Id] [int] NOT NULL,
	[Hos_City] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[S_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff_Pay]    Script Date: 4/28/2018 4:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff_Pay](
	[Pay_Id] [int] IDENTITY(1,1) NOT NULL,
	[Pay_date] [datetime] NOT NULL,
	[Staff_Id] [int] NOT NULL,
	[pay_status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Pay_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffAttendance]    Script Date: 4/28/2018 4:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffAttendance](
	[Attendance_Id] [int] IDENTITY(1,1) NOT NULL,
	[Staff_Id] [int] NOT NULL,
	[S_Date] [date] NOT NULL,
	[Status_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Attendance_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Admit_Patient]  WITH CHECK ADD FOREIGN KEY([B_Id], [R_Id])
REFERENCES [dbo].[Bed] ([Bed_Id], [Room_Id])
GO
ALTER TABLE [dbo].[Admit_Patient]  WITH CHECK ADD  CONSTRAINT [FK_AdmitPatientAkb] FOREIGN KEY([Patient_Id])
REFERENCES [dbo].[Patient] ([P_Id])
GO
ALTER TABLE [dbo].[Admit_Patient] CHECK CONSTRAINT [FK_AdmitPatientAkb]
GO
ALTER TABLE [dbo].[Admit_Patient]  WITH CHECK ADD  CONSTRAINT [FK_AdmitPatientBkb] FOREIGN KEY([R_Id])
REFERENCES [dbo].[Room] ([Room_Id])
GO
ALTER TABLE [dbo].[Admit_Patient] CHECK CONSTRAINT [FK_AdmitPatientBkb]
GO
ALTER TABLE [dbo].[Bed]  WITH CHECK ADD  CONSTRAINT [FK_Bedd] FOREIGN KEY([Room_Id])
REFERENCES [dbo].[Room] ([Room_Id])
GO
ALTER TABLE [dbo].[Bed] CHECK CONSTRAINT [FK_Bedd]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Bills] FOREIGN KEY([Patient_Id])
REFERENCES [dbo].[Patient] ([P_Id])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Bills]
GO
ALTER TABLE [dbo].[Doc_Pay]  WITH CHECK ADD  CONSTRAINT [FK_docPay] FOREIGN KEY([Doctor_Id])
REFERENCES [dbo].[Doctor] ([D_Id])
GO
ALTER TABLE [dbo].[Doc_Pay] CHECK CONSTRAINT [FK_docPay]
GO
ALTER TABLE [dbo].[Doc_Pay]  WITH CHECK ADD  CONSTRAINT [FK_Paystatus] FOREIGN KEY([pay_status])
REFERENCES [dbo].[P_Status] ([PayStatusId])
GO
ALTER TABLE [dbo].[Doc_Pay] CHECK CONSTRAINT [FK_Paystatus]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD FOREIGN KEY([Brnch_Id], [Hos_City])
REFERENCES [dbo].[Hospital] ([Branch_Id], [H_City])
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doct] FOREIGN KEY([D_DeptID])
REFERENCES [dbo].[Department] ([Dpt_id])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doct]
GO
ALTER TABLE [dbo].[doctor_admitPatient]  WITH CHECK ADD FOREIGN KEY([doc_Id])
REFERENCES [dbo].[Doctor] ([D_Id])
GO
ALTER TABLE [dbo].[doctor_admitPatient]  WITH CHECK ADD FOREIGN KEY([pat_Id])
REFERENCES [dbo].[Admit_Patient] ([InP_Id])
GO
ALTER TABLE [dbo].[DoctorAttendance]  WITH CHECK ADD  CONSTRAINT [FK_DAttendanceA] FOREIGN KEY([Doctor_Id])
REFERENCES [dbo].[Doctor] ([D_Id])
GO
ALTER TABLE [dbo].[DoctorAttendance] CHECK CONSTRAINT [FK_DAttendanceA]
GO
ALTER TABLE [dbo].[DoctorAttendance]  WITH CHECK ADD  CONSTRAINT [FK_DAttendanceB] FOREIGN KEY([Status_Id])
REFERENCES [dbo].[sStatus] ([Status_Id])
GO
ALTER TABLE [dbo].[DoctorAttendance] CHECK CONSTRAINT [FK_DAttendanceB]
GO
ALTER TABLE [dbo].[H_User]  WITH CHECK ADD FOREIGN KEY([Brnch_Id], [Hos_City])
REFERENCES [dbo].[Hospital] ([Branch_Id], [H_City])
GO
ALTER TABLE [dbo].[H_User]  WITH CHECK ADD  CONSTRAINT [FK_H_UserA] FOREIGN KEY([Access_Id])
REFERENCES [dbo].[Accessibility] ([Access_Id])
GO
ALTER TABLE [dbo].[H_User] CHECK CONSTRAINT [FK_H_UserA]
GO
ALTER TABLE [dbo].[OutPatient]  WITH CHECK ADD  CONSTRAINT [FK_AdmitPatientA] FOREIGN KEY([Patient_Id])
REFERENCES [dbo].[Patient] ([P_Id])
GO
ALTER TABLE [dbo].[OutPatient] CHECK CONSTRAINT [FK_AdmitPatientA]
GO
ALTER TABLE [dbo].[OutPatient]  WITH CHECK ADD  CONSTRAINT [FK_AdmitPatientC] FOREIGN KEY([Doctor_Id])
REFERENCES [dbo].[Doctor] ([D_Id])
GO
ALTER TABLE [dbo].[OutPatient] CHECK CONSTRAINT [FK_AdmitPatientC]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK__Patient__3B75D760] FOREIGN KEY([Brnch_Id], [Hos_City])
REFERENCES [dbo].[Hospital] ([Branch_Id], [H_City])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK__Patient__3B75D760]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient] FOREIGN KEY([Dpt_Id])
REFERENCES [dbo].[Department] ([Dpt_id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient]
GO
ALTER TABLE [dbo].[Prescription]  WITH CHECK ADD  CONSTRAINT [FK_AdmitPatienttA] FOREIGN KEY([Patient_Id])
REFERENCES [dbo].[Patient] ([P_Id])
GO
ALTER TABLE [dbo].[Prescription] CHECK CONSTRAINT [FK_AdmitPatienttA]
GO
ALTER TABLE [dbo].[Prescription]  WITH CHECK ADD  CONSTRAINT [FK_AdmitPatienttB] FOREIGN KEY([Medicine_Id])
REFERENCES [dbo].[Medicine] ([Med_Id])
GO
ALTER TABLE [dbo].[Prescription] CHECK CONSTRAINT [FK_AdmitPatienttB]
GO
ALTER TABLE [dbo].[Prescription]  WITH CHECK ADD  CONSTRAINT [FK_AdmitPatienttC] FOREIGN KEY([Doctor_Id])
REFERENCES [dbo].[Doctor] ([D_Id])
GO
ALTER TABLE [dbo].[Prescription] CHECK CONSTRAINT [FK_AdmitPatienttC]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([Brnch_Id], [Hos_City])
REFERENCES [dbo].[Hospital] ([Branch_Id], [H_City])
GO
ALTER TABLE [dbo].[Staff_Pay]  WITH CHECK ADD  CONSTRAINT [FK_dochPay] FOREIGN KEY([Staff_Id])
REFERENCES [dbo].[Staff] ([S_Id])
GO
ALTER TABLE [dbo].[Staff_Pay] CHECK CONSTRAINT [FK_dochPay]
GO
ALTER TABLE [dbo].[Staff_Pay]  WITH CHECK ADD  CONSTRAINT [FK_Paystatvus] FOREIGN KEY([pay_status])
REFERENCES [dbo].[P_Status] ([PayStatusId])
GO
ALTER TABLE [dbo].[Staff_Pay] CHECK CONSTRAINT [FK_Paystatvus]
GO
ALTER TABLE [dbo].[StaffAttendance]  WITH CHECK ADD  CONSTRAINT [FK_DAttendancedA] FOREIGN KEY([Staff_Id])
REFERENCES [dbo].[Staff] ([S_Id])
GO
ALTER TABLE [dbo].[StaffAttendance] CHECK CONSTRAINT [FK_DAttendancedA]
GO
ALTER TABLE [dbo].[StaffAttendance]  WITH CHECK ADD  CONSTRAINT [FK_DAttendancedB] FOREIGN KEY([Status_Id])
REFERENCES [dbo].[sStatus] ([Status_Id])
GO
ALTER TABLE [dbo].[StaffAttendance] CHECK CONSTRAINT [FK_DAttendancedB]
GO
USE [master]
GO
ALTER DATABASE [Hospital Management System] SET  READ_WRITE 
GO
