using Microsoft.EntityFrameworkCore;
using Net8GraphQLExample.Domain.Entities;

namespace Net8GraphQLExample.Data.Context
{
    public class GraphQLExampleDbContext : DbContext
    {
        public GraphQLExampleDbContext() { }
        public GraphQLExampleDbContext(DbContextOptions<GraphQLExampleDbContext> options) : base(options) { }

        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
