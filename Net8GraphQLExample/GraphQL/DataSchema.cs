using GraphQL.Types;

namespace Net8GraphQLExample.GraphQL
{
    public class DataSchema : Schema
    {
        public DataSchema(IServiceProvider resolver) : base(resolver) 
        {
            Query = resolver.GetRequiredService<StateQuery>();
            Mutation = resolver.GetRequiredService<CityMutation>();
        }
    }
}
