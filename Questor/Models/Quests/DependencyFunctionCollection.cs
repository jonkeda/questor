using System.Collections.ObjectModel;

namespace Questor.Models.Quests
{
    public class DependencyFunctionCollection : ObservableCollection<DependencyFunction>
    {

        private static DependencyFunctionCollection _default = new DependencyFunctionCollection
        {
            new DependencyFunction("technology", "Technology researched"),
            new DependencyFunction("quest", "Quest finished"),
            new DependencyFunction("story", "Story finished"),
        };
        public static DependencyFunctionCollection Default()
        {
            return _default;
        }
    }
}