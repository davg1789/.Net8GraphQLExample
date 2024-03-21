using GraphQL.Types;

namespace Net8GraphQLExample.GraphQL
{
    public class CityInputType : InputObjectGraphType
    {
        public CityInputType() 
        {
            Name = "CityInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<IntGraphType>("population");
            Field<NonNullGraphType<IntGraphType>>("stateId");
        }
    }
}
