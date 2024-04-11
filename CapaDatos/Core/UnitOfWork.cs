using CapaDatos.BaseDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Core
{
    public class UnitOfWork
    {
        private readonly ConsultorioContext dbContext;
        private DbContextTransaction _transaction;

        public UnitOfWork()
        {
            this.dbContext = new ConsultorioContext();
        }

        public void ComenzarTransaccion()
        {
            _transaction = dbContext.Database.BeginTransaction();
        }
        public void ConfirmarTransaccion()
        {
            _transaction.Commit();
            _transaction.Dispose();
            _transaction = null;
        }
        public int Guardar()
        {
            int guardar = 0;
            if (_transaction == null)
            {
                try
                {
                    ComenzarTransaccion();
                    guardar = dbContext.SaveChanges();
                    ConfirmarTransaccion();
                    return guardar;
                }
                catch (Exception ex)
                {
                    ReversarTransaccion();
                    throw ex;
                }

            }
            return dbContext.SaveChanges();
        }
        public IRepository<T> Repository<T>() where T : class
        {
            var repository = new Repository<T>();
            repository.dbContext = dbContext;
            return repository; ;

        }
        public void ReversarTransaccion()
        {
            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;
        }
    }
}
