namespace Questor.Models.Quests
{
    public class Quest
    {
        public Quest()
        {
            Name = "new quest";
        }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public GoalCollection Goals { get; set; } = new GoalCollection();

        public RewardCollection Rewards { get; set; } = new RewardCollection();

        public DependencyCollection Dependencies { get; set; } = new DependencyCollection();
    }
}