USE [CollectionManagement]
GO
/****** Object:  StoredProcedure [dbo].[AddTransactionData]    Script Date: 8/7/2018 1:53:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dhanashree D
-- Create date: 2018-08-04
-- Description:	Inserts the dta for CollectionTransaction
-- =============================================
ALTER PROCEDURE [dbo].[AddTransactionData] 
(	-- Add the parameters for the stored procedure here
	@TransactionList TransactionServiceList READONLY, 
	@TransactionId VARCHAR(50),
	@TransactionStatus int=0,
	@ApplicantName VARCHAR(100),
	@MobileNumber VARCHAR(50),
	@Address VARCHAR(500),
	@AadhaarNumber VARCHAR(20)=NULL,
	@PanNumber VARCHAR(20)=NULL,
	@ApplicantGSTNumber VARCHAR(100),
	@TotalAmount DECIMAL(18,2),
	--@CreatedOn DATETIME=GETDATE,
	@CreatedBy INT,
	@Remarks VARCHAR(500)=NULL,
	@DepartmentId int=0,
	@OutTransactionId VARCHAR(50) OUT
)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY
	BEGIN TRAN
	SET @OutTransactionId= '';
  INSERT INTO [dbo].[CollectionTransaction]
           ([TransactionId]
           ,[TransactionStatus]
           ,[ApplicantName]
           ,[MobileNumber]
           ,[Address]
           ,[AadhaarNumber]
           ,[PanNumber]
           ,[ApplicantGSTNumber]
           ,[TotalAmount]
           ,[CreatedOn]
           ,[CreatedBy]
		   ,[Remarks]
		   ,[DepartmentId]
           )
     VALUES
           (@TransactionId
           ,@TransactionStatus
           ,@ApplicantName
		   ,@MobileNumber
           ,@Address
           ,@AadhaarNumber
           ,@PanNumber
           ,@ApplicantGSTNumber
           ,@TotalAmount
           ,GETDATE()
           ,@CreatedBy
		   ,@Remarks
		   ,@DepartmentId
           )

		   DECLARE @InsertedId BIGINT = @@IDENTITY;

		   SET @OutTransactionId=(SELECT [TransactionId] FROM [dbo].[CollectionTransaction] WHERE [CollectionTransactionId]=@InsertedId);

		   INSERT INTO [dbo].[TransactionService]
           ([CollectionTransactionId]
           ,[ServiceId]
           ,[Rate]
           ,[Quantity]
           ,[Remarks]
           ,[CreatedOn]
           ,[CreatedBy])
     SELECT
           @InsertedId
           ,ServiceId
           ,Rate
           ,Quantity
           ,Remarks
           ,GETDATE()
           ,@CreatedBy
	FROM	@TransactionList
	SELECT @@ROWCOUNT;
	
	COMMIT;
	END TRY
	BEGIN CATCH
	IF(@@TRANCOUNT<>0)
	ROLLBACK;
	END CATCH
END
