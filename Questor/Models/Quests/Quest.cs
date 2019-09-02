using System.Linq;
using System.Xml.Serialization;
using Questor.Generators;

namespace Questor.Models.Quests
{
    public class Quest : BaseModel
    {
        public Quest()
        {
            Name = "new quest";
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


        public DependencyCollection Dependencies { get; set; } = new DependencyCollection();

        public GoalCollection Goals { get; set; } = new GoalCollection();

        public RewardCollection Rewards { get; set; } = new RewardCollection();

        public override void RenderData(LuaCodeWriter cw)
        {
            cw.AddName(Name, true);
            cw.AppendLine(@" = ");

            cw.OpenLine();

            cw.AddField("name", Name);
            cw.AddFieldObject("title",  CreateTitle());

            cw.AddField("description", Description);

            cw.AddModels("dependencies", Dependencies);
            cw.AddModels("goals", Goals);
            cw.AddModels("rewards", Rewards);

            cw.Close();
        }

        private string CreateTitle()
        {
            if (!string.IsNullOrEmpty(Title))
            {
                return $@"""{Title}""";
            }
            Goal goal = Goals.FirstOrDefault();
            if (goal == null)
            {
                return null;
            }

            return goal.CreateTitle();
        }
    }
}