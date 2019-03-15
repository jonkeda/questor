using System.Collections.ObjectModel;
using Questor.Models.Contexts;
using Questor.UI;

namespace Questor.ViewModels.Quests
{
    public abstract class CollectionViewModel<C, TVi, T> : CollectionViewModel<C, TVi, T, CampaignContext>
        where C : ObservableCollection<T>
        where TVi : IViewModel, IEditModel, new()
        where T : new()
    {
        protected CollectionViewModel()
        {
        }

        protected CollectionViewModel(C models) : base(models)
        {
        }
    }
}