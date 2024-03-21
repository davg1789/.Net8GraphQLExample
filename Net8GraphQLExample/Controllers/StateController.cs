using Microsoft.AspNetCore.Mvc;
using Net8GraphQLExample.Domain.Entities;
using Net8GraphQLExample.Domain.Interfaces.Repository;

namespace Net8GraphQLExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository repository;

        private readonly ILogger<StateController> _logger;

        public StateController(ILogger<StateController> logger, IStateRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        [HttpGet()]
        public async Task<IEnumerable<State>> Get()
        {
            return await repository.GetAllAsync();
        }

        [HttpGet("[action]/{id}")]
        public async Task<State> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        [HttpGet("[action]/{name}")]
        public async Task<State> GetByNameAsync(string name)
        {
            return await repository.GetByNameAsync(name);
        }        
    }
}
