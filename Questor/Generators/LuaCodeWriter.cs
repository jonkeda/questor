using System.Collections;
using System.Linq;
using System.Text;
using Questor.Models;

namespace Questor.Generators
{
    public enum LuaBlockClose
    {
        None,
        Comma,
        Line
    }

    public class LuaCodeWriter
    {
        private readonly StringBuilder _sb = new StringBuilder();
        private int _spaces;

        public override string ToString()
        {
            return _sb.ToString();
        }

        public bool IsEmpty()
        {
            return _sb.Length == 0;
        }

        public void OpenLine()
        {
            OpenLine("{");
        }

        public void OpenLine(string text)
        {
            WriteLine(text);
            _spaces++;
        }

        public void Append(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                _sb.Append(text);
            }
        }

        public void AppendLine(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                _sb.AppendLine(text);
            }
        }
        public void AppendLine()
        {
            _sb.AppendLine("");
        }

        private bool _hasRegion = false;

        public void Region(string text)
        {
            if (!_hasRegion)
            {
                _hasRegion = true;
                EmptyLine();
                Comment("region " + text);
                EmptyLine();
            }
        }

        public void EndRegion(string text)
        {
            if (_hasRegion)
            {
                EmptyLine();
                Comment("endregion " + text);
                EmptyLine();
                _hasRegion = false;
            }
        }

        public void Documentation(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                LineStart();
                _sb.Append("/** ");
                _sb.Append(text);
                _sb.AppendLine(" */");
            }
        }


        public void Comment(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                LineStart();
                _sb.Append("//");
                _sb.AppendLine(text);
            }
        }

        public void Write(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                LineStart();
                _sb.Append(text);
            }
        }

        public void WriteLine(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                LineStart();
                _sb.AppendLine(text);
            }
        }

        public void Tabs(int tabs)
        {
            for (int i = 0; i < tabs; i++)
            {
                _sb.Append("    ");
            }
        }

        public void LineStart()
        {
            for (int i = 0; i < _spaces; i++)
            {
                _sb.Append("    ");
            }
        }
        public void CloseLine(string text)
        {
            _spaces--;
            LineStart();
            _sb.AppendLine(text);

        }

        public void CloseLine()
        {
            _spaces--;
            LineStart();
            _sb.AppendLine("}");

        }

        public void Close()
        {
            _spaces--;
            LineStart();
            _sb.Append("}");

        }

        public void EmptyLine()
        {
            _sb.AppendLine("");
        }

        public void Replace(string key, string text)
        {
            _sb.Replace(key, text);
        }

        public void AddModel(string name, BaseModel model)
        {
            LineStart();
            _sb.Append(name);
            _sb.Append(" = ");
            model.RenderData(this);
        }

        public void AddName(string name, bool asIndex)
        {
            LineStart();
            if (asIndex)
            {
                _sb.Append(@"[""");
                AddValue(name);
                _sb.Append(@"""]");

            }
            else
            {
                _sb.Append(name);
            }
        }

        public bool AddField(string name, string value)
        {
            return AddField(name, value, false);
        }

        public bool AddField(string name, string value, bool asIndex)
        {
            if (!string.IsNullOrEmpty(name)
                && !string.IsNullOrEmpty(value))
            {
                AddName(name, asIndex);
                _sb.Append(@" = ");
                _sb.Append(@"""");
                AddValue(value);
                _sb.Append(@"""");
                _sb.AppendLine(",");

                return true;
            }

            return false;
        }

        public bool AddFieldObject(string name, string value)
        {
            if (!string.IsNullOrEmpty(name)
                && !string.IsNullOrEmpty(value))
            {
                AddName(name, false);
                _sb.Append(@" = ");
                AddValue(value);
                _sb.AppendLine(",");

                return true;
            }

            return false;
        }


        public bool AddField(string name, int value)
        {
            return AddField(name, value, false);
        }

        public bool AddField(string name, int value, bool asIndex)
        {
            if (!string.IsNullOrEmpty(name))
            {
                AddName(name, asIndex);
                _sb.Append(@" = ");
                _sb.Append(value);
                _sb.AppendLine(",");

                return true;
            }

            return false;
        }

        private void AddValue(string value)
        {
            _sb.Append(value);
        }

        public void AddModels(string name, IList list)
        {
            AddModels(name, list, false);
        }

        public void AddModels(string name, IList list, bool asIndex)
        {
            bool first = true;
            foreach (BaseModel model in list.OfType<BaseModel>())
            {
                if (first)
                {
                    AddName(name, asIndex);
                    _sb.AppendLine(@" = ");
                    OpenLine();
                    first = false;
                }
                model.RenderData(this);
                _sb.AppendLine(", ");
            }

            if (!first)
            {
                Close();
                _sb.AppendLine(",");
            }
        }
    }
}