namespace URL.Builder
{
    public interface IURLBuilder
    {
        public IURLBuilder SetPath(string path);
        public IURLBuilder AddParameter(string key, string value);

        public string ToString();
    }
}
