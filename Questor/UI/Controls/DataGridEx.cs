using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Questor.UI.Controls
{
    public class DataGridEx : DataGrid
    {
        #region Command

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(DataGridEx), new PropertyMetadata(null));

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(DataGridEx),
                new PropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            ICommand command = Command;
            if (command != null
                && command.CanExecute(CommandParameter))
            {
                e.Handled = true;
                command.Execute(CommandParameter);
            }
        }

        #endregion
    }
}