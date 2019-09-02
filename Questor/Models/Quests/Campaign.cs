using System.Xml.Serialization;
using Questor.Generators;

namespace Questor.Models.Quests
{
    public class Campaign : BaseModel
    {

        public Campaign()
        {
            Name = "new campaign";
        }

        private string _name;
        private string _description;
        [XmlAttribute]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _title;
        [XmlAttribute]
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public StoryCollection Stories { get; set; } = new StoryCollection();

        public QuestLineCollection QuestLines { get; set; } = new QuestLineCollection();

        public override void RenderData(LuaCodeWriter cw)
        {
            cw.OpenLine();

            cw.AddField("name", Name);
            cw.AddField("title",  string.IsNullOrEmpty(Title) ? Name : Title);
            cw.AddField("description", Description);

            cw.AddModels("questLines", QuestLines);

            cw.Close();
        }
    }
}