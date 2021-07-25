using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private IAnimalRepository animalRepository;
        public AnimalController(IConfiguration configuration)
        {
            animalRepository = new SQLAnimalRepository(configuration.GetConnectionString("DBCon"));
        }

        [HttpPost("feed/{id}")]
        public bool Post(long id)
        {
            return animalRepository.Feeding(id);
        }
    }
}
