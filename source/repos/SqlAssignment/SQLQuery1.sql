
-- Help her to perform the following operations using functions :

CREATE TABLE EMPLOYEE(empId INT PRIMARY KEY, empName NCHAR(50), job NCHAR(50), manager INT, hireDate DATETIME, salary INT, commision INT, deptId INT);

-- 1. Display details of all the employees from Employee table.

CREATE OR ALTER FUNCTION FetchEmployeeDetailsNew()
RETURNS TABLE
AS RETURN 
(SELECT * FROM employee)
GO

-- 2. Add a new record to Employee table. 8088, 'Ramesh', 'CLERK', 8789, '2022-08-09', 4500.00, NULL, 10

CREATE OR ALTER PROCEDURE AddEmployee
(@empId INT, @empName NCHAR(50), @job NCHAR(50), @manager INT, @hireDate DATETIME, @salary INT, @commision INT, @deptId INT)
AS
BEGIN
    INSERT INTO EMPLOYEE (empId, empName, job, manager, hireDate, salary, commision, deptId)
    VALUES (@empId, @empName, @job, @manager, @hireDate, @salary, @commision, @deptId); 
END;

EXEC AddEmployee 80899, 'Suresh', 'CLERK', 8789, '2022-08-09', 4500.00, NULL, 10;

-- 3. Count the number of records in Employee table

CREATE OR ALTER FUNCTION GetEmployeeCount()
RETURNS INT
AS
BEGIN
    RETURN (SELECT COUNT(*) FROM EMPLOYEE);
END;

-- 4. Search the details of those employees who work in deptno 30.

CREATE OR ALTER FUNCTION GetEmployeesInDept(@deptId INT)
RETURNS TABLE
AS
RETURN
    SELECT * FROM EMPLOYEE WHERE deptId = @deptId;

-- 5. Sort the records in Employee table

CREATE OR ALTER FUNCTION GetSortedEmployeeDetails()
RETURNS TABLE
AS
RETURN
    SELECT * FROM EMPLOYEE ORDER BY empName ASC;

-- 6. Update the salary of the last inserted record to 500.

CREATE OR ALTER PROCEDURE UpdateLastInsertedRecord
AS
BEGIN
  UPDATE EMPLOYEE SET salary = 500 WHERE empId = (SELECT MAX(empId) FROM EMPLOYEE);  
END;

-- 7. Delete the last inserted record.

CREATE OR ALTER PROCEDURE DeleteLastInsertedRecord
AS
BEGIN
   DELETE FROM EMPLOYEE WHERE hireDate = (SELECT MAX(hireDate)FROM EMPLOYEE);
END


-- SQL ASSIGNMENT 2 --

CREATE TABLE PRODUCT_TABLE(productCode NCHAR(10) PRIMARY KEY, productName NCHAR(100),price INT, quantityRemaining INT, quantitySold INT);

CREATE TABLE SALES_TABLE(orderId INT IDENTITY(1,1) PRIMARY KEY,orderDate DATETIME, productCode NCHAR(10),quantityOrder INT, salePrice INT, CONSTRAINT fk_sales FOREIGN KEY (productCode) REFERENCES PRODUCT_TABLE(productCode));

-- CHECK AND ALTER FOR IPHONE 13 PRO MAX

CREATE OR ALTER PROCEDURE checkIphone13Max @quantity INT
AS
BEGIN
  DECLARE @price INT;

  IF EXISTS (SELECT price FROM PRODUCT_TABLE WHERE productCode = 'P1' AND quantityRemaining >= @quantity)
  BEGIN
    UPDATE PRODUCT_TABLE 
    SET quantityRemaining = quantityRemaining - @quantity, 
        quantitySold = quantitySold + @quantity
    WHERE productCode = 'P1' AND quantityRemaining >= @quantity;

    SELECT @price = price FROM PRODUCT_TABLE WHERE productCode = 'P1';

    INSERT INTO SALES_TABLE (orderDate, productCode, quantityOrder, salePrice) 
    VALUES (CURRENT_TIMESTAMP, 'P1', @quantity, @price);

    SELECT 'Sale completed successfully.';
  END
  ELSE
  BEGIN
    SELECT 'Not enough stock available.';
  END
END

-- CHECK AND ALTER FOR ALL PRODUCT 

CREATE OR ALTER PROCEDURE checkProduct @productName NCHAR(100), @quantity INT
AS
BEGIN
  DECLARE @price INT;

  IF EXISTS (SELECT price FROM PRODUCT_TABLE WHERE productName = @productName AND quantityRemaining >= @quantity)
  BEGIN
    UPDATE PRODUCT_TABLE 
    SET quantityRemaining = quantityRemaining - @quantity, 
        quantitySold = quantitySold + @quantity
    WHERE productName = @productName AND quantityRemaining >= @quantity;

    SELECT @price = price FROM PRODUCT_TABLE WHERE productName = @productName;

    INSERT INTO SALES_TABLE (orderDate, productCode, quantityOrder, salePrice) 
    VALUES (CURRENT_TIMESTAMP, 'P1', @quantity, @price);

    SELECT 'Sale completed successfully.';
  END
  ELSE
  BEGIN
    SELECT 'Not enough stock available.';
  END
END

INSERT INTO PRODUCT_TABLE VALUES ('P1','Iphone 13 pro max',1200,1000,0);
INSERT INTO PRODUCT_TABLE VALUES ('P2','Airpod Pro',900,700,0);
INSERT INTO PRODUCT_TABLE VALUES ('P3','Macbook Pro 16',400,10,0);
INSERT INTO PRODUCT_TABLE VALUES ('P4','Ipad Air',200,5,0);
INSERT INTO PRODUCT_TABLE VALUES ('P5','Iphone 11',1600,30,0);

EXEC checkIphone13Max 200;


