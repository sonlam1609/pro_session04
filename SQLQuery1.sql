CREATE DATABASE Session4;

USE Session4;

CREATE TABLE PARTS(
	ID INT IDENTITY PRIMARY KEY,
	PartName NVARCHAR(200),
	EffectiveLife date,
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

alter table OrderItems
alter column Amount float

select * from PARTS
SELECT MAX(ID)  FROM Orders
delete Orders where ID = 21
select * from Orders
select * from OrderItems

select PartName, MinimumAmount, sum(Amount) as 'Tong' from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID
     inner join Orders on Orders.ID = OrderItems.OrderID
	  where Destination = 2
	  group by PartName,MinimumAmount


delete Orders where ID =34

select BathNumber from OrderItems where BathNumber = 'sdf'

select * from Orders inner join OrderItems on Orders.ID = OrderItems.OrderID
where TranSactionID = 2 and BathNumber = 'AC66'

select BathNumber, Amount from OrderItems inner join Orders on Orders.ID = OrderItems.OrderID where TranSactionID = 1 and BathNumber = 'AC55'

delete Orders where ID = 24

select MinimumAmount from PARTS where PartName = 'Part1'

update PARTS set MinimumAmount = MinimumAmount + 100 where PartName = 'Part2'
select * from Orders

select * from OrderItems inner join Orders on Orders.ID = OrderItems.OrderID

select BathNumber, Amount from OrderItems inner join Orders on Orders.ID = OrderItems.OrderID
where BathNumber = 'AC55' and SourceWareHouse = 3

select sum(Amount) as 'so luong mua'
from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID 
inner join Orders on Orders.ID = OrderItems.OrderID
where Orders.Destination = 1 and BathNumber = 'AC55'

/*Lay Tat car*/
select DISTINCT t.PartName, t.Mua - ISNULL(h.Ban, 0 ) as 'Con', t.Mua from (
select PARTS.PartName, sum(Amount) as 'Mua'
from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID 
inner join Orders on Orders.ID = OrderItems.OrderID
where Orders.Destination = 2
group by PARTS.PartName) t full join (
select PARTS.PartName, sum(Amount) as 'Ban' 
from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID 
inner join Orders on Orders.ID = OrderItems.OrderID
where Orders.SourceWareHouse = 2 and Orders.TranSactionID = 2
group by PARTS.PartName) h 
on t.PartName = h.PartName 

select BathNumber,Amount,TranSactionID,SourceWareHouse, Destination  from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID
inner join Orders on Orders.ID = OrderItems.OrderID
where ((Orders.SourceWareHouse = 1 and Orders.TranSactionID = 2) or Orders.Destination = 1) and PartName = 'Laptop'

select BathNumber, Amount, TranSactionTypes.TranSactionName, e1.WareHouseName as 'Source' , e2.WareHouseName as 'Destination'
from Orders 
inner join WareHouses e1 on Orders.SourceWareHouse = e1.ID
inner join WareHouses e2 on Orders.Destination = e2.ID
inner join OrderItems on Orders.ID = OrderItems.OrderID
inner join Parts on OrderItems.PartID = Parts.ID
inner join TranSactionTypes on TranSactionTypes.ID = Orders.TranSactionID
where ((Orders.SourceWareHouse = 1 and Orders.TranSactionID = 2) or Orders.Destination = 1) and PartName = 'Laptop'



select * from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID
inner join Orders on Orders.ID = OrderItems.OrderID

select * from Parts

select a.Mua - b.Ban, 0 from (select BathNumber, sum(Amount) as 'Mua'
from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID
inner join Orders on Orders.ID = OrderItems.OrderID
where Orders.Destination = 1 and PARTS.PartName = 'Laptop' and BathNumber = 'AC88'
group by BathNumber) a inner join (select BathNumber, sum(Amount) as 'Ban'
from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID
inner join Orders on Orders.ID = OrderItems.OrderID
where Orders.SourceWareHouse = 1 and PARTS.PartName = 'Laptop' and BathNumber = 'AC88'
group by BathNumber) b on a.BathNumber = b.BathNumber

/*-------------*/
select t.Mua - ISNULL(h.Ban, 0 ) as 'Con' from (
select PARTS.PartName, sum(Amount) as 'Mua'
from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID 
inner join Orders on Orders.ID = OrderItems.OrderID
where Orders.Destination = 2
group by PARTS.PartName) t full join (
select PARTS.PartName, sum(Amount) as 'Ban' 
from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID 
inner join Orders on Orders.ID = OrderItems.OrderID
where Orders.SourceWareHouse = 2 and Orders.TranSactionID = 2
group by PARTS.PartName) h 
on t.PartName = h.PartName 
where t.PartName = 'Laptop'

select Parts.ID, PARTS.PartName, OrderItems.BathNumber, Amount, SourceWareHouse, Destination, TranSactionID
from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID
inner join Orders on Orders.ID = OrderItems.OrderID
where SourceWareHouse = 3

select * from Parts

select BathNumber from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID
inner join Orders on Orders.ID = OrderItems.OrderID
where Destination = 1 and PartID = 2 and BatchNumberHasRequired = 'true'


create function SLBan(@Id int)
returns @thongke table(
	PartName nvarchar(30),
	Amount float
)
as
begin
	insert into @thongke 
	select PARTS.PartName, sum(Amount)
	from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID 
	inner join Orders on Orders.ID = OrderItems.OrderID
	where Orders.SourceWareHouse = @Id
	group by PARTS.PartName
	return
end

drop function SLBan

select *from  dbo.SLBan(1)

select sum(Amount)
from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID 
inner join Orders on Orders.ID = OrderItems.OrderID
where Orders.SourceWareHouse = 1 and BathNumber = 'AC55'


select BathNumber from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID
inner join Orders on Orders.ID = OrderItems.OrderID
where Destination = 1 and PartID = 2 and BatchNumberHasRequired = 'true' group by BathNumber



UPDATE OrderItems SET Amount = Amount - 50 FROM OrderItems inner join Orders on Orders.ID = OrderItems.OrderID WHERE SourceWareHouse = 3 and BathNumber = 'AC55'


select DISTINCT PartID, PartName
from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID
     inner join Orders on Orders.ID = OrderItems.OrderID
where BatchNumberHasRequired = 'true' and Orders.Destination = 3

select BathNumber
from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID
     inner join Orders on Orders.ID = OrderItems.OrderID
where BatchNumberHasRequired = 'true' and Orders.Destination = 3 and PartID = 2

select * from Orders
select * from OrderItems
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

INSERT INTO OrderItems VALUES (8,3,'AB11',400),
															(1,2,'AB22',40),
															(2,1,'AB33',50),
															(3,4,'AB44',400),
															(4,5,'AB55',400);
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