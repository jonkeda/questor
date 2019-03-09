using System.Collections.ObjectModel;

namespace Questor.Models.Prototypes
{
    public class TechnologyCollection : Collection<Technology>
    {
        public static TechnologyCollection Default()
        {
            return new TechnologyCollection
            {
                new Technology("steel-processing"),
            };
        }
    }
}