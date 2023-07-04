INSERT INTO TypeModel
VALUES ('Model1','Model1')
GO
INSERT INTO TypeModel
VALUES ('Model2','Model2')
GO

INSERT INTO RobotType
VALUES(1,'Model1_Type1','Model1_Type1')
GO
INSERT INTO RobotType
VALUES (1,'Model1_Type2','Model1_Type2')
GO

INSERT INTO RobotType
VALUES(2,'Model2_Type1','Model2_Type1')
GO
INSERT INTO RobotType
VALUES (2,'Model2_Type2','Model2_Type2')
GO
INSERT INTO RobotType
VALUES (2,'Model2_Type3','Model2_Type3')
GO

INSERT INTO [User]
VALUES (NEWID(),'Fname1','Lname1','email1@gmail.com','password1',GETDATE())
GO


INSERT INTO [User]
VALUES (NEWID(),'Fname2','Lname2','email2@gmail.com','password2',GETDATE())
GO