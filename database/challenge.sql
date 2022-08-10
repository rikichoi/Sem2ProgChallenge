create database challenge

use challenge

GO
DROP TABLE IF EXISTS Category;
GO
DROP TABLE IF EXISTS Segment;
GO
DROP TABLE IF EXISTS Region;
GO
DROP TABLE IF EXISTS Shipping;
GO
DROP TABLE IF EXISTS Product;
GO
DROP TABLE IF EXISTS Customer;
GO
DROP TABLE IF EXISTS [Order];

SELECT sobjects.name
FROM sysobjects sobjects
WHERE sobjects.xtype = 'U'

GO
CREATE TABLE Category(
    CatID INT,
    CatName NVARCHAR(50),
    PRIMARY KEY (CatID),
);

GO
CREATE TABLE Segment(
    SegID INT,
    SegName NVARCHAR(50),
    PRIMARY KEY (SegID),
);

GO
CREATE TABLE Region(
    Region NVARCHAR(50),
    PRIMARY KEY (Region),
);

GO
CREATE TABLE Shipping(
    ShipMode NVARCHAR(50),
    PRIMARY KEY (ShipMode),
);

GO
CREATE TABLE Product(
    ProdID NVARCHAR(50),
    CatID INT,
    Description NVARCHAR(100),
    UnitPrice INT,
    PRIMARY KEY (ProdID),
    FOREIGN KEY (CatID) REFERENCES Category
);

GO
CREATE TABLE Customer(
    CustID NVARCHAR(50),
    SegID INT,
    Region NVARCHAR(50),
    FullName NVARCHAR(50),
    Country NVARCHAR(50),
    City NVARCHAR(50),
    State NVARCHAR(50),
    PostCode INT,
    PRIMARY KEY (CustID),
    FOREIGN KEY (SegID) REFERENCES Segment,
    FOREIGN KEY (Region) REFERENCES Region
);

GO
CREATE TABLE [Order](
    OrderDate Date,
    ProdID NVARCHAR(50),
    ShipMode NVARCHAR(50),
    CustID NVARCHAR(50),
    Quantity INT,
    ShipDate Date,
    PRIMARY KEY (OrderDate,CustID,ProdID),
    FOREIGN KEY (ProdID) REFERENCES Product,
    FOREIGN KEY (CustID) REFERENCES Customer,
    FOREIGN KEY (ShipMode) REFERENCES Shipping,
);

select * from Category;
select * from Segment;
select * from Region;
select * from Shipping;
select * from Product;
select * from Customer;
select * from [Order];



INSERT INTO Category( CatID, CatName ) VALUES ( 1,'Furniture' );
INSERT INTO Category( CatID, CatName ) VALUES ( 2,'Office Supplies' );
INSERT INTO Category( CatID, CatName ) VALUES ( 3,'Technology' );

INSERT INTO Segment( SegID, SegName ) VALUES ( 1,'Consumer' );
INSERT INTO Segment( SegID, SegName ) VALUES ( 2,'Corporate' );
INSERT INTO Segment( SegID, SegName ) VALUES ( 3,'Home Office' );

INSERT INTO Product( ProdID, CatID, Description, UnitPrice ) VALUES ( 'FUR-BO-10001798', 1, 'Bush Somerset Collection Bookcase', 261.96 );
INSERT INTO Product( ProdID, CatID, Description, UnitPrice ) VALUES ( 'FUR-CH-10000454', 2, 'Mitel 5320 IP Phone VoIP phone', 731.94 );
INSERT INTO Product( ProdID, CatID, Description, UnitPrice ) VALUES ( 'OFF-LA-10000240', 3, 'Self-Adhesive Address Labels for Typewriters by Universal', 14.62 );

INSERT INTO Shipping( ShipMode ) VALUES ( 'Second Class' );
INSERT INTO Shipping( ShipMode ) VALUES ( 'Standard Class' );
INSERT INTO Shipping( ShipMode ) VALUES ( 'First Class' );
INSERT INTO Shipping( ShipMode ) VALUES ( 'Overnight Express' );

INSERT INTO Region( Region ) VALUES ( 'South' );
INSERT INTO Region( Region ) VALUES ( 'Central' );
INSERT INTO Region( Region ) VALUES ( 'West' );
INSERT INTO Region( Region ) VALUES ( 'East' );
INSERT INTO Region( Region ) VALUES ( 'North' );

INSERT INTO Customer( CustID,	FullName,	SegID,	Country,	City,	State,	PostCode,	Region ) VALUES ( 'CG-12520',	'Claire Gute',	1,	'United States',	'Henderson',	'Oklahoma',	42420,	'Central');
INSERT INTO Customer( CustID,	FullName,	SegID,	Country,	City,	State,	PostCode,	Region ) VALUES ( 'DV-13045',	'Darrin Van Huff',	2,	'United States',	'Los Angeles',	'California',	90036,	'West');
INSERT INTO Customer( CustID,	FullName,	SegID,	Country,	City,	State,	PostCode,	Region ) VALUES ( 'SO-20335',	'Sean O''Donnell',	1,	'United States',	'Fort Lauderdale',	'Florida',	33311,	'South');
INSERT INTO Customer( CustID,	FullName,	SegID,	Country,	City,	State,	PostCode,	Region ) VALUES ( 'BH-11710',	'Brosina Hoffman',	3,	'United States',	'Los Angeles',	'California',	90032,	'West');

INSERT INTO [Order]( CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode ) VALUES ( 'CG-12520',	'FUR-BO-10001798',	'2016/11/8',	2,	'2016/11/11',	'Second Class' );
INSERT INTO [Order]( CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode ) VALUES ( 'CG-12520',	'FUR-CH-10000454',	'2016/11/8',	3,	'2016/11/11',	'Second Class' );
INSERT INTO [Order]( CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode ) VALUES ( 'CG-12520',	'OFF-LA-10000240',	'2016/06/12',	2,	'2016/06/16',	'Second Class' );
INSERT INTO [Order]( CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode ) VALUES ( 'DV-13045',	'OFF-LA-10000240',	'2015/11/21',	2,	'2015/11/26',	'Second Class' );
INSERT INTO [Order]( CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode ) VALUES ( 'DV-13045',	'OFF-LA-10000240',	'2014/10/11',	1,	'2014/10/15',	'Standard Class' );
INSERT INTO [Order]( CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode ) VALUES ( 'DV-13045',	'FUR-CH-10000454',	'2016/11/12',	9,	'2016/11/16',	'Standard Class' );
INSERT INTO [Order]( CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode ) VALUES ( 'SO-20335',	'OFF-LA-10000240',	'2016/09/2',	5,	'2016/09/8',	'Standard Class' );
INSERT INTO [Order]( CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode ) VALUES ( 'SO-20335',	'FUR-BO-10001798',	'2017/08/25',	2,	'2017/08/29',	'Overnight Express' );
INSERT INTO [Order]( CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode ) VALUES ( 'SO-20335',	'FUR-CH-10000454',	'2017/06/22',	2,	'2017/06/26',	'Standard Class' );
INSERT INTO [Order]( CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode ) VALUES ( 'SO-20335',	'FUR-BO-10001798',	'2017/05/1',	3,	'2017/05/2',	'First Class' );

