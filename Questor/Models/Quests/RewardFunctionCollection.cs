using System.Collections.ObjectModel;
using Questor.Models.Prototypes;

namespace Questor.Models.Quests
{
    public class RewardFunctionCollection : ObservableCollection<RewardFunction>
    {

        private static RewardFunctionCollection _Default = new RewardFunctionCollection()
        {
            new RewardFunction("items", "Item", DataType.Item),
            new RewardFunction("technology", "Technology", DataType.Technology),
            new RewardFunction("enable_technology", "Technology enabled", DataType.Technology),
            new RewardFunction("recipe", "Recipe", DataType.Recipe),
            new RewardFunction("force", "Force modifier", DataType.Force),
        };

        public static RewardFunctionCollection Default()
        {
            return _Default;
        }
    }
}