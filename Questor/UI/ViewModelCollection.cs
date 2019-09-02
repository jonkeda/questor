using System.Collections;
using System.Collections.ObjectModel;

namespace Questor.UI
{
    public class ViewModelCollection<TVm, TCtx> : ObservableCollection<TVm>
        where TVm : IViewModel
    {
        private readonly IList _items;
        private readonly TCtx _viewModelContext;
        private readonly ViewModel _parentViewModel;

        public ViewModelCollection(IList items, ViewModel parentViewModel, TCtx viewModelContext)
        {
            _items = items;
            _parentViewModel = parentViewModel;
            _viewModelContext = viewModelContext;
        }

        protected override void InsertItem(int index, TVm item)
        {
            if (item is ITreeViewModel<TCtx> treeViewModel)
            {
                treeViewModel.ParentCollection = _items;
                treeViewModel.ViewModelContext = _viewModelContext;
                treeViewModel.Parent = _parentViewModel;
            }
            base.InsertItem(index, item);
        }

    }
}