CREATE DATABASE MusicStore; -- Creates Database MusicStore
GO

USE MusicStore; -- We use MusicStore and literally thats it
GO

CREATE SCHEMA SalesManagement;
GO 

CREATE SCHEMA People;
GO


CREATE TABLE SalesManagement.Product (
    Id INT PRIMARY KEY IDENTITY(1,1), -- PK and Incrementation from1 every time by 1
    Name VARCHAR(60) NOT NULL,
    Category VARCHAR(20) NOT NULL,
    Price DECIMAL(10,2) NOT NULL, --(10,2) its the precision
    ReleaseDate DATETIME NOT NULL
);
GO

CREATE TABLE SalesManagement.[Order] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductId INT NOT NULL,
    CustomerId INT NOT NULL,
    EmployeeId INT NOT NULL,
    TotalPrice DECIMAL(10,2) NOT NULL,
    PurchaseDate DATETIME NOT NULL
);
GO

CREATE TABLE People.Customer (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(20) NOT NULL,
    BirthDate DATETIME NOT NULL
);
GO

CREATE TABLE People.Employee (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(20) NOT NULL,
    BirthDate DATETIME NOT NULL,
    Salary DECIMAL(10,2) NOT NULL
);
GO

ALTER TABLE SalesManagement.[Order] ADD CONSTRAINT FK_Order_Product FOREIGN KEY(ProductId) REFERENCES SalesManagement.Product(Id);
ALTER TABLE SalesManagement.[Order] ADD CONSTRAINT FK_Order_Employee FOREIGN KEY(EmployeeId) REFERENCES People.Employee(Id);
ALTER TABLE SalesManagement.[Order] ADD CONSTRAINT FK_Order_Customer FOREIGN KEY(CustomerId) REFERENCES People.Customer(Id);

CREATE INDEX IX_Order_ProductId ON SalesManagement.[Order](ProductId); -- Faster working on FK (especially JOIN...) 
CREATE INDEX IX_Order_Employee ON SalesManagement.[Order](EmployeeId);
CREATE INDEX IX_Order_Customer ON SalesManagement.[Order](CustomerId);
CREATE INDEX IX_Product_Category ON SalesManagement.Product(Category); -- Probably frequently filtered column