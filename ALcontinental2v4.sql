
-----Accessory Listing (Continental Motors)-----------------------

USE Test2ALcontinental2v4 --This will change
GO
-------------------**important** IMPORT DATA ----------------------------
--MAKE SURE that you import Accessor and Spechead tables into your new database from the USAExport database.
-----------------------------------------------------------

-----------------------------------------------------------
-------------------Author: Mikael Thrash v2.4------------------------

-- * Creation of tables tblModel and tblSpec * 

--1. Get model and DISTINCT spec relationship from the Spechead table and insert into a new table named tblSpec


SELECT DISTINCT RTRIM(LTRIM(spec)) AS SpecName, [Model]
INTO tblSpec
FROM Spechead	--2457 rows 
GO
--**TEST
--SELECT * FROM tblSpec		--2457 rows

--2. Add the specid to tblSpec
ALTER TABLE tblSpec
ADD SpecID INT IDENTITY (1,1) PRIMARY KEY
GO
--3. Get the DISTINCT model from tblSpec and place them in a new table name tblModel
SELECT DISTINCT Model
INTO tblModel
FROM tblSpec --(180 row(s) affected)
GO

--**TEST
--SELECT * FROM tblModel --180 rows

--4.Add the ModelID to tblModel
ALTER TABLE tblModel
ADD ModelID INT IDENTITY (1,1) PRIMARY KEY
GO
--5.Add the ModelID to the tblSpec
ALTER TABLE tblSpec
ADD ModelID INT NULL
GO

--SELECT * FROM tblSpec
--6. Update tblSpec table with ModelID from tblModel. 
--Create the relationship between tblSpec and tblModel 

--Update tblSpec ModelID based on tblModel.Model = tblSpec.Model
UPDATE tblSpec
SET tblSpec.ModelID = tblModel.ModelID
FROM tblSpec, tblModel
WHERE tblModel.Model = tblSpec.Model --(2457 row(s) affected)
GO

--Add fk CONSTRAINTS to tblSpec.
ALTER TABLE tblSpec
ADD CONSTRAINT fk_ModelID
FOREIGN KEY (ModelID)
REFERENCES tblModel(ModelID)
GO
/*
TEST

SELECT * FROM tblModel
WHERE Model = 'I0550N'

SELECT SpecName from tblSpec
WHERE ModelID = 14
ORDER BY SpecName

*/

--Create tblDescription from the Accessor table
SELECT DISTINCT Descript
INTO tblDescription
FROM Accessor  --(359 row(s) affected)
GO

ALTER TABLE tblDescription
ADD DescriptionID INT IDENTITY (1,1) PRIMARY KEY
GO
--**TEST
--SELECT * FROM tblDescription --359 rows

--Create tblCategory from the Accessor table
SELECT DISTINCT category
INTO tblCategory
FROM Accessor --(86 row(s) affected)
GO

ALTER TABLE tblCategory
ADD CategoryID INT IDENTITY (1,1) PRIMARY KEY
GO
--**TEST
--SELECT * FROM tblCategory --86 Rows


--Create tblPosition from the Spechead table
SELECT DISTINCT position AS Position
INTO tblPosition
FROM Spechead
WHERE position != '' --(7 row(s) affected)
GO

ALTER TABLE tblPosition
ADD PositionID INT IDENTITY (1,1) PRIMARY KEY
GO
--**TEST
--SELECT * FROM tblPosition --7 rows

--Create tblStatus from the Spechead table
SELECT DISTINCT cond AS [Status]
INTO tblStatus
FROM Spechead
WHERE cond != '' --(4 row(s) affected)
GO

ALTER TABLE tblStatus
ADD StatusID INT IDENTITY (1,1) PRIMARY KEY
GO
--**TEST
--SELECT * FROM tblStatus --4 rows

------------------------------------------------------------------------------------
--**Create intersection tables.
------------------------------------------------------------------------------------

--5 Creating table tblSpecPosition
CREATE TABLE tblSpecPosition
(
SpecPositionID		INT		IDENTITY (1,1)		PRIMARY KEY,
SpecName		char(16)		NOT NULL,
SpecPosition		char(25)		NOT NULL		
)
GO
--Get the relationship of the spec and position from the Spechead table.
INSERT INTO tblSpecPosition(SpecName, SpecPosition)
SELECT RTRIM(LTRIM(spec)) AS SpecName, position As Position
FROM Spechead
WHERE position != '' --(2332 row(s) affected)
GO
--**TEST
--SELECT * FROM tblSpecPosition --2332

--Add SpecID to the tblSpecPosition
ALTER TABLE tblSpecPosition
ADD SpecID INT NULL
GO
--Add PositionID to the tblSpecPosition
ALTER TABLE tblSpecPosition
ADD PositionID INT NULL
GO

UPDATE tblSpecPosition
SET tblSpecPosition.SpecID = tblSpec.SpecID
FROM tblSpecPosition, tblSpec
WHERE tblSpec.SpecName = tblSpecPosition.SpecName --(2332 row(s) affected)
GO
/**TEST Note: SpecName is Distinct and SpecID is also..

SELECT * FROM tblSpecPosition 
ORDER BY SpecID		
	
*/
--SELECT * FROM tblSpec

/**TEST
SELECT * FROM tblPosition
*/
--Update the PositionID in the tblSpecPosition
UPDATE tblSpecPosition
SET tblSpecPosition.PositionID = tblPosition.PositionID
FROM tblSpecPosition, tblPosition
WHERE tblSpecPosition.SpecPosition = tblPosition.Position  --(2332 row(s) affected) **Still tracking
GO

/**TEST Note: SpecPosition matches PositionID

SELECT * FROM tblSpecPosition 
ORDER BY PositionID

TEST Note: verify

SELECT * FROM tblPosition
*/


-----------------Add fk_CONSTRAINTS tblSpecPosition------------------------------------------------
ALTER TABLE tblSpecPosition
ADD CONSTRAINT fk_SpecID
FOREIGN KEY (SpecID)
REFERENCES tblSpec(SpecID)
GO
/*
ALTER TABLE tblSpecPosition
DROP CONSTRAINT fk_SpecID
*/

ALTER TABLE tblSpecPosition
ADD CONSTRAINT fk_SpecPositionID
FOREIGN KEY (PositionID)
REFERENCES tblPosition(PositionID)
GO
/*
ALTER TABLE tblSpecPosition
DROP CONSTRAINT fk_SpecPositionID
*/



------------------------------------------------------------------------------------
--5 Creating table tblSpecStatus
CREATE TABLE tblSpecStatus
(
SpecStatusID		INT		IDENTITY (1,1)		PRIMARY KEY,
SpecName		char(16)		NOT NULL,
SpecStatus		char(25)		NOT NULL		
)
GO
--Get the relationship of the spec and cond[Status] from the Spechead table.
INSERT INTO tblSpecStatus(SpecName, SpecStatus)
SELECT RTRIM(LTRIM(spec)) AS SpecName, cond As [Status]
FROM Spechead
WHERE cond != '' --(2453 row(s) affected)
GO
--Add SpecID to the tblSpecStatus
ALTER TABLE tblSpecStatus
ADD SpecID INT NULL
GO

--Add PositionID to the tblSpecStatus
ALTER TABLE tblSpecStatus
ADD StatusID INT NULL
GO
--Update the SpecID in the tblSpecStatus table
UPDATE tblSpecStatus
SET tblSpecStatus.SpecID = tblSpec.SpecID
FROM tblSpecStatus, tblSpec
WHERE tblSpec.SpecName = tblSpecStatus.SpecName  --(2453 row(s) affected)
GO
/*TEST
SELECT * FROM tblSpecStatus 
ORDER BY SpecID --2453 rows


SELECT * FROM tblStatus
*/

--Update the StatusID in the tblSpecStatus table
UPDATE tblSpecStatus
SET tblSpecStatus.StatusID = tblStatus.StatusID
FROM tblSpecStatus, tblStatus
WHERE tblSpecStatus.SpecStatus = tblStatus.Status  --(2453 row(s) affected)
GO
/*TEST Note: StausID matches SpecStatus

SELECT * FROM tblSpecStatus 
ORDER BY StatusID 

SELECT * FROM tblStatus
*/


-----------------Add fk_CONSTRAINTS tblSpecStatus------------------------------------------------
ALTER TABLE tblSpecStatus
ADD CONSTRAINT fk_StatusSpecID
FOREIGN KEY (SpecID)
REFERENCES tblSpec(SpecID)
GO
/*
ALTER TABLE tblSpecStatus
DROP CONSTRAINT fk_StatusSpecID
*/

ALTER TABLE tblSpecStatus
ADD CONSTRAINT fk_SpecStatusID
FOREIGN KEY (StatusID)
REFERENCES tblStatus(StatusID)
GO
/*
ALTER TABLE tblSpecStatus
DROP CONSTRAINT fk_SpecStatusID
*/

------------------------------------------------------------------------------------
/*
CREATE TABLE tblSpecCategory
(
SpecCategoryID		INT		IDENTITY (1,1)		PRIMARY KEY,
SpecName		char(16)		NOT NULL,
SpecCategory		char(20)		NOT NULL		
)

INSERT INTO tblSpecCategory(SpecName, SpecCategory)
SELECT RTRIM(LTRIM(spec)) AS SpecName,  category As [Category]
FROM Accessor
WHERE category != '' --(27039 row(s) affected)

--Add SpecID to the tblSpecCategory
ALTER TABLE tblSpecCategory
ADD SpecID INT NULL

--Add CategoryID to the tblSpecCategory
ALTER TABLE tblSpecCategory
ADD CategoryID INT NULL

UPDATE tblSpecCategory
SET tblSpecCategory.SpecID = tblSpec.SpecID
FROM tblSpecCategory, tblSpec
WHERE tblSpecCategory.SpecName = tblSpec.SpecName --(26973 row(s) affected)

/*TEST Note: --66 Null values for SpecID assigned. **row 67 starts SpecID 1 
Reason: Spec count different in Spechead and Accessor tables. 

SELECT * FROM tblSpecCategory --26951 rows 
ORDER BY SpecID 

*/

--SELECT * FROM tblCategory --86 rows

--Update the StatusID in the tblSpecStatus table.

UPDATE tblSpecCategory
SET tblSpecCategory.CategoryID = tblCategory.CategoryID
FROM tblSpecCategory, tblCategory
WHERE tblSpecCategory.SpecCategory = tblCategory.category  --(27039 row(s) affected)

/* TEST Note: No Null values for CategoryID

SELECT * FROM tblSpecCategory --27039 rows
ORDER BY CategoryID 

*/

-----------------Add fk_CONSTRAINTS tblSpecCategory------------------------------------------------
ALTER TABLE tblSpecCategory
ADD CONSTRAINT fk_CategorySpecID
FOREIGN KEY (SpecID)
REFERENCES tblSpec(SpecID)

/*
ALTER TABLE tblSpecCategory
DROP CONSTRAINT fk_CategorySpecID
*/

ALTER TABLE tblSpecCategory
ADD CONSTRAINT fk_SpecCategoryID
FOREIGN KEY (CategoryID)
REFERENCES tblCategory(CategoryID)

/*
ALTER TABLE tblSpecCategory
DROP CONSTRAINT fk_SpecCategoryID
*/


*/

----------------------------------------------------------------------------------
--Create intersection TABLE tblCategoryDescription.
----------------------------------------------------------------------------------
CREATE TABLE tblCategoryDescription
(
CategoryDescriptionID		INT		IDENTITY (1,1)		PRIMARY KEY,
Category		char(20)		NOT NULL,
CategoryDescription 		char(55)		NOT NULL
)
GO

INSERT INTO tblCategoryDescription(Category, CategoryDescription)
SELECT RTRIM(LTRIM(category)) AS Category,  descript AS [Description]
FROM Accessor 
WHERE category != '' --27039 rows
GO
--Order By Category 

--Add CategoryID to the tblCategoryDescription
ALTER TABLE tblCategoryDescription
ADD CategoryID INT NULL
GO
--Add DescriptionID to the tblCategoryDescription
ALTER TABLE tblCategoryDescription
ADD DescriptionID INT NULL
GO

UPDATE tblCategoryDescription
SET tblCategoryDescription.CategoryID = tblCategory.CategoryID
FROM tblCategoryDescription, tblCategory
WHERE tblCategoryDescription.Category = tblCategory.category
GO
--(27039 row(s) affected)

--TEST
--SELECT * FROM tblCategoryDescription
--ORDER BY CategoryID --27039 rows **No Null Values assigned


--SELECT * FROM tblDescription --359 rows

--Update the DescriptionID in the tblCategoryDescription table
UPDATE tblCategoryDescription
SET tblCategoryDescription.DescriptionID = tblDescription.DescriptionID
FROM tblCategoryDescription, tblDescription
WHERE tblCategoryDescription.CategoryDescription = tblDescription.Descript
GO
--(27039 row(s) affected)

--TEST*******
--SELECT * FROM tblCategoryDescription --439 rows
--ORDER BY DescriptionID --No Null values for DescriptionID assigned



-----------------Add fk_CONSTRAINTS tblCategoryDescription------------------------------------------------
ALTER TABLE tblCategoryDescription
ADD CONSTRAINT fk_DescriptionCategoryID
FOREIGN KEY (CategoryID)
REFERENCES tblCategory(CategoryID)
GO
/*
ALTER TABLE tblCategoryDescription
DROP CONSTRAINT fk_DescriptionCategoryID
*/

ALTER TABLE tblCategoryDescription
ADD CONSTRAINT fk_CategoryDescriptionID
FOREIGN KEY (DescriptionID)
REFERENCES tblDescription(DescriptionID)
GO
/*
ALTER TABLE tblCategoryDescription
DROP CONSTRAINT fk_CategoryDescriptionID
*/


--------------------------------------------------------------------------------------
					--Create the SpecCategoryDescription
--------------------------------------------------------------------------------------

CREATE TABLE tblSpecCategoryDescription
(
SpecCategoryDescriptionID		INT		IDENTITY (1,1)		PRIMARY KEY,
SpecName		char(16)		NOT NULL,
SpecCategory	char(20)		NOT NULL,
SpecCategoryDescription 		char(55)		NOT NULL,
[Weight]		decimal			NULL
)
GO
--SELECT * FROM tblCategoryDescription
INSERT INTO tblSpecCategoryDescription(SpecName, SpecCategory, SpecCategoryDescription, [Weight] )
SELECT RTRIM(LTRIM(spec)) AS SpecName, category As Category,  descript AS [Description], [weight] 
FROM Accessor 
GO
--(27039 row(s) affected)

--Add SpecID to the tblSpecCategoryDescription
ALTER TABLE tblSpecCategoryDescription
ADD SpecID INT NULL
GO
--Add CategoryDescriptionID to the tblSpecCategoryDescription
ALTER TABLE tblSpecCategoryDescription
ADD CategoryDescriptionID INT NULL
GO

--Add CategoryID to the tblSpecCategoryDescription
ALTER TABLE tblSpecCategoryDescription
ADD CategoryID INT NULL
GO
--Add DescriptionID to the tblSpecCategoryDescription
ALTER TABLE tblSpecCategoryDescription
ADD DescriptionID INT NULL
GO
--Add CategoryID to the tblSpecCategoryDescription
--ALTER TABLE tblSpecCategoryDescription
--ADD CategoryID INT NULL

--SELECT * FROM tblSpecCategoryDescription
UPDATE tblSpecCategoryDescription
SET tblSpecCategoryDescription.SpecID = tblSpec.SpecID
FROM tblSpecCategoryDescription, tblSpec
WHERE tblSpecCategoryDescription.SpecName = tblSpec.SpecName
GO
--(26973 row(s) affected)

--SELECT * FROM tblSpecCategoryDescription
UPDATE tblSpecCategoryDescription
SET tblSpecCategoryDescription.CategoryID = tblCategory.CategoryID
FROM tblSpecCategoryDescription, tblCategory
WHERE tblSpecCategoryDescription.SpecCategory = tblCategory.category
GO
--(27039 row(s) affected)
--SELECT * FROM tblSpecCategoryDescription
--ORDER BY SpecID 
--27039 rows **No Null Values assigned
UPDATE tblSpecCategoryDescription
SET tblSpecCategoryDescription.DescriptionID = tblDescription.DescriptionID
FROM tblSpecCategoryDescription, tblDescription
WHERE tblSpecCategoryDescription.SpecCategoryDescription = tblDescription.Descript
GO
--(27039 row(s) affected)

--SELECT * FROM tblSpecCategoryDescription --27039 rows

--Update the CategoryDescriptionID in the tblSpecCategoryDescription table
UPDATE tblSpecCategoryDescription
SET tblSpecCategoryDescription.CategoryDescriptionID = tblCategoryDescription.CategoryDescriptionID
FROM tblSpecCategoryDescription, tblCategoryDescription
WHERE tblSpecCategoryDescription.SpecCategory = tblCategoryDescription.Category AND tblSpecCategoryDescription.SpecCategoryDescription = tblCategoryDescription.CategoryDescription
GO

--(27039 row(s) affected) NOTE: time 12 secs

--SELECT * FROM tblSpecCategoryDescription --27039 rows
--ORDER BY DescriptionID --No Null values for DescriptionID assigned


-----------------Add fk_CONSTRAINTS tblSpecCategoryDescription------------------------------------------------
ALTER TABLE tblSpecCategoryDescription
ADD CONSTRAINT fk_SpecCategoryDescription_SpecID
FOREIGN KEY (SpecID)
REFERENCES tblSpec(SpecID)
GO
/*
ALTER TABLE tblSpecCategoryDescription
DROP CONSTRAINT fk_SpecCategoryDescriptionSpecID
*/

ALTER TABLE tblSpecCategoryDescription
ADD CONSTRAINT fk_SpecCategoryDescription_CategoryDescriptionID
FOREIGN KEY (CategoryDescriptionID)
REFERENCES tblCategoryDescription(CategoryDescriptionID)
GO
/*
ALTER TABLE tblSpecCategoryDescription
DROP CONSTRAINT fk_SpecCategoryDescription_CategoryDescriptionID
*/



--**********************DROP********************************************************
------------------------------------------------------------------------------------
--**********************************************************************************
------------DROP COLUMNS tblCategoryDescription-----------------------

--SELECT * FROM tblSpec
ALTER TABLE dbo.tblSpec
DROP COLUMN Model
GO
------------DROP COLUMNS tblSpecPosition-----------------------


--SELECT * FROM tblSpecPosition
ALTER TABLE dbo.tblSpecPosition
DROP COLUMN SpecName, SpecPosition
GO

------------DROP COLUMNS tblSpecStatus-----------------------

--SELECT * FROM tblSpecStatus
ALTER TABLE dbo.tblSpecStatus
DROP COLUMN SpecName, SpecStatus
GO

------------DROP COLUMNS tblCategoryDescription-----------------------

--SELECT * FROM tblCategoryDescription
ALTER TABLE dbo.tblCategoryDescription
DROP COLUMN Category, CategoryDescription
GO

------------DROP COLUMNS tblSpecCategoryDescription-----------------------

--SELECT * FROM tblSpecCategoryDescription
ALTER TABLE dbo.tblSpecCategoryDescription
DROP COLUMN SpecName, SpecCategory, SpecCategoryDescription, CategoryID, DescriptionID
GO

/*
*********DONT FORGET*********************
Make sure you have created a new database and imported the db.Accessor and db.Spechead TABLES from the dbo.USAExport database
Before you execute ALcontinental2v4.sql file.
 *****************************************

ALcontinental2v4.sql TOTAL execute runtime 00:24

(2457 row(s) affected)

(180 row(s) affected)

(2457 row(s) affected)

(359 row(s) affected)

(86 row(s) affected)

(7 row(s) affected)

(4 row(s) affected)

(2332 row(s) affected)

(2332 row(s) affected)

(2332 row(s) affected)

(2453 row(s) affected)

(2453 row(s) affected)

(2453 row(s) affected)

(27039 row(s) affected)

(27039 row(s) affected)

(27039 row(s) affected)

(27039 row(s) affected)

(26973 row(s) affected)

(27039 row(s) affected)

(27039 row(s) affected)

(27039 row(s) affected)

*/
