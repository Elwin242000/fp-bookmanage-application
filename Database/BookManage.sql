create database BooM
go

use BooM
go

create table Account
(
	UserName nvarchar(100) primary key,
	Password nvarchar(100) not null default 0,
	Type int not null default 0
)
go
create table ResetClick
(
	id int identity primary key,
	name nvarchar(100)
)
go
create table Suppliers
(
	id int identity primary key,
	name nvarchar(500) not null default N'Unnamed',
	address nvarchar(500) not null default N'Unfill',
	phone varchar(200) not null default N'Unfill'
)
go
create table Items
(
	id int identity primary key,
	name nvarchar(100) not null default N'Unnamed'
)
go
create table ItemType
(
	id int identity primary key,
	name nvarchar(100),
	idItem int not null

	foreign key (idItem) references Items (id)
)
go
create table Products
(
	id int identity primary key,
	name nvarchar(100) not null default N'Unnamed',
	author nvarchar(100),
	idItem int not null,
	idItemType int not null,
	idSupplier int not null,
	price float not null default 0

	foreign key (idItem) references dbo.Items (id),
	foreign key (idItemType) references dbo.ItemType (id),
	foreign key (idSupplier) references dbo.Suppliers (id)
)
go
create table Bills
(
	id int identity primary key,
	DateCheckIn date not null default getdate(),
	DateCheckOut date, 
	idReset int not null,
	status int not null default 0,
	discount int default 0

	foreign key (idReset) references dbo.ResetClick(id)
)
go
create table BillInfo
(
	id int identity primary key,
	idBill int not null,
	idProduct int not null,
	count int not null default 0

	foreign key (idBill) references dbo.Bills (id),
	foreign key (idProduct) references dbo.Products (id)
)
go

--============================================================================
create proc usp_GetAccountByUserName
@username nvarchar(100)
as
begin
	select * from dbo.Account where UserName = @username
end
go

create proc usp_Login
@userName nvarchar(100), @passWord nvarchar(100)
as
begin
	select * from dbo.Account where UserName = @userName and Password = @passWord
end
go

create proc usp_GetResetButton
as select * from dbo.ResetClick
go

create proc usp_InsertBill
@idReset int
as
begin
	insert into Bills(DateCheckIn, DateCheckOut, idReset, status, discount) values (GETDATE(), null, @idReset, 0, 0)
end
go

create proc usp_InsertBillInfo
@idBill int, @idProduct int, @count int
as
begin
	declare @isExitsBillInfo INT
	declare @productCount INT = 1

	select @isExitsBillInfo = id, @productCount = b.count
	from dbo.BillInfo AS b
	where idBill = @idBill and idProduct = @idProduct

	if (@isExitsBillInfo > 0)
	begin
		declare @newCount INT = @productCount + @count
		if (@newCount > 0)
			update dbo.BillInfo set count = @productCount + @count where idProduct = @idProduct
		else
			delete dbo.BillInfo where idBill = @idBill and idProduct = @idProduct
	end
	else
	begin
		insert dbo.BillInfo (idBill, idProduct, count) values (@idBill, @idProduct, @count)
	end
end
go

create trigger utg_UpdateBillInfo
on dbo.BillInfo for insert, update
as
begin
	declare @idBill int
	select @idBill = idBill from inserted
	
	declare @idReset int
	select @idReset = idReset from dbo.Bills where id = @idBill and status = 0
end
go

create trigger utg_UpdateBill
on dbo.Bills for update
as
begin
	declare @idBill int
	select @idBill = id from inserted

	declare @idReset int
	select @idReset = idReset from dbo.Bills where id = @idBill

	declare @count int = 0
	select @count = count(*) from dbo.Bills where idReset = @idReset and status = 0
end
go

create proc usp_UpdateAccount
@username nvarchar(100), @password nvarchar(100), @newPassword nvarchar(100)
as
begin
	declare @isRight int

	select @isRight = count(*) from dbo.Account where UserName = @userName and Password = @password

	if (@isRight = 1)
	begin
			update dbo.Account set PassWord = @newPassword where UserName = @userName		
	end
end
go

create proc usp_ListBillDate
@checkIn date, @checkOut date
as
begin
	select DateCheckIn as [Date check in], DateCheckOut as [Date check out], discount as [Discount], b.TotalPrice as [Total price]
	from dbo.Bills as b, dbo.ResetClick as t
	where DateCheckIn >= @checkIn and DateCheckOut <= @checkOut and b.status = 1 
		and t.id = b.idReset 
end
go

create trigger utg_DeleteBillInfo
on dbo.BillInfo for delete
as
begin
	declare @idBI int
	declare @idBill int
	select @idBI = id, @idBill = deleted.id from deleted
end
go
--============================================================================
select * from dbo.Account
select * from dbo.ResetClick
select * from dbo.Suppliers
select * from dbo.Items
select * from dbo.ItemType
select * from dbo.Products
select * from dbo.Bills
select * from dbo.BillInfo

delete dbo.BillInfo
delete dbo.Bills