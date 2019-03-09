using System.Collections.Generic;
using Questor.Models.Contexts;
using Questor.Models.Prototypes;
using Questor.Models.Quests;

namespace Questor.ViewModels.Quests
{
    public class GoalCollectionViewModel : CollectionViewModel<GoalCollection, GoalViewModel, Goal>
    {
        public GoalCollectionViewModel(GoalCollection models) : base(models)
        {
        }
    }

    public class GoalViewModel : ViewModel<Goal>
    {
        private GoalFunction _function;

        public IEnumerable<GoalFunction> Functions
        {
            get
            {
                foreach (GoalFunction function in GoalFunctionCollection.Default())
                {
                    yield return function;
                }
            }
        }

        public GoalFunction Function
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