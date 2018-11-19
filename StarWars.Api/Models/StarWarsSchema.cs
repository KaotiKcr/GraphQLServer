using System;
using GraphQL;
using GraphQL.Types;

namespace StarWars.Api.Models
{
    public class StarWarsSchema : Schema
    {
        public StarWarsSchema(IDependencyResolver resolver, StarWarsQuery query, StarWarsMutation mutation)
        {
            Query = query;
            Mutation = mutation;
            DependencyResolver = resolver;  
        }
    }
}