using csharp_metar_decoder.entity;
using NString;
using System;
using System.Text;

namespace csharp_metar_display.metadata
{
    /// <inheritdoc/>
    public class VisibilityMetadata : Metadata
    {
        public override void Parse(DecodedMetar decodedMetar)
        {
            var visibility = new StringBuilder();
            if (decodedMetar.Cavok)
            {
                visibility.Append($"{strings.VisibilityCAVOK}");
            }
            else if (decodedMetar.Visibility?.PrevailingVisibility != null)
            {
                if (Math.Round(decodedMetar.Visibility.PrevailingVisibility.GetConvertedValue(Value.Unit.Meter)) == 9999)
                {
                    visibility.Append($"{strings.Visibility10KmOrMore}");
                }
                else
                {
                    visibility.Append(
                        StringTemplate.Format(
                            strings.PrevailingVisibility,
                            new
                            {
                                prevailingVisibility = decodedMetar.Visibility.PrevailingVisibility.GetConvertedValue(Value.Unit.Meter)
                            }, false));
                }
            }
            Label = strings.VisibilityLabel; Message = visibility.ToString();
        }
    }
}
