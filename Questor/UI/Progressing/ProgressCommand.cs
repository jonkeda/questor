using System;
using System.Windows.Input;

namespace Questor.UI.Progressing
{
    public class ProgressCommand : ICommand
    {
        private readonly ProgressCanExecuteDelegate _canExecute;
        private readonly ProgressDelegate _method;
        public string Title { get; set; } = "Progress";
        public string Label { get; set; }
        public bool IsCancelable { get; set; } = false;

        public ProgressCommand(ProgressDelegate method) : this(method, null, null, false)
        {
        }

        public ProgressCommand(ProgressDelegate method, string title, string label) : this(method, title, label, false)
        {
        }

        public ProgressCommand(ProgressDelegate method, string title, string label, bool isCancelable)
        {
            _method = method;
            Title = title;
            Label = label;
            IsCancelable = isCancelable;
        }

        public ProgressCommand(ProgressDelegate method, ProgressCanExecuteDelegate canExecute)
        {
            _method = method;
            _canExecute = canExecute;
        }

        #region ICommand Members

        public void Execute(object parameter)
        {
            Progress.Run(_method, Title, Label, IsCancelable);
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute();
            }
            return true;
        }

        public event EventHandler CanExecuteChanged;

        #endregion
    }
}
