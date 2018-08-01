namespace csharp_metar_display
{
    public static class UnitConverter
    {
        /// <summary>
        /// Converts Celsius degrees to Fahrenheit degrees
        /// </summary>
        /// <param name="celsius">Celsius degrees</param>
        /// <returns>Fahrenheit degrees</returns>
        public static double ConvertCelsiusToFahrenheit(this double celsius)
        {
            return ((9.0 / 5.0) * celsius) + 32;
        }

        /// <summary>
        /// Converts Fahrenheit degrees to Celsius degrees
        /// </summary>
        /// <param name="fahrenheit">Fahrenheit degrees</param>
        /// <returns>Celsius degrees</returns>
        public static double ConvertFahrenheitToCelsius(this double fahrenheit)
        {
            return (5.0 / 9.0) * (fahrenheit - 32);
        }

        /// <summary>
        /// Converts degrees to cardinal direction (8 cardinal points)
        /// </summary>
        /// <param name="degrees">Degrees</param>
        /// <param name="abbreviate">Abbreviates the cardinals if true</param>
        /// <returns></returns>
        public static string ConvertDegreesToCardinal(this double degrees, bool abbreviate = true)
        {
            string[] cardinals;

            if (abbreviate)
            {
                cardinals = new string[] { "N", "NE", "E", "SE", "S", "SW", "W", "NW", "N" };
            }
            else
            {
                cardinals = new string[]
                {
                    strings.CardinalNorth,
                    strings.CardinalNorthEast,
                    strings.CardinalEast,
                    strings.CardinalSouthEast,
                    strings.CardinalSouth,
                    strings.CardinalSouthWest,
                    strings.CardinalWest,
                    strings.CardinalNorthWest,
                    strings.CardinalNorth,
                };
            }

            return cardinals[(int)System.Math.Round((degrees % 360) / 45)];
        }

        /// <summary>
        /// Converts degrees to cardinal direction (16 cardinal points)
        /// </summary>
        /// <param name="degrees">Degrees</param>
        /// <param name="abbreviate">Abbreviates the cardinals if true</param>
        /// <returns></returns>
        public static string ConvertDegreesToCardinalDetailed(this double degrees, bool abbreviate = true)
        {
            degrees *= 10;
            string[] cardinals;

            if (abbreviate)
            {
                cardinals = new string[] { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
            }
            else
            {
                cardinals = new string[]
                {
                    strings.CardinalNorth,
                    strings.CardinalNorthNorthEast,
                    strings.CardinalNorthEast,
                    strings.CardinalEastNorthEast,
                    strings.CardinalEast,
                    strings.CardinalEastSouthEast,
                    strings.CardinalSouthEast,
                    strings.CardinalSouthSouthEast,
                    strings.CardinalSouth,
                    strings.CardinalSouthSouthWest,
                    strings.CardinalSouthWest,
                    strings.CardinalWestSouthWest,
                    strings.CardinalWest,
                    strings.CardinalWestNorthWest,
                    strings.CardinalNorthWest,
                    strings.CardinalNorthNorthWest,
                    strings.CardinalNorth,
                };
            }

            return cardinals[(int)System.Math.Round((degrees % 3600) / 225)];
        }
    }
}
