using System.Windows.Input;
using MahApps.Metro.Controls;

namespace Questor.UI.Controls
{
    public class DialogWindow : MetroWindow
    {
        public DialogWindow()
        {
            KeyDown += DialogWindow_KeyDown;
        }

        private void DialogWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
