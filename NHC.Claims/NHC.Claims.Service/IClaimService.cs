using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NHC.Claims.Service
{
    public interface IClaimService
    {
        Task<bool> AddClaimAsync(Entities.Claims claim);
        Task<bool> DeleteClaimByIdAsync(object Id);
        Task<List<Entities.Claims>> GetAllClaimsForYearAsync(int year);
        Task<Entities.Claims> GetClaimByIdAsync(object Id);

    }
}
