using Questor.Models.Prototypes;

namespace Questor.Models.Quests
{
    public class GoalFunction
    {
        public GoalFunction()
        {
        }

        public GoalFunction(string name, string description, DataType dataType, string localString, string actionString)
        {
            Name = name;
            Description = description;
            DataType = dataType;
            LocalString = localString;
            ActionString = actionString;
        }

        public string Name { get; }
        
        public string Description { get; }

        public DataType DataType { get; }

        public string LocalString { get; }

        public string ActionString { get; }
    }
}