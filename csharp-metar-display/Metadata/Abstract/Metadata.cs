using csharp_metar_decoder.entity;
using System.Web;

namespace csharp_metar_display.metadata
{
    public abstract class Metadata : IMetadata
    {
        public string Label { get; protected set; }
        public string Message { get; protected set; }

        /// <summary>
        /// Prepares the Label and Message for use
        /// </summary>
        /// <param name="decodedMetar"></param>
        public abstract void Parse(DecodedMetar decodedMetar);

        /// <summary>
        /// Outputs a string with a label
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Message)) return string.Empty;
            return $"{Label}: {Message}\n";
        }

        /// <summary>
        /// Outputs an HTML table row with a row header
        /// </summary>
        /// <returns></returns>
        public string ToHtmlTableRow()
        {
            if (string.IsNullOrEmpty(Message)) return string.Empty;
            return $"<tr><td>{HttpUtility.HtmlEncode(Label)}</td><td>{HttpUtility.HtmlEncode(Message)}</td></tr>\n";
        }

        /// <summary>
        /// Outputs an html line to be used in a div with a label
        /// </summary>
        /// <returns></returns>
        public string ToHtmlLine()
        {
            if (string.IsNullOrEmpty(Message)) return string.Empty;
            return $"<b>{HttpUtility.HtmlEncode(Label)}&nbsp;:</b>&nbsp;{HttpUtility.HtmlEncode(Message)}<br />\n";
        }
    }
}
