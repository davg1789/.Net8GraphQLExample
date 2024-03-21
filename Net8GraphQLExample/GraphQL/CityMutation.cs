using GraphQL;
using GraphQL.Types;
using Net8GraphQLExample.Domain.Entities;
using Net8GraphQLExample.Domain.Interfaces.Repository;

namespace Net8GraphQLExample.GraphQL
{
    public class CityMutation : ObjectGraphType
    {
        public CityMutation(ICityRepository cityRepository) 
        {
            Field<CityType>(
                    "createCity",
                    arguments: new QueryArguments( new List<QueryArgument>
                    {
                        new QueryArgument<NonNullGraphType<CityInputType>> { Name = "city"}
                    }),
                    resolve: context =>
                    {
                        var city = context.GetArgument<City>("city");
                        return cityRepository.CreateAsync(city);
                    }                 
                );
        }
    }
}
