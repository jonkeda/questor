using System.Collections.Generic;
using Questor.Models.Quests;
using Questor.UI;

namespace Questor.ViewModels.Quests
{
    public class CampaignViewModel : ViewModel<Campaign>
    {
        public CampaignViewModel() : base(new Campaign())
        {}

        public CampaignViewModel(Campaign model) : base(model)
        {}

        public IEnumerable<ViewModel> Items
        {
            get { yield return new  QuestLineCollectionViewModel(Model.QuestLines) ; }
        }
    }
}
