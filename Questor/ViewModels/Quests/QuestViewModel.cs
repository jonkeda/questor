using System.Collections.Generic;
using Questor.Models.Contexts;
using Questor.Models.Quests;
using Questor.UI;

namespace Questor.ViewModels.Quests
{
    public abstract class ViewModel<M> : ViewModel<M, CampaignContext>
    {
        protected ViewModel()
        {
        }

        protected ViewModel(M model) : base(model)
        {
        }
    }

    public class QuestViewModel : ViewModel<Quest>
    {
        public IEnumerable<ViewModel> Items
        {
            get 
            { 
                yield return new  DependencyCollectionViewModel(Model.Dependencies) ; 
                yield return new  GoalCollectionViewModel(Model.Goals) ; 
                yield return new  RewardCollectionViewModel(Model.Rewards) ;
            }
        }
    }
}