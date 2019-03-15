using Questor.Models.Quests;

namespace Questor.ViewModels.Quests
{
    public class QuestLineViewModel : ModelCollectionViewModel<QuestLine, QuestCollection, QuestViewModel, Quest>
    {
        private bool _nameIsValid;
        private bool _titleIsValid;
        private bool _descriptionIsValid;

        protected override QuestCollection GetModelCollection()
        {
            return Model.Quests;
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

            return isValid;
        }

    }
}