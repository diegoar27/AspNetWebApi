using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InsuranceCompany.API.Constants;
using InsuranceCompany.API.Domain.Models;
using InsuranceCompany.API.Domain.Services;
using InsuranceCompany.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyService _policyService;
        private readonly IClientService _clientService;
        private readonly IMapper _transform;
        public PoliciesController(IPolicyService policyService, IClientService clientService, IMapper transform)
        {
            this._clientService = clientService;
            this._policyService = policyService;
            this._transform = transform;
        }

        // Only admins
        /// <summary>
        /// Lists of policies data by user name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns> List of policy.</returns>
        // GET api/policies?userName={userName}
        [Route("[action]/{userName}")]
        [HttpGet]
        public ActionResult<IEnumerable<PolicyResource>> GetByUserName(string userName)
        {
            var clientServiceResult = _clientService.GetByName(userName);
            if (!clientServiceResult.Success)
            {
                return BadRequest(new ErrorResource(clientServiceResult.Message));
            }

            if (clientServiceResult.Resource.Role != Role.Admin && clientServiceResult.Resource.Role != Role.User)
            {
                return Unauthorized();
            }
            
            var policyServiceResult = _policyService.GetByUserName(userName);
            if (!policyServiceResult.Success)
            {
                return BadRequest(new ErrorResource(policyServiceResult.Message));
            }
            
            return Ok(policyServiceResult.Resource.Select(p => _transform.Map<Policy, PolicyResource>(p)));
        }
    }
}
