using System.Collections.ObjectModel;

namespace Questor.Models.Quests
{
    public class DependencyFunctionCollection : ObservableCollection<DependencyFunction>
    {

        public static DependencyFunctionCollection Default()
        {
            return new DependencyFunctionCollection
            {
                new DependencyFunction("technology", "Technology researched"),
                new DependencyFunction("quest", "Quest finished"),
                new DependencyFunction("story", "Story finished"),

            };
        }
    }
}