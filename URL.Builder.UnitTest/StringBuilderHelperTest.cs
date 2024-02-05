using System.Text;
using URL.Builder.Helper;

namespace URL.Builder.UnitTest
{
    [TestClass]
    public class StringBuilderHelperTest
    {
        [TestMethod]
        public void TrimEmptyStringTest()
        {
            var output = "";

            var stringBuilder = StringBuilderHelper.TrimEnd(new StringBuilder(""), '/');

            Assert.AreEqual(output, stringBuilder.ToString());
        }

        [TestMethod]
        public void TrimACharTest()
        {
            var output = "aa";

            var stringBuilder = StringBuilderHelper.TrimEnd(new StringBuilder("aa//"), '/');

            Assert.AreEqual(output, stringBuilder.ToString());
        }

        [TestMethod]
        public void TrimNullStringBuilderTest()
        {
            var stringBuilder = StringBuilderHelper.TrimEnd(null, '/');

            Assert.AreEqual(null, stringBuilder);
        }
    }
}
