using Questor.UI;

namespace Questor.Models.Prototypes
{
    public class Item : PropertyNotifier
    {
        public Item()
        {
        }

        public Item(string name)
        {
            Name = name;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

    }
}