using Questor.Generators;

namespace Questor.Models.Quests
{
    public class Reward : BaseModel
    {

        private string _functionName;
        private string _value;
        private int _amount;

        public string FunctionName
        {
            get { return _functionName; }
            set { SetProperty(ref _functionName, value); }
        }

        public string Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

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
    }
}