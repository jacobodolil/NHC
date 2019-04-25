using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NHC.Claims.Service;

namespace NHC.Claims.API.Controllers
{
    [Route("api/[controller]")]
    public class ClaimsController : Controller
    {
        private readonly IClaimService _claimService;
        public ClaimsController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        /// <summary>
        /// Get all claims for a Year
        /// </summary>
        /// <param name="year"></param>
        /// <returns>List of claims</returns>
        [Route("api/[controller]/GetClaimsForYear")]
        [HttpGet]
        public async Task<IList<Entities.Claims>> GetClaimsForYear(int year)
        {
            return await _claimService.GetAllClaimsForYearAsync(year).ConfigureAwait(false);
        }

        /// <summary>
        /// Get claim by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Claim details for the Id</returns>
        [HttpGet("{id}")]
        public async Task<Entities.Claims> Get(int id)
        {
            return await _claimService.GetClaimByIdAsync(id).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new claim
        /// </summary>
        /// <param name="claims"></param>
        [HttpPost]
        public async Task<IActionResult> Post(Entities.Claims claims)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                var result = await _claimService.AddClaimAsync(claims).ConfigureAwait(false);
                if (result)
                    return Ok();
                else
                    return Ok("There was an issue in updating the claim");
            }
        }

        /// <summary>
        /// Delete claim by Id
        /// </summary>
        /// <param name="id">Id of the Claim</param>
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _claimService.DeleteClaimByIdAsync(id).ConfigureAwait(false);
        }
    }
}
