using Questor.Models;
using Questor.Models.Contexts;
using Questor.UI;

namespace Questor.ViewModels.Quests
{
    public abstract class ViewModel<TM> : ViewModel<TM, CampaignContext> 
        where TM : BaseModel
    {
        protected ViewModel()
        {
        }

        protected ViewModel(TM model) : base(model)
        {
        }


    }
}