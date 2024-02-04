namespace URL.Builder.UnitTest
{
    [TestClass]
    public class URLBuilderTest
    {
        [TestMethod]
        public void BaseURLWithPathTest()
        {
            var output = "https://meusite.com.br/user/change-password";

            var builder = new URLBuilder("https://meusite.com.br")
                .SetPath("user/change-password");

            string url = builder.ToString();

            Assert.AreEqual(output, url);
        }

        [TestMethod]
        public void BaseURLWithPathAndParametersTest()
        {
            var output = "https://meusite.com.br/user?key1=val1&key2=val2";

            var builder = new URLBuilder("https://meusite.com.br")
                .SetPath("user")
                .AddParameter("key1", "val1")
                .AddParameter("key2", "val2");

            string url = builder.ToString();

            Assert.AreEqual(output, url);
        }
    }
}