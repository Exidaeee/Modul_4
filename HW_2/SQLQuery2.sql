/****** Script for SelectTopNRows command from SSMS  ******/
----------------------������� �1-----------------------------
--������� ��� ���������� �� ������� Sales.Customer 
-------------------------------------------------------------
SELECT *
FROM [AdventureWorks2019].[Sales].[Customer]
--  --------------------������� �2-----------------------------
--������� ��� ���������� �� ������� Sales.Store ��������������� 
--�� Name � ���������� �������
-------------------------------------------------------------
SELECT*
FROM [AdventureWorks2019].[Sales].[Store]
ORDER BY Name
-- --------------------������� �3-----------------------------
--������� �� ������� HumanResources.Employee ��� ����������
--� ������ �����������, ������� �������� ����� 1989-09-28
-------------------------------------------------------------
SELECT TOP(10)*
FROM [AdventureWorks2019].[HumanResources].[Employee]
WHERE BirthDate > '1989-09-28'
----------------------������� �4-----------------------------
--������� �� ������� HumanResources.Employee �����������
--� ������� ��������� ������ LoginID �������� 0.
--������� ������ NationalIDNumber, LoginID, JobTitle.
--������ ������ ���� ������������� �� JobTitle �� ��������
-------------------------------------------------------------
SELECT [NationalIDNumber]
      ,[LoginID]
	  ,[JobTitle]
FROM [AdventureWorks2019].[HumanResources].[Employee]
WHERE LoginID LIKE '%0'
ORDER BY JobTitle DESC
----------------------������� �5-----------------------------
--������� �� ������� Person.Person ��� ���������� � �������, ������� ���� 
--��������� � 2008 ���� (������� �� ������� Person.Person ��� ���������� � �������, ������� ���� 
--��������� � 2008 ���� (ModifiedDate) � MiddleName ��������) � MiddleName ��������
--�������� � Title �� �������� �������� 
-------------------------------------------------------------
SELECT *
FROM [AdventureWorks2019].[Person].[Person]
WHERE ModifiedDate BETWEEN '2008-01-01 00:00:00' AND '2008-12-31 23:59:59' AND MiddleName IS NOT NULL AND Title IS NULL
----------------------������� �6-----------------------------
--������� �������� ������ (HumanResources.Department.Name) ��� ����������
--� ������� ���� ����������
--������������ ������� HumanResources.EmployeeDepartmentHistory � HumanResources.Department
-------------------------------------------------------------
SELECT DISTINCT Department.Name
FROM [AdventureWorks2019].[HumanResources].[EmployeeDepartmentHistory]
JOIN HumanResources.Department
ON EmployeeDepartmentHistory.DepartmentID = Department.DepartmentID
----------------------������� �7-----------------------------
--������������ ������ �� ������� Sales.SalesPerson �� TerritoryID
--� ������� ����� CommissionPct, ���� ��� ������ 0
-------------------------------------------------------------
SELECT TerritoryID, SUM(CommissionPct) as TotalCommission
FROM [AdventureWorks2019].[Sales].[SalesPerson]
WHERE CommissionPct > 0
GROUP BY TerritoryID
----------------------������� �8-----------------------------
--������� ��� ���������� � ����������� (HumanResources.Employee) 
--������� ����� ����� ������� ���-�� 
--������� (HumanResources.Employee.VacationHours)
------------------------------------------------------------
SELECT *
FROM[AdventureWorks2019].[HumanResources].[Employee]
WHERE VacationHours = (SELECT MAX(VacationHours) FROM HumanResources.Employee)
----------------------������� �9-----------------------------
--������� ��� ���������� � ����������� (HumanResources.Employee) 
--������� ����� ������� (HumanResources.Employee.JobTitle)
--'Sales Representative' ��� 'Network Administrator' ��� 'Network Manager'
-------------------------------------------------------------
SELECT *
FROM [AdventureWorks2019].[HumanResources].[Employee]
WHERE JobTitle IN ('Sales Representative', 'Network Administrator', 'Network Manager')
----------------------������� �10-----------------------------
--������� ��� ���������� � ����������� (HumanResources.Employee) � 
--�� ������� (Purchasing.PurchaseOrderHeader). ���� � ���������� ���
--������� �� ������ ���� ������� ����!!!
---------------------------------------------------------------
SELECT HumanResources.Employee.*, Purchasing.PurchaseOrderHeader.*
FROM [AdventureWorks2019].[HumanResources].[Employee]
LEFT JOIN Purchasing.PurchaseOrderHeader
ON HumanResources.Employee.BusinessEntityID = Purchasing.PurchaseOrderHeader.EmployeeID
