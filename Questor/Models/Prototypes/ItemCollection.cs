using System.Collections.ObjectModel;

namespace Questor.Models.Prototypes
{
    public class ItemCollection : Collection<Item>
    {
        public static ItemCollection Default()
        {
            return new ItemCollection
            {
                new Item("iron-plate"),
            };
        }
    }
}