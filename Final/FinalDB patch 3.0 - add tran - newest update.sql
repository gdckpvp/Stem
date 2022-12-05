Create database StemDB
go

Use StemDB
go

-- Create TABLES

Create table [dbo].[Users](
	UserID int IDENTITY (1,1) primary key,
	Username nvarchar(15) not null,
	Pass nvarchar(16) not null,
	Wallet int check(Wallet >= 0),
	DOB date,
	CreditCard char(12),
	Spent int check(Spent >= 0),
	[Admin] int default 0,
)
go

Create table [dbo].[Studio](
    StudioID int IDENTITY (1,1) primary key,
    StudioName nvarchar(max) not null,
    Country nvarchar(max),
)
Go

Create table [dbo].[Game](
	GameID nvarchar(5) primary key,
	StudioID int,
	GameName nvarchar(max) not null,
	Descri nvarchar(max),
	Price int check (Price >=0 ),
	[Image] varbinary(max),
	Lang nvarchar(100),
	Download int check(Download >=0),
	Release date not null,
	Plat nvarchar(100),
	Size float check(Size >=0 and Size <=100),
	CONSTRAINT FK_StudioGame FOREIGN KEY (StudioID) REFERENCES Studio(StudioID)
)
go

Create table [dbo].[RedeemCode](
    Code nvarchar(10) primary key,
    GameID nvarchar(5),
	UserID int null,
    CONSTRAINT FK_RedeemCode FOREIGN KEY (GameID) REFERENCES Game(GameID),
	CONSTRAINT FK_RedeemUser FOREIGN KEY (UserID) REFERENCES Users(UserID),
)
go

Create table [dbo].[Lib](
	GameID nvarchar(5),
	UserID int,
	BuyDate date,
	CONSTRAINT FK_GameLib FOREIGN KEY (GameID) REFERENCES Game(GameID),
	CONSTRAINT FK_UserLib FOREIGN KEY (UserID) REFERENCES Users(UserID),
)
go


Create table [dbo].[DisEvent](
	DisID int Primary key,
	DisName nvarchar(max) not null,
	Amount int check(Amount >= 0),
	DisType nvarchar(20) not null,
	DayBegin date,
	DayEnd date
)
go

Create table [dbo].[DisGame](
	DisID int,
	GameID nvarchar(5),
	CONSTRAINT FK_DisGame_DisEvent FOREIGN KEY (DisID) REFERENCES DisEvent(DisID),
	CONSTRAINT FK_DisGame_Game FOREIGN KEY (GameID) REFERENCES Game(GameID)
)
go

Create table [dbo].[Tag](
	TagName nvarchar(40) Primary key
)
go

Create table [dbo].[Category](
	TagName nvarchar(40),
	GameID nvarchar(5),
	CONSTRAINT FK_Category_Game FOREIGN KEY (GameID) REFERENCES Game(GameID),
	CONSTRAINT FK_Category_Tag FOREIGN KEY (TagName) REFERENCES Tag(TagName)
)
go


Create table [dbo].[Sale](
    SaleID int IDENTITY (1,1) primary key,
    GameID nvarchar(5),
    SaleDate date not null,
    Amount int Check(Amount >=0),
    CONSTRAINT FK_Sale FOREIGN KEY (GameID) REFERENCES Game(GameID)
)
Go


------------------- Add, update, delete user


---------- USERS

-- ADD
Create Procedure [dbo].[sp_AddNewUser]
@uname nvarchar(15),
@password nvarchar(16)
as
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			insert into Users values(@uname, @password,0,null,null,0,0)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
go


-- UPDATE
-- Chỉnh sữa thông tin user
create procedure [dbo].[sp_UpdateUserProfile]
(
@uid int,
@username nvarchar(15),
@pass nvarchar(16),
@dob date,
@credit nvarchar(12)
)
as
begin
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			update Users
			set UserName = @username, Pass = @pass, DOB = @dob, CreditCard = @credit
			where UserID = @uid
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
    
end
go

Create Procedure [dbo].[sp_UpdateUserWallet]
@amount int,
@uid int
as
SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			update Users
			set Wallet = Wallet + @amount
			where UserID = @uid
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
go



---------- LIB


-- ADD
Create Procedure [dbo].[sp_AddNewGameToLib]
@uid int,
@gid nvarchar(5),
@date date
as
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			insert into Lib values(@uid, @gid,@date)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
go


-- UPDATE






---------- GAME


-- ADD
Create Procedure [dbo].[sp_AddNewGame]
@gameid nvarchar(5),
@stuid int,
@name nvarchar(max),
@desc nvarchar(max),
@price int,
@language nvarchar(100),
@release date,
@platform nvarchar(100),
@size float,
@img varbinary(max)
as
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			insert into Game values(@gameid,@stuid, @name, @desc, @price, @img, @language, 0, @release, @platform, @size)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
go


-- UPDATE


-- DELETE
Create Procedure [dbo].[sp_DeleteGame]
@gid nvarchar(5)
as
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			Delete from Game where GameID = @gid
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
	
go


---------- STUDIO


-- ADD
Create Procedure [dbo].[sp_AddNewStudio]
@stuname nvarchar(max),
@country nvarchar(max)
as
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			insert into Studio values(@stuname, @country)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
go

-- UPDATE


-- DELETE
Create Procedure [dbo].[sp_DeleteStudio]
@StudioID int
as
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			Delete from Studio where StudioID = @StudioID
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
go


---------- SALE
-- ADD
Create Procedure [dbo].[sp_AddNewSale]
@saleid int,
@gameid nvarchar(5),
@total int
as
SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			declare @saledate date = GETDATE()
	
			If exists(
				Select Sale.SaleID 
				From Sale 
				Where MONTH(Sale.SaleDate) = MONTH(@saledate) and YEAR(Sale.SaleDate) = YEAR(@saledate)
			) 
			Begin
				update Sale
				set Amount = Amount + @total
				where SaleID = @saleid
			end
			else insert into Sale values (@gameid,@saledate, @total)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
go

-- UPDATE


-- DELETE
Create Procedure [dbo].[sp_DeleteSale]
@saleid int
as
SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			Delete from Sale where SaleID = @saleid
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
go


---------- RedeemCode


-- ADD
create procedure [dbo].[sp_CreateRedeemCode]
@GameID nvarchar(5)
as
begin
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			declare @Count int = 1
			WHILE (@Count<=10)
			Begin
				declare @Code nvarchar(10)  = (SELECT SUBSTRING(CONVERT(varchar(40), NEWID()),0,11))
				if not exists (select RedeemCode.Code from RedeemCode where RedeemCode.Code = @Code)
					begin
						INSERT INTO RedeemCode(Code,GameID,UserID) VALUES (@Code,@GameID,null);
						Set @Count = @Count+1
					end
			end
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
end
go
-- UPDATE

create Procedure [dbo].[sp_UpdateGameInfo]
@gid nvarchar(5),
@stuid int,
@name nvarchar(max),
@desc nvarchar(max),
@price int,
@language nvarchar(50),
@release date,
@platform nvarchar(max),
@size float,
@img varbinary(max)
as
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			update Game
			set StudioID = @stuid, 
			GameName = @name, 
			Descri = @desc, 
			Price = @price, 
			Lang = @language, 
			Release = @release, 
			Plat = @platform, 
			Size = @size, 
			[Image] = @img
			where GameID = @gid
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
go
-- DELETE
create procedure [dbo].[sp_DeleteRedeemCode]
@code nvarchar(10)
as
begin
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			DELETE FROM RedeemCode WHERE RedeemCode.Code = @code;
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
end
GO

create function [dbo].[func_DeleteNonUseCode](@code nvarchar(10))
returns int
as 
begin
	if (exists(select Code from RedeemCode where RedeemCode.Code = @code and RedeemCode.UserID != null))
		begin
			return 0
		end
	return 1
end
go
---------- Tag


-- ADD
create procedure [dbo].[sp_CreateTag](@TagName nvarchar(40))
as
begin
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			INSERT INTO Tag(TagName) VALUES (@TagName);
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
end
go

-- UPDATE


-- DELETE
create procedure [dbo].[sp_DeleteTag](@TagName nvarchar(40))
as
begin
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			DELETE FROM Category WHERE Category.TagName = @TagName;
			DELETE FROM Tag WHERE Tag.TagName = @TagName;
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
    
end
go

---------- Category


-- ADD
create procedure [dbo].[sp_LinkGameWithTag](@TagName nvarchar(40), @GameID nvarchar(5))
as
begin
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			INSERT INTO Category(TagName,GameID) VALUES (@TagName,@GameID);
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
    INSERT INTO Category(TagName,GameID)
    VALUES (@TagName,@GameID);
end
go

-- UPDATE


-- DELETE


---------- Discount Event


-- ADD
create procedure [dbo].[sp_CreateDisEvent](@DisID int,@DisName nvarchar(max), @Amount int, @DisType nvarchar(20),  @Disbegin date, @Disend date)
as
begin
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			INSERT INTO DisEvent VALUES (@DisID,@DisName,@Amount,@DisType, @Disbegin, @Disend);
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
end
go


-- UPDATE
create procedure [dbo].[sp_UpdateDisEvent](@DisID int,@DisName nvarchar(max), @Amount int, @Distype nvarchar(20),@Disbegin date, @Disend date)
as
begin
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			Update DisEvent
			set DisName = @DisName,Amount = @Amount, DisType = @Distype, DayBegin = @Disbegin, DayEnd = @Disend
			where DisID = @DisID
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
end
GO

-- DELETE
create procedure [dbo].[sp_DeleteDisEvent](@DisID int)
as
begin
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			delete from DisEvent Where DisEvent.DisID = @DisID
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
end
GO

---------- Discount Game


-- ADD
create procedure [dbo].[sp_DiscountGame](@DisID int, @GameID nvarchar(5))
as
begin
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			INSERT INTO DisGame(DisID,GameID) VALUES (@DisID,@GameID);
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
end
go

-- UPDATE

create procedure [dbo].[sp_UpdateStudio](@StudioID int,@StudioName nvarchar(max),@Country nvarchar(max))
as
begin
	SET NOCOUNT ON;
	BEGIN TRAN
		BEGIN TRY
			Update Studio
			set StudioName = @StudioName,Country = @Country
			where Studio.StudioID = @StudioID
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
end
GO

create function [dbo].[func_GetStudioFromID](@StudioID int)
returns table
as
	return(
		Select * From Studio 
		Where StudioID = @StudioID
	)
go


------------------- Phụ


-- Count mã game 
Create Function [dbo].[func_RedeemCodeLeft](@gid nvarchar(5))
returns int
as
begin
	declare @Amount int	

	set @Amount = (Select count(Code) From dbo.RedeemCode where RedeemCode.GameID = @gid)
	
	return @Amount
end
go


-- Hiển thị tất cả các game trong lib
create function [dbo].[func_ShowLibUser](@uid int)
returns table
as
return(
    select Distinct Game.GameName, Game.[Image],Studio.StudioName, Game.Plat, Game.Lang,
					STUFF((SELECT '; ' + Tag.TagName 
							FROM Tag
							WHERE Category.GameID = Game.GameID
							FOR XML PATH('')), 1, 1, '') [Tags],
					
					Game.Price, Game.Download, Game.Size, Game.Descri, Game.Release,RedeemCode.Code,Lib.BuyDate
					from Game
	left join Category on Category.GameID = Game.GameID
	left join Tag on Category.TagName = Tag.TagName
	left join Studio on Studio.StudioID = Game.StudioID
	left join RedeemCode on RedeemCode.GameID = Game.GameID
	left join Lib on Lib.GameID = Game.GameID
	left join Users on Users.UserID = Lib.UserID
	where Users.UserID = @uid and RedeemCode.UserID = @uid
    )
GO

-- Tinh gia tien cho game
create function [dbo].[func_PriceApplyDiscount](@Gameprice int, @DiseventAmount int)
returns int
as 
begin
	declare @price int = @Gameprice - @Gameprice*@DiseventAmount/100
	return @price;
end
go

-- Hien thi thu vien theo tag
Create Function [dbo].[func_ShowLibByTag](@uid int, @tagname nvarchar(40))
returns table
as
	return(
		Select GameTag.GameName
		From Lib join (Select Game.GameID, Game.GameName
						From Game join (Select Category.TagName, Category.GameID
										From Tag join Category
										on Tag.TagName = Category.TagName) as TagCate
						on Game.GameID = TagCate.GameID ) as GameTag
		on Lib.GameID = GameTag.GameID
		Where Lib.UserID = @uid
	)
go

-- Tạo acc ( xét tính hợp lệ của pass, username, kiểm tra xem có trùng không )
create Function [dbo].[func_CheckAccount](@pass nvarchar(16), @usr nvarchar(15))
returns int
as
begin
	declare @check int = 0
	if LEN(@pass) >= 6
		if not ((@pass LIKE '%!%' or @pass LIKE '%@%' or @pass LIKE '%#%' or @pass LIKE '%$%' or @pass LIKE '%^%' or @pass LIKE '%&%' or @pass LIKE '%*%' or @pass LIKE '%(%' or @pass LIKE '%)%') 
		and (@pass LIKE '%1%' or @pass LIKE '%2%' or @pass LIKE '%3%' or @pass LIKE '%4%' or @pass LIKE '%5%' or @pass LIKE '%6%' or @pass LIKE '%7%' or @pass LIKE '%8%' or @pass LIKE '%9%' or @pass LIKE '%9%'))
			set @check = 1
	if exists(select Username from Users where @usr = Users.Username)
			 set @check = 2
	return @check
end
go

-- Kiểm tra credit card chuyển thành tiền -> chuyển vào wallet



-- Tính sale theo năm
Create Function [dbo].[func_Sale](@year int)
returns table
as
    return(
        Select Sale.Amount,Sale.SaleDate,Game.GameName From Sale
		inner join Game on Game.GameID = Sale.GameID where (YEAR(Sale.SaleDate) = @year
		)
    )
GO


-- Lọc theo tag
Create Function [dbo].[func_ShowGameByTag](@uid int, @tagname nvarchar(40))
returns table
as
	return(
		Select Game.GameID, Game.GameName
		From Game join (Select Category.TagName, Category.GameID
						From Tag join Category
						on Tag.TagName = Category.TagName
						Where Tag.TagName = @tagname) as TagCate
		on Game.GameID = TagCate.GameID
	)
go


create function [dbo].[func_GetAllGameAdmin]()
returns table
as
return(
    select Distinct Game.GameID, Game.GameName, Game.[Image],Studio.StudioName, Game.Plat, Game.Lang,
					STUFF((SELECT '; ' + Tag.TagName 
							FROM Tag
							WHERE Game.GameID = Game.GameID
							FOR XML PATH('')), 1, 1, '') [Tags],
					STUFF((SELECT '; ' + RedeemCode.Code
							FROM RedeemCode
							WHERE Game.GameID = Game.GameID
							FOR XML PATH('')), 1, 1, '') [Code],
					Game.Price, Game.Download, Game.Size, Game.Descri, Game.Release
					from Game
	inner join Category on Category.GameID = Game.GameID
	inner join Tag on Category.TagName = Tag.TagName
	inner join Studio on Studio.StudioID = Game.StudioID
	inner join RedeemCode on RedeemCode.GameID = Game.GameID
    )
go



-- Hiện Category
create function [dbo].[func_GameCategories]()
returns table
as return
(
	select Distinct Game.GameName, Studio.StudioName, Tag.TagName from Category
	inner join Tag on Category.TagName = Tag.TagName
	inner join Game on Category.GameID = Game.GameID
	inner join Studio on Studio.StudioID = Game.StudioID
)
go

-- Tìm game
create function [dbo].[func_FindGame](@GameName nvarchar(max) null)
returns table
as return
(
	select Distinct Game.GameName, Game.[Image],Studio.StudioName, Game.Plat, Game.Lang,
					STUFF((SELECT '; ' + Tag.TagName 
							FROM Tag
							WHERE Game.GameID = Game.GameID
							FOR XML PATH('')), 1, 1, '') [Tags], 
					Game.Price, Game.Download, Game.Size, Game.Descri, Game.Release
					from Game
	inner join Category on Category.GameID = Game.GameID
	inner join Tag on Category.TagName = Tag.TagName
	inner join Studio on Studio.StudioID = Game.StudioID
	where Game.GameName = @GameName
)
go

-- Get All Tag

create function [dbo].[func_GetAllTags]()
returns table
as
return(
    select *from Tag
    )
go

--
create function [dbo].[func_GetAllGame]()
returns table
as
return(
    select Distinct Game.GameName, Game.[Image],Studio.StudioName, Game.Plat, Game.Lang,
					STUFF((SELECT '; ' + Tag.TagName 
							FROM Tag
							WHERE Game.GameID = Game.GameID
							FOR XML PATH('')), 1, 1, '') [Tags], 
					Game.Price, Game.Download, Game.Size, Game.Descri, Game.Release
					from Game
	inner join Category on Category.GameID = Game.GameID
	inner join Tag on Category.TagName = Tag.TagName
	inner join Studio on Studio.StudioID = Game.StudioID
    )
go
-- find codegame theo ten game
create function [dbo].[func_AdminSearchCodeGame](@GameID nvarchar(5))
returns table
as
return(
    select Distinct RedeemCode.Code,Game.GameID,Game.GameName,Studio.StudioName,
					STUFF((SELECT '; ' + Tag.TagName 
							FROM Tag
							WHERE Game.GameID = Game.GameID
							FOR XML PATH('')), 1, 1, '') [Tags],Game.Price, Game.Download,Game.Release
					from Game
	inner join Category on Category.GameID = Game.GameID
	inner join Tag on Category.TagName = Tag.TagName
	inner join Studio on Studio.StudioID = Game.StudioID
	inner join RedeemCode on RedeemCode.GameID = Game.GameID
	where Game.GameID = @GameID
    )
GO
-- Login 
create function [dbo].[func_loginaccount](@username nvarchar(15), @pass nvarchar(16))
returns int
as
begin
    if exists(Select Pass, Users.[Admin] From [dbo].[Users] Where Username = @username and Pass = @pass and Users.[Admin] = 0)
        return 1
    if exists(Select Pass, Users.[Admin] From [dbo].[Users] Where Username = @username and Pass = @pass and Users.[Admin] = 1) 
        return 2
    return 0
end
go
create function [dbo].[func_GetAllStudio]()
returns table
as
return(
    select *from Studio
    )
go
create function [dbo].[func_GetAllGameSingle]()
returns table
as
return(
    select *from Game
    )
go
create function [dbo].[func_GetAllGameAdminbyTag](@TagName nvarchar(40))
returns table
as
return(
    select Distinct Game.GameID, Game.GameName,Studio.StudioName,
					STUFF((SELECT '; ' + Category.TagName 
							FROM Category
							WHERE Category.GameID = Game.GameID
							FOR XML PATH('')), 1, 1, '') [Tags]
					from Game
	inner join Category on Category.GameID = Game.GameID
	inner join Tag on Category.TagName = Tag.TagName
	inner join Studio on Studio.StudioID = Game.StudioID
	where Tag.TagName = @TagName
    )
go
create function [dbo].[func_GetAllCode]()
returns table
as
return(
    select *from RedeemCode
    )
go

-- Tính sale theo tháng
Create Function [dbo].[func_SaleByMonth](@year int)
returns table
as
    return(
        Select Month(Sale.SaleDate) as sale_Month,Sum(Sale.Amount) as sale From Sale
		where (YEAR(Sale.SaleDate) = @year)
		Group by Month(Sale.SaleDate)
    )
GO


-- Tính sale theo năm
Create Function [dbo].[func_SaleByYear]()
returns table
as
    return(
        Select Year(Sale.SaleDate) as sale_Year,Sum(Sale.Amount) as sale From Sale
		Group by Year(Sale.SaleDate)		
    )
GO


--Tính sale của tất cả game theo tháng trong năm
Create Function [dbo].[func_SaleOfAllGameByMonth](@year int,@month int)
returns table
as
    return(
        Select Game.GameName,Sale.Amount
		From 
		(Sale Inner Join Game on Game.GameID = Sale.GameID)
		where (YEAR(Sale.SaleDate) = @year and MONTH(Sale.SaleDate) = @month) 
    )
GO


--Tính sale của tất cả game theo năm
Create Function [dbo].[func_SaleOfAllGameByYear](@year int)
returns table
as
    return(
        Select Game.GameName,Sum(Sale.Amount) as Sale
		From 
		(Sale Inner Join Game on Game.GameID = Sale.GameID)
		where (YEAR(Sale.SaleDate) = @year) 
		Group By Year(Sale.SaleDate),Game.GameName
    )
GO

--Tính sale của game x theo tháng trong năm
Create Function [dbo].[func_SaleOfGameByMonth](@year int,@gamename nvarchar(max))
returns table
as
    return(
        Select Month(Sale.SaleDate) as Sale_Month, Game.GameName,Sale.Amount
		From (Sale Inner Join Game on Game.GameID = Sale.GameID)
		where (YEAR(Sale.SaleDate) = @year and Game.GameName = @gamename)
    )
GO


--Tính sale của game x theo năm
Create Function [dbo].[func_SaleOfGameByYear](@gamename nvarchar(max))
returns table
as
    return(
        Select Year(Sale.SaleDate) as Sale_Year, Game.GameName,Sum(Sale.Amount) as Sale
		From (Sale Inner Join Game on Game.GameID = Sale.GameID)
		where (Game.GameName = @gamename)
		Group by Year(Sale.SaleDate),Game.GameName
    )
GO

-- Full Sale
Create Function [dbo].[func_ShowSaleData]()
returns table
as
	return(
		Select Sale.SaleDate,Game.GameName, Sale.Amount From (Sale inner join Game on Sale.GameID = Game.GameID)
	)
Go

-- Hiện thị game dựa theo tên studio
create function [dbo].[func_ShowGameByStudio](@studioname nvarchar(max))
returns table
as
return
(
	Select Game.GameName, Game.[Image], Game.Price, Studio.StudioName, Studio.Country
		from Game
		inner join Studio on Game.StudioID = Studio.StudioID
		where Studio.StudioName = @studioname
)
go

-- Hiện thị game dựa theo tag
create function [dbo].[func_ShowGameByCate](@uid int ,@gamecate nvarchar(40))
returns table
as
return
(
	select Distinct Game.GameName, Game.[Image],Studio.StudioName, Game.Plat, Game.Lang,
					STUFF((SELECT '; ' + Tag.TagName 
							FROM Tag
							WHERE Game.GameID = Game.GameID
							FOR XML PATH('')), 1, 1, '') [Tags], 
					Game.Price, Game.Download, Game.Size, Game.Descri, Game.Release
					from Game
	inner join Category on Category.GameID = Game.GameID
	inner join Tag on Category.TagName = Tag.TagName
	inner join Studio on Studio.StudioID = Game.StudioID
	inner join Lib on Game.GameID = Lib.GameID
	inner join Users on Users.UserID = Lib.UserID
	where Category.TagName = @gamecate and Lib.UserID = @uid
)
go

-- Hiện thị game dựa theo tên DisEvent
create function [dbo].[func_ShowGameByDisEvent](@disname nvarchar(max))
returns table
as return
(
	select Distinct DisGame.GameID, Game.GameName, Studio.StudioName, DisEvent.Amount, Game.Price,(select  [dbo].[func_PriceApplyDiscount](Game.Price, DisEvent.Amount)) as DisPrice from DisGame
	inner join DisEvent on DisGame.DisID = DisEvent.DisID
	inner join Game on DisGame.GameID = Game.GameID
	inner join Studio on Studio.StudioID = Game.StudioID
	where DisEvent.DisName = @disname
)
go

-- Hiện thị game dựa theo Redeemcode
create function [dbo].[func_ShowGamebyRedeemcode](@uid int, @code nvarchar(10))
returns table
as
return
(
	select Distinct Game.GameName, Game.[Image],Studio.StudioName, Game.Plat, Game.Lang,
					STUFF((SELECT '; ' + Tag.TagName 
							FROM Tag
							WHERE Game.GameID = Game.GameID
							FOR XML PATH('')), 1, 1, '') [Tags], 
					Game.Price, Game.Download, Game.Size, Game.Descri, Game.Release
					from Game
	inner join Category on Category.GameID = Game.GameID
	inner join Tag on Category.TagName = Tag.TagName
	inner join Studio on Studio.StudioID = Game.StudioID
	inner join RedeemCode on Game.GameID = RedeemCode.GameID
	inner join Users on Users.UserID = RedeemCode.UserID
	where RedeemCode.Code = @code and RedeemCode.UserID = @uid
)
go

-- lấy thông tin user dựa vào id
create function [dbo].[func_GetInfoUser](@uid int)
returns table
as
	return(
	select Users.Username, Users.DOB, Users.Wallet, Users.Spent, Users.[Admin] from Users
	where UserID = @uid
	)
go


-- lấy thông tin của tất cả user
Create function [dbo].[func_GetAllUser]()
returns table
as
return
(
	select Users.UserID,Users.Username, Users.DOB, Users.Wallet, Users.Spent, Users.[Admin] from Users
)
go

-- Cấp quyền Admin cho tài khoản
create procedure [dbo].[sp_SetAdminMode](@uid int)
as
	Update Users
	set [Admin] = 1
	where Users.UserID = @uid
go

-- Cấp quyền User cho tài khoản
create procedure [dbo].[sp_SetUserMode](@uid int)
as
	Update Users
	set [Admin] = 0
	where Users.UserID = @uid
go

-- Hiện thị game mà user đã mua trước đó
Create function [dbo].[func_GetGameOfUser](@uid int, @gid nvarchar(5))
returns table
as
return
(
    --select Game.GameID, Game.GameName, Game.Plat, Game.Lang, Game.Download, Game.Size, RedeemCode.Code, Game.Descri, Game.[Image]
                    --from Users
	--left join RedeemCode on RedeemCode.UserID = Users.UserID
    --left join Game on RedeemCode.GameID = Game.GameID
    --where Users.UserID = @uid and Game.GameID = @gid
	--Select Game.GameID, Game.GameName, Game.Plat, Game.Lang, Game.Download, Game.Size, RedeemCode.Code, Game.Descri, Game.[Image]
	--From RedeemCode join Game
	--on RedeemCode.GameID = Game.GameID
	--Where RedeemCode.GameID = @gid and RedeemCode.UserID = @uid

	Select Lib_Game.GameID, Lib_Game.GameName, Lib_Game.Plat, Lib_Game.Lang, Lib_Game.Download, Lib_Game.Size, RedeemCode.Code, Lib_Game.Descri, Lib_Game.[Image]
	From RedeemCode full join ( Select Game.GameID, Game.GameName, Game.Plat, Game.Lang, Game.Download, Game.Size,Game.Descri, Game.[Image]
							From Game full join (Select Users.UserID, Lib.GameID
											From Users full join Lib
											on Users.UserID = Lib.UserID
											--Where Users.UserID = @uid
											) as User_Lib
							on Game.GameID = User_Lib.GameID ) as Lib_Game
	on RedeemCode.GameID = Lib_Game.GameID
	where RedeemCode.GameID = @gid and RedeemCode.UserID = @uid
)
go

-- Hiển thị thông tin của các game hiện đang có event
Create function [dbo].[func_DisAllEvent]()
returns table
as return(Select * from DisEvent)
go


-- Hiển thị 100 game mới nhất hiện có của hệ thống
Create function [dbo].[func_GetNewestGame]()
returns table
as 
	return(Select top 100 percent * from Game Order by Release desc)
go

-- Hiển thị 10 game có lượt download nhiều nhất
create function [dbo].[func_GetTopMostDownloaded]()
returns table
as
	return(Select top 10 * from Game Order by Download desc)
go

-- Kiểm tra xem có đủ tiền để mua game hay không
Create function [dbo].[func_BuyGameCheck](@gid nvarchar(5), @uid int)
returns int
as
begin
	declare @price int
	set @price = (Select TOP 1 Price from Game where GameID = @gid)
	declare @uwallet int
	set @uwallet = (Select TOP 1 Wallet from Users where UserID = @uid)
	if exists(select * from Game where GameID = @gid)
		if @uwallet >= @price
			return 1
		return 0
	return 0
end
go

-- Tìm tên game
Create function [dbo].[func_SearchGame](@gamename nvarchar(max))
returns table
as
	return(Select * from Game where Game.GameName = @gamename)
go

-- Tìm RedeemCode
Create function [dbo].[func_SearchRedeemCode](@code nvarchar(10))
returns table
as
	return(Select * from RedeemCode where RedeemCode.Code = @code)
go

-- Tìm Studio
Create function [dbo].[func_SearchStudio](@studioname nvarchar(max))
returns table
as
	return(Select * from Studio where Studio.StudioName = @studioname)
go

-- Tìm tag
Create function [dbo].[func_SearchTag](@tagname nvarchar(max))
returns table
as
	return(Select * from Tag where Tag.TagName = @tagname)
go

--Tìm UserID
create function [dbo].[func_FindUserID](@username nvarchar(15), @password nvarchar(16))
returns int
	as
	begin
		return(select UserID from Users where Username = @username and Pass = @password)
	end
go



-- Create TRIGGERS

create trigger Delete_Tags
on dbo.Tag
instead of delete
as
	declare @TagName nvarchar(40) select @TagName = TagName from deleted

	Alter table Category drop constraint FK_Category_Tag
	Alter table Category drop constraint FK_Category_Game

	delete Category from Category
	where Category.TagName = @TagName

	delete Tag from Tag
	where Tag.TagName = @TagName

	Alter table Category add CONSTRAINT FK_Category_Game FOREIGN KEY (GameID) REFERENCES Game(GameID) 
	Alter table Category add CONSTRAINT FK_Category_Tag FOREIGN KEY (TagName) REFERENCES Tag(TagName)
go

Create trigger Insert_Category
on dbo.Category
instead of insert
as
	declare @TagName nvarchar(40) select @TagName = TagName from inserted
	declare @GameID nvarchar(5) select @GameID = GameID from inserted
	if not exists(select * from Category where @TagName = Category.TagName and @GameID = Category.GameID)
		insert into Category values(@TagName,@GameID)
go

Create trigger Insert_Studio
on dbo.Studio
instead of insert
as
	declare @StudioName nvarchar(max) select @StudioName = StudioName from inserted
	declare @Country nvarchar(max) select @Country = Country from inserted
	if not exists(select * from Studio where @StudioName = Studio.StudioName)
		insert into Studio values(@StudioName,@Country)
go

create trigger Update_Studio
on dbo.Studio
instead of update
as
	declare @StudioNameOld  nvarchar(max) select @StudioNameOld = StudioName from deleted
	declare @StudioName nvarchar(max) select @StudioName = StudioName from inserted
	declare @Country nvarchar(max) select @Country = Country from inserted
	if not exists(select Studio.StudioName from Studio where @StudioName = Studio.StudioName)
	begin
		update Studio set StudioName = @StudioName , Country=@Country where StudioName = @StudioNameOld
	end
	else
	begin
		update Studio set Country=@Country where StudioName = @StudioNameOld
	end
go

Create trigger Delete_Studio
on dbo.Studio
instead of delete
as
    declare @StudioID int select @StudioID = StudioID from deleted
    update Game
    set Game.StudioID = NULL
    from Game
    where Game.StudioID = @StudioID
    delete from Studio where Studio.StudioID = @StudioID
go

Create trigger Delete_Users
on dbo.Users
instead of delete
as
    declare @UserID int select @UserID = UserID from deleted

    Alter table Lib drop constraint FK_GameLib 
    Alter table Lib drop constraint FK_UserLib

    delete Lib from Lib
    where Lib.UserID = @UserID

    delete Users from Users
    where Users.UserID = @UserID

    Alter table Lib add constraint FK_GameLib foreign key (GameID) references Games(GameID)
    Alter table Lib add constraint FK_UserLib foreign key (UserID) references Users(UserID)
go

create trigger Delete_DisEvent
on dbo.DisEvent
instead of delete
as
    declare @DisID int select @DisID = DisID from deleted

    Alter table DisGame drop constraint FK_DisGame_DisEvent 
    Alter table DisGame drop constraint FK_Disgame_Game

    delete DisGame from DisGame
    where DisGame.DisID = @DisID

    delete DisEvent from DisEvent
    where DisEvent.DisID = @DisID

    Alter table DisGame add constraint FK_DisGame_DisEvent foreign key (DisID) references DisEvent(DisID)
    Alter table DisGame add constraint FK_Disgame_Game foreign key (GameID) references Game(GameID)
go


create TRIGGER DeleteGame ON dbo.Game
instead of delete
as
    declare @GameID nvarchar(5) select @GameID = GameID from deleted
    
	Alter table Lib drop CONSTRAINT FK_GameLib
	Alter table Lib drop CONSTRAINT FK_UserLib
	Alter table DisGame drop CONSTRAINT FK_DisGame_DisEvent
	Alter table DisGame drop CONSTRAINT FK_DisGame_Game
	Alter table Category drop CONSTRAINT FK_Category_Game
	Alter table Category drop CONSTRAINT FK_Category_Tag
	Alter table RedeemCode drop CONSTRAINT FK_RedeemCode
	Alter table Sale drop CONSTRAINT FK_Sale

	delete Game from Game
	where Game.GameID = @GameID

	delete Lib from Lib
	where Lib.GameID = @GameID

	delete RedeemCode from RedeemCode
	where RedeemCode.GameID = @GameID

	delete DisGame from DisGame
	where DisGame.GameID = @GameID

	delete Category from Category
	where Category.GameID = @GameID

	delete Sale from Sale
	where Sale.GameID = @GameID

	Alter table Lib add CONSTRAINT FK_GameLib FOREIGN KEY (GameID) REFERENCES Game(GameID)
	Alter table Lib add CONSTRAINT FK_UserLib FOREIGN KEY (UserID) REFERENCES Users(UserID)
	Alter table DisGame add CONSTRAINT FK_DisGame_DisEvent FOREIGN KEY (DisID) REFERENCES DisEvent(DisID)
	Alter table DisGame add CONSTRAINT FK_DisGame_Game FOREIGN KEY (GameID) REFERENCES Game(GameID)
	Alter table Category add CONSTRAINT FK_Category_Game FOREIGN KEY (GameID) REFERENCES Game(GameID)
	Alter table Category add CONSTRAINT FK_Category_Tag FOREIGN KEY (TagName) REFERENCES Tag(TagName)
	Alter table RedeemCode add CONSTRAINT FK_RedeemCode FOREIGN KEY (GameID) REFERENCES Game(GameID)
	Alter table Sale add CONSTRAINT FK_Sale FOREIGN KEY (GameID) REFERENCES Game(GameID)
go

Create procedure [dbo].[sp_BuyGame]
@gameid nvarchar(5),
@userid int
as
--begin tran
begin
	begin TRANSACTION
	BEGIN TRY 
	declare @today date
	set @today = GETDATE()

	declare @discountamount int
	if exists(Select Top 1 DisEvent.Amount from Game 
						inner join DisGame on Game.GameID = DisGame.GameID
						inner join DisEvent on DisEvent.DisID = DisGame.DisID
						where DisEvent.DayBegin <= @today and DisEvent.DayEnd >= @today)
		set @discountamount = (Select Top 1 DisEvent.Amount from Game 
							inner join DisGame on Game.GameID = DisGame.GameID
							inner join DisEvent on DisEvent.DisID = DisGame.DisID
							where DisEvent.DayBegin <= @today and DisEvent.DayEnd >= @today)

	else set @discountamount = 0
	-- kiểm tra người đó có mua game chưa
	if exists(select * from RedeemCode where GameID = @gameid and UserID = @userid)
	begin
		rollback
		return
	end

	-- Chọn redeem code chưa có chủ sở hữu
	declare @chosenRC nvarchar(10)
	set @chosenRC = (Select top(1) Code from RedeemCode where GameID = @gameid and UserID is null)
	
	if @chosenRC is null
	begin
		rollback
		return
	end
	
	-- Giao quyền sở hữu redeem code cho user
	update RedeemCode
	set UserID = @userid
	where Code = @chosenRC

	-- Lấy giá game
	declare @gamePrice int
	set @gamePrice = (select top(1) Price From Game where GameID = @gameid)
	
	declare @gamePriceDiscount int
	select @gamePriceDiscount = dbo.func_PriceApplyDiscount(@gamePrice,@discountamount)
	--set @gamePriceDiscount = @gamePrice


	-- Trừ tiền user
	update Users
	set Wallet = Wallet - @gamePriceDiscount, Spent = Spent + @gamePriceDiscount
	where UserID = @userid
	
	-- Thêm game vào thư viện user
 	insert into Lib Values (@gameid, @userid, @today)

	-- Cập nhật lượt tải của game
	update Game
	set Download = Download + 1
	where GameID = @gameid

	-- Thêm doanh thu vào sale
	if exists(select * from Sale where GameID = @gameid and SaleDate = @today)
		update Sale
		set Amount = Amount + (Select Price from Game where GameID = @gameid)
	else insert into Sale(GameID,SaleDate,Amount) Values(@gameid,@today,@gamePriceDiscount)

	COMMIT TRANSACTION

	END TRY
    BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH

	--if(@@ERROR != 0)
		--rollback
end
--commit tran
go

--Lấy thông tin của user
create function [dbo].[func_Get1User](@uid int)
returns table
as
	return (select * from Users where UserID = @uid)
go


-- Hiển thị các game theo tag ở HomePage
Create function [dbo].[func_GetGameByTagForHomePage](@TagName nvarchar(40))
returns table
as
    return(Select distinct Game.GameID, Game.[Image], Game.GameName, Game.Price
    from Game
    inner join Category on Category.GameID = Game.GameID
    inner join Tag on Category.TagName = Tag.TagName
    inner join Studio on Studio.StudioID = Game.StudioID
    where Tag.TagName = @TagName)
go
Create function [dbo].[func_GetGameNameOfUser](@uid int)
returns table
as
return
(
    select Distinct Game.GameID, Game.GameName
                    from Game
    inner join Lib on Game.GameID = Lib.GameID
    inner join Users on Users.UserID = Lib.UserID
    where Users.UserID = @uid
)
go



Create function [dbo].[func_GetFullGameInformation]()
returns table
as
    return( Select Game.*, Studio.StudioName From Game inner join Studio on Game.StudioID = Studio.StudioID )
go




-- Create Login and User for both user and admin

IF NOT EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = 'foradmins')
BEGIN
    CREATE LOGIN foradmins WITH PASSWORD = N'adsupremacy'
END

IF NOT EXISTS
    (SELECT name
     FROM sys.database_principals
     WHERE name = 'anadmin')
BEGIN
    CREATE USER anadmin FOR LOGIN foradmins
END


IF NOT EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = 'forusers')
BEGIN
    CREATE LOGIN forusers WITH PASSWORD = N'justanormalnpc'
END

IF NOT EXISTS
    (SELECT name
     FROM sys.database_principals
     WHERE name = 'anuser')
BEGIN
    CREATE USER anuser FOR LOGIN forusers
END
go

Create procedure [dbo].[sp_getpermission]
as
declare @idColumn int
declare @cmd varchar(max)

select @idColumn = min( rownum ) from cmdtable

while @idColumn is not null
begin
	set @cmd = (select cmd from cmdtable where rownum = @idColumn)
	execute (@cmd)
    select @idColumn = min (rownum) from cmdtable where rownum > @idColumn
end
go
-- grant permission for admid

-- get permission on table
Grant select,insert,delete,references on dbo.Users to anadmin
Grant select,insert,delete,references on dbo.Tag to anadmin
Grant select,insert,delete,references on dbo.Studio to anadmin
Grant select,insert,delete,references on dbo.Sale to anadmin
Grant select,insert,delete,references on dbo.RedeemCode to anadmin
Grant select,insert,delete,references on dbo.Lib to anadmin
Grant select,insert,delete,references on dbo.Game to anadmin
Grant select,insert,delete,references on dbo.DisEvent to anadmin
Grant select,insert,delete,references on dbo.DisGame to anadmin
Grant select,insert,delete,references on dbo.Category to anadmin
go

-- get permission on Scalar-valued Functions
Select ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS rownum, 'grant execute on dbo.'+ name + ' to anadmin' as cmd
into cmdtable
from sys.objects
where type = 'fn' and is_ms_shipped = 0
go

execute sp_getpermission
go

drop table cmdtable
go

-- get permission on Tables-valued Functions
Select ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS rownum, 'grant select on dbo.'+ name + ' to anadmin' as cmd
into cmdtable
from sys.objects
where type in ('IF', 'TF', 'FT') and is_ms_shipped = 0
go

execute sp_getpermission
go

drop table cmdtable
go

-- get permission on Procedures
Select ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS rownum, 'grant execute on dbo.'+ name + ' to anadmin' as cmd
into cmdtable
from sys.objects
where type ='p'
go

execute sp_getpermission
go

drop table cmdtable
go

-- grant permission for user

-- get permission on table
Grant select,insert,references on dbo.Users to anuser
Grant select,insert,delete,references on dbo.Lib to anuser
Grant select,insert,delete,references on dbo.Game to anuser
Grant select,insert,delete,references on dbo.Category to anuser
Grant select,references on dbo.DisEvent to anuser
Grant select,references on dbo.DisGame to anuser
Grant select,references on dbo.Tag to anuser
Grant select,update,references on dbo.RedeemCode to anuser
Grant select,insert,references on dbo.Sale to anuser
Grant select,references on dbo.Studio to anuser
go

-- get permission on Scalar-valued Functions
Select ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS rownum, 'grant execute on dbo.'+ name + ' to anuser' as cmd
into cmdtable
from sys.objects
where type = 'fn' and is_ms_shipped = 0
go

execute sp_getpermission
go

drop table cmdtable
go

-- get permission on Tables-valued Functions
--Grant select on dbo.func_DissAllEvent to anuser
Grant select, references on dbo.func_FindGame to anuser
Grant select, references on dbo.func_Get1User to anuser
Grant select, references on dbo.func_GetAllGame to anuser
Grant select, references on dbo.func_GetAllGameSingle to anuser
Grant select, references on dbo.func_GetAllStudio to anuser
Grant select, references on dbo.func_GetAllTags to anuser
Grant select, references on dbo.func_GetAllUser to anuser
Grant select, references on dbo.func_GetFullGameInformation to anuser
Grant select, references on dbo.func_GetGameByTagForHomePage to anuser
Grant select, references on dbo.func_GetGameNameOfUser to anuser
Grant select, references on dbo.func_GetGameOfUser to anuser
Grant select, references on dbo.func_GetNewestGame to anuser
Grant select, references on dbo.func_GetStudioFromID to anuser
Grant select, references on dbo.func_GetTopMostDownloaded to anuser
Grant select, references on dbo.func_SearchGame to anuser
Grant select, references on dbo.func_ShowLibUser to anuser

--Grant select on dbo.func_GameCategories to anuser
--Grant select on dbo.func_GetAllGame to anuser
--Grant select on dbo.func_FindGame to anuser
--Grant select on dbo.func_ShowGameByTag to anuser
--Grant select on dbo.func_ShowLibByTag to anuser
--Grant select on dbo.func_ShowLibUser to anuser
go

-- get permission on Procedures
--Grant execute on dbo.sp_AddFund to anuser
Grant execute on dbo.sp_AddNewGameToLib to anuser
Grant execute on dbo.sp_AddNewSale to anuser
Grant execute on dbo.sp_AddNewUser to anuser
Grant execute on dbo.sp_BuyGame to anuser
Grant execute on dbo.sp_UpdateUserProfile to anuser
Grant execute on dbo.sp_UpdateUserWallet to anuser
--Grant execute on dbo.sp_UpdateUser to anuser
go



-- Tạo tài khoản admin mặc định
execute dbo.sp_AddNewUser 'admin', '123!@#'
execute dbo.sp_SetAdminMode 1

-- Tạo tài khoản user mặc định
execute dbo.sp_AddNewUser 'defaultuser', '123!@#'