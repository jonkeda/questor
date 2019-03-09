using System.Collections.ObjectModel;

namespace Questor.Models.Prototypes
{
    public class FluidCollection : Collection<Fluid>
    {
        public static FluidCollection Default()
        {
            return new FluidCollection
            {
                new Fluid("water"),
            };
        }
    }
}