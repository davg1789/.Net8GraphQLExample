using Microsoft.EntityFrameworkCore;
using Net8GraphQLExample.Data.Context;
using Net8GraphQLExample.Domain.Entities;
using Net8GraphQLExample.Domain.Interfaces.Repository;

namespace Net8GraphQLExample.Data.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly GraphQLExampleDbContext context;

        public StateRepository(GraphQLExampleDbContext context)
        {
            this.context = context;
        }
        public async Task<List<State>> GetAllAsync()
        {
            return await context.States.ToListAsync();
        }

        public async Task<State> GetByIdAsync(int id)
        {
            return await context.States.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<State> GetByNameAsync(string name)
        {
            return await context.States.FirstOrDefaultAsync(s => s.Name.ToUpper() == name.ToUpper());
        }
    }
}
