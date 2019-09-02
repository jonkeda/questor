using System.Xml.Serialization;

namespace Questor.Models.Quests
{
    public class Mod : BaseModel
    {
        public Mod()
        {
            Name = "new mod";
        }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool Required { get; set; }

        [XmlAttribute]
        public string MinimumVersion { get; set; }

    }
}