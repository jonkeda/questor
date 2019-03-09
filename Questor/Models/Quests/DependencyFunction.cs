namespace Questor.Models.Quests
{
    public class DependencyFunction
    {
        public DependencyFunction()
        {
        }

        public DependencyFunction(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}