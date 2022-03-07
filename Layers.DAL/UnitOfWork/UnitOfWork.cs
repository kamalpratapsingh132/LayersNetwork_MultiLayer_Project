using Layers.DAL.EntityDbContext;
using Layers.DAL.IRepository;
using Layers.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;



namespace Layers.DAL.UnitOfWork
{
   public class UnitOfWork
    {
        #region private fields
        private readonly ApplicationDBContext Context;
        private IAdminRegistrationRepository _IAdminRegistrationRepository;

        public UnitOfWork(ApplicationDBContext dbContext)
        {
            Context = dbContext;

            #endregion
        }
        #region public properties        


        public virtual IAdminRegistrationRepository IAdminRegistrationRepository
        {
            get { return _IAdminRegistrationRepository ?? (_IAdminRegistrationRepository = new AdminRegistrationRepository(Context)); }
        }


        #endregion

        public bool SaveChanges()
        {
            try
            {
                Context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        #region Disposable
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

