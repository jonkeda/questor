using Questor.UI;

namespace Questor.Models.Prototypes
{
    public class Fluid : PropertyNotifier
    {
        public Fluid()
        {
        }

        public Fluid(string name)
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