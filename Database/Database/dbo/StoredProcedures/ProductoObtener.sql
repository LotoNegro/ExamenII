CREATE PROCEDURE [DBO].[ProductoObtener]
	@IdProducto int= NULL
AS BEGIN
	SET NOCOUNT ON

SELECT
	E.IdProducto,
	E.NombreProducto,
	E.PrecioProducto
	FROM DBO.Producto E
	WHERE
	(@IdProducto IS NULL OR IdProducto=@IdProducto)
END