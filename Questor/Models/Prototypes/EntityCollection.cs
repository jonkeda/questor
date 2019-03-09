using System.Collections.ObjectModel;

namespace Questor.Models.Prototypes
{
    public class EntityCollection : Collection<Entity>
    {
        public static EntityCollection Default()
        {
            return new EntityCollection
            {
                new Entity("water"),
            };
        }
    }
}