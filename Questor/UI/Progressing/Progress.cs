using System.Windows;
using Questor.ViewModels.Other;
using Questor.Views.Other;

namespace Questor.UI.Progressing
{
    public class Progress
    {
        private ProgressWindow _window;
        private ProgressViewModel _viewModel;
        private readonly string _title;
        private readonly string _label;
        private readonly bool _isCancelable;

        private volatile bool _isCanceled;

        public bool IsCanceled
        {
            get { return _isCanceled; }
        }

        private Progress(string title, string label, bool isCancelable)
        {
            _title = title;
            _label = label;
            _isCancelable = isCancelable;
        }

        public void SetMessage(string message)
        {
            _viewModel.Message = message;
        }

        public void SetLabel(string label)
        {
            _viewModel.Label = label;
        }

        public void Cancel()
        {
            _isCanceled = true;
        }

        private void Run(ProgressDelegate method)
        {
            _viewModel = new ProgressViewModel(this);
            _window = new ProgressWindow(_viewModel)
            {
                Owner = Application.Current.MainWindow,
                Title =  _title
            };

            _viewModel.IsCancelable = _isCancelable;
            SetLabel(_label);

            _window.Run(this, method);
        }

        public static void Run(ProgressDelegate action, string title, string label)
        {
            Run(action, title, label, false);
        }

        public static void Run(ProgressDelegate action, string title, string label, bool isCancelable)
        {
            Progress progress = new Progress(title, label, isCancelable);

            progress.Run(action);
        }
    }
}
