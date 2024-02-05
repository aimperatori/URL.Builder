using System.Text;

namespace URL.Builder.Helper
{
    public static class StringBuilderHelper
    {
        public static StringBuilder TrimEnd(StringBuilder _sb, char trimChar)
        {
            if (_sb is null || _sb.Length == 0)
            {
                return _sb;
            }

            while (_sb[_sb.Length - 1] == trimChar)
            {
                _sb.Length--;
            }

            return _sb;
        }
    }
}
