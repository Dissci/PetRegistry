
/**
CREATE TABLE [Person]
(
 [PersonID] bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
 [Name]     varchar(50) NOT NULL ,
 [Surname]  varchar(50) NOT NULL ,

);
**/

/**
CREATE TABLE [Dog]
(
 [DogID]      bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
 [SkillLevel] smallint NOT NULL ,
 [BodySize]   int NOT NULL ,

);
**/

/**
CREATE TABLE [Cat]
(
 [CatID]    bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
 [isActive] bit NOT NULL ,

);
**/

/**
CREATE TABLE [Animal]
(
 [AnimalID]     bigint NOT NULL IDENTITY(1,1),
 [DogID]        bigint NULL,
 [CatID]        bigint NULL,
 [Birthday]     date NOT NULL ,
 [FeedingCount] int  DEFAULT 0,
 [Name]         varchar(50) NOT NULL ,


 CONSTRAINT [PK_animal] PRIMARY KEY CLUSTERED ([AnimalID] ASC),
 CONSTRAINT [FK_12] FOREIGN KEY ([DogID])  REFERENCES [Dog]([DogID]),
 CONSTRAINT [FK_18] FOREIGN KEY ([CatID])  REFERENCES [Cat]([CatID])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_13] ON [Animal] 
 (
  [DogID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_19] ON [Animal] 
 (
  [CatID] ASC
 )

GO



CREATE TABLE [P_A]
(
 [AnimalID] bigint NOT NULL ,
 [PersonID] bigint NOT NULL ,


 CONSTRAINT [PK_p_a] PRIMARY KEY CLUSTERED ([AnimalID] ASC, [PersonID] ASC),
 CONSTRAINT [FK_35] FOREIGN KEY ([AnimalID])  REFERENCES [Animal]([AnimalID]),
 CONSTRAINT [FK_47] FOREIGN KEY ([PersonID])  REFERENCES [Person]([PersonID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_36] ON [P_A] 
 (
  [AnimalID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_48] ON [P_A] 
 (
  [PersonID] ASC
 )
 GO
 **/

 /**
INSERT INTO
	Person 
	(Name,Surname)
VALUES
	('Jozo', 'Mrkvicka'),
	('Andrej', 'Horcica'),
	('Tomas', 'Krkoska'),
	('Michal', 'Vana'),
	('Peter', 'Tatra')
	;
**/

/**
INSERT INTO
	Dog
	(SkillLevel, BodySize)
VALUES
	(10, 40),
	(9, 30),
	(8, 50),
	(7, 20),
	(6, 35)
	;
**/


/**
INSERT INTO
	Cat
	(isActive)
VALUES
	(0),
	(1)
	;
**/


/**
INSERT INTO
	Animal
	(DogID,CatID,Birthday,Name)
VALUES
	(1,null,'2020-01-13','Tina'),
	(2,null,'2021-01-13','Aja'),
	(3,null,'2019-01-13','Falco'),
	(4,null,'2020-05-20','Jack'),
	(5,null,'2020-06-21','Labka'),

	(null,1,'2020-04-05','Baltazar'),
	(null,1,'2020-7-09','Dafne'),
	(null,2,'2019-12-10','Hasan'),
	(null,2,'2018-11-28','Chaplin'),
	(null,2,'2017-10-01','Jess')
	;**/
	

/**
INSERT INTO
	P_A
	(AnimalID,PersonID)
VALUES
	(1,1),
	(1,2),
	(2,2),
	(3,3),
	(4,4),
	(5,4),
	(6,4),
	(7,2),
	(8,3),
	(9,1),
	(10,2)
	;
**/
