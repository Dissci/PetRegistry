/**
*	SELECT LIST OF PET OWNERS
**/
SELECT
	PersonID,
	Name,
	Surname
FROM 
	Person
;

/**
*	SELECT OWNER PETS DETAIL
**/
SELECT
	pa.AnimalID,
	an.dogID,
	an.catID,
	an.Birthday,
	an.FeedingCount,
	an.Name,
	d.SkillLevel,
	d.BodySize,
	c.isActive
FROM
	Person pe
JOIN
	P_A pa ON (pe.PersonID=pa.PersonID)
JOIN
	Animal an ON (an.AnimalID=pa.AnimalID)
LEFT JOIN
	Dog d ON (d.DogID=an.DogID)
LEFT JOIN
	Cat c ON (c.CatID=an.CatID)
WHERE (1=1)
	AND pe.PersonID = 1
;

/**
*	PETS FEEDING
**/
UPDATE
	Animal
SET
	FeedingCount = FeedingCount + 1
WHERE
	AnimalID IN(9,1)
;

/**
*	OVERVIEW
**/
SELECT 
	count(xx.PersonID) selectedPeople,
	SUM(xx.AnimalIDs) selectedPets,
	SUM(xx.AnimalIDs)/count(xx.PersonID) avgPetsCount,
	CAST(CAST(AVG(xx.value) AS DATETIME) AS DATE) avgDateTime
FROM
	(SELECT
		pe.PersonID,
		count(an.AnimalID) AnimalIDs,
		avgAge.value
	FROM
		Person pe
	LEFT JOIN
		P_A pa 
	ON 
		(pe.PersonID=pa.PersonID)
	LEFT JOIN
		Animal an 
	ON 
		(an.AnimalID=pa.AnimalID)
	LEFT JOIN (	SELECT 
					pa.PersonID
					,AVG(CAST(CAST(an.Birthday AS DATETIME) AS INT)) AS value
				FROM 
					Animal an
				LEFT JOIN 
					P_A pa 
				ON 
					(an.AnimalID=pa.AnimalID)
				GROUP BY
					pa.PersonID
				) AS avgAge 
	ON 
		(avgAge.PersonID=pe.PersonID)
	WHERE (1=1)
		AND pe.PersonID IN (1,2)
	GROUP BY
		pe.PersonID,
		avgAge.value,
		pe.name,
		pe.surname
		) xx
;

