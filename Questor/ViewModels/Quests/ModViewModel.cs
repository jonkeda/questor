using Questor.Models.Quests;

namespace Questor.ViewModels.Quests
{
    public class ModViewModel : ViewModel<Mod>
    {
        private bool _nameIsValid;
        private bool _minimumVersionIsValid;

        public ModViewModel() : base(new Mod())
        {}

        public ModViewModel(Mod model) : base(model)
        {}
        
        public bool NameIsValid
        {
            get { return _nameIsValid; }
            set { SetProperty(ref _nameIsValid, value); }
        }

        public bool MinimumVersionIsValid
        {
            get { return _minimumVersionIsValid; }
            set { SetProperty(ref _minimumVersionIsValid, value); }
        }

        protected override bool DoValidate()
        {
            bool  isValid = NameIsValid = !string.IsNullOrEmpty(Model.Name);

            IsValid &= MinimumVersionIsValid = !string.IsNullOrEmpty(Model.MinimumVersion);

            return IsValid;
        }
    }
}
