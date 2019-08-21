using System;
using AutoMapper;
using InsuranceCompany.API.Constants;
using InsuranceCompany.API.Domain.Models;
using InsuranceCompany.API.Domain.Services;
using InsuranceCompany.API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _transform;
        public ClientsController(IClientService clientService, IMapper transform)
        {
            this._clientService = clientService;
            this._transform = transform;
        }

        /// <summary>
        /// Lists of client data by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns> List of clients.</returns>
        /// api/clients/a0ece5db-cd14-4f21-812f-966633e7be86
        [HttpGet("{id}")]
        public ActionResult<ClientResource> GetDataById(Guid id)
        {
            var clientServiceResult = _clientService.GetById(id);
            if (!clientServiceResult.Success)
            {
                return BadRequest(new ErrorResource(clientServiceResult.Message));
            }
           
            if (clientServiceResult.Resource.Role != Role.Admin && clientServiceResult.Resource.Role != Role.User)
            {
                return Unauthorized();
            }
           
            return Ok(_transform.Map<Client, ClientResource>(clientServiceResult.Resource));
        }

        /// <summary>
        /// Client data by user name
        /// </summary>
        /// <param name="name"></param>
        /// <returns> Clients.</returns>
        /// api/clients/getByName/{name}
        [Route("[action]/{name}")]
        [HttpGet]
        public ActionResult<ClientResource> GetByName(string name)
        {
            var clientServiceResult = _clientService.GetByName(name);
            if (!clientServiceResult.Success)
            {
                return BadRequest(new ErrorResource(clientServiceResult.Message));
            }

            if (clientServiceResult.Resource.Role != Role.Admin && clientServiceResult.Resource.Role != Role.User)
            {
                return Unauthorized();
            }

            return Ok(_transform.Map<Client, ClientResource>(clientServiceResult.Resource));
        }

        // Only admins
        /// <summary>
        /// Client data by policyNumber
        /// </summary>
        /// <param name="policyNumber"></param>
        /// <returns> Clients.</returns>
        /// api/clients/getByPolicyNumber/{policyNumber}
        [Route("[action]/{policyNumber}")]
        [HttpGet]
        public ActionResult<ClientResource> GetByPolicyNumber(string policyNumber)
        {
            var clientServiceResult = _clientService.GetByPolicyNumber(policyNumber);
            if (!clientServiceResult.Success)
            {
                return BadRequest(new ErrorResource(clientServiceResult.Message));
            }

            if (clientServiceResult.Resource.Role != Role.Admin)
            {
                return Unauthorized();
            }

            return Ok(_transform.Map<Client, ClientResource>(clientServiceResult.Resource));
        }
    }
}
