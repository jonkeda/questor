using Questor.UI;

namespace Questor.Models.Quests
{
    public class Goal : PropertyNotifier
    {
        public Goal()
        {
            Name = "new goal";
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }        public string Description { get; set; }

        public string FunctionName { get; set; }

        public string Value { get; set; }

        public int Amount { get; set; }
    }
}