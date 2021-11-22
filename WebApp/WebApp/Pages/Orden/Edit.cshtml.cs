using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApp.Pages.Orden
{
    public class EditModel : PageModel
    {
        private readonly IOrdenService OrdenService;
        private readonly IProductoService IdProductoService;

        public EditModel(IOrdenService OrdenService, IProductoService IdProductoService)
        {
            this.OrdenService = OrdenService;
            this.IdProductoService = IdProductoService;
        }

        [BindProperty]
        public OrdenEntity Entity { get; set; } = new OrdenEntity();
        public IEnumerable<ProductoEntity> IdProductoLista { get; set; } = new List<ProductoEntity>();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await OrdenService.GetById(new() { IdOrden = id });
                }

                IdProductoLista = await IdProductoService.GetLista();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }


        }

        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                //Metodo Actualizar
                if (Entity.IdOrden.HasValue)
                {
                    var result = await OrdenService.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se ha actualizado";
                }
                else
                {
                    var result = await OrdenService.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se ha insertado";
                }

                return RedirectToPage("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }


        }








    }
}