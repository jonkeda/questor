using System.Collections.ObjectModel;

namespace Questor.Models.Prototypes
{
    public class PlayerCollection : Collection<Player>
    {
        public static PlayerCollection Default()
        {
            // https://lua-api.factorio.com/latest/LuaControl.html
            return new PlayerCollection
            {
                new Player("character_trash_slot_count"),
            };
        }
    }
}