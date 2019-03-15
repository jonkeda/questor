using Questor.Models.Quests;

namespace Questor.ViewModels.Quests
{
    public class DependencyCollectionViewModel : CollectionViewModel<DependencyCollection, DependencyViewModel, Dependency>
    {
        public DependencyCollectionViewModel(DependencyCollection models) : base(models)
        {
        }
    }
}