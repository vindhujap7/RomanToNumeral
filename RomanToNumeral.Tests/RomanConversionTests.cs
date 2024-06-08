using NUnit.Framework;

namespace RomanToNumeral.Tests
{
    public class RomanConversionTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [TestCase("I", 1)]
        [TestCase("MMXXI", 2021)]
        [TestCase("MMMCMXCIX", 3999)]
        public void ConvertRomanToInt_Test(string roman, int expected)
        {
            int result = RomanConversion.ConvertRomanToInt(roman);
            Assert.AreEqual(expected, result);     
        }


        [TestCase("AA")]
        [TestCase("123")]
        public void ConvertRomanToInt_InvalidInput_Test(string roman)
        {
            var message = Assert.Throws<Exception>(() => RomanConversion.ConvertRomanToInt(roman));

            Assert.AreEqual("Roman Numerals with letters M,D,C,L,X,V,I only accepted", message.Message);

        }
    }
}