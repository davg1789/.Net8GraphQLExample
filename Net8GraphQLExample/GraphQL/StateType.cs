using GraphQL;
using GraphQL.Types;
using Net8GraphQLExample.Data.Repository;
using Net8GraphQLExample.Domain.Entities;
using Net8GraphQLExample.Domain.Interfaces.Repository;

namespace Net8GraphQLExample.GraphQL
{
    public class StateType : ObjectGraphType<State>
    {
        public StateType(ICityRepository cityRepository) 
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Population);
            Field(x => x.Abbreviation);
            Field<ListGraphType<CityType>>(
                 "cities",
                 resolve: context => cityRepository.GetByStateIdAsync(context.Source.Id));

            Field<CityType>(
               "city",
               arguments: new QueryArguments(new List<QueryArgument>
               {
                   new QueryArgument<IdGraphType>{ Name = "id" },
                   new QueryArgument<StringGraphType>{Name = "name"}
               }),
            resolve: context =>
               {
                   var result = cityRepository;
                   var cityId = context.GetArgument<int?>("id");
                   var cityName = context.GetArgument<string>("name");
                   if (cityId.HasValue)
                   {
                       return result.GetByIdAsync(cityId.Value);
                   }
                   else if (!string.IsNullOrWhiteSpace(cityName))
                   {
                       return result.GetByNameAsync(cityName);
                   }

                   return result.GetAllAsync();
               });
        }
    }
}
