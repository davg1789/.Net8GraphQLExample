using Net8GraphQLExample.Data.Context;
using Net8GraphQLExample.Domain.Entities;

namespace Net8GraphQLExample.Data.Seed
{
    public static class SeedData
    {
        public static void SeedDbData(this GraphQLExampleDbContext graphQLExampleDbContext)
        {
            if (!graphQLExampleDbContext.States.Any())
            {
                var states = new State
                {

                };

                graphQLExampleDbContext.States.Add(states);
                graphQLExampleDbContext.SaveChanges();
            }
        }
    }
}
