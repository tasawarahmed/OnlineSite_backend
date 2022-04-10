using backend.DTOs;
using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Authorize]
    public class CityController : BaseController
    {
        private readonly IUnitOfWork uow;

        public CityController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            //throw new UnauthorizedAccessException("Unauthorized");
            var cities = await uow.CityRepository.GetCitiesAsync();

            var citiesDTO = from c in cities
                            select new CityDTO()
                            {
                                cityName = c.Name,
                                cityID = c.Id

                            };

            return Ok(citiesDTO);
        }

        /*
        //Post api/city/add?cityname=abc
        [HttpPost("add")]
        //Post api/city/add/abc
        [HttpPost("add/{cityname}")]
        public async Task<IActionResult> AddCity(string cityName)
        {
            City city = new City();
            city.Name = cityName;
            await dc.Cities.AddAsync(city);
            dc.SaveChanges();
            return Ok(city);
        }
        */

        //In case of form data we have to post a JSON object and not individual fields
        [HttpPost("post")]
        public async Task<IActionResult> AddCity(CityDTO city)
        {
            //Data annotations based Validation test is done even before entering into this line
            //This is all because of [ApiController] written on top of this class. If we comment this out, 
            //no validation error will be thrown. Before .Net Core 2.1 we had to check ModelState

            City c = new City();
            c.Name = city.cityName;
            c.Country = city.Country;
            c.LastUpdatedBy = 1;
            c.LastUpdatedOn = DateTime.Now;

            uow.CityRepository.AddCity(c);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        //In put method we have to provide all the fields even if we need to update only one.
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityDTO city)
        {
            var cityFromdb = await uow.CityRepository.FindCity(id);
            cityFromdb.LastUpdatedBy = 1;
            cityFromdb.LastUpdatedOn = DateTime.Now;
            cityFromdb.Country = city.Country;
            await uow.SaveAsync();
            return StatusCode(200);
        }

        //In put method we have to provide all the fields even if we need to update only one.
        [HttpPut("updateCityName/{id}")]
        public async Task<IActionResult> UpdateCityName(int id, CityUpdateDTO city)
        {
            var cityFromdb = await uow.CityRepository.FindCity(id);
            if (cityFromdb == null)
            {
                return BadRequest("Update not allowed");
            }
            cityFromdb.LastUpdatedBy = 1;
            cityFromdb.LastUpdatedOn = DateTime.Now;
            cityFromdb.Name = city.Name;
            await uow.SaveAsync();
            return StatusCode(200);
        }


        //In patch method we can do partial updates.
        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch)
        {
            var cityFromdb = await uow.CityRepository.FindCity(id);
            cityFromdb.LastUpdatedBy = 1;
            cityFromdb.LastUpdatedOn = DateTime.Now;

            cityToPatch.ApplyTo(cityFromdb, ModelState);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        //In case of form data we have to post a JSON object and not individual fields
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.CityRepository.DeleteCity(id);
            await uow.SaveAsync();
            return Ok(id);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Lahore";
        }
    }
}
