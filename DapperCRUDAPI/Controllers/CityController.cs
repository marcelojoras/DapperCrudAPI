using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperCRUDAPI.Controllers.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityRepository cityRepository;

        public CityController()
        {
            cityRepository = new CityRepository();
        }

        [HttpGet]
        public IEnumerable<City> Get()
        {
            return cityRepository.GetAll();
        }

        [HttpGet("{id}")]
        public City Get(int id)
        {
            return cityRepository.GetById(id); 
        }

        [HttpPost]
        public void Post([FromBody]City city)
        {
            if (ModelState.IsValid)
                cityRepository.Add(city);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] City city)
        {
            city.CityId = id;
            if (ModelState.IsValid)
                cityRepository.Update(city);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            cityRepository.Delete(id);
        }
    }
}
