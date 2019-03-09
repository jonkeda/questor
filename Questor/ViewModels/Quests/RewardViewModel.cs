using System.Collections.Generic;
using Questor.Models.Contexts;
using Questor.Models.Quests;

namespace Questor.ViewModels.Quests
{
    public class RewardCollectionViewModel : CollectionViewModel<RewardCollection, RewardViewModel, Reward>
    {
        public RewardCollectionViewModel(RewardCollection models) : base(models)
        {
        }
    }

    public class RewardViewModel : ViewModel<Reward>
    {

        public IEnumerable<RewardFunction> Functions
        {
            get
            {
                foreach (RewardFunction function in RewardFunctionCollection.Default())
                {
                    yield return function;
                }
            }
        }

        private RewardFunction _function;
        public RewardFunction Function
        {
            get { return _function; }
            set
            {
                if (SetProperty(ref _function, value))
                {
                    NotifyPropertyChanged(nameof(Values));
                }
            }
        }

        public IEnumerable<string> Values
        {
            get
            {
                return CampaignContext.GetValues(Function?.DataType);
            }
        }

    }
}