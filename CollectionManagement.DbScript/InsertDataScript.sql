

INSERT INTO [dbo].[Department]
           ([DepartmentNameEnglish]
           ,[DepartmentNameMarathi]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[IsActive])
     SELECT
           'Department 1'
           ,'Dept1'
           ,GETDATE()
           ,1
           ,1
INSERT INTO [dbo].[Department]
           ([DepartmentNameEnglish]
           ,[DepartmentNameMarathi]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[IsActive])
	  SELECT
           'Department 2'
           ,'Dept2'
           ,GETDATE()
           ,1
           ,1
INSERT INTO [dbo].[Department]
           ([DepartmentNameEnglish]
           ,[DepartmentNameMarathi]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[IsActive])
	  SELECT
           'Department 3'
           ,'Dept3'
           ,GETDATE()
           ,1
           ,1
GO








INSERT INTO [dbo].[Service]
           ([ServiceNameEnglish]
           ,[ServiceNameMarathi]
           ,[FunctionCode]
           ,[ObjectCode]
           ,[DepartmentId]
           ,[IsActive]
           ,[CreatedOn]
           ,[CreatedBy])
     SELECT
           'Service 11'
           ,'Service 11'
           ,'123654'
           ,'123456'
           ,1
           ,1
           ,GETDATE()
           ,1
INSERT INTO [dbo].[Service]
           ([ServiceNameEnglish]
           ,[ServiceNameMarathi]
           ,[FunctionCode]
           ,[ObjectCode]
           ,[DepartmentId]
           ,[IsActive]
           ,[CreatedOn]
           ,[CreatedBy])
	    SELECT
           'Service 12'
           ,'Service 12'
           ,'123654'
           ,'123456'
           ,1
           ,1
           ,GETDATE()
           ,1
INSERT INTO [dbo].[Service]
           ([ServiceNameEnglish]
           ,[ServiceNameMarathi]
           ,[FunctionCode]
           ,[ObjectCode]
           ,[DepartmentId]
           ,[IsActive]
           ,[CreatedOn]
           ,[CreatedBy])
		SELECT
           'Service 13'
           ,'Service 13'
           ,'123654'
           ,'123456'
           ,1
           ,1
           ,GETDATE()
           ,1
INSERT INTO [dbo].[Service]
           ([ServiceNameEnglish]
           ,[ServiceNameMarathi]
           ,[FunctionCode]
           ,[ObjectCode]
           ,[DepartmentId]
           ,[IsActive]
           ,[CreatedOn]
           ,[CreatedBy])
	SELECT
           'Service 21'
           ,'Service 21'
           ,'123654'
           ,'123456'
           ,2
           ,1
           ,GETDATE()
           ,1
INSERT INTO [dbo].[Service]
           ([ServiceNameEnglish]
           ,[ServiceNameMarathi]
           ,[FunctionCode]
           ,[ObjectCode]
           ,[DepartmentId]
           ,[IsActive]
           ,[CreatedOn]
           ,[CreatedBy])
	SELECT
           'Service 22'
           ,'Service 22'
           ,'123654'
           ,'123456'
           ,2
           ,1
           ,GETDATE()
           ,1
INSERT INTO [dbo].[Service]
           ([ServiceNameEnglish]
           ,[ServiceNameMarathi]
           ,[FunctionCode]
           ,[ObjectCode]
           ,[DepartmentId]
           ,[IsActive]
           ,[CreatedOn]
           ,[CreatedBy])
SELECT
           'Service 31'
           ,'Service 31'
           ,'123654'
           ,'123456'
           ,3
           ,1
           ,GETDATE()
           ,1



