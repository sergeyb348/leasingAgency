use leasingAgency_BD

drop table User_Table

create table User_Table
(
	ID_User int primary key identity(1, 1),
	User_Login char(30) unique NOT NULL,
	User_Password char(32) NOT NULL
)

select * from User_Table;