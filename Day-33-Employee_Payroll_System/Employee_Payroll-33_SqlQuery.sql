--Creating Database
create database Employee_payroll_33
use Employee_payroll_33
--Creating Table in Employee_Payroll_33 DataBase
create table employee_payroll
(
Id int primary key NOT NULL identity,
name varchar(50),
phone varchar(15),
address varchar(100),
department varchar(20),
gender varchar(1),
basic_pay money,
deduction money,
taxable_pay money,
tax money,
netpay money,
startDate date
);

--Inserting Records into the Employee_payroll Table
insert into employee_payroll values
('Ansh','9426458950','vikram nagar','ENTC','M','40000','1000','2000','5','37000','2018-08-03'),
('Ganesh','9821558780','Vilas nagar','COMP','M','49000','1000','2450','5','45350','2022-01-02'),
('Dinesh','9845751845','Vasant nagar','ELECT','M','58000','1000','2900','5','53900','2019-08-13'),
('komal','9963568412','Mantri nagar','IT','F','65000','1000','3250','5','60550','2021-11-03'),
('Meena','94005900','Shyam nagar','ENTC','F','35000','1000','1750','5','32050','2020-05-11'),
('Arjun','7741891918','Adarsha nagar','ENTC','M','44000','1000','2200','5','40600','2021-08-25'),
('Aravi','7689585849','Phushpak colony','COMP','F','36000','1000','1800','5','33000','2022-09-23'),
('Nimisha','9426006598','Shardul vihar','COMP','F','66000','1000','3300','5','61500','2017-02-12')

--Display Records of employee_payroll table
select * from employee_payroll 
