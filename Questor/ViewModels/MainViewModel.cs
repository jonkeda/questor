using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Newtonsoft.Json;
using Questor.Extensions;
using Questor.Generators;
using Questor.Models.Other;
using Questor.Models.Prototypes;
using Questor.Models.Quests;
using Questor.UI;
using Questor.ViewModels.Quests;

namespace Questor.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private ProjectViewModel _project;
        private ViewModel _selectedItem;
        private string _filename;
        private Data _data;

        public MainViewModel()
        {
            Project = new ProjectViewModel();
        }

        #region Commands

        public ICommand NewCommand
        {
            get { return new TargetCommand(New); }
        }

        private void New()
        {
            if (MessageBox.Show("Clear existing Project?", "New Project", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Project = new ProjectViewModel();
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
                DefaultExt = ".Project",
                Filter = "Project|*.Project"
            };
            if (ofd.ShowDialog() == true)
            {
                _filename = ofd.FileName;
                Project = new ProjectViewModel(ofd.FileName.Load<Project>());
            }

        }

        public ICommand SaveCommand
        {
            get { return new TargetCommand(Save); }
        }

        private void Save()
        {
            if (!string.IsNullOrEmpty(_filename))
            {
                XmlSerializerEx.Save(_filename, Project.Model);
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    DefaultExt = ".Project",
                    Filter = "Project|*.Project"
                };
                if (sfd.ShowDialog() == true)
                {
                    XmlSerializerEx.Save(sfd.FileName, Project.Model);
                    _filename = sfd.FileName;
                }
            }
        }
        
        public ICommand LoadDataCommand
        {
            get { return new TargetCommand(LoadData); }
        }

        private void LoadData()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                DefaultExt = ".json",
                Filter = "Json|*.Json"
            };
            if (ofd.ShowDialog() == true)
            {
                string json = File.ReadAllText(ofd.FileName);

                DataPrototypes dataPrototypes = JsonConvert.DeserializeObject<DataPrototypes>(json);

                Project.Model.Data = new Data(dataPrototypes);
            }

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

        public ICommand CreateCommand
        {
            get { return new TargetCommand(Create, false); }
        }

        private void Create()
        {
            IEditModel editModel = SelectedItem as IEditModel;
            editModel?.Create();
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
            get { yield return Project; }
        }

        public ProjectViewModel Project
        {
            get { return _project; }
            set
            {
                if (SetProperty(ref _project, value))
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

        #region Generate
        
        public ICommand GenerateCommand
        {
            get { return new TargetCommand(Generate); }
        }

        private void WriteFile(string folder, string filename, string text)
        {
            Directory.CreateDirectory(folder);
            File.WriteAllText(Path.Combine(folder, filename), text);
        }

        private void Generate()
        {
            string modFolder = CreateModFolder(Project.Model);

            string infoJson = GenerateJson(Project.Model);
            WriteFile(modFolder, "info.json", infoJson);

            foreach (Campaign campaign in Project.Model.Campaigns)
            {
                string data = GenerateData(campaign);

                WriteFile(Path.Combine(modFolder, "campaigns"), $"{campaign.Name}.lua", data);
            }

            string control = GenerateControl(Project.Model);
            WriteFile(modFolder, "control.lua", control);

        }

        private string GenerateControl(Project project)
        {
            LuaCodeWriter cw = new LuaCodeWriter();

            foreach (Campaign campaign in project.Campaigns)
            {
                cw.AppendLine($@"require(""campaigns.{campaign.Name}"")");
            }

            cw.OpenLine("function init_questor()");
            foreach (Campaign campaign in Project.Model.Campaigns)
            {
                cw.WriteLine($@"remote.call(""questor"", ""addCampaign"", campaign_{campaign.Name})");
            }
            cw.CloseLine("end");


            cw.AppendLine("script.on_init(init_questor)");
            cw.AppendLine("script.on_load(init_questor)");

            return cw.ToString();
        }

        private string CreateModFolder(Project project)
        {
            string appfolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string modFolder = Path.Combine(appfolder, "Factorio", "mods", 
                $"{project.Name}_{project.VersionMax}.{project.VersionMin}.{project.VersionFix}");

            return modFolder;
        }

        private string GenerateData(Campaign campaign)
        {
            LuaCodeWriter lua = new LuaCodeWriter();

            lua.AddModel($"campaign_{campaign.Name}", campaign);

            return lua.ToString();
        }

        private string GenerateJson(Project project)
        {
           JsonCodeWriter cw = new JsonCodeWriter();

            cw.OpenLine();

            cw.AddElement("name", project.Name, true);

            cw.AddElement("version",  $"{project.VersionMax}.{project.VersionMin}.{project.VersionFix}", true);
            cw.AddElement("factorio_version", project.FactorioVersion, true);
            cw.AddElement("title", project.Title, true);
            cw.AddElement("author", project.Author, true);
            cw.AddElement("description", project.Description, true);

            cw.LineStart();
            cw.Append(@"""dependencies"": [""base >= 0.17"", ""Questor >= 0.0.0""");

            foreach (Mod mod in project.Mods)
            {
                cw.Append(", ");
                if (mod.Required)
                {
                    cw.Append($@"""{mod.Name} >= {mod.MinimumVersion}""");
                }
                else
                {
                    cw.Append($@"""? {mod.Name} >= {mod.MinimumVersion}""");
                }
            }

            cw.AppendLine(@"]");

            cw.CloseLine();

           return cw.ToString();
        }

        #endregion
    }
}
