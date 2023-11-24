use AssetTracking;



-- UPDATE Model SET AssetTypeID = 1 WHERE Id = 5;
-- INSERT INTO Brand (Brand) VALUES ('Motorola');

--HP Elitebook Laptop
--HP Notebook Laptop
--Apple Iphone Stationary
--Apple MacBook Stationary
--Lenovo Yoga Phone
--Lenovo Thinkstation Phone
--Olivetti d-Color P3302 Printer

-- https://stackoverflow.com/questions/27838045/where-to-use-outer-apply
-- https://stackoverflow.com/questions/9275132/real-life-example-when-to-use-outer-cross-apply-in-sql/9275865#9275865
-- https://www.mssqltips.com/sqlservertip/1958/sql-server-cross-apply-and-outer-apply/
--		The APPLY operator allows you to join two table expressions; the right table expression is processed 
--		every time for each row from the left table expression. As you might have guessed, the left table expression 
--		is evaluated first and then the right table expression is evaluated against each row of the left 
--		table expression for the final result set. 

SELECT * FROM Brand b INNER JOIN Model m ON b.ID = m.AssetBrandID 
	INNER JOIN Type t ON m.AssetTypeID = t.ID;

SELECT b.Brand, m.Model FROM Brand b INNER JOIN Model m ON b.ID = m.AssetBrandID;
SELECT b.Brand, m.Model FROM Brand b LEFT JOIN Model m ON b.ID = m.AssetBrandID;
SELECT b.Brand, m.Model FROM Brand b CROSS JOIN Model m;

SELECT b.Brand, m.Model, t.Type FROM Brand b INNER JOIN Model m ON b.ID = m.AssetBrandID 
	INNER JOIN Type t ON m.AssetTypeID = t.ID;

-- UPDATE Model SET AssetTypeID = 1 WHERE Id = 5;
-- INSERT INTO Brand (Brand) VALUES ('Motorola');
-- DELETE FROM Brand WHERE Id = 7;
-- UPDATE Asset SET PurchaseDate = '2023-09-17' WHERE Id = 5;

SELECT * FROM Model;
SELECT * FROM Brand;
SELECT * FROM Type;
SELECT * FROM Office;
SELECT * FROM Asset;

-- DROP TABLE Asset;
-- DROP TABLE Model;
-- DROP TABLE Type
-- DROP TABLE Office;
-- DROP TABLE Brand;
-- DROP TABLE __EFMigrationsHistory

SELECT t.Type, b.Brand, m.Model FROM Brand b INNER JOIN Model m ON b.ID = m.AssetBrandID 
	INNER JOIN Type t ON m.AssetTypeID = t.ID;


SELECT t.Type, b.Brand, m.Model FROM Brand b INNER JOIN Model m ON b.ID = m.AssetBrandID 
	INNER JOIN Type t ON m.AssetTypeID = t.ID WHERE t.Type = 'Laptop' AND b.Brand = 'HP';

SELECT * FROM Model m INNER JOIN Brand b ON b.ID = m.AssetBrandID 
	INNER JOIN Type t ON m.AssetTypeID = t.ID WHERE t.Type = 'Laptop' AND b.Brand = 'HP';


-- --------------------------------------------------------------------------------------------------------------
SELECT * FROM Type;

SELECT b.Brand, m.Id FROM Model m INNER JOIN Brand b ON b.ID = m.AssetBrandID 
	INNER JOIN Type t ON m.AssetTypeID = t.ID WHERE t.Type = 'Laptop';

SELECT m.Model, m.Id FROM Model m INNER JOIN Brand b ON b.ID = m.AssetBrandID 
	INNER JOIN Type t ON m.AssetTypeID = t.ID WHERE t.Type = 'Laptop' AND b.Brand = 'HP';

SELECT t.Type, m.Model, o.Country, b.Brand, a.Price, a.PurchaseDate, a.Id, a.AssetModelId FROM Asset a
	INNER JOIN Model m ON a.AssetModelId = m.Id INNER JOIN Office o ON a.OfficeId = o.Id
	INNER JOIN Type t ON m.AssetTypeID = t.ID INNER JOIN Brand b ON b.ID = m.AssetBrandID;
-- --------------------------------------------------------------------------------------------------------------






