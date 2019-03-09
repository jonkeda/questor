using Questor.Models.Prototypes;

namespace Questor.Models.Quests
{
    public class RewardFunction
    {
        public RewardFunction()
        {
        }

        public RewardFunction(string name, string description, DataType dataType)
        {
            Name = name;
            Description = description;
            DataType = dataType;
        }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public DataType DataType { get; set; }
    }
}