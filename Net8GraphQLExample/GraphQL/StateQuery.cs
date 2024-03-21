using GraphQL;
using GraphQL.Types;
using Net8GraphQLExample.Domain.Interfaces.Repository;

namespace Net8GraphQLExample.GraphQL
{
    public class StateQuery : ObjectGraphType
    {
        public StateQuery(IStateRepository stateRepository, ICityRepository cityRepository)
        {
            Field<ListGraphType<StateType>>(
                "states",
                resolve: context => stateRepository.GetAllAsync());

            Field<StateType>(
               "state",
               arguments: new QueryArguments(new List<QueryArgument>
               {
                   new QueryArgument<IdGraphType>{ Name = "id" },
                   new QueryArgument<StringGraphType>{Name = "name"}
               }),
               resolve: context =>
               {
                   var result = stateRepository;
                   var id = context.GetArgument<int?>("id");
                   var name = context.GetArgument<string>("name");
                   if (id.HasValue)
                   {
                       return result.GetByIdAsync(id.Value);
                   }
                   else if (!string.IsNullOrWhiteSpace(name))
                   {
                       return  result.GetByNameAsync(name);
                   }

                   return result.GetAllAsync();
               });

            Field<ListGraphType<CityType>>(
               "cities",
               resolve: context => cityRepository.GetAllAsync());

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
                   var id = context.GetArgument<int?>("id");
                   var name = context.GetArgument<string>("name");
                   if (id.HasValue)
                   {
                       return result.GetByIdAsync(id.Value);
                   }
                   else if (!string.IsNullOrWhiteSpace(name))
                   {
                       return result.GetByNameAsync(name);
                   }

                   return result.GetAllAsync();
               });


        }
    }
}

