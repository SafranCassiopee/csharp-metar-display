using csharp_metar_decoder.entity;
using NString;
using System.Text;
using System.Text.RegularExpressions;

namespace csharp_metar_display.metadata
{
    public class ObservationDateMetadata : Metadata
    {
        /// <inheritdoc/>
        public override void Parse(DecodedMetar decodedMetar)
        {
            var observationDate = new StringBuilder();
            string sMetarDay = decodedMetar.Day.ToString();
            string sMetarTime = new Regex(@"\d{2}:\d{2}").Match(decodedMetar.Time).Value;

            observationDate.Append(StringTemplate.Format(strings.ObservationDetails,
                new
                {
                    metarDay = sMetarDay,
                    metarTime = sMetarTime,
                }, false));

            if (decodedMetar.Status == "AUTO")
            {
                observationDate.Append(", ");
                observationDate.Append($"{strings.AutomatedObservation}");
            }
            Label = strings.ObservationDateLabel;
            Message = observationDate.ToString();
        }
    }
}
