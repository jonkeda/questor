using Questor.Models.Quests;

namespace Questor.ViewModels.Quests
{
    public class ModCollectionViewModel : CollectionViewModel<ModCollection, ModViewModel, Mod>
    {
        public ModCollectionViewModel(ModCollection models) : base(models)
        {
        }
    }
}