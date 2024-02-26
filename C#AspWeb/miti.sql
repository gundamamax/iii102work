create database mi


use mi 
go



drop table ANSWER
drop table question
drop table member
go

create table member(
M_ID int primary key IDENTITY,
M_NAME nvarchar(50),
M_PASS NVARCHAR(50)
)

insert into member values ('AAAAA','AAAAAAAA')


create table question(
Q_ID int primary key IDENTITY,
M_ID int ,
Q_TITLE nvarchar(50),
Q_contents  NVARCHAR(max),
Q_ANSWER NVARCHAR(50),
Q_answered bit DEFAULT 0
 FOREIGN KEY (M_ID) REFERENCES member (M_ID)
)


create table ANSWER(
A_ID int primary key IDENTITY,
Q_ID int ,
M_ID int ,
A_ANSWER NVARCHAR(50),
A_ANSWERdetail  NVARCHAR(max),
A_CORRECT bit 

 FOREIGN KEY (Q_ID) REFERENCES question (Q_ID),
 FOREIGN KEY (M_ID) REFERENCES member (M_ID)
)



/*SELECT q.Q_TITLE,b.M_NAME
 FROM [question] as q inner join member as b on q.M_ID=b.M_ID*/