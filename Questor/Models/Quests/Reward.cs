namespace Questor.Models.Quests
{
    public class Reward
    {
        public Reward()
        {
            Name = "new reward";
        }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public string FunctionName { get; set; }

        public string Value { get; set; }

        public int Amount { get; set; }
    }
}