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

        [TestMethod]
        public void BaseURLWithPathAndParametersAddedAndRemovedTest()
        {
            var output = "https://meusite.com.br/user?key2=val2";

            var builder = new URLBuilder("https://meusite.com.br")
                .SetPath("user")
                .AddParameter("key1", "val1")
                .AddParameter("key2", "val2");

            builder.RemoveParameter("key1");

            string url = builder.ToString();

            Assert.AreEqual(output, url);
        }

        [TestMethod]
        public void RemoveParameterTest()
        {
            var output = "https://meusite.com.br";

            var builder = new URLBuilder("https://meusite.com.br");

            builder.RemoveParameter("a");

            string url = builder.ToString();

            Assert.AreEqual(output, url);
        }

        [TestMethod]
        public void RemoveAddedParameterTest()
        {
            var output = "https://meusite.com.br";

            var builder = new URLBuilder("https://meusite.com.br")
                .AddParameter("foo", "bar");

            builder.RemoveParameter("foo");

            string url = builder.ToString();

            Assert.AreEqual(output, url);
        }

        [TestMethod]
        public void SetTwoTimesPathTest()
        {
            var output = "https://meusite.com.br/user";

            var builder = new URLBuilder("https://meusite.com.br")
                .SetPath("usuario");

            builder.SetPath("user");

            string url = builder.ToString();

            Assert.AreEqual(output, url);
        }

        [TestMethod]
        public void SetPort()
        {
            var output = "https://meusite.com.br:666";

            var builder = new URLBuilder("https://meusite.com.br/")
                .SetPort(666);

            string url = builder.ToString();

            Assert.AreEqual(output, url);
        }

        [TestMethod]
        public void SetPortAndPath()
        {
            var output = "https://meusite.com.br:666/user";

            var builder = new URLBuilder("https://meusite.com.br/")
                .SetPath("user")
                .SetPort(666);

            string url = builder.ToString();

            Assert.AreEqual(output, url);
        }
    }
}