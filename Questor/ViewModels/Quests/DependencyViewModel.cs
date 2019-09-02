using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Questor.Models.Contexts;
using Questor.Models.Other;
using Questor.Models.Quests;

namespace Questor.ViewModels.Quests
{
    public class DependencyViewModel : ViewModel<Dependency>
    {
        private bool _functionNameIsValid;
        private bool _valueIsValid;

        public IEnumerable<DependencyFunction> Functions
        {
            get
            {
                foreach (DependencyFunction function in DependencyFunctionCollection.Default())
                {
                    yield return function;
                }
            }
        }
        
        public DependencyFunction Function
        {
            get { return Functions.FirstOrDefault(f => f.Name == Model.FunctionName); }
            set
            {
                Model.FunctionName = value?.Name;
                NotifyPropertyChanged(nameof(Function));
                NotifyPropertyChanged(nameof(Data));
                NotifyPropertyChanged(nameof(Title));
            }
        }

        public Data Data
        {
            get { return CampaignContext.Data; }
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