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
    public class FurnishingTypeController : BaseController
    {
        private readonly IUnitOfWork uow;
        readonly Mapper m = new Mapper();
        public FurnishingTypeController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet("list")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyTypes()
        {
            var furnishingTypes = await uow.FurnishingTypeRepository.GetFurnishingTypesAsync();
            List<KVPair> clientList = m.MapFurnishingTypesToKVPairDTO(furnishingTypes);
            return Ok(clientList);
        }
    }
}
