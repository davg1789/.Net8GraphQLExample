using Microsoft.EntityFrameworkCore;
using Net8GraphQLExample.Data.Context;
using Net8GraphQLExample.Domain.Entities;
using Net8GraphQLExample.Domain.Interfaces.Repository;

namespace Net8GraphQLExample.Data.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly GraphQLExampleDbContext context;

        public CityRepository(GraphQLExampleDbContext context) 
        { 
            this.context = context;
        }
        public async Task<City> CreateAsync(City city)
        {
            await context.AddAsync(city);
            await context.SaveChangesAsync();
            return city;
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await context.Cities.ToListAsync();
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await context.Cities.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<City> GetByNameAsync(string name)
        {
            return await context.Cities.FirstOrDefaultAsync(s => s.Name.ToUpper() == name.ToUpper());
        }

        public async Task<List<City>> GetByStateIdAsync(int id)
        {
            return await context.Cities.Where(s => s.StateId == id).ToListAsync();
        }
    }
}
