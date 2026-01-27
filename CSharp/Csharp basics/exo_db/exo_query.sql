
-- 1.1
--SELECT * FROM Dogs;

---- 1.2
--SELECT first_name, last_name FROM People;

---- 1.3
--SELECT * FROM Dogs WHERE owner_id is null;

---- 1.4
-- SELECT * FROM Dogs WHERE breed='Labrador';

---- 2.1
--SELECT name, first_name,last_name FROM Dogs INNER JOIN People ON Dogs.owner_id = People.id;

---- 2.2
--SELECT * FROM People JOIN Dogs on Dogs.owner_id = People.id WHERE weight > 20;

---- 3.1
--SELECT * FROM PEOPLE Left JOIN Dogs on Dogs.owner_id = People.Id;

---- 3.2
--SELECT name, COALESCE(People.first_name, 'No Owner') AS OwnerName FROM Dogs LEFT JOIN People on Dogs.owner_id = People.Id;

---- 4.1
--SELECT * FROM people FULL JOIN Dogs on Dogs.owner_id = people.id;

-- 5.1
SELECT * FROM Dogs where weight > 10 AND weight < 30;

-- 5.2
SELECT * FROM Dogs JOIN People on Dogs.owner_id = People.id WHERE address='123 main st';

-- 6.1
SELECT first_name, COUNT(dogs.id) FROM People LEFT JOIN Dogs on Dogs.owner_id = People.id GROUP BY People.first_name;

-- 6.2
SELECT first_name, SUM(dogs.weight) FROM People LEFT JOIN Dogs on Dogs.owner_id = People.Id GROUP BY People.first_name;

-- 7.1
SELECT * FROM People JOIN Dogs on Dogs.owner_id = People.id 
WHERE dogs.Weight = (SELECT MAX(weight) FROM Dogs);

-- 7.2
SELECT Dogs.* FROM Dogs Left Join People on dogs.owner_id = People.id 
WHERE people.age > 40;

-- 8.1
SELECT * FROM People LEFT JOIN Dogs on dogs.owner_id = people.id WHERE dogs.owner_id is null;

-- 8.2
SELECT TOP 1 breed, COUNT(*) AS CountOfDogs FROM Dogs GROUP BY breed ORDER BY COUNT(*) DESC;

-- 8.3
SELECT people.first_name, COUNT(*) AS CountOfDogs  
FROM People join dogs on dogs.owner_id = people.id group by people.first_name 
having count(dogs.id) >= 2;

