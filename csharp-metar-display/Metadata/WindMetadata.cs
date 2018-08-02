using csharp_metar_decoder.entity;
using NString;
using System;
using System.Text;

namespace csharp_metar_display.metadata
{
    /// <inheritdoc/>
    public class WindMetadata : Metadata
    {
        public override void Parse(DecodedMetar decodedMetar)
        {
            var wind = new StringBuilder();

            if (decodedMetar.SurfaceWind != null)
            {
                if (decodedMetar.SurfaceWind.MeanDirection != null)
                {
                    wind.Append(StringTemplate.Format(strings.WindDetails,
                        new
                        {
                            meanDirectionDegrees = decodedMetar.SurfaceWind.MeanDirection.ActualValue,
                            meanDirectionCardinal = decodedMetar.SurfaceWind.MeanDirection.ActualValue.ConvertDegreesToCardinal(false).ToLowerInvariant(),
                            speedKnot = Math.Round(decodedMetar.SurfaceWind.MeanSpeed.GetConvertedValue(Value.Unit.Knot)),
                        }));
                }

                // SurfaceWind.SpeedVariations property contains gust wind speed
                if (decodedMetar.SurfaceWind.SpeedVariations != null)
                {
                    if (decodedMetar.SurfaceWind.MeanDirection != null)
                    {
                        wind.Append(", ");
                        wind.Append($"{strings.WindWith} ");
                    }
                    wind.Append(StringTemplate.Format(strings.WindGusts,
                        new { windGustsKnot = Math.Round(decodedMetar.SurfaceWind.SpeedVariations.GetConvertedValue(Value.Unit.Knot)) },
                        false));
                }

                // SurfaceWind.VariableDirection property contains variable wind direction flag information (VRB)
                if (decodedMetar.SurfaceWind.VariableDirection)
                {
                    wind.Append($" ({strings.WindVariableDirection})");
                }
                else if (decodedMetar.SurfaceWind.DirectionVariations?.Length > 1 && decodedMetar.SurfaceWind.DirectionVariations[0] != null && decodedMetar.SurfaceWind.DirectionVariations[1] != null)
                {
                    wind.Append(StringTemplate.Format(strings.WindDirectionVariations,
                        new
                        {
                            windDirectionVariationMinDegrees = decodedMetar.SurfaceWind.DirectionVariations[0].ActualValue,
                            windDirectionVariationMinCardinal = decodedMetar.SurfaceWind.DirectionVariations[0].ActualValue.ConvertDegreesToCardinal(false).ToLowerInvariant(),
                            windDirectionVariationMaxDegrees = decodedMetar.SurfaceWind.DirectionVariations[1].ActualValue,
                            windDirectionVariationMaxCardinal = decodedMetar.SurfaceWind.DirectionVariations[1].ActualValue.ConvertDegreesToCardinal(false).ToLowerInvariant(),
                        }, false));
                }
            }
            Label = strings.WindLabel;
            Message = wind.ToString();
        }
    }
}
