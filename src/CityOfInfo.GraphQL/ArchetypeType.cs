using CityOfInfo.Domain;
using GraphQL.Types;

namespace CityOfHerosPlanner.GraphQL
{
    public class ArchetypeType : ObjectGraphType<Archetype>
    {
        public ArchetypeType()
        {
            Name = "Archetype";
            Description = "Your archetype is arguably the most important choice you make while creating a character. It determines which powers are—and aren't—available for you to use during the entire lifetime of your character. The decision of which archetype to play should be made based on what type of philosophy you wish to use for your character.";
            Field(a => a.Name).Description("The archetype name.");
            Field(a => a.Description).Description("The archetype description");
        }
    }
}
