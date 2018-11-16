using AutoMapper;
using GraphQL.Types;

namespace StarWars.Api.Models
{
    public class StarWarsMutation : ObjectGraphType
    {
        public StarWarsMutation() { }

        public StarWarsMutation(Core.Data.IHumanRepository humanRepository, IMapper mapper)
        {
            Name = "Mutation";
            Description = "These are the things we can change";

            Field<HumanType>(
                "CreateOrUpdateHuman",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the human" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name", Description = "name of the human" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var name = context.GetArgument<string>("name");

                    var human = humanRepository.Get(id).Result;
                    if (human == null)
                    {
                        human = new StarWars.Core.Models.Human { Id = id, Name = name };
                        humanRepository.Add(human);
                    }
                    else
                    {
                        human.Id = id;
                        human.Name = name;
                        humanRepository.Update(human);
                    }
                    humanRepository.SaveChangesAsync();

                    var mapped = mapper.Map<Human>(human);
                    return mapped;
                }
            );
        }
    }
}