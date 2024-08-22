CREATE DATABASE MOVIES_DB_EJEMPLO

USE MOVIES_DB_EJEMPLO

DROP TABLE Director;

CREATE TABLE Director(
ID_Director int primary key identity,
Director_Name varchar(100),
Age INT,
Active BIT
)

CREATE TABLE Movies(
ID_Movies int primary key identity,
Movie_Name varchar(100),
Gender varchar(50),
Duration time,
Director_Key int,
FOREIGN KEY (Director_Key) REFERENCES Director(ID_Director)
)

INSERT INTO Director (Director_Name, Age, Active)
VALUES 
	('Steven Spielberg', 75, 1),
	('Christopher Nolan', 53, 1),
    ('Quentin Tarantino', 61, 1),
    ('Alfred Hitchcock', 80, 0),
	('Guiilermo del Toro', 58,1);

INSERT INTO Movies (Movie_Name, Gender, Duration, Director_Key)
VALUES 
    ('Jurassic Park', 'Science Fiction', '02:07:00', 1),
	('Inception', 'Science Fiction', '02:28:00', 2),
	('Pan''s Labyrinth', 'Fantasy/Drama', '01:58:00', 5),
    ('Schindler''s List', 'Historical Drama', '03:15:00', 1),
    ('Rear Window', 'Mystery/Thriller', '01:52:00', 4),
    ('Pulp Fiction', 'Crime/Drama', '02:34:00', 3),
    ('Psycho', 'Horror/Thriller', '01:49:00', 4),
    ('The Shape of Water', 'Fantasy/Romance', '02:03:00', 5);

	INSERT INTO Director (Director_Name, Age, Active)
VALUES
    ('Alfred Hitchcock', 80, 0)

	SELECT * FROM Director;
	SELECT * FROM Movies;

 