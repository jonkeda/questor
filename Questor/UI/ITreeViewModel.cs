using System.Collections;

namespace Questor.UI
{
    public interface ITreeViewModel<TCtx>
    {
        IList ParentCollection { get; set; }
        bool IsExanded { get; set; }
        ViewModel Parent { get; set; }

        TCtx ViewModelContext { get; set; }
    }
}