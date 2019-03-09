namespace Questor.Models.Quests
{
    public class Dependency
    {
        public Dependency()
        {
            Name = "new dependency";
        }

        public string Name { get; set; }

        public string FunctionName { get; set; }

        public int Amount { get; set; }
    }
}