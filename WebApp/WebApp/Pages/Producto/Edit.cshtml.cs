using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApp.Pages.Producto
{
    public class EditModel : PageModel
    {
        private readonly IProductoService ProductoService;

        public EditModel(IProductoService ProductoService, IProductoService IdProductoService)
        {
            this.ProductoService = ProductoService;
            this.ProductoService = IdProductoService;
        }

        [BindProperty]
        public ProductoEntity Entity { get; set; } = new ProductoEntity();
        public IEnumerable<ProductoEntity> IdProductoLista { get; set; } = new List<ProductoEntity>();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await ProductoService.GetById(new() { IdProducto = id });
                }

                IdProductoLista = await ProductoService.GetLista();

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
                if (Entity.IdProducto.HasValue)
                {
                    var result = await ProductoService.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se ha actualizado";
                }
                else
                {
                    var result = await ProductoService.Create(Entity);

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