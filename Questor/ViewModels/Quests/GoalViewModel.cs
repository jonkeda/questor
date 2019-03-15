using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Questor.Models.Contexts;
using Questor.Models.Quests;

namespace Questor.ViewModels.Quests
{
    public class GoalViewModel : ViewModel<Goal>
    {
        private bool _functionNameIsValid;
        private bool _valueIsValid;

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
            get { return Functions.FirstOrDefault(f => f.Name == Model.FunctionName); }
            set
            {
                Model.FunctionName = value?.Name;
                NotifyPropertyChanged(nameof(Values));
                NotifyPropertyChanged(nameof(Title));
            }
        }
        
        public IEnumerable<string> Values
        {
            get
            {
                return CampaignContext.GetValues(Function?.DataType);
            }
        }

        public string Title
        {
            get { return $@"{Function?.Name} {Model.Value} {Model.Amount}"; }
        }
        
        public bool FunctionNameIsValid
        {
            get { return _functionNameIsValid; }
            set { SetProperty(ref _functionNameIsValid, value); }
        }

        public bool ValueIsValid
        {
            get { return _valueIsValid; }
            set { SetProperty(ref _valueIsValid, value); }
        }

        protected override void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(Title));
        }       
        
        protected override bool DoValidate()
        {
            bool isValid = FunctionNameIsValid = !string.IsNullOrEmpty(Model.FunctionName);

            isValid &= ValueIsValid = !string.IsNullOrEmpty(Model.Value);

            return isValid;
        }
    }
}