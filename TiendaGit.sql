CREATE DATABASE TiendaGit;
USE TiendaGit;

CREATE TABLE Productos(
IdProducto INT PRIMARY KEY AUTO_INCREMENT,
Nombre VARCHAR(100),
Descripcion VARCHAR(150),
Precio DOUBLE);

DELIMITER //
CREATE PROCEDURE p_InsertarProductos(

	IN _Nombre VARCHAR(100),
	IN _Descripcion VARCHAR(150),
	IN _Precio DOUBLE

)
BEGIN 
	INSERT INTO Productos (Nombre,Descripcion,Precio) VALUES(_Nombre,_Descripcion,_Precio);
END //
DELIMITER ;

CALL p_InsertarProductos('Coca Cola','Un refresco de verdad',90.08);
SELECT *FROM productos;
TRUNCATE Productos;

DELIMITER //
CREATE PROCEDURE p_EliminarProductos(

	IN _IdProducto INT
	)
	BEGIN
		DELETE FROM Productos WHERE IdProducto = _IdProducto;
	END //
	
	DELIMITER //

CALL p_EliminarProductos(1);

DELIMITER //
CREATE PROCEDURE p_EditarProductos(
	IN _IdProducto INT,
	IN _Nombre VARCHAR(100),
	IN _Descripcion VARCHAR(150),
	IN _Precio DOUBLE
	)
	BEGIN
	UPDATE productos SET Nombre=_Nombre,Descripcion=_Descripcion,Precio=_Precio WHERE IdProducto=_IdProducto;
END //
DELIMITER ;

CALL p_EditarProductos(1,'Pepsi','La competencia',70.65);



