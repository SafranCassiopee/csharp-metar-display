using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace csharp_metar_display.tests
{
    [TestFixture, Category("GetWeatherMessage")]
    public class ReferenceTest
    {
        [Test]
        public void DisplayEnTest1()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            var message = MetarDisplay.GetWeatherMessage("CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019", OutputType.Text, true, true);
            Assert.AreEqual("Raw Metar: CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019\nObservation Date: 27 day of the month at 15:15 UTC\nWind: from 320 degrees (northeast) at 17 knots\nVisibility: 4828.02 meters\nTemperatures: temperature -29°C (-20.2°F), dew point: -34°C (-29.2°F)\nPressure: 1001 hPa (30 inHg)\nClouds: broken at 4000 feet (1219 meters)\n", message);
        }

        [Test]
        public void DisplayEnTest2()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            var message = MetarDisplay.GetWeatherMessage("CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019", OutputType.Text);
            Assert.AreEqual("Observation Date: 27 day of the month at 15:15 UTC\nWind: from 320 degrees (northeast) at 17 knots\nVisibility: 4828.02 meters\nTemperatures: temperature -29°C (-20.2°F), dew point: -34°C (-29.2°F)\nPressure: 1001 hPa (30 inHg)\nClouds: broken at 4000 feet (1219 meters)\n", message);
        }

        [Test]
        public void DisplayEnTest3()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            var message = MetarDisplay.GetWeatherMessage("EETU 271450Z 05005KT 9000 OVC006 01/M00 Q1019", OutputType.Text);
            Assert.AreEqual("Observation Date: 27 day of the month at 14:50 UTC\nWind: from 50 degrees (northeast) at 5 knots\nVisibility: 9000 meters\nTemperatures: temperature 1°C (33.8°F), dew point: 0°C (32°F)\nPressure: 1019 hPa (30 inHg)\nClouds: overcast at 600 feet (183 meters)\n", message);
        }


        [Test]
        public void DisplayEnTest4()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            var message = MetarDisplay.GetWeatherMessage("SBGU 271400Z 27006KT 8000 TS VCSH BKN020 FEW030CB BKN080 25/20 Q1017", OutputType.Text);
            Assert.AreEqual("Observation Date: 27 day of the month at 14:00 UTC\nWind: from 270 degrees (west) at 6 knots\nVisibility: 8000 meters\nTemperatures: temperature 25°C (77°F), dew point: 20°C (68°F)\nPressure: 1017 hPa (30 inHg)\nClouds: broken at 2000 feet (610 meters), few cumulonimbus at 3000 feet (914 meters), broken at 8000 feet (2438 meters)\n", message);
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

        [Test]
        public void DisplayHtmlTableTest()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            var message = MetarDisplay.GetWeatherMessage("CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019", OutputType.HtmlTable, true, true, "tableClass");
            Assert.AreEqual("<table class=\"tableClass\">\n<tr><td>Raw Metar</td><td>CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019</td></tr>\n<tr><td>Observation Date</td><td>27 day of the month at 15:15 UTC</td></tr>\n<tr><td>Wind</td><td>from 320 degrees (northeast) at 17 knots</td></tr>\n<tr><td>Visibility</td><td>4828.02 meters</td></tr>\n<tr><td>Temperatures</td><td>temperature -29&#176;C (-20.2&#176;F), dew point: -34&#176;C (-29.2&#176;F)</td></tr>\n<tr><td>Pressure</td><td>1001 hPa (30 inHg)</td></tr>\n<tr><td>Clouds</td><td>broken at 4000 feet (1219 meters)</td></tr>\n</table>", message);
        }

        [Test]
        public void DisplayHtmlDivTest()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            var message = MetarDisplay.GetWeatherMessage("CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019", OutputType.HtmlDiv, true, true, "divClass");
            Assert.AreEqual("<div class=\"divClass\">\n<b>Raw Metar&nbsp;:</b>&nbsp;CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019<br />\n<b>Observation Date&nbsp;:</b>&nbsp;27 day of the month at 15:15 UTC<br />\n<b>Wind&nbsp;:</b>&nbsp;from 320 degrees (northeast) at 17 knots<br />\n<b>Visibility&nbsp;:</b>&nbsp;4828.02 meters<br />\n<b>Temperatures&nbsp;:</b>&nbsp;temperature -29&#176;C (-20.2&#176;F), dew point: -34&#176;C (-29.2&#176;F)<br />\n<b>Pressure&nbsp;:</b>&nbsp;1001 hPa (30 inHg)<br />\n<b>Clouds&nbsp;:</b>&nbsp;broken at 4000 feet (1219 meters)<br />\n</div>", message);
        }

        [Test]
        public void DisplayHtmlTableWithNoClassTest()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            var message = MetarDisplay.GetWeatherMessage("CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019", OutputType.HtmlTable, true, true);
            Assert.AreEqual("<table>\n<tr><td>Raw Metar</td><td>CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019</td></tr>\n<tr><td>Observation Date</td><td>27 day of the month at 15:15 UTC</td></tr>\n<tr><td>Wind</td><td>from 320 degrees (northeast) at 17 knots</td></tr>\n<tr><td>Visibility</td><td>4828.02 meters</td></tr>\n<tr><td>Temperatures</td><td>temperature -29&#176;C (-20.2&#176;F), dew point: -34&#176;C (-29.2&#176;F)</td></tr>\n<tr><td>Pressure</td><td>1001 hPa (30 inHg)</td></tr>\n<tr><td>Clouds</td><td>broken at 4000 feet (1219 meters)</td></tr>\n</table>", message);
        }

        [Test]
        public void DisplayHtmlDivWithNoClassTest()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            var message = MetarDisplay.GetWeatherMessage("CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019", OutputType.HtmlDiv, true, true);
            Assert.AreEqual("<div>\n<b>Raw Metar&nbsp;:</b>&nbsp;CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019<br />\n<b>Observation Date&nbsp;:</b>&nbsp;27 day of the month at 15:15 UTC<br />\n<b>Wind&nbsp;:</b>&nbsp;from 320 degrees (northeast) at 17 knots<br />\n<b>Visibility&nbsp;:</b>&nbsp;4828.02 meters<br />\n<b>Temperatures&nbsp;:</b>&nbsp;temperature -29&#176;C (-20.2&#176;F), dew point: -34&#176;C (-29.2&#176;F)<br />\n<b>Pressure&nbsp;:</b>&nbsp;1001 hPa (30 inHg)<br />\n<b>Clouds&nbsp;:</b>&nbsp;broken at 4000 feet (1219 meters)<br />\n</div>", message);
        }

        [Test]
        public void DisplayInvalidMetarTest()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            var message = MetarDisplay.GetWeatherMessage("ABC", OutputType.HtmlDiv, true, true);
            Assert.AreEqual("ABC\nMETAR is not valid:\nStation ICAO code not found (4 char expected)\n", message);
        }

        [Test]
        public void DisplayRVRAndWindshearTest()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            var message = MetarDisplay.GetWeatherMessage("METAR CYWG 172000Z 30015G25KT 3/4SM R36/4000FT/U -SN BLSN BKN008 OVC040 M05/M08 A2992 REFZRA WS RWY36 RMK SF5NS3 SLP134", OutputType.Text, true, true);
            Assert.AreEqual("Raw Metar: METAR CYWG 172000Z 30015G25KT 3/4SM R36/4000FT/U -SN BLSN BKN008 OVC040 M05/M08 A2992 REFZRA WS RWY36 RMK SF5NS3 SLP134\nObservation Date: 17 day of the month at 20:00 UTC\nWind: from 300 degrees (northeast) at 15 knots, with gusts up to 25 knots\nVisibility: 1207.005 meters\nVisual Range: for runway 36 : 1219 meters (upward trend) \nTemperatures: temperature -5°C (23°F), dew point: -8°C (17.6°F)\nPressure: 1013 hPa (30 inHg)\nWindshear: Windshear on runway 36\nClouds: broken at 800 feet (244 meters), overcast at 4000 feet (1219 meters)\n", message);
        }

        [Test]
        public void DisplayAllRVRTest()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            var message = MetarDisplay.GetWeatherMessage("METAR CYWG 172000Z AUTO 30015G25KT 3/4SM R36/4000FT/D -SN BLSN BKN008 OVC040 M05/M08 A2992 REFZRA WS ALL RWY RMK SF5NS3 SLP134", OutputType.Text, true, true);
            Assert.AreEqual("Raw Metar: METAR CYWG 172000Z AUTO 30015G25KT 3/4SM R36/4000FT/D -SN BLSN BKN008 OVC040 M05/M08 A2992 REFZRA WS ALL RWY RMK SF5NS3 SLP134\nObservation Date: 17 day of the month at 20:00 UTC, automated observation\nWind: from 300 degrees (northeast) at 15 knots, with gusts up to 25 knots\nVisibility: 1207.005 meters\nVisual Range: for runway 36 : 1219 meters (downward trend) \nTemperatures: temperature -5°C (23°F), dew point: -8°C (17.6°F)\nPressure: 1013 hPa (30 inHg)\nWindshear: Windshear all runways \nClouds: broken at 800 feet (244 meters), overcast at 4000 feet (1219 meters)\n", message);
        }
    }
}
