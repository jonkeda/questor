using System.Collections.ObjectModel;
using Questor.Models.Contexts;
using Questor.Models.Quests;
using Questor.UI;

namespace Questor.ViewModels.Quests
{
    public abstract class CollectionViewModel<C, VI, I> : CollectionViewModel<C, VI, I, CampaignContext>
        where C : ObservableCollection<I>
        where VI : IViewModel, new()
        where I : new()
    {
        protected CollectionViewModel()
        {
        }

        protected CollectionViewModel(C models) : base(models)
        {
        }
    }

    public abstract class ModelCollectionViewModel<M, C, VI, I> : ModelCollectionViewModel<M, C, VI, I, CampaignContext>
        where C : ObservableCollection<I>
        where VI : ViewModel, IViewModel, new()
        where I : new()
    {
        protected ModelCollectionViewModel()
        {
        }

        protected ModelCollectionViewModel(M model) : base(model)
        {
        }
    }

    public class QuestLineCollectionViewModel : CollectionViewModel<QuestLineCollection, QuestLineViewModel, QuestLine>
    {
        public QuestLineCollectionViewModel(QuestLineCollection models) : base(models)
        {
        }
    }

    public class QuestLineViewModel : ModelCollectionViewModel<QuestLine, QuestCollection, QuestViewModel, Quest>
    {
        protected override QuestCollection GetModelCollection()
        {
            return Model.Quests;
        }
    }

    
}