using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Data.Repositories.Base
{
    public class Repositorio<Entidad, Contexto> 
        : IRepositorio<Entidad> where Entidad : class
                                where Contexto : DbContext, new()
    {
        readonly DbContext _dbContext;

        private Contexto _entities = new Contexto();

        public Contexto context
        {

            get { return _entities; }
            set { _entities = value; }
        }


        public virtual void Agregar(Entidad entity)
        {
            _entities.Set<Entidad>().Add(entity);
        }

        public virtual void Eliminar(Entidad entity)
        {
            _entities.Set<Entidad>().Remove(entity);
        }

        public virtual void Editar(Entidad entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        public virtual IQueryable<Entidad> GetAll()
        {
            return _entities.Set<Entidad>();
        }

        #region IDisposable Support
        private bool disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _entities.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                this.disposed = true;
            }
        }



        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion



    }
}