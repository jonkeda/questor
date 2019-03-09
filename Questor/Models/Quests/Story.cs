namespace Questor.Models.Quests
{
    public class Story
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public QuestCollection Quests { get; set; } = new QuestCollection();
    }
}