using System.Text;
using URL.Builder.Helper;

namespace URL.Builder
{
    public class URLBuilder(string authority) : IURLBuilder
    {
        private StringBuilder _stringBuilder = new();
        private readonly string _authority = authority;
        private string? _path;
        private int _port;
        private readonly Dictionary<string, string> _parameters = new();

        public IURLBuilder SetPath(string path)
        {
            _path = path;
            return this;
        }

        public IURLBuilder SetPort(int port)
        {
            _port = port;
            return this;
        }

        public IURLBuilder AddParameter(string key, string value)
        {
            _parameters.Add(key, value);
            return this;
        }

        public IURLBuilder RemoveParameter(string key)
        {
            _parameters.Remove(key);
            return this;
        }

        public override string ToString()
        {
            _stringBuilder.Clear();

            AppendAuthority();

            AppendPort();

            AppendPath();

            AppendParameters();

            return _stringBuilder.ToString();
        }

        private void AppendAuthority()
        {
            _stringBuilder.Append(_authority);
        }

        private void AppendPort()
        {
            if (_port > 0)
            {
                _stringBuilder = StringBuilderHelper.TrimEnd(_stringBuilder, '/');                
                _stringBuilder.Append($":{_port}");
            }
        }

        private void AppendParameters()
        {
            _stringBuilder.Append(FormatParameters());
        }

        private void AppendPath()
        {
            if (_path is not null)
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
