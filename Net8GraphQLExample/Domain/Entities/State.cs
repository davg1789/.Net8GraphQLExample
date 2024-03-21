﻿namespace Net8GraphQLExample.Domain.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int Population { get; set; }
        public List<City> Cities { get; set; }
    }
}
