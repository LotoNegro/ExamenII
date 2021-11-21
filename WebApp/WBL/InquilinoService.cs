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
        Task<DBEntity> Create(InquilinoEntity entity);
        Task<DBEntity> Delete(InquilinoEntity entity);
        Task<IEnumerable<InquilinoEntity>> Get();
        Task<InquilinoEntity> GetById(InquilinoEntity entity);
        Task<DBEntity> Update(InquilinoEntity entity);
    }

    public class InquilinoService : IInquilinoService1
    {
        private readonly IDataAccess sql;

        public InquilinoService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCrud

        //Metodo Get


        public async Task<IEnumerable<InquilinoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<InquilinoEntity>("exp.InquilinoObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //Metodo GetById
        public async Task<InquilinoEntity> GetById(InquilinoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<InquilinoEntity>("exp.InquilinoObtener", new
                { entity.IdInquilino });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Create

        public async Task<DBEntity> Create(InquilinoEntity entity)
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
        public async Task<DBEntity> Update(InquilinoEntity entity)
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
        public async Task<DBEntity> Delete(InquilinoEntity entity)
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