"use strict";
var OrdenGrid;
(function (OrdenGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Orden/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    OrdenGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(OrdenGrid || (OrdenGrid = {}));
//# sourceMappingURL=Gird.js.map