using Questor.Models.Quests;

namespace Questor.ViewModels.Quests
{
    public class QuestLineCollectionViewModel : CollectionViewModel<QuestLineCollection, QuestLineViewModel, QuestLine>
    {
        public QuestLineCollectionViewModel(QuestLineCollection models) : base(models)
        {
        }
    }
}