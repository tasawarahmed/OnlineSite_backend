using backend.DTOs;
using backend.Helpers;
using backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    public class PropertyTypeController : BaseController
    {
        private readonly IUnitOfWork uow;
        readonly Mapper m = new Mapper();
        public PropertyTypeController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet("list")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyTypes()
        {
            var propertyTypes = await uow.PropertyTypeRepository.GetPropertyTypesAsync();
            List<KVPair> clientList = m.MapPropertyTypesToKVPairDTO(propertyTypes);
            return Ok(clientList);

        }

    }
}
