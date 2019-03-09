using System.Windows;

namespace Questor.UI.Interfaces
{
    public interface IParentWindow
    {
        WindowState WindowState { get; set; }
        void Focus();
    }
}