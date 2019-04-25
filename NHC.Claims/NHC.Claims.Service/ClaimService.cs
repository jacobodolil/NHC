using NHC.Claims.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHC.Claims.Service
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimrepository;
        public ClaimService(IClaimRepository claimRepository)
        {
            _claimrepository = claimRepository;
        }

        public async Task<bool> AddClaimAsync(Entities.Claims claim)
        {
            DataModel.Claims newClaim = new DataModel.Claims()
            {
                Name = claim.Name,
                Type = claim.Type,
                Year = claim.Year,
                DamageCost = claim.DamageCost
            };

            return await _claimrepository.AddClaimAsync(newClaim).ConfigureAwait(false);
        }

        public async Task<bool> DeleteClaimByIdAsync(object Id)
        {
            return await _claimrepository.DeleteClaimByIdAsync(Id).ConfigureAwait(false);
        }

        public async Task<Entities.Claims> GetClaimByIdAsync(object Id)
        {
            var claim = await _claimrepository.GetClaimByIdAsync(Id).ConfigureAwait(false);

            return new Entities.Claims()
            {
                Name = claim.Name,
                Type = claim.Type,
                Year = claim.Year,
                DamageCost = claim.DamageCost
            };
        }

        public async Task<List<Entities.Claims>> GetAllClaimsForYearAsync(int year)
        {
            var claims = await _claimrepository.GetAllClaimsForYearAsync(year).ConfigureAwait(false);
            return claims.Select(item => new Entities.Claims
            {
                Name = item.Name,
                Type = item.Type,
                Year = item.Year,
                DamageCost = item.DamageCost
            }).ToList();
        }
    }
}
