using System.Collections.ObjectModel;
using Questor.ViewModels;

namespace Questor.UI
{
    public abstract class ModelCollectionViewModel<TM, TC, TVi, TI, TCtx> : CollectionViewModel<TC, TVi, TI, TCtx>, IViewModel<TVi> 
        where TC : ObservableCollection<TI> 
        where TVi : ViewModel, IViewModel, IEditModel, new()
        where TI : new()

    {
        protected ModelCollectionViewModel() 
        {
        }

        protected ModelCollectionViewModel(TM model)
        {
            Model = model;
            Models = GetModelCollection();

        }

        private TM _model;

        public TM Model
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

        protected abstract TC GetModelCollection();
        public object GetModel()
        {
            return Model;
        }

        public void SetModel(object model)
        {
            Model = (TM) model;
        }

        public override void Delete()
        {
            ParentCollection.Remove(Model);
        }
    }
}