IF DB_ID(N'pmsdb') IS NULL
	CREATE DATABASE pmsdb;
GO

USE pmsdb;
GO

IF OBJECT_ID(N'dbo.products', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.products
	(
		Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_products PRIMARY KEY,
		Title varchar(50) NOT NULL,
		[description] varchar(50) NOT NULL,
		[image] varchar(255) NOT NULL,
		price int NOT NULL CONSTRAINT CK_products_price_nonnegative CHECK (price >= 0),
		quantity int NOT NULL CONSTRAINT CK_products_quantity_nonnegative CHECK (quantity >= 0),
		status varchar(150) NOT NULL
	);
END;
GO
