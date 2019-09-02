using System.Xml.Serialization;
using Questor.Models.Contexts;
using Questor.Models.Other;

namespace Questor.Models.Quests
{
    public class Project : BaseModel
    {
        private string _name = "VanilaQuests";
        private string _description = "Basic quests for Factorio Vanila.";
        private string _author = "Factorio";
        private string _title = "Vanila Quests";
        private string _factorioVersion = "0.17";
        private int _versionFix = 1;
        private int _versionMin = 17;
        private int _versionMax = 0;
        private Data _data;

        public Project()
        {
            Name = "new Project";
        }

        [XmlAttribute]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        [XmlAttribute]
        public int VersionMax
        {
            get { return _versionMax; }
            set { SetProperty(ref _versionMax, value); }
        }

        [XmlAttribute]
        public int VersionMin
        {
            get { return _versionMin; }
            set { SetProperty(ref _versionMin, value); }
        }

        [XmlAttribute]
        public int VersionFix
        {
            get { return _versionFix; }
            set { SetProperty(ref _versionFix, value); }
        }

        [XmlAttribute]
        public string FactorioVersion
        {
            get { return _factorioVersion; }
            set { SetProperty(ref _factorioVersion, value); }
        }

        [XmlAttribute]
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        [XmlAttribute]
        public string Author
        {
            get { return _author; }
            set { SetProperty(ref _author, value); }
        }

        [XmlAttribute]
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public CampaignCollection Campaigns { get; set; } = new CampaignCollection();

        public ModCollection Mods { get; set; } = new ModCollection();

        public Data Data
        {
            get { return _data; }
            set
            {
                CampaignContext.Data = value;
                SetProperty(ref _data, value);
            }
        }
    }
}