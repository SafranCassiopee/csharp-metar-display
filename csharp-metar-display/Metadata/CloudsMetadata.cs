using csharp_metar_decoder.entity;
using NString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_metar_display.metadata
{
    public class CloudsMetadata : Metadata
    {
        /// <inheritdoc/>
        public override void Parse(DecodedMetar decodedMetar)
        {
            var clouds = new StringBuilder();
            var subWeatherMessageSb = new StringBuilder();
            if (decodedMetar.Clouds?.Count > 0)
            {
                clouds.Append(string.Join(", ", decodedMetar.Clouds.Select(cloud =>
                {
                    subWeatherMessageSb.Clear();

                    var cloudAmount = CloudsAmount.ContainsKey(cloud.Amount.ToString()) ? CloudsAmount[cloud.Amount.ToString()] : string.Empty;
                    var cloudType = CloudsType.ContainsKey(cloud.Type.ToString()) ? CloudsType[cloud.Type.ToString()] : string.Empty;
                    subWeatherMessageSb.Append($"{cloudAmount}{(cloud.Type != CloudLayer.CloudType.NULL ? string.Concat(" ", cloudType) : string.Empty)} ");

                    if (cloud.BaseHeight != null)
                    {
                        subWeatherMessageSb.Append(
                            StringTemplate.Format(
                                strings.CloudsDetails,
                                new
                                {
                                    feet = Math.Round(cloud.BaseHeight.GetConvertedValue(Value.Unit.Feet)),
                                    meters = Math.Round(cloud.BaseHeight.GetConvertedValue(Value.Unit.Meter))
                                }, false));
                    }

                    return subWeatherMessageSb;
                })));
            }
            Label = strings.CloudsLabel;
            Message = clouds.ToString();
        }

        public static Dictionary<string, string> CloudsAmount => new Dictionary<string, string>()
        {
            {  "FEW", strings.CloudsAmountFEW },
            {  "SCT", strings.CloudsAmountSCT },
            {  "BKN", strings.CloudsAmountBKN },
            {  "OVC", strings.CloudsAmountOVC },
            {   "VV", strings.CloudsAmountVV },
            {  "NSC", strings.CloudsAmountNSC },
            {  "CLR", strings.CloudsAmountCLR },
            { "NULL", strings.CloudsAmountNULL },
        };

        public static Dictionary<string, string> CloudsType => new Dictionary<string, string>()
        {
            {            "CB", strings.CloudsTypeCB },
            {           "TCU", strings.CloudsTypeTCU },
            { "CannotMeasure", strings.CloudsTypeCannotMeasure},
            {          "NULL", strings.CloudsTypeNULL },
        };
    }
}
