using System.Xml.Serialization;

namespace Questor.Models.Quests
{
    public class Story : BaseModel
    {
        private string _name;
        private string _description;
        [XmlAttribute]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        [XmlAttribute]
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
        
        public QuestCollection Quests { get; set; } = new QuestCollection();
    }
}