namespace URL.Builder
{
    public interface IURLBuilder
    {
        public IURLBuilder SetPath(string path);
        public IURLBuilder SetPort(int port);
        public IURLBuilder AddParameter(string key, string value);
        public IURLBuilder RemoveParameter(string key);

        public string ToString();
    }
}
