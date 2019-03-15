using System.Collections;
using System.ComponentModel;
using Questor.Models;
using Questor.ViewModels;

namespace Questor.UI
{
    public abstract class ViewModel : PropertyNotifier
    { }

    public interface IViewModel<TM> : IViewModel
    {
        TM Model { get; set; }
    }

    public abstract class ViewModel<TM, TCtx> : ViewModel, IViewModel<TM>, ITreeViewModel<TCtx>, IEditModel
        where TM : BaseModel
    {
        protected ViewModel()
        {

        }

        protected ViewModel(TM model)
        {
            Model = model;
        }

        private bool _isValid;        
        public bool IsValid
        {
            get { return _isValid; }
            set { SetProperty(ref _isValid, value); }
        }

        private TM _model;
        public TM Model
        {
            get { return _model; }
            set
            {
                if (_model != null)
                {
                    _model.PropertyChanged -= ModelOnPropertyChanged;
                }
                SetProperty(ref _model, value);
                if (_model != null)
                {
                    _model.PropertyChanged += ModelOnPropertyChanged;
                }
            }
        }

        protected virtual void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Validate();
        }

        public object GetModel()
        {
            return Model;
        }

        public void SetModel(object model)
        {
            Model = (TM) model;
        }

        public IList ParentCollection { get; set; }
        public bool IsExanded { get; set; } = true;
        public ViewModel Parent { get; set; }
        public TCtx ViewModelContext { get; set; }

        public void Insert()
        {
            
        }

        public void Delete()
        {
            ParentCollection.Remove(Model);
        }

        public bool Validate()
        {
            IsValid = DoValidate();
            return IsValid;
        }

        protected virtual bool DoValidate()
        {
            return true;
        }
    }
}