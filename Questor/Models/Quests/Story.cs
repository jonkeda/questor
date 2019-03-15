namespace Questor.Models.Quests
{
    public class Story : BaseModel
    {
        private string _name;
        private string _description;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }


        public QuestCollection Quests { get; set; } = new QuestCollection();
    }
}