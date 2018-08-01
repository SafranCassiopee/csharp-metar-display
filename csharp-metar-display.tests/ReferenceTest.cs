using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace csharp_metar_display.tests
{
    [TestFixture]
    public class ReferenceTest
    {
        [Test]
        public void DisplayEnTest()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            var message = MetarDisplay.GetWeatherMessage("CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019", OutputType.Text, true);
            Assert.AreEqual("Observation Date: 27 day of the month at 15:15 UTC\nWind: from 320 degrees (northeast) at 17 knots\nVisibility: 4828.02 meters\nTemperatures: temperature -29°C (-20.2°F), dew point: -34°C (-29.2°F)\nPressure: 1001 hPa (30 inHg)\nClouds: broken at 4000 feet (1219 meters)\n", message);
        }

        [Test]
        public void DisplayFrTest()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
            var message = MetarDisplay.GetWeatherMessage("CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019", OutputType.Text, true);
            Assert.AreEqual("Date d'observation: Jour 27 du mois à 15:15 UTC\nVent: de 320 degrés (nord-est) à 17 nœuds\nVisibilité: 4828.02 mètres\nTempératures: température -29°C (-20.2°F), point de rosée: -34°C (-29.2°F)\nPression: 1001 hectopascal (30 millimètres de mercure)\nNuages: fragmenté à 1219 mètres (4000 pieds)\n", message);
        }

        [Test]
        public void DisplayDeTest()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
            var message = MetarDisplay.GetWeatherMessage("CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019", OutputType.Text, true);
            Assert.AreEqual("Beobachtungsdatum: Tag 27 des Monats um 15:15 UTC\nWind: von 320 Grad (nordwesten) zu 17 Knoten\nSichtweite: 4828.02 Meter\nTemperaturen: Temperatur -29°C (-20.2°F), Taupunkt: -34°C (-29.2°F)\nDruck: 1001 hPa (30 inHg)\nWolken: gebrochene zu 4000 Fuß (1219 Meter)\n", message);
        }
    }
}
