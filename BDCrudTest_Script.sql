/**DataBase**/
CREATE DATABASE BDCrudTest;
GO
USE BDCrudTest;
GO

/**Tables**/
CREATE TABLE coCategoria (
    nIdCategori INT NOT NULL PRIMARY KEY ,
    cNombCateg NVARCHAR(100) NOT NULL,
    cEsActiva BIT NOT NULL
);
GO

CREATE TABLE coProducto (
    nIdProduct INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    cNombProdu NVARCHAR(100) NOT NULL,
    nPrecioProd DECIMAL(10, 2) NOT NULL,
    nIdCategori INT FOREIGN KEY REFERENCES coCategoria(nIdCategori)
);
GO

/**Data**/
INSERT INTO coCategoria (nIdCategori,cNombCateg, cEsActiva)
VALUES (1,'Electrónica', 1), (2,'Motores', 1);
GO

INSERT INTO coProducto (cNombProdu, nPrecioProd, nIdCategori)
VALUES 
    ('Laptop', 800.00, 1),
    ('Celular', 500.00, 1),
    ('Cámara', 300.00, 1),
    ('Radio', 20.00, 1),
    ('Motor de piston', 400.00, 2),
    ('Motor de cremallera', 300.00, 2);
GO

/**Stored Procedure**/
CREATE PROCEDURE Usp_Sel_Co_Productos @idCategori INT = Null
AS
BEGIN
    SELECT p.nIdProduct, p.cNombProdu, p.nPrecioProd, c.nIdCategori, c.cNombCateg
    FROM coProducto p
    INNER JOIN coCategoria c ON p.nIdCategori = c.nIdCategori
    WHERE (@idCategori IS NULL OR c.nIdCategori = @idCategori) AND c.cEsActiva = 1
	ORDER BY p.cNombProdu
END;
GO

CREATE PROCEDURE Usp_Ins_Co_Categoria
	@idCateg INT,
    @nombreCateg NVARCHAR(100)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM coCategoria WHERE nIdCategori = @idCateg)
    BEGIN
        /**RAISERROR('La categoría con el ID %d ya existe.', 16, 1, @idCateg);**/
        RETURN;
    END
    INSERT INTO coCategoria (nIdCategori,cNombCateg, cEsActiva)
    VALUES (@idCateg, @nombreCateg, 1);
END;
GO

CREATE PROCEDURE Usp_Upd_Co_Categoria
    @idCateg INT,
    @nombreCateg NVARCHAR(100),
    @activo BIT
AS
BEGIN
    UPDATE coCategoria
    SET cNombCateg = @nombreCateg, cEsActiva = @activo
    WHERE nIdCategori = @idCateg;
END;
GO

CREATE PROCEDURE Usp_Sel_Co_Categoria
AS
BEGIN
    SELECT c.nIdCategori, c.cNombCateg, c.cEsActiva FROM coCategoria c;
END;
GO