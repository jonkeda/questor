using Questor.Generators;

namespace Questor.Models.Quests
{
    public class QuestLine : BaseModel
    {
        public QuestLine()
        {
            Name = "new questline";
        }

        private string _name;
        private string _description;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _title;
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


        public QuestCollection Quests { get; set; } = new QuestCollection();

        public override void RenderData(LuaCodeWriter cw)
        {
            cw.AddName(Name, true);
            cw.AppendLine(@" = ");

            cw.OpenLine();

            cw.AddField("name", Name);
            cw.AddField("title", Title);
            cw.AddField("description", Description);

            cw.AddModels("quests", Quests);

            cw.Close();
        }
    }
}