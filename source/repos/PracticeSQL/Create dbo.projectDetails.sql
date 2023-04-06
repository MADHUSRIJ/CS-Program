SELECT * FROM projectDetails;
SELECT * FROM employeeDetails;

CREATE or ALTER PROCEDURE updateProjectDetails @projectId int
AS
BEGIN
UPDATE employeeDetails SET projectId = NULL WHERE projectId = @projectId;
DELETE FROM projectDetails WHERE projectId = @projectId;
END


INSERT INTO employeeDetails VALUES ('Shan','2001-12-20','Banking','CSS','Coimbatore',23433,105);

EXEC updateProjectDetails 105;