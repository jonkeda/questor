using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Questor.Extensions;
using Questor.Models.Quests;
using Questor.UI;
using Questor.ViewModels.Quests;

namespace Questor.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private CampaignViewModel _campaign;
        private ViewModel _selectedItem;

        public MainViewModel()
        {
            Campaign = new CampaignViewModel();
        }

        #region Commands

        public ICommand NewCommand
        {
            get { return new TargetCommand(New); }
        }

        private void New()
        {
            if (MessageBox.Show("Clear existing campaign?", "New campaign", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Campaign = new CampaignViewModel();
            }
        }

        public ICommand LoadCommand
        {
            get { return new TargetCommand(Load); }
        }

        private void Load()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                DefaultExt = ".campaign",
                Filter = "campaign|*.campaign"
            };
            if (ofd.ShowDialog() == true)
            {
                Campaign = new CampaignViewModel(ofd.FileName.Load<Campaign>());
            }

        }

        public ICommand SaveCommand
        {
            get { return new TargetCommand(Save); }
        }

        private void Save()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                DefaultExt = ".campaign",
                Filter = "campaign|*.campaign"
            };
            if (sfd.ShowDialog() == true)
            {
                XmlSerializerEx.Save(sfd.FileName, Campaign.Model);
            }
        }

        public ICommand RefreshCommand
        {
            get { return new TargetCommand(Refresh); }
        }

        private void Refresh()
        {
           
        }

        public ICommand InsertCommand
        {
            get { return new TargetCommand(Insert); }
        }

        private void Insert()
        {
            IEditModel editModel = SelectedItem as IEditModel;
            editModel?.Insert();
        }

        public ICommand EditCommand
        {
            get { return new TargetCommand(Edit); }
        }

        private void Edit()
        {
         
        }

        public ICommand DeleteCommand
        {
            get { return new TargetCommand(Delete); }
        }

        private void Delete()
        {
            IEditModel editModel = SelectedItem as IEditModel;
            editModel?.Delete();
        }

        #endregion

        #region Properties

        public IEnumerable<ViewModel> Models
        {
            get { yield return Campaign; }
        }

        public CampaignViewModel Campaign
        {
            get { return _campaign; }
            set
            {
                if (SetProperty(ref _campaign, value))
                {
                    NotifyPropertyChanged(nameof(Models));
                }
            }
        }

        public ViewModel SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        #endregion
    }

    internal interface IEditModel
    {
        void Insert();
        void Delete();
    }
}
