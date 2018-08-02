using csharp_metar_decoder;
using csharp_metar_decoder.entity;
using System.Linq;
using System.Text;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using NString;
using csharp_metar_display.metadata;
using System.Collections.ObjectModel;

namespace csharp_metar_display
{
    public static class MetarDisplay
    {
        /// <summary>
        /// Retrieves a beautified string output of a METAR message
        /// </summary>
        /// <param name="rawMetar">The raw METAR.</param>
        /// <param name="strictMode">METAR strict decoding mode</param>
        /// <returns></returns>
        public static string GetWeatherMessage(string rawMetar, OutputType outputType = OutputType.Text, bool strictMode = true, bool showRawMetar = false, string htmlClass = "")
        {
            var decodedMetar = MetarDecoder.ParseWithMode(rawMetar, strictMode);
            return decodedMetar.GetWeatherMessage(outputType, showRawMetar, htmlClass);
        }

        private static ReadOnlyCollection<Metadata> _defaultMetadataToDisplay = new ReadOnlyCollection<Metadata>(new List<Metadata>()
        {
            new ObservationDateMetadata(),
            new WindMetadata(),
            new VisibilityMetadata(),
            new VisualRangeMetadata(),
            new TemperaturesMetadata(),
            new PressureMetadata(),
            new WindShearMetadata(),
            new CloudsMetadata(),
        });

        /// <summary>
        /// Retrieves a beautified string output of a DecodedMetar
        /// </summary>
        /// <param name="decodedMetar">The decoded METAR.</param>
        public static string GetWeatherMessage(this DecodedMetar decodedMetar, OutputType outputType = OutputType.Text, bool showRawMetar = false, string htmlClass = "")
        {
            var weatherMessageSb = new StringBuilder();

            if (!decodedMetar.IsValid)
            {
                weatherMessageSb.AppendLine($"{decodedMetar.RawMetar}");
                weatherMessageSb.AppendLine($"{strings.MetarIsNotValid}:");

                foreach (var metarChunkDecodedEx in decodedMetar.DecodingExceptions)
                {
                    weatherMessageSb.AppendLine($"{metarChunkDecodedEx.Message}");
                }
            }
            else
            {
                switch (outputType)
                {
                    default:
                    case OutputType.Text:
                        weatherMessageSb.Append(decodedMetar.OutputText(showRawMetar));
                        break;
                    case OutputType.HtmlTable:
                        weatherMessageSb.Append(decodedMetar.OutputHtmlTable(htmlClass, showRawMetar));
                        break;
                    case OutputType.HtmlDiv:
                        weatherMessageSb.Append(decodedMetar.OutputHtmlText(htmlClass, showRawMetar));
                        break;
                }
            }

            return weatherMessageSb.ToString();
        }
        private static string OutputText(this DecodedMetar decodedMetar, bool showRawMetar = false)
        {
            var weatherMessageSb = new StringBuilder();
            if (showRawMetar)
            {
                var rawMetarMetadata = new RawMetarMetadata();
                rawMetarMetadata.Parse(decodedMetar);
                weatherMessageSb.Append(rawMetarMetadata.ToString());
            }

            foreach (var metadata in _defaultMetadataToDisplay)
            {
                metadata.Parse(decodedMetar);
                weatherMessageSb.Append(metadata.ToString());
            }
            return weatherMessageSb.ToString();
        }
        private static string OutputHtmlTable(this DecodedMetar decodedMetar, string tableClass = "", bool showRawMetar = false)
        {
            var weatherMessageSb = new StringBuilder();
            if (string.IsNullOrEmpty(tableClass))
            {
                weatherMessageSb.Append($"<table>\n");
            }
            else
            {
                weatherMessageSb.Append($"<table class=\"{tableClass}\">\n");
            }
            if (showRawMetar)
            {
                var rawMetarMetadata = new RawMetarMetadata();
                rawMetarMetadata.Parse(decodedMetar);
                weatherMessageSb.Append(rawMetarMetadata.ToHtmlTableRow());
            }

            foreach (var metadata in _defaultMetadataToDisplay)
            {
                metadata.Parse(decodedMetar);
                weatherMessageSb.Append(metadata.ToHtmlTableRow());
            }

            weatherMessageSb.Append("</table>");
            return weatherMessageSb.ToString();
        }
        private static string OutputHtmlText(this DecodedMetar decodedMetar, string divClass = "", bool showRawMetar = false)
        {
            var weatherMessageSb = new StringBuilder();
            if (string.IsNullOrEmpty(divClass))
            {
                weatherMessageSb.Append($"<div>\n");
            }
            else
            {
                weatherMessageSb.Append($"<div class=\"{divClass}\">\n");
            }
            if (showRawMetar)
            {
                var rawMetarMetadata = new RawMetarMetadata();
                rawMetarMetadata.Parse(decodedMetar);
                weatherMessageSb.Append(rawMetarMetadata.ToHtmlLine());
            }
            foreach (var metadata in _defaultMetadataToDisplay)
            {
                metadata.Parse(decodedMetar);
                weatherMessageSb.Append(metadata.ToHtmlLine());
            }
            weatherMessageSb.Append("</div>");
            return weatherMessageSb.ToString();
        }
    }
}
