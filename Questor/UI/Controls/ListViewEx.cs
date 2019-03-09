using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Questor.UI.Controls
{
    public class ListViewEx : ListView
    {
        public ListViewEx()
        {
            AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(OnColumnClick));
        }

        #region Command

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(ListViewEx), new PropertyMetadata(null));

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(ListViewEx),
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
        
        #region Columns

        private void OnColumnClick(object sender, RoutedEventArgs e)
        {
            if (!(e.OriginalSource is GridViewColumnHeader columnHeader)
                || !(columnHeader.Column is GridViewColumnEx column) )
            {
                return;
            }

            string orderBy = column.OrderBy ?? column.Header as string;
            ICommand command = OrderByCommand;
            if (command != null
                && command.CanExecute(orderBy))
            {
                e.Handled = true;
                command.Execute(orderBy);
            }
        }

        public static readonly DependencyProperty OrderByCommandProperty =
            DependencyProperty.Register(nameof(OrderByCommand), typeof(ICommand), 
                typeof(ListViewEx), new PropertyMetadata(null));


        public ICommand OrderByCommand
        {
            get { return (ICommand)GetValue(OrderByCommandProperty); }
            set { SetValue(OrderByCommandProperty, value); }
        }

        #endregion

    }
}