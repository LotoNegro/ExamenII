CREATE PROCEDURE [dbo].[OrdenObtener]
	@IdOrden int= NULL
AS BEGIN
	SET NOCOUNT ON

SELECT
	E.IdOrden,
	E.CantidadProducto,
	E.Estado,
	E.IdProducto
	FROM DBO.Orden E
	WHERE
	(@IdOrden IS NULL OR IdOrden=@IdOrden)
END