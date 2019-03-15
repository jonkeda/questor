namespace Questor.Models.Quests
{
    public class Mod : BaseModel
    {
        public Mod()
        {
            Name = "new mod";
        }

        public string Name { get; set; }

        public bool Required { get; set; }

        public string MinimumVersion { get; set; }

    }
}