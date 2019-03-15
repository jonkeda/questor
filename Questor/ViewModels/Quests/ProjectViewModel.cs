using System.Collections.Generic;
using System.Linq;
using Questor.Models.Quests;
using Questor.UI;

namespace Questor.ViewModels.Quests
{
    public class ProjectViewModel : ViewModel<Project>
    {
        public ProjectViewModel() : this(new Project())
        {}

        public ProjectViewModel(Project model) : base(model)
        {

        }

        private ModCollectionViewModel _modCollectionViewModel;
        public ModCollectionViewModel ModCollectionViewModel
        {
            get
            {
                if (_modCollectionViewModel == null)
                {
                    _modCollectionViewModel = new ModCollectionViewModel(Model.Mods);
                }
                return _modCollectionViewModel;
            }
        }

        private CampaignCollectionViewModel _campaignCollectionViewModel;
        public CampaignCollectionViewModel CampaignCollectionViewModel
        {
            get
            {
                if (_campaignCollectionViewModel == null)
                {
                    _campaignCollectionViewModel = new CampaignCollectionViewModel(Model.Campaigns);
                }
                return _campaignCollectionViewModel;
            }
        }

        public IEnumerable<ViewModel> Items
        {
            get
            {
                yield return ModCollectionViewModel;
                yield return CampaignCollectionViewModel;
            }
        }

        public bool NameIsValid { get; set; }
        
        public bool TitleIsValid { get; set; }

        public bool DescriptionIsValid { get; set; }
        
        protected override bool DoValidate()
        {
            bool isValid = NameIsValid = !string.IsNullOrEmpty(Model.Name);

            isValid &= TitleIsValid = !string.IsNullOrEmpty(Model.Title);

            isValid &= ModCollectionViewModel.Validate();

            isValid &= CampaignCollectionViewModel.Validate();

            return isValid;
        }

    }
}