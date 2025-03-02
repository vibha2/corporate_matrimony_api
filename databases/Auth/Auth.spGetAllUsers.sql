
CREATE PROCEDURE [Auth].[spGetAllUsers] 
AS 
BEGIN
	 SELECT TOP 3 * FROM [Auth].[Users];
END;