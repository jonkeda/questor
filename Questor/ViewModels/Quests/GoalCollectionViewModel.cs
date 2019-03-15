using Questor.Models.Quests;

namespace Questor.ViewModels.Quests
{
    public class GoalCollectionViewModel : CollectionViewModel<GoalCollection, GoalViewModel, Goal>
    {
        public GoalCollectionViewModel(GoalCollection models) : base(models)
        {
        }
    }
}