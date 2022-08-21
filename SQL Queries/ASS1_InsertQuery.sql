create procedure InsertIntoFootBallLeague 
@MatchID int,
@TeamName1 nvarchar(50),
@TeamName2 nvarchar(50),
@MatchStatus nvarchar(50),
@WinningTeam nvarchar(50),
@Points int
AS
BEGIN
insert into FootBallLeague(MatchId,TeamName1,TeamName2,MatchStatus,WinningTeam,Points) 
values(@MatchID,
@TeamName1,
@TeamName2,
@MatchStatus,
@WinningTeam,
@Points)
END

select * from FootBallLeague

EXEC InsertIntoFootBallLeague 1001,'Italy','France','Win','France',4
EXEC InsertIntoFootBallLeague 1002,'Brazil','Portugal','Draw','',2
EXEC InsertIntoFootBallLeague 1003,'England','Japan','Win','England',4
EXEC InsertIntoFootBallLeague 1004,'USA','Russia','Win','Russia',4
EXEC InsertIntoFootBallLeague 1005,'Portugal','Italy','Draw','',2
EXEC InsertIntoFootBallLeague 1006,'Brazil','France','Win','Brazil',4
EXEC InsertIntoFootBallLeague 1007,'England','Russia','Win','Russia',4
EXEC InsertIntoFootBallLeague 1008,'Japan','USA','Draw','',2
select * from FootBallLeague


create procedure WinningTeams
AS
BEGIN
select * from FootBallLeague where MatchStatus='Win'
END

EXEC WinningTeams 

select * from FootBallLeague

create procedure DrawTeams
AS
BEGIN
select * from FootBallLeague where MatchStatus='Draw'
END

EXEC DrawTeams

create procedure JapanMatchDetails
AS
BEGIN
select * from FootBallLeague where TeamName1='Japan' or TeamName2='Japan'
END

EXEC JapanMatchDetails

select * from FootBallLeague