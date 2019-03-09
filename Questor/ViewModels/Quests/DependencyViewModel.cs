using System.Collections.Generic;
using Questor.Models.Quests;
using Questor.UI;

namespace Questor.ViewModels.Quests
{
    public class DependencyCollectionViewModel : CollectionViewModel<DependencyCollection, DependencyViewModel, Dependency>
    {
        public DependencyCollectionViewModel(DependencyCollection models) : base(models)
        {
        }
    }

    public class DependencyViewModel : ViewModel<Dependency>
    {
        public IEnumerable<DependencyFunction> Functions
        {
            get
            {
                foreach (DependencyFunction function in DependencyFunctionCollection.Default())
                {
                    yield return function;
                }
            }
        }

    }
}