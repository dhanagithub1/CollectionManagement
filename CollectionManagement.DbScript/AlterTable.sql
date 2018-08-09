ALTER TABLE [dbo].[CollectionTransaction]
ADD [Remarks] varchar(500) NULL
ALTER TABLE [uSER]
ADD DepartmentId int null

ALTER TABLE [dbo].[CollectionTransaction]
ADD DepartmentId int null

ALTER TABLE CollectionTransaction
ADD ModeOfPayment INT NULL
ALTER TABLE CollectionTransaction
ADD Denomination2K INT NULL
ALTER TABLE CollectionTransaction
ADD Denomination5H INT NULL
ALTER TABLE CollectionTransaction
ADD Denomination2H INT NULL
ALTER TABLE CollectionTransaction
ADD Denomination1H INT NULL
ALTER TABLE CollectionTransaction
ADD UpdatedBy INT NULL
ALTER TABLE CollectionTransaction
ADD UpdatedOn DATETIME NULL