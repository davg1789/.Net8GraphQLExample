using Net8GraphQLExample.Domain.Entities;

namespace Net8GraphQLExample.Domain.Interfaces.Repository
{
    public interface IStateRepository
    {
        Task<List<State>> GetAllAsync();

        Task<State> GetByIdAsync(int id);

        Task<State> GetByNameAsync(string name);

    }
}
