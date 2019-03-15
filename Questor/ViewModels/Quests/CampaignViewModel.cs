using System.Collections.Generic;
using Questor.Models.Quests;
using Questor.UI;

namespace Questor.ViewModels.Quests
{
    public class CampaignViewModel : ViewModel<Campaign>
    {
        private bool _nameIsValid;
        private bool _titleIsValid;
        private bool _descriptionIsValid;

        public CampaignViewModel() : base(new Campaign())
        {}

        public CampaignViewModel(Campaign model) : base(model)
        {}

        private QuestLineCollectionViewModel _questLineCollectionViewModel;
        public QuestLineCollectionViewModel QuestLineCollectionViewModel
        {
            get
            {
                if (_questLineCollectionViewModel == null)
                {
                    _questLineCollectionViewModel = new QuestLineCollectionViewModel(Model.QuestLines);
                }
                return _questLineCollectionViewModel;
            }
        }


        public IEnumerable<ViewModel> Items
        {
            get { yield return QuestLineCollectionViewModel; }
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

            isValid &= QuestLineCollectionViewModel.Validate();

            return isValid;
        }
    }
}
