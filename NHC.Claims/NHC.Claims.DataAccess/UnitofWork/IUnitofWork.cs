using NHC.Claims.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NHC.Claims.DataAccess.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        IRepository<DataModel.Claims> ClaimRepository { get; }
    }
}
