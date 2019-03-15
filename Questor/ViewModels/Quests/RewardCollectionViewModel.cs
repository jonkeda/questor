using Questor.Models.Quests;

namespace Questor.ViewModels.Quests
{
    public class RewardCollectionViewModel : CollectionViewModel<RewardCollection, RewardViewModel, Reward>
    {
        public RewardCollectionViewModel(RewardCollection models) : base(models)
        {
        }
    }
}