using System.Xml.Serialization;
using Questor.Generators;
using Questor.UI;

namespace Questor.Models
{
    public abstract class BaseModel : PropertyNotifier
    {
        public virtual void RenderData(LuaCodeWriter cw)
        {}
    }
}
