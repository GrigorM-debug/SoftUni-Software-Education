--Problem 05: Online store database
CREATE DATABASE OnlineStoredb

USE OnlineStoredb

CREATE TABLE Cities (
    CityID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(1000)
)

CREATE TABLE [ItemTypes](
    ItemTypeID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100)
)

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Birthday DATE NOT NULL,
    CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE [Items](
    ItemID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(200) NOT NULL,
    ItemTypeID INT FOREIGN KEY REFERENCES [ItemTypes](ItemTypeID)
)

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY,
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems(
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ItemId INT FOREIGN KEY REFERENCES Items(ItemID),
    PRIMARY KEY (OrderID, ItemID)
)