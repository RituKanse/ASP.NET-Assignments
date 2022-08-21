create procedure InsertIntoBusInfo

@BoardingPoint nvarchar(50),
@TravelDate datetime,
@Amount decimal,
@Rating int,
@BusId int out
AS
BEGIN
insert into BusInfo(BoardingPoint,TravelDate,Amount,Rating) 
values(@BoardingPoint,@TravelDate,@Amount,@Rating)
select @BusId=SCOPE_IDENTITY()
END

select * from BusInfo

EXEC InsertIntoBusInfo 'BGL','2017-06-18',400.65,2
EXEC InsertIntoBusInfo 'HYD','2017-10-05',600.00,3
EXEC InsertIntoBusInfo 'CHN','2016-07-25',445.95,3
EXEC InsertIntoBusInfo 'PUN','2017-12-10',543.00,4
EXEC InsertIntoBusInfo 'MUM','2017-01-28',500.50,4
EXEC InsertIntoBusInfo 'PUN','2016-03-27',333.55,3
EXEC InsertIntoBusInfo 'MUM','2016-11-06',510.00,4




create procedure Bus_View
AS
BEGIN
select BusId, BoardingPoint from BusInfo where Rating>3
END

EXEC Bus_View

select * from BusInfo

create procedure DetailsByAmount
AS
BEGIN
select BoardingPoint, TravelDate from BusInfo where Amount>450
END

EXEC DetailsByAmount

create procedure DetailsByDate
AS
BEGIN
select BusId, BoardingPoint from BusInfo where TravelDate='2017-12-10'
END

EXEC DetailsByDate