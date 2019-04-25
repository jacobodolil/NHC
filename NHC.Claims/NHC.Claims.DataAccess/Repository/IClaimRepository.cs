using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NHC.Claims.DataAccess.Repository
{
    public interface IClaimRepository
    {
        Task<bool> AddClaimAsync(DataModel.Claims claim);
        Task<bool> DeleteClaimByIdAsync(object Id);
        Task<IEnumerable<DataModel.Claims>> GetAllClaimsForYearAsync(int year);
        Task<DataModel.Claims> GetClaimByIdAsync(object Id);
    }
}
