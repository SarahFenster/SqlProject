create table Products 
(
Id int identity(1,1) primary key,
CategoryId int,
Name varchar(30),
Price int,
Description varchar(100),
Image varchar(20)
Constraint fk_product_category foreign key(CategoryId)references Categories(Id)
)