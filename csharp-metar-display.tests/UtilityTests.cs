using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace csharp_metar_display.tests
{
    [TestFixture, Category("Utility")]
    public class UtilityTests
    {
        [Test]
        public static void ConvertDegreesToCardinalAbbreviatedTest()
        {
            var t = 123.4.ConvertDegreesToCardinal(true);
            Assert.AreEqual("SE", t);
        }
        [Test]
        public static void ConvertDegreesToCardinalTest()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            var t = 123.4.ConvertDegreesToCardinal(false);
            Assert.AreEqual("SouthEast", t);
        }

        [Test]
        public static void ConvertDegreesToCardinalDetailedAbbreviatedTest()
        {
            var t = 123.4.ConvertDegreesToCardinalDetailed(true);
            Assert.AreEqual("ESE", t);
        }
        [Test]
        public static void ConvertDegreesToCardinalDetailedTest()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            var t = 123.4.ConvertDegreesToCardinalDetailed(false);
            Assert.AreEqual("EastSouthEast", t);
        }

        [Test]
        public static void TestAllCardinal()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            for (int i = 0; i < 8; i++)
            {
                var t = ((double)(i*45)).ConvertDegreesToCardinal(true);
                Assert.AreEqual(cardinals8[i], t);
            }
        }

        [Test]
        public static void TestAllCardinalDetailed()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            for (int i = 0; i < 16; i++)
            {
                var t = (((double)i * 22.5)).ConvertDegreesToCardinalDetailed(true);
                Assert.AreEqual(cardinals16[i], t);
            }
        }

        public static string[] cardinals8 = new string[] { "N", "NE", "E", "SE", "S", "SW", "W", "NW", "N" };
        public static string[] cardinals16 = new string[] { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };


        [Test]
        public static void ConvertCelsiusToFahrenheitTest()
        {
            Assert.AreEqual(32, 0.0.ConvertCelsiusToFahrenheit());
        }

        [Test]
        public static void ConvertFahrenheitToCelsiusTest()
        {
            Assert.AreEqual(0, 32.0.ConvertFahrenheitToCelsius());
        }
    }
}
