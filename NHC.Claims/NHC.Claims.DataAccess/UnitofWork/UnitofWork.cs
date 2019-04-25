using NHC.Claims.DataAccess.DataStoreContext;
using NHC.Claims.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NHC.Claims.DataAccess.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly SqlDataStoreContext _context;
        public UnitofWork(SqlDataStoreContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        private bool dispposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!dispposed && disposing)
            {
                _context.Dispose();
            }

            dispposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        IRepository<DataModel.Claims> _claimRepository;
        public IRepository<DataModel.Claims> ClaimRepository =>
            _claimRepository ?? (_claimRepository = new Repository<DataModel.Claims>(_context));
    }
}
