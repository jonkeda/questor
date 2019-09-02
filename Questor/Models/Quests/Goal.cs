using System.Xml.Serialization;
using Questor.Generators;

namespace Questor.Models.Quests
{
    public class Goal : BaseModel
    {
        private string _functionName;
        private string _value;
        private int _amount = 1;

        [XmlAttribute]
        public string FunctionName
        {
            get { return _functionName; }
            set { SetProperty(ref _functionName, value); }
        }

        [XmlAttribute]
        public string Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        [XmlAttribute]
        public int Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }

        public override void RenderData(LuaCodeWriter cw)
        {
            cw.OpenLine();

            cw.AddField("functionName", FunctionName);
            cw.AddField("value", Value);
            cw.AddField("amount", Amount);

            cw.Close();
        }

        public string CreateTitle()
        {
            GoalFunction function = GoalFunctionCollection.GetByName(FunctionName);

            return $@"{{""description.{function?.ActionString}"", {{""{function?.LocalString}.{Value}""}}, {Amount}}}";

        }
    }
}