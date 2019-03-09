using System.Windows.Input;
using Questor.UI;
using Questor.UI.Progressing;

namespace Questor.ViewModels.Other
{
    public class ProgressViewModel : ViewModel
    {
        public ProgressViewModel(Progress progress)
        {
            Progress = progress;
        }

        private string _message;
        private string _label;
        private bool _isCancelable;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public string Label
        {
            get { return _label; }
            set { SetProperty(ref _label, value); }
        }

        public bool IsCancelable
        {
            get { return _isCancelable; }
            set { SetProperty(ref _isCancelable, value); }
        }

        public Progress Progress { get; }

        public ICommand CancelCommand
        {
            get { return new TargetCommand(Cancel); }
        }

        private void Cancel()
        {
            Progress.Cancel();
        }
    }
}