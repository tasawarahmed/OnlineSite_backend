using backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs;
using backend.Helpers;
using backend.Models;
using backend.Services;

namespace backend.Controllers
{
    public class PropertyController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly Mapper m = new Mapper();
        private readonly PhotoService photoservice;

        public PropertyController(IUnitOfWork uow, PhotoService photoservice)
        {
            this.uow = uow;
            this.photoservice = photoservice;
        }

        //property/list/1
        [HttpGet("list/{sellRent}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyList (int sellRent)
        {
            var properties =  await uow.PropertyRepository.GetPropertiesAsync(sellRent);
            List<PropertyListDTO> list = m.MapPropertiesToPropertiesDTO(properties);
            return Ok(list);
        }

        //property/add
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddProperty(PropertyDTO property)
        {
            Property p = m.MapPropertyToPropertyDTO(property);
            int userID = GetUserId();
            p.PostedBy = userID;
            p.LastUpdatedBy = userID;
            uow.PropertyRepository.AddProperty(p);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        //property/add/photo/1
        [HttpPost("add/photo/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> AddPropertyPhoto(IFormFile file, int id)
        {
            var result = await photoservice.UploadPhotoAsync(file);
            if (result.Error != null)
            {
                return BadRequest(result.Error.Message);
            }
            return Ok(201);
        }

        [HttpGet("detail/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyDetail(int id)
        {
            var property = await uow.PropertyRepository.GetPropertyDetailAsync(id);
            PropertyDetailDTO prty = m.MapPropertyToPropertyDetailDTO(property);
            return Ok(prty);
        }
    }
}