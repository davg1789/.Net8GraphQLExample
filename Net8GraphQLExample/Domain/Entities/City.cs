namespace Net8GraphQLExample.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public int Population { get; set; }
        public int StateId { get; set; }
    }
}