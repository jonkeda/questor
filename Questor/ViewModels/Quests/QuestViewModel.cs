    using System.Collections.Generic;
using Questor.Models.Quests;
using Questor.UI;

namespace Questor.ViewModels.Quests
{
    public class QuestViewModel : ViewModel<Quest>
    {
        private bool _nameIsValid;
        private bool _titleIsValid;
        private bool _descriptionIsValid;

        private DependencyCollectionViewModel _DependencyCollectionViewModel;
        public DependencyCollectionViewModel DependencyCollectionViewModel
        {
            get
            {
                if (_DependencyCollectionViewModel == null)
                {
                    _DependencyCollectionViewModel = new DependencyCollectionViewModel(Model.Dependencies);
                }
                return _DependencyCollectionViewModel;
            }
        }

        private GoalCollectionViewModel _goalCollectionViewModel;
        public GoalCollectionViewModel GoalCollectionViewModel
        {
            get
            {
                if (_goalCollectionViewModel == null)
                {
                    _goalCollectionViewModel = new GoalCollectionViewModel(Model.Goals);
                }
                return _goalCollectionViewModel;
            }
        }

        private RewardCollectionViewModel _rewardCollectionViewModel;
        public RewardCollectionViewModel RewardCollectionViewModel
        {
            get
            {
                if (_rewardCollectionViewModel == null)
                {
                    _rewardCollectionViewModel = new RewardCollectionViewModel(Model.Rewards);
                }
                return _rewardCollectionViewModel;
            }
        }
        public IEnumerable<ViewModel> Items
        {
            get 
            { 
                yield return DependencyCollectionViewModel; 
                yield return GoalCollectionViewModel; 
                yield return RewardCollectionViewModel;
            }
        }

        public bool NameIsValid
        {
            get { return _nameIsValid; }
            set { SetProperty(ref _nameIsValid, value); }
        }

        public bool TitleIsValid
        {
            get { return _titleIsValid; }
            set { SetProperty(ref _titleIsValid, value); }
        }

        public bool DescriptionIsValid
        {
            get { return _descriptionIsValid; }
            set { SetProperty(ref _descriptionIsValid, value); }
        }
        
        protected override bool DoValidate()
        {
            bool isValid = NameIsValid = !string.IsNullOrEmpty(Model.Name);

            isValid &= TitleIsValid = !string.IsNullOrEmpty(Model.Title);

            isValid &= DependencyCollectionViewModel.Validate(); 

            isValid &= GoalCollectionViewModel.Validate(); 

            isValid &= RewardCollectionViewModel.Validate();

            return isValid;
        }

    }
}