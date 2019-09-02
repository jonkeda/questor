using Questor.Models.Quests;

namespace Questor.ViewModels.Quests
{
    public class CampaignCollectionViewModel : CollectionViewModel<CampaignCollection, CampaignViewModel, Campaign>
    {
        public CampaignCollectionViewModel(CampaignCollection models) : base(models)
        {
            IsExpanded = true;
        }
    }
}