using System.Text;

namespace Questor.Generators
{
    public class JsonCodeWriter
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

        public bool AddElement(string name, string value, bool addComma)
        {
            if (!string.IsNullOrEmpty(name)
                && !string.IsNullOrEmpty(value))
            {
                LineStart();

                _sb.Append(@"""");
                _sb.Append(name);
                _sb.Append(@"""");
                _sb.Append(@": ");
                _sb.Append(@"""");
                _sb.Append(value);
                _sb.Append(@"""");
                if (addComma)
                {
                    _sb.AppendLine(",");
                }
                else
                {
                    _sb.AppendLine("");
                }

                return true;
            }

            return false;
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

        public void EmptyLine()
        {
            _sb.AppendLine("");
        }

        public void Replace(string key, string text)
        {
            _sb.Replace(key, text);
        }
    }
}