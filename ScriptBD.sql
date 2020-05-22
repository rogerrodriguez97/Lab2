CREATE TABLE video(
idVideo int primary key,
titulo varchar (100),
repro int,
url varchar(100)
);

--INSERTAR
CREATE PROCEDURE sp_video_insertar
	@idVideo int,
	@titulo varchar(100),
	@repro int,
	@url varchar(100)
as
begin
	INSERT INTO video
	VALUES(@idVideo,@titulo,@repro,@url)
end

--REGISTRO
EXEC sp_video_insertar 1,'Video',1,'x'
EXEC sp_video_insertar 3,'video',34,'https://www.youtube.com/embed/watch?v=IEzK4zn6JIQ'

--ACTUALIZAR
CREATE PROCEDURE SP_video_ACTUALIZAR
@idVideo int,
@titulo varchar(100),
@repro int,
@url varchar(100)
AS
BEGIN
UPDATE video SET titulo= @titulo, repro = @repro, url = @url WHERE idVideo = @idVideo 
END
--REGISTRO MODIFICADO
EXEC SP_video_ACTUALIZAR 3, 'cancio', 34, 'https://www.youtube.com/embed/watch?v=IEzK4zn6JIQ'


--ELIMINAR
CREATE PROCEDURE SP_video_ELIMINAR 
@idVideo int
AS
BEGIN
DELETE FROM video WHERE idVideo = @idVideo
END

EXEC SP_video_ELIMINAR 1


--VER TODOS
CREATE PROCEDURE SP_video_Consultar
AS
BEGIN
SELECT * FROM video 
END

EXEC SP_video_Consultar


SELECT * FROM video