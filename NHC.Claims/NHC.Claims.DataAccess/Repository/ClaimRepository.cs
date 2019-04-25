using NHC.Claims.DataAccess.UnitofWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NHC.Claims.DataAccess.Repository
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly IUnitofWork _unitofWork;
        public ClaimRepository(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<bool> AddClaimAsync(DataModel.Claims claim)
        {
            var result = await _unitofWork.ClaimRepository.InsertAsync(claim).ConfigureAwait(false);
            if (result)
            {
                await _unitofWork.SaveChangesAsync().ConfigureAwait(false);
            }

            return result;
        }

        public async Task<bool> DeleteClaimByIdAsync(object Id)
        {
            var result = await _unitofWork.ClaimRepository.DeleteAsync(Id).ConfigureAwait(false);
            if (result)
            {
                await _unitofWork.SaveChangesAsync().ConfigureAwait(false);
            }

            return result;
        }

        public async Task<IEnumerable<DataModel.Claims>> GetAllClaimsForYearAsync(int year)
        {
            return await _unitofWork.ClaimRepository.GetAllAsync(x => x.Year.Equals(year)).ConfigureAwait(false);
        }

        public async Task<DataModel.Claims> GetClaimByIdAsync(object Id)
        {
            return await _unitofWork.ClaimRepository.GetByIdAsync(Id).ConfigureAwait(false);
        }
    }
}
