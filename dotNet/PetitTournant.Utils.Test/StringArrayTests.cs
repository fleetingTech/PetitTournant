using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PetitTournant.Utils.Test
{
    [TestClass]
    public class StringArrayTests
    {
        [TestMethod]
        public void ParseStringForKeyValue_Tests()
        {
            string key = "testkey";
            string value = "value";

            string space = key+": "+ value;
            string nospace = key + ":" + value; 
            string garbage = "asdsadsad"+key + ":" + value;
            string spaceBefore = "        " + key + ":" + value;
            string emptyStr = "               ";
            string actual = "    " + space;

            string[] arr = new string[] { space, nospace, garbage, spaceBefore, emptyStr, actual };


            int index = 0;

            string spaceResult;
            Assert.IsTrue(Utils.StringArray.ParseStringForKeyValue(arr, key, ref index, out spaceResult));
            StringAssert.Equals(spaceResult, value);
            Assert.AreEqual(1, index);

            string nospaceResult;
            Assert.IsTrue(Utils.StringArray.ParseStringForKeyValue(arr, key, ref index, out nospaceResult));
            StringAssert.Equals(nospaceResult, value);
            Assert.AreEqual(2, index);

            string garbageResult;
            Assert.IsTrue(Utils.StringArray.ParseStringForKeyValue(arr, key, ref index, out garbageResult));
            StringAssert.Equals(garbageResult, value);
            Assert.AreEqual(3, index);

            string spaceBeforeResult;
            Assert.IsTrue(Utils.StringArray.ParseStringForKeyValue(arr, key, ref index, out spaceBeforeResult));
            StringAssert.Equals(spaceBeforeResult, value);
            Assert.AreEqual(4, index);

            string twoLineResult;
            Assert.IsTrue(Utils.StringArray.ParseStringForKeyValue(arr, key, ref index, out twoLineResult));
            StringAssert.Equals(twoLineResult, value);
            Assert.AreEqual(6, index);
        }
    }
}
