USE [CollectionManagement]
GO
/****** Object:  StoredProcedure [dbo].[AddTransactionData]    Script Date: 8/9/2018 2:01:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dhanashree D
-- Create date: 2018-08-04
-- Description:	uPDATES the dta for CollectionTransaction pAYMENT DETAILS
-- =============================================
CREATE PROCEDURE [dbo].[SavePaymentDetails] 
(	-- Add the parameters for the stored procedure here
	
	@ModeOfPayment INT,
	@CollectionTransactionId BIGINT,	
	@TransactionStatus INT,
	@BankName VARCHAR(50) =NULL,
	@BankAddress VARCHAR(100)=NULL,
	@Denomination2K INT=NULL,
	@Denomination5H	INT=NULL,
	@Denomination2H	INT=NULL,
	@Denomination1H	INT=NULL,
	@UpdatedBy INT,
	@DDNumber VARCHAR(50)=NULL,
	@ChequeNumber VARCHAR(50)=NULL
	 
)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY
	BEGIN TRAN

	UPDATE [dbo].[CollectionTransaction]
	SET	
			[TransactionStatus]   =@TransactionStatus
			,[Denomination2K]	  =@Denomination2K
			,[Denomination5H]	  =@Denomination5H
			,[Denomination2H]	  =@Denomination2H
			,[Denomination1H]	  =@Denomination1H
			,[ModeOfPayment]	  =@ModeOfPayment
			,[UpdatedBy]		  =@UpdatedBy
			,[UpdatedOn]		  =GETDATE()
			,[ChequeNumber]		  =@ChequeNumber
			,[DDNumber]			  =@DDNumber
			,[BankName]			  =@BankName
			,[BankAddress]		  =@BankAddress		 
	WHERE [CollectionTransactionId]=@CollectionTransactionId  
		 
	SELECT @CollectionTransactionId;
	
	COMMIT;
	END TRY
	BEGIN CATCH
	IF(@@TRANCOUNT<>0)
	ROLLBACK;
	END CATCH
END