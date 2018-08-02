using csharp_metar_decoder.entity;

namespace csharp_metar_display.metadata
{
    public class RawMetarMetadata : Metadata
    {
        /// <inheritdoc/>
        public override void Parse(DecodedMetar decodedMetar)
        {
            Label = strings.RawMetarLabel;
            Message = decodedMetar.RawMetar;
        }
    }
}
