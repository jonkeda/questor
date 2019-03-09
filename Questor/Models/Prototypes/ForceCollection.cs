using System.Collections.ObjectModel;

namespace Questor.Models.Prototypes
{
    public class ForceCollection : Collection<Force>
    {
        public static ForceCollection Default()
        {
            // https://lua-api.factorio.com/latest/LuaForce.html
            return new ForceCollection
            {
                new Force("character_trash_slot_count"),
            };
        }
    }
}