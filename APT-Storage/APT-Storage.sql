USE [master]
GO

/****** Object:  Database [APT-Storage]    Script Date: 6/26/2023 8:10:40 AM ******/
CREATE DATABASE [APT-Storage]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'APT-Storage', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS02\MSSQL\DATA\APT-Storage.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'APT-Storage_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS02\MSSQL\DATA\APT-Storage_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [APT-Storage].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [APT-Storage] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [APT-Storage] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [APT-Storage] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [APT-Storage] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [APT-Storage] SET ARITHABORT OFF 
GO

ALTER DATABASE [APT-Storage] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [APT-Storage] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [APT-Storage] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [APT-Storage] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [APT-Storage] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [APT-Storage] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [APT-Storage] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [APT-Storage] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [APT-Storage] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [APT-Storage] SET  ENABLE_BROKER 
GO

ALTER DATABASE [APT-Storage] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [APT-Storage] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [APT-Storage] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [APT-Storage] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [APT-Storage] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [APT-Storage] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [APT-Storage] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [APT-Storage] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [APT-Storage] SET  MULTI_USER 
GO

ALTER DATABASE [APT-Storage] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [APT-Storage] SET DB_CHAINING OFF 
GO

ALTER DATABASE [APT-Storage] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [APT-Storage] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [APT-Storage] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [APT-Storage] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [APT-Storage] SET QUERY_STORE = ON
GO

ALTER DATABASE [APT-Storage] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [APT-Storage] SET  READ_WRITE 
GO

