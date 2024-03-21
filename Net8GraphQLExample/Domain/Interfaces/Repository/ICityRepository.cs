using Net8GraphQLExample.Domain.Entities;

namespace Net8GraphQLExample.Domain.Interfaces.Repository
{
    public interface ICityRepository
    {
        Task<List<City>> GetByStateIdAsync(int id);

        Task<City> GetByIdAsync(int id);

        Task<City> GetByNameAsync(string name);

        Task<List<City>> GetAllAsync();

        Task<City> CreateAsync(City city);
    }
}
