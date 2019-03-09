using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Questor.ViewModels;

namespace Questor.UI
{
    public abstract class ViewModel : PropertyNotifier
    { }

    public interface IViewModel
    {
        object GetModel();
        void SetModel(object model);
    }

    public interface IViewModel<M> : IViewModel
    {
        M Model { get; set; }
    }

    public interface IViewModelContext
    {}

    public interface ITreeViewModel<TCtx>
    {
        IList ParentCollection { get; set; }
        bool IsExanded { get; set; }
        ViewModel Parent { get; set; }

        TCtx ViewModelContext { get; set; }
    }

    public abstract class ViewModel<M, TCtx> : ViewModel, IViewModel<M>, ITreeViewModel<TCtx>, IEditModel
    {
        protected ViewModel()
        {

        }

        protected ViewModel(M model)
        {
            _model = model;
        }

        private M _model;

        public M Model
        {
            get { return _model; }
            set { SetProperty(ref _model, value); }
        }

        public object GetModel()
        {
            return Model;
        }

        public void SetModel(object model)
        {
            Model = (M) model;
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
    }

    public abstract class CollectionViewModel<C, VI, I, TCtx> : ViewModel, IEditModel, ITreeViewModel<TCtx>
        where C : ObservableCollection<I>
        where VI : IViewModel, new()
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
        public ViewModel Parent { get; set; }
        public TCtx ViewModelContext { get; set; }
    }

    public abstract class ModelCollectionViewModel<M, C, VI, I, TCtx> : CollectionViewModel<C, VI, I, TCtx>, IViewModel<VI> 
        where C : ObservableCollection<I> 
        where VI : ViewModel, IViewModel, new()
        where I : new()

    {
        protected ModelCollectionViewModel() 
        {
        }

        protected ModelCollectionViewModel(M model)
        {
            Model = model;
            Models = GetModelCollection();

        }

        private M _model;

        public M Model
        {
            get { return _model; }
            set
            {
                if (SetProperty(ref _model, value))
                {
                    Models = GetModelCollection();
                }
            }
        }

        protected abstract C GetModelCollection();
        public object GetModel()
        {
            return Model;
        }

        public void SetModel(object model)
        {
            Model = (M) model;
        }

        public override void Delete()
        {
            ParentCollection.Remove(Model);
        }
    }
}