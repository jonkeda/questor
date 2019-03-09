namespace Questor.Models.Quests
{
    public class Campaign
    {
        public Campaign()
        {
            Name = "new campaign";
        }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public StoryCollection Stories { get; set; } = new StoryCollection();

        public QuestLineCollection QuestLines { get; set; } = new QuestLineCollection();

    }
}