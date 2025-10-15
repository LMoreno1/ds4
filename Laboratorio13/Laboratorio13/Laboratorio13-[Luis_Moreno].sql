USE Northwind

-- EJEMPLO 1

-- El asterisco significa que se quiere seleccionar todos los campos de la tabla Products
SELECT * FROM Products

-- EJEMPLO 2

-- Para seleccionar ciertos campos hay que colocarlos como en un listado 
-- en este ejemplo solo se mostraran los registros almacenados en los campos ProductID ProductName y UnitPrice
SELECT ProductID, ProductName, UnitPrice FROM Products

-- EJEMPLO 3

-- Seleccionar los datos de la tabla Products donde el dato almacenado en el campo UnitPrice sea mayor a 15
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice > 15

-- EJEMPLO 4

-- Seleccionar los datos de la tabla Products donde el dato almacenado en el campo 
-- UnitPrice sea mayor o igual a 15 y menor o igual a 50
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice >= 15 AND UnitPrice <= 50   

-- EJEMPLO 5

-- Otra forma de crear la consulta anterior es utilizando la instruccion BETWEEN
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice BETWEEN 15 AND 50

-- EJEMPLO 6

-- Haciendo uso del operador NOT obtenermos lo registros de la tabla Products donde 
-- el dato almacenado en el campo UnitPrice sea menor que 15
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE NOT UnitPrice > 15

-- EJEMPLO 7

-- Seleccionar los registros de la tabla Products donde el dato almacenado en el campo 
-- ProductID sea mayor a 50 y el dato almacenado en el campo UnitPrice sea menor a 10
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE ProductID > 15 OR UnitPrice < 10 

-- EJEMPLO 8

-- Seleccionar los campo EmployeeID y LastName de la tabla Employees donde el dato almacenado 
-- en el campo LastName comience con la letra D
SELECT EmployeeID, LastName FROM Employees
WHERE LastName LIKE 'D%'

-- EJEMPLO 9

-- Seleccionar los campos EmployeeID y LastName de la tabla Employees donde el dato almacenado 
-- en el campo LastName termine con la letra N
SELECT EmployeeID, LastName FROM Employees
WHERE LastName LIKE '%N'

-- EJEMPLO 10

-- Seleccionar los campos EmployeeID, LastName y Title de la tabla Employees donde el dato 
-- almacenado en el campo Title se encuentre la palabra SALES, no importanto en que posicion
SELECT EmployeeID, LastName, Title FROM Employees
WHERE Title LIKE '%SALES%'

-- EJEMPLO 11

-- Seleccionar los campos EmployeeID y LastName de empleados EXCEPTO aquellos donde el dato almacenado 
-- en LastName comience con la letra D
SELECT EmployeeID, LastName FROM Employees
WHERE LastName NOT LIKE 'D%'

-- EJEMPLO 12

-- Ordenar de forma ascendente los registros en los campos ProductID, ProductName 
-- y UnitPrice de la tabla Products, se ordenaran por medio del campo ProductID
SELECT ProductID, ProductName, UnitPrice
FROM Products
ORDER BY ProductID ASC
-- De forma predeterminada los datos de ordenaran de forma ascendente, por lo tanot la instrucción ASC opcional

-- EJEMPLO 13

-- Ordenar de forma descendente los registros almacenados en los campos ProductID, ProductName 
-- y UnitPrice de la tabla Products, se ordenaran por medio del campo ProductID
SELECT ProductID, ProductName, UnitPrice
FROM Products
ORDER BY ProductID DESC

-- EJEMPLO 14

-- Seleccionar todos lo registros no repetidos almacenados en el campo OrderID de la tabla Order Details
SELECT DISTINCT OrderID FROM [Order Details]

-- EJEMPLO 15

-- Mostrar los primeros cinco registros de la tabla Order Details
SELECT TOP 5 OrderID, ProductID, Quantity
FROM [Order Details]

-- EJEMPLO 16

-- En el ejemplo siguiente se mostraran el 10% de todos los pedidos almacenados en la tabla Order Details
SELECT TOP 10 PERCENT OrderID, ProductID, Quantity
FROM [Order Details]

-- EJEMPLO 17

-- Seleccionar los datos almacenados en el campo CategoryName de la tabla Categories y renombrar 
-- a la columna con el nombre Nombre de Categorias
SELECT CategoryName AS [Nombre de Categoria]
FROM Categories

-- EJEMPLO 18

-- Se requiere conocer cual seria la fecha de envio (ShippedDate) con un retraso de 5 dias 
-- Mostrar los campos OrderID, OrderDate y ShippedDate de la tabla Orders
SELECT OrderId, OrderDate, ShippedDate, ShippedDate + 5 AS RetrasoEnvio
FROM Orders

-- EJEMPLO 19

SELECT OrderID, P.ProductID, ProductName
FROM Products P
INNER JOIN [Order Details] OD
ON P.ProductID=OD.ProductID

-- EJEMPLO 20

SELECT ProductName, CompanyName, ContactName
FROM Products P
FULL JOIN Suppliers S
ON P.SupplierID=S.SupplierID

