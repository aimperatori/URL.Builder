using System.Text;

namespace URL.Builder
{
    public class URLBuilder(string authority) : IURLBuilder
    {
        private readonly StringBuilder _stringBuilder = new();
        private string _authority = authority;
        private string? _path;
        private Dictionary<string, string> _parameters = new();

        public IURLBuilder SetPath(string path)
        {
            _path = path;
            return this;
        }

        public IURLBuilder AddParameter(string key, string value)
        {
            _parameters.Add(key, value);
            return this;
        }

        public override string ToString()
        {
            _stringBuilder.Clear();

            AppendAuthority();

            AppendPath();

            AppendParameters();

            return _stringBuilder.ToString();
        }

        private void AppendParameters()
        {
            _stringBuilder.Append(FormatParameters());
        }

        private void AppendAuthority()
        {
            _stringBuilder.Append(_authority);
        }

        private void AppendPath()
        {
            if (_path != null)
            {
                if (!_stringBuilder.ToString().EndsWith('/'))
                {
                    _stringBuilder.Append("/");
                }

                _stringBuilder.Append(_path);
            }
        }

        private string FormatParameters()
        {
            StringBuilder paramBuilder = new();

            if (_parameters.Count > 0)
            {
                paramBuilder.Append("?");
            }

            foreach (var parameter in _parameters)
            {
                paramBuilder.Append(FormatParameter(parameter));
                paramBuilder.Append("&");
            }

            if (_parameters.Count > 0)
            {
                paramBuilder.Remove(paramBuilder.Length - 1, 1);
            }

            return paramBuilder.ToString();
        }

        private static string FormatParameter(KeyValuePair<string, string> parameter)
        {
            return parameter.Key + "=" + parameter.Value;
        }
    }
}
