CREATE DATABASE MusicStore; -- Creates Database MusicStore
GO

USE MusicStore; -- We use MusicStore and literally thats it
GO

CREATE SCHEMA SalesManagement;
GO 

CREATE SCHEMA People;
GO


CREATE TABLE SalesManagement.[Products] (
    Id INT PRIMARY KEY IDENTITY(1,1), -- PK and Incrementation from1 every time by 1
    Name VARCHAR(60) NOT NULL,
    Category VARCHAR(20) NOT NULL,
    Price DECIMAL(10,2) NOT NULL, --(10,2) its the precision
    ReleaseDate DATETIME NOT NULL
);
GO

CREATE TABLE SalesManagement.[Orders] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductId INT NOT NULL,
    CustomerId INT NOT NULL,
    EmployeeId INT NOT NULL,
    TotalPrice DECIMAL(10,2) NOT NULL,
    PurchaseDate DATETIME NOT NULL
);
GO

CREATE TABLE People.[Customers] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(20) NOT NULL,
    BirthDate DATETIME NOT NULL
);
GO

CREATE TABLE People.[Employees] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(20) NOT NULL,
    BirthDate DATETIME NOT NULL,
    Salary DECIMAL(10,2) NOT NULL
);
GO

ALTER TABLE SalesManagement.[Orders] ADD CONSTRAINT FK_Orders_Products FOREIGN KEY(ProductsId) REFERENCES SalesManagement.[Products](Id);
ALTER TABLE SalesManagement.[Orders] ADD CONSTRAINT FK_Orders_Employees FOREIGN KEY(EmployeesId) REFERENCES People.[Employees](Id);
ALTER TABLE SalesManagement.[Orders] ADD CONSTRAINT FK_Orders_Customers FOREIGN KEY(CustomersId) REFERENCES People.[Customers](Id);

CREATE INDEX IX_Orders_ProductId ON SalesManagement.[Orders](ProductsId); -- Faster working on FK (especially JOIN...) 
CREATE INDEX IX_Orders_EmployeeId ON SalesManagement.[Orders](EmployeesId);
CREATE INDEX IX_Orders_CustomerId ON SalesManagement.[Orders](CustomersId);

CREATE INDEX IX_Products_Category ON SalesManagement.[Products](Category); -- Probably frequently filtered column
CREATE INDEX IX_Products_Price ON SalesManagement.[Products](Price);
CREATE INDEX IX_Products_ReleaseDate ON SalesManagement.[Products](ReleaseDate);
CREATE INDEX IX_Orders_Category ON SalesManagement.[Orders](TotalPrice);
CREATE INDEX IX_Orders_Category ON SalesManagement.[Orders](PurchaseDate);
CREATE INDEX IX_Customers_BirthDate ON People.[Customers](BirthDate);
CREATE INDEX IX_Employees_BirthDate ON People.[Employees](BirthDate);
CREATE INDEX IX_Employees_Salary ON People.[Employees](Salary);