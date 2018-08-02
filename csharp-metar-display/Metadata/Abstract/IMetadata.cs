using csharp_metar_decoder.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_metar_display.metadata
{
   public interface IMetadata
    {
        void Parse(DecodedMetar decodedMetar);
    }
}
