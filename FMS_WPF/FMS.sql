USE ShashwatDB;

DROP Table Films
CREATE Table Films
(
	[Film ID] int Primary Key IDENTITY,
	Title varchar(50) UNIQUE,
	Description varchar(100) NOT NULL,
	[Release Year] int NOT NULL,
	[Rental Duration] int NULL,
	[Rental Rate] decimal(6,2) NULL,
	Length int NULL,
	[Replacement Cost] decimal(6,2) NULL,
	Rating decimal(3,1) NULL,
	Actors varchar(100) NOT NULL,
	Category varchar(100) NOT NULL,
	Language varchar(100) NOT NULL
);

GO;

-- INSERT
DROP Procedure usp_InsertFilm;
CREATE Procedure usp_InsertFilm
(@Title varchar(50),
@Description varchar(100),
@ReleaseYear int,
@RentalDuration int,
@RentalRate decimal(6,2),
@Length int,
@ReplacementCost decimal(6,2),
@Rating decimal(3,1),
@Actors varchar(100),
@Category varchar(100),
@Language varchar(100))
AS BEGIN
	INSERT INTO Films values
	(@Title,
	@Description,
	@ReleaseYear,
	@RentalDuration,
	@RentalRate,
	@Length,
	@ReplacementCost,
	@Rating,
	@Actors,
	@Category,
	@Language);
END

EXECUTE usp_InsertFilm 'Kopouiu', 'asds', 1212, 237, 24.3, 234, 435.6, 6.9, 'efdas', 'hetgs', 'wfwefq';

--SEARCH

DROP Procedure usp_SearchFilm;
GO
CREATE Procedure usp_SearchFilm
(@Title varchar(50),
@ReleaseYear int,
@Rating decimal(3,1))
AS BEGIN
	SELECT *
	FROM Films
	WHERE ((@Title IS NULL) OR (Title LIKE ('%' + @Title + '%'))) AND
	((@ReleaseYear IS NULL) OR ([Release Year] = @ReleaseYear)) AND
	((@Rating IS NULL) OR (Rating = @Rating) OR ( (@Rating IN (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10))
												  AND (Rating>=@Rating)
												  AND (Rating<(@Rating+1)) ))
END

EXECUTE usp_SearchFilm Null, Null, 9;

-- UPDATE
DROP Procedure usp_UpdateFilm;
CREATE Procedure usp_UpdateFilm
(@Title varchar(50),
@Description varchar(100),
@ReleaseYear int,
@RentalDuration int,
@RentalRate decimal(6,2),
@Length int,
@ReplacementCost decimal(6,2),
@Rating decimal(3,1),
@Actors varchar(100),
@Category varchar(100),
@Language varchar(100))
AS BEGIN
	UPDATE Films
	SET
	Description = @Description,
	[Release Year]=@ReleaseYear,
	[Rental Duration]=@RentalDuration,
	[Rental Rate]=@RentalRate,
	Length=@Length,
	[Replacement Cost]=@ReplacementCost,
	Rating=@Rating,
	Actors=@Actors,
	Category=@Category,
	Language=@Language
	WHERE Title = @Title;
END

EXECUTE usp_InsertFilm 'Kopouiu', 'asds', 1212, 237, 24.3, 234, 435.6, 6.9, 'efdas', 'hetgs', 'wfwefq';

--DELETE
DROP Procedure usp_DeleteFilm;
CREATE Procedure usp_DeleteFilm
(@Title varchar(50))
AS BEGIN
DELETE FROM Films
WHERE Title=@Title;
END

EXECUTE usp_DeleteFilm 'Dummy';


SELECT *
FROM Films;

TRUNCATE Table Films;
