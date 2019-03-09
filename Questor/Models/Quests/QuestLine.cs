namespace Questor.Models.Quests
{
    public class QuestLine
    {
        public QuestLine()
        {
            Name = "new questline";
        }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public QuestCollection Quests { get; set; } = new QuestCollection();
    }
}