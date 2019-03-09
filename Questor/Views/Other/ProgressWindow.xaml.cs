using System;
using System.Threading.Tasks;
using System.Windows;
using Questor.Threading;
using Questor.UI.Progressing;
using Questor.ViewModels.Other;

namespace Questor.Views.Other
{
    public partial class ProgressWindow
    {
        public ProgressWindow(ProgressViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        }

        private ProgressDelegate _method;
        private Progress _progress;

        private ProgressViewModel ViewModel { get; }

        public void Run(Progress progress, ProgressDelegate method)
        {
            _progress = progress;
            _method = method;

            Task.Run(RunTask);

            ShowDialog();
        }

        private void RunTask()
        {
            try
            {
                _method.Invoke(_progress);
            }
            catch (Exception e)
            {
                ThreadDispatcher.Invoke(() => MessageBox.Show(e.Message));
            }
            finally
            {
                ThreadDispatcher.Invoke(Close);
            }
        }
    }
}
