     CREATE DATABASE GOODFOOD
     GO   

	 use goodfood
	 go

	 create table [dbo].[custormer](
		custormer_ID int IDENTITY(0,1) not null,
		_name varchar(20) NULL,
		nickname varchar(20) NULL,
		phone_number varchar(30) NULL,
		cellphone varchar(30) NULL,
		custormer_address  varchar(100) NULL,
		
        PRIMARY KEY(custormer_ID)
	 )



	 create table _order(
		order_id int IDENTITY(0,1) ,
		custormer_ID int,
		_DATE datetime,
		totalprice decimal(10,2),
		delivery_date datetime,
		delivery_adress  varchar(100),
		phone varchar(30),
		cellphone varchar(30),
		delivery_check bit DEFAULT 0,
		pay_check bit DEFAULT 0,
		lastdate datetime,
		
		 PRIMARY KEY(order_id),
		
         FOREIGN KEY (custormer_ID) REFERENCES custormer(custormer_ID) ON UPDATE CASCADE ON DELETE SET NULL
		 	 )


	 create table product(
	 product_id int IDENTITY(0,1) ,
	 product_name varchar(50),
	 product_cost decimal(10,2),
	 product_price decimal(10,2),
	  PRIMARY KEY(product_id)
	 )

	 create table order_detail(
		order_id int ,
		details int,
		product_id  int,
		quantity int,
		--Discount decimal(4,2),
		Subtotal decimal(10,2),

		PRIMARY KEY (order_id, details),
		FOREIGN KEY (order_id) REFERENCES _order(order_id) ON UPDATE CASCADE ,
		FOREIGN KEY (product_id) REFERENCES product(product_id) ON UPDATE CASCADE ON DELETE SET NULL,
	 )

	 insert into custormer values ('普通客人','普通客人','','','')





	 insert into custormer values ('AA','AAa','AAAA','07aaaa','09aaaa')
	 insert into custormer values ('AB','AAb','AAAb','07bbbb','09bbbb')
	 insert into custormer values ('AC','AAc','AAAc','07cccc','09cccc')

	 insert into _order (custormer_ID,totalprice) values (1,400)
	 insert into _order (custormer_ID,totalprice) values (2,500)

	 
	 insert into product (product_name) values('AAA')
	 insert into product (product_name) values('BBB')



	 	 insert into _order (totalprice)  values (300)


	 select*
	 from custormer

	 
	 select*
	 from product
	 
	 drop table order_detail
	 drop table  _order
	 drop table  [custormer]
	 drop table product
	 
	 select * from custormer where _name like '1'
	 delete from custormer where _name = ''


	 select * from custormer where custormer_ID= 65

	 

	 select*from _order where a

	 
	 insert into _order(totalprice) values (300)
	 insert into _order(totalprice) values (400)

	 insert into _order(totalprice,delivery_check,pay_check) values (400,true,fales)
	 
	 
	 delivery_check bit DEFAULT 0,
		pay_check bit DEFAULT 0,


		select *
		into _order
		from ordertem



		  ALTER TABLE product
  ALTER  COLUMN product_cost decimal(10,2)

select *  
from _order 
where custormer_ID=(select custormer_ID from custormer where _name ='普通客人')



select sum(totalprice) as so 
from _order 
where 
(custormer_ID=(select custormer_ID from custormer where _name='阿貓')) and (_DATE > '2018-1-1' and _DATE<'2019-1-1')




select sum(totalprice) as so from _order where (custormer_ID = (select custormer_ID from custormer where _name='阿貓')  and (_DATE > '2018-6-4' and _DATE < '2018-6-26')





        CREATE TABLE dairy (
         _id INTEGER IDENTITY(0,1) PRIMARY KEY , 
         title TEXT , 
         content nvarchar(MAX), 
         _Date date,
         place TEXT,
         picture TEXT,
         _public TEXT,
         upload TEXT) 