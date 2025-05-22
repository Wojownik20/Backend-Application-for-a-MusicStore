CREATE DATABASE MusicStore; -- Creates Database MusicStore
GO

USE MusicStore; -- We use MusicStore and literally thats it
GO

CREATE TABLE dbo.Product (
    Id INT PRIMARY KEY IDENTITY(1,1), -- PK and Incrementation from1 every time by 1
    Name VARCHAR(60) NOT NULL,
    Category VARCHAR(20) NOT NULL,
    Price DECIMAL(10,2) NOT NULL, --(10,2) its the precision
    ReleaseDate DATETIME NOT NULL
);
GO

CREATE TABLE dbo.[Order] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductId INT NOT NULL,
    CustomerId INT NOT NULL,
    EmployeeId INT NOT NULL,
    TotalPrice DECIMAL(10,2) NOT NULL,
    PurchaseDate DATETIME NOT NULL
);
GO

CREATE TABLE dbo.Customer (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(20) NOT NULL,
    BirthDate DATETIME NOT NULL
);
GO

CREATE TABLE dbo.Employee (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(20) NOT NULL,
    BirthDate DATETIME NOT NULL,
    Salary DECIMAL(10,2) NOT NULL
);
GO

ALTER TABLE dbo.[Order] ADD CONSTRAINT FK_Order_Product FOREIGN KEY(ProductId) REFERENCES dbo.Product(Id);
ALTER TABLE dbo.[Order] ADD CONSTRAINT FK_Order_Employee FOREIGN KEY(EmployeeId) REFERENCES dbo.Employee(Id);
ALTER TABLE dbo.[Order] ADD CONSTRAINT FK_Order_Customer FOREIGN KEY(CustomerId) REFERENCES dbo.Customer(Id);

CREATE INDEX IX_Order_ProductId ON dbo.[Order](ProductId);
CREATE INDEX IX_Order_Employee ON dbo.[Order](EmployeeId);
CREATE INDEX IX_Order_Customer ON dbo.[Order](CustomerId);
CREATE INDEX IX_Product_Category ON dbo.Product(Category); -- Probably frequently filtered column