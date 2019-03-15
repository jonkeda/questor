using System.Collections.ObjectModel;
using Questor.Models.Contexts;
using Questor.UI;

namespace Questor.ViewModels.Quests
{
    public abstract class ModelCollectionViewModel<TM, TC, TVi, T> : ModelCollectionViewModel<TM, TC, TVi, T, CampaignContext>
        where TC : ObservableCollection<T>
        where TVi : ViewModel, IViewModel, IEditModel, new()
        where T : new()
    {
        protected ModelCollectionViewModel()
        {
        }

        protected ModelCollectionViewModel(TM model) : base(model)
        {
        }
    }
}