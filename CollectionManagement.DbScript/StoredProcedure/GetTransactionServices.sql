USE [CollectionManagement]
GO
/****** Object:  StoredProcedure [dbo].[GetTransactionServices]    Script Date: 8/5/2018 12:25:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dhanashree Dhabade
-- Create date: 2018-08-04
-- Description:	Get the Transaction Details
-- =============================================
ALTER PROCEDURE [dbo].[GetTransactionServices]
	-- Add the parameters for the stored procedure here
	@TransactionId int=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT [TransactionServiceId]
      ,T.[CollectionTransactionId]
      ,T.[ServiceId]
      ,T.[Rate]
      ,T.[Quantity]
      ,T.[Remarks]
      ,T.[CreatedOn]
      ,T.[CreatedBy]
	  ,S.ServiceNameEnglish AS ServiceName
  FROM [dbo].[TransactionService] T
  INNER JOIN [Service] S
  ON S.ServiceId=T.ServiceId
  WHERE [CollectionTransactionId]=@TransactionId
END
