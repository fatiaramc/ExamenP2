create database clima
go
use clima
go

create table users(
	iduser int primary key identity(1,1),
	username nvarchar(50) not null,
	email nvarchar(60) not null,
	pass nvarchar(15) not null,
);
go

insert into users
values
('fati','fatima@gmail.com','pass123')
go

create procedure getusers
as
select * from users
go

create procedure adduser
(
	@username nvarchar(50),
	@email nvarchar(60),
	@pass nvarchar(15),
	@haserror bit out
)
as
begin try
	set @haserror = 0;
	insert into users
	values
	(@username,@email,@pass)
end try
begin catch
	set @haserror = 1;
end catch
go

create procedure getuser
(
	@username nvarchar(50),
	@haserror bit out
)
as
begin try
	set @haserror = 0;
	select idUser, username, email, pass from users where username=@username
end try
begin catch
	set @haserror=1;
end catch
go

create table cities(
	id int primary key identity(1,1),
	idUser int not null,
	city nvarchar(50) not null
);
go

insert into cities
values(1,'Rome') 
go

create procedure getcities
(
	@idUser int,
	@haserror bit out
)
as
begin try
	set @haserror = 0;
	select city from cities where idUser = @idUser
end try
begin catch
	set @haserror=1;
end catch
go

create procedure addcity
(
	@idUser int,
	@city nvarchar(50),
	@haserror bit out
)
as
begin try
	set @haserror = 0;
	insert into cities
	values( @idUser,@city)
end try
begin catch
	set @haserror=1;
end catch
go
