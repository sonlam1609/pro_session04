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
select * from PARTS
SELECT MAX(ID)  FROM Orders
delete Orders where ID = 21
select * from Orders
select * from OrderItems
select BathNumber from OrderItems where BathNumber = 'sdf'


delete Orders where ID = 24

select MinimumAmount from PARTS where PartName = 'Part1'

update PARTS set MinimumAmount = MinimumAmount + 100 where PartName = 'Part2'

select * from PARTS
select DISTINCT PartID, PartName
from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID
     inner join Orders on Orders.ID = OrderItems.OrderID
where BatchNumberHasRequired = 'true' and Orders.Destination = 3

select BathNumber
from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID
     inner join Orders on Orders.ID = OrderItems.OrderID
where BatchNumberHasRequired = 'true' and Orders.Destination = 3 and PartID = 3


INSERT INTO PARTS VALUES('Part1','2020/02/02',1,100),
												('Part2','2020/02/02',0,150),
												('Part3','2020/02/02',1,160),
												('Part4','2020/02/02',1,100),
												('Part5','2020/02/02',1,50);

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

INSERT INTO OrderItems VALUES (8,3,300,400),
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

insert into Orders (TranSactionID, SourceWareHouse, Destination, OrderDate) values(2,4,3,'2020-06-07')


select Parts.PartName, TranSactionTypes.TranSactionName,  Orders.OrderDate, OrderItems.Amount, e1.WareHouseName as 'Source' , e2.WareHouseName as 'Destination', OrderItems.ID as 'OrderItemId', Orders.ID as 'OrdersId'
from Orders 
inner join WareHouses e1 on Orders.SourceWareHouse = e1.ID
inner join WareHouses e2 on Orders.Destination = e2.ID
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

select TranSactionTypes.ID
from TranSactionTypes
where TranSactionName = 'Plane'

Update Orders
set SourceWareHouse = 2, Destination = 4, TranSactionID = 2
where Orders.ID = 4


select * from OrderItems
INSERT INTO OrderItems VALUES (2,3,300,400)

delete OrderItems
where OrderItems.ID = 7

INSERT INTO Orders VALUES (2,3,2,3,'2020/10/6')
select * from WareHouses

select BatchNumberHasRequired
from PARTS
where ID = 2

select * from Orders
delete Orders where ID = 11