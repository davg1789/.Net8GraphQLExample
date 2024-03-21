using GraphQL.Types;
using Net8GraphQLExample.Domain.Entities;

namespace Net8GraphQLExample.GraphQL
{
    public class CityType : ObjectGraphType<City>
    {
        public CityType() 
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.StateId);
            Field(x => x.Population);
        }
    }
}
