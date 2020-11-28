CREATE VIEW Travel AS 
SELECT * 
FROM Allocations 
WHERE BocCode IN ('21', '28') AND
Amount > 0