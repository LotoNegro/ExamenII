using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IInquilinoService1
    {
        Task<DBEntity> Create(ProductoService entity);
        Task<DBEntity> Delete(ProductoService entity);
        Task<IEnumerable<ProductoService>> Get();
        Task<ProductoService> GetById(ProductoService entity);
        Task<DBEntity> Update(ProductoService entity);
    }

    public class OrdenService : IInquilinoService1
    {
        private readonly IDataAccess sql;

        public OrdenService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCrud

        //Metodo Get


        public async Task<IEnumerable<ProductoService>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ProductoService>("exp.InquilinoObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //Metodo GetById
        public async Task<ProductoService> GetById(ProductoService entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ProductoService>("exp.InquilinoObtener", new
                { entity.IdInquilino });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Create

        public async Task<DBEntity> Create(ProductoService entity)
        {
            try
            {
                var result = sql.ExecuteAsync("exp.InquilinoInsertar", new
                {
                    entity.Nombre,
                    entity.PrimerApellido,
                    entity.SegundoApellido,
                    entity.Edad,
                    entity.FechaNacimiento



                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Update
        public async Task<DBEntity> Update(ProductoService entity)
        {
            try
            {
                var result = sql.ExecuteAsync("exp.InquilinoActualizar", new
                {
                    entity.IdInquilino,
                    entity.Nombre,
                    entity.PrimerApellido,
                    entity.SegundoApellido,
                    entity.Edad,
                    entity.FechaNacimiento


                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Delete
        public async Task<DBEntity> Delete(ProductoService entity)
        {
            try
            {
                var result = sql.ExecuteAsync("exp.InquilinoEliminar", new
                {
                    entity.IdInquilino,



                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }






        #endregion



    }
}