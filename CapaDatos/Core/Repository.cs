using CapaDatos.BaseDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public ConsultorioContext dbContext;

        public Repository()
        {
            dbContext = new ConsultorioContext();
        }

        public void Agregar(T entidad)
        {
            dbContext.Set<T>().Add(entidad);
        }
        public IQueryable<T> Consulta()
        {
            return dbContext.Set<T>().AsQueryable();
        }
        public void Editar(T entidad)
        {

            dbContext.Set<T>();
        }
        public void Eliminar(T entidad)
        {
            dbContext.Set<T>().Remove(entidad);
        }
    }
}
