using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Questor.ViewModels;

namespace Questor.UI
{
    public abstract class CollectionViewModel<C, VI, I, TCtx> : ViewModel, IEditModel, ITreeViewModel<TCtx>
        where C : ObservableCollection<I>
        where VI : IViewModel, IEditModel, new()
        where I : new()

    {
        protected CollectionViewModel()
        {
        }

        public ViewModelCollection<VI, TCtx> ModelViewModels { get; set; }

        public void Insert()
        {
            Models.Add(new I());
        }

        public virtual void Delete()
        {
        }

        private C _models;

        protected CollectionViewModel(C models)
        {
            Models = models;
        }

        private void AddModelsToViewModel(C items)
        {
            ModelViewModels = new ViewModelCollection<VI, TCtx>(items, this, ViewModelContext);
            foreach (I item in items)
            {
                ModelViewModels.Add(CreateItemViewModel(item));
            }

        }

        public C Models
        {
            get { return _models; }
            set
            {
                if (_models != null)
                {
                    _models.CollectionChanged -= ModelViewModelsOnCollectionChanged;
                }
                SetProperty(ref _models, value);
                if (_models != null)
                {
                    AddModelsToViewModel(_models);

                    _models.CollectionChanged += ModelViewModelsOnCollectionChanged;
                }
            }
        }

        protected virtual VI CreateItemViewModel(I model)
        {
            VI vi = new VI();
            if (vi is IViewModel modelVi)
            {
                modelVi.SetModel(model);
            }
            return vi;
        }

        private void ModelViewModelsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (I model in e.NewItems)
                {
                    ModelViewModels.Add(CreateItemViewModel(model));
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (I model in e.OldItems)
                {   
                    ModelViewModels.Remove(ModelViewModels.FirstOrDefault(i => ReferenceEquals(i.GetModel(), model)));
                }

            }
        }

        public VI Model { get; set; }

        public IList ParentCollection { get; set; }

        public bool IsExanded { get; set; } = true;

        private bool _isValid;        
        public bool IsValid
        {
            get { return _isValid; }
            set { SetProperty(ref _isValid, value); }
        }

        public ViewModel Parent { get; set; }

        public TCtx ViewModelContext { get; set; }

        public bool Validate()
        {
            bool isValid = true;

            foreach (VI model in ModelViewModels)
            {
                isValid &= model.Validate();
            }

            IsValid = isValid && DoValidate();
            return isValid;
        }

        protected virtual bool DoValidate()
        {
            return true;
        }
    }
}