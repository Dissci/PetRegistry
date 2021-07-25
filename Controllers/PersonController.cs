using Evidence.utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Persistence;
using Project1.Persistence.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonRepository personRepository;
        private IAnimalRepository animalRepository;

        public PersonController(IConfiguration configuration)
        {
            personRepository = new SQLPersonRepository(configuration.GetConnectionString("DBCon"));
            animalRepository = new SQLAnimalRepository(configuration.GetConnectionString("DBCon"));
        }

        // GET: <ValuesController>
        [HttpGet]
        public List<Person> Get()
        {
            return personRepository.GetListofPetOwners();
        }

        [HttpGet("detail/{id}")]
        public Detail GetDetail(long id)
        {
            List<Animal> pets = animalRepository.GetListofPets(id);
            List<DateTime> dates = pets.Select(animal => animal.birthday).ToList();
            return new Detail(id, pets, DateTimeUtils.ToAgeString(DateTimeUtils.CalcAvgDateTime(dates)));
        }

        [HttpGet("overview")]
        public IEnumerable<Overview> GetOverview([FromQuery] string[] ID)
        {
            return personRepository.GetOverview(ID);
        }
    }
}
