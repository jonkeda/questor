using System.Collections.ObjectModel;
using Questor.Models.Prototypes;

namespace Questor.Models.Quests
{
    public class RewardFunctionCollection : ObservableCollection<RewardFunction>
    {
        public static RewardFunctionCollection Default()
        {
            return new RewardFunctionCollection()
            {
                new RewardFunction("items", "Item", DataType.Item),
                new RewardFunction("technology", "Technology", DataType.Technology),
                new RewardFunction("enable_technology", "Technology enabled", DataType.Technology),

            };
        }
    }
}