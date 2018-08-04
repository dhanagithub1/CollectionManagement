-- ================================
-- Create User-defined Table Type
-- ================================
USE [CollectionManagement]
GO

-- Create the data type
CREATE TYPE [dbo].[TransactionServiceList] AS TABLE 
(
	[ServiceId] [bigint] NULL,
	[Rate] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[Remarks] [varchar](500) NULL
)
GO
