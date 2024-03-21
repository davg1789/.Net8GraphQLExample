using Microsoft.AspNetCore.Mvc;
using Net8GraphQLExample.Domain.Entities;
using Net8GraphQLExample.Domain.Interfaces.Repository;

namespace Net8GraphQLExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository repository;

        private readonly ILogger<CityController> _logger;

        public CityController(ILogger<CityController> logger, ICityRepository repository)
        {
            _logger = logger;
            this.repository = repository;

        }

        [HttpGet()]
        public async Task<IEnumerable<City>> Get()
        {
            return await repository.GetAllAsync();
        }


        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<City>> GetByStateIdAsync(int id)
        {
            return await repository.GetByStateIdAsync(id);
        }

        [HttpGet("[action]/{id}")]
        public async Task<City> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        [HttpGet("[action]/{name}")]
        public async Task<City> GetByNameAsync(string name)
        {
            return await repository.GetByNameAsync(name);
        }

        [HttpPost("[action]")]
        public async Task<City> CreateAsync(City city)
        {
            return await repository.CreateAsync(city);
        }
    }
}
