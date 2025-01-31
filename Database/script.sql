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

INSERT INTO Categories (Name) VALUES
('Electronics'),
('Clothing'),
('Home & Kitchen'),
('Books'),
('Toys'),
('Sports'),
('Beauty'),
('Automotive'),
('Health'),
('Grocery'),
('Furniture'),
('Jewelry'),
('Tools'),
('Music'),
('Movies');

INSERT INTO Products (ProductCode, Title, Description, Price, Stock) VALUES
('P001', 'Smartphone X', 'Latest model with 128GB storage', 699.99, 100),
('P002', 'Laptop Pro', '15-inch laptop with 16GB RAM', 1299.99, 50),
('P003', 'Wireless Earbuds', 'Noise-cancelling wireless earbuds', 199.99, 200),
('P004', 'Smart Watch', 'Fitness tracker with heart rate monitor', 149.99, 150),
('P005', '4K TV', '55-inch 4K Ultra HD Smart TV', 799.99, 75),
('P006', 'Blender', 'High-speed blender for smoothies', 89.99, 120),
('P007', 'Coffee Maker', 'Programmable coffee maker', 59.99, 90),
('P008', 'Running Shoes', 'Lightweight running shoes', 79.99, 300),
('P009', 'Yoga Mat', 'Eco-friendly yoga mat', 29.99, 250),
('P010', 'Backpack', 'Water-resistant backpack', 49.99, 180),
('P011', 'Novel: The Great Adventure', 'Bestselling fiction novel', 14.99, 500),
('P012', 'Board Game: Strategy', 'Family strategy board game', 39.99, 100),
('P013', 'Perfume: Ocean Breeze', 'Eau de parfum for men and women', 69.99, 200),
('P014', 'Car Wax', 'Premium car wax for shine and protection', 19.99, 150),
('P015', 'Protein Powder', 'Whey protein for muscle recovery', 34.99, 300);

INSERT INTO ProductCategories (ProductID, CategoryID) VALUES
(1, 1),
(2, 1),
(3, 1),
(4, 1),
(5, 1),
(6, 3),
(7, 3),
(8, 6),
(9, 6),
(10, 2),
(11, 4),
(12, 5),
(13, 7),
(14, 8),
(15, 9);

INSERT INTO Customers (FirstName, LastName) VALUES
('John', 'Doe'),
('Jane', 'Smith'),
('Alice', 'Johnson'),
('Bob', 'Brown'),
('Charlie', 'Davis'),
('Eva', 'Martinez'),
('Frank', 'Garcia'),
('Grace', 'Lee'),
('Henry', 'Wilson'),
('Ivy', 'Taylor'),
('Jack', 'Anderson'),
('Karen', 'Thomas'),
('Leo', 'Hernandez'),
('Mia', 'Moore'),
('Nina', 'Clark');

INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) VALUES
(1, '2023-10-01', 699.99),
(2, '2023-10-02', 1299.99),
(3, '2023-10-03', 199.99),
(4, '2023-10-04', 149.99),
(5, '2023-10-05', 799.99),
(6, '2023-10-06', 89.99),
(7, '2023-10-07', 59.99),
(8, '2023-10-08', 79.99),
(9, '2023-10-09', 29.99),
(10, '2023-10-10', 49.99),
(11, '2023-10-11', 14.99),
(12, '2023-10-12', 39.99),
(13, '2023-10-13', 69.99),
(14, '2023-10-14', 19.99),
(15, '2023-10-15', 34.99);

INSERT INTO OrderDetails (OrderID, ProductID, Quantity) VALUES
(1, 1, 1),
(2, 2, 1),
(3, 3, 2),
(4, 4, 1),
(5, 5, 1),
(6, 6, 1),
(7, 7, 1),
(8, 8, 1),
(9, 9, 1),
(10, 10, 1),
(11, 11, 2),
(12, 12, 1),
(13, 13, 1),
(14, 14, 1),
(15, 15, 1);
