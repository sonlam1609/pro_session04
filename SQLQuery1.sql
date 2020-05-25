CREATE DATABASE Session4;

USE Session4;

CREATE TABLE PARTS(
	ID INT IDENTITY PRIMARY KEY,
	PartName NVARCHAR(200),
	EffectiveLife NVARCHAR(200),
	BatchNumberHasRequired bit,
	MinimumAmount int
);

CREATE TABLE Suppliers(
	ID INT IDENTITY PRIMARY KEY,
	SupplyName NVARCHAR(100),

);

CREATE TABLE WareHouses(
	ID INT IDENTITY PRIMARY KEY,
	WareHouseName NVARCHAR(100),
);

CREATE TABLE TranSactionTypes(
	ID INT IDENTITY PRIMARY KEY,
	TranSactionName NVARCHAR(100),
);

CREATE TABLE Orders(
	ID INT IDENTITY PRIMARY KEY,
	TranSactionID INT FOREIGN KEY REFERENCES TranSactionTypes(ID),
	SupplierID INT FOREIGN KEY REFERENCES Suppliers(ID),
	SourceWareHouse INT FOREIGN KEY REFERENCES WareHouses(ID),
	Destination INT FOREIGN KEY REFERENCES WareHouses(ID),
	OrderDate DATE
);

CREATE TABLE  OrderItems(
	ID INT IDENTITY PRIMARY KEY,
	OrderID INT FOREIGN KEY REFERENCES Orders(ID),
	PartID  INT FOREIGN KEY REFERENCES PARTS(ID),
	BathNumber nvarchar(50),
	Amount int
)

INSERT INTO PARTS VALUES('Part1','ok',1,100),
												('Part2','ok',0,150),
												('Part3','ok',1,160),
												('Part4','ok',1,100),
												('Part5','ok',1,50);

INSERT INTO Suppliers VALUES ('SamSung'),
														 ('Son'),
														 ('Apple'),
														 ('LG'),
														 ('Tokuda');

INSERT INTO TranSactionTypes VALUES ('Plane'),
																		('Taxi'),
																		('Ship');

INSERT INTO WareHouses VALUES ('Mikuta'),
															('Mario Ozawa'),
															('Mikata'),
															('Tokuda');
INSERT INTO Orders VALUES (1,1,2,3,'2019/2/4'),
													(2,3,1,2,'1977/12/3'),
													(2,2,1,2,'1999/12/4'),
													(3,1,1,2,'2017/12/3'),
													(1,2,2,3,'2020/4/3');

INSERT INTO OrderItems VALUES (1,1,200,400),
															(1,2,20,40),
															(2,1,50,50),
															(3,4,200,400),
															(4,5,200,400);
select * from PARTS;
select * from Suppliers;
select * from TranSactionTypes;
select * from WareHouses;

select * from OrderItems;
select * from Orders;

select Parts.PartName, TranSactionTypes.TranSactionName,  Orders.OrderDate, OrderItems.Amount, WareHouses.WareHouseName as 'Source' , Destination.Destination, OrderItems.ID as 'OrderItemId', Orders.ID as 'OrdersId'
from Orders 
inner join WareHouses on Orders.SourceWareHouse = WareHouses.ID
inner join Destination on Orders.Destination = Destination.ID
inner join OrderItems on Orders.ID = OrderItems.OrderID
inner join Parts on OrderItems.PartID = Parts.ID
inner join TranSactionTypes on TranSactionTypes.ID = Orders.TranSactionID;

drop table Source
drop table Destination

select Warehouses.ID, Warehouses.WareHouseName as 'Destination' into Destination
from Warehouses

select * from Destination

select PARTS.ID
from PARTS
where PARTS.PartName = 'Part3';

select WareHouses.ID
from WareHouses
where WareHouses.WareHouseName = 'Mikuta'


Update Orders
set SourceWareHouse = 2, Destination = 4, TranSactionID = 2
where Orders.ID = 1

select * from WareHouses
