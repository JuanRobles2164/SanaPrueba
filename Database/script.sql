CREATE DATABASE Sanadb;
USE Sanadb;

CREATE TABLE Categories (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(30) NOT NULL
);

CREATE TABLE Products (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ProductCode NVARCHAR(50) NOT NULL UNIQUE,
    Title NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255),
    Price DECIMAL(18, 2) NOT NULL,
    Stock INT NOT NULL
);

CREATE TABLE ProductCategories (
    ProductID INT NOT NULL,
    CategoryID INT NOT NULL,
    PRIMARY KEY (ProductID, CategoryID),
    FOREIGN KEY (ProductID) REFERENCES Products(ID) ON DELETE CASCADE,
    FOREIGN KEY (CategoryID) REFERENCES Categories(ID) ON DELETE CASCADE
);

CREATE TABLE Customers (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL
);

CREATE TABLE Orders (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    TotalAmount DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(ID) ON DELETE CASCADE
);

CREATE TABLE OrderDetails (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(ID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Products(ID) ON DELETE CASCADE
);

CREATE INDEX idx_ProductCode ON Products(ProductCode);
CREATE INDEX idx_CustomerID ON Orders(CustomerID);
CREATE INDEX idx_OrderID ON OrderDetails(OrderID);
CREATE INDEX idx_Product_Title ON Products(Title);
CREATE INDEX idx_ProductCategories_CategoryID ON ProductCategories(CategoryID);
CREATE INDEX idx_OrderDetails_ProductID ON OrderDetails(ProductID);
CREATE INDEX idx_Orders_OrderDate ON Orders(OrderDate);
