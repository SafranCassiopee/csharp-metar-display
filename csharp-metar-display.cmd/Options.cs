using CommandLine;

namespace csharp_metar_display.cmd
{
    public class Options
    {
        [Option('m', "Metar", HelpText = "The metar to parse.", Required = true)]
        public string Metar { get; set; }

        [Option('c', "Culture", HelpText = "Culture information code.", Default = "en-US", Required = false)]
        public string Culture { get; set; }

        [Option('n', "ClassName", HelpText = "Class to use for html tag", Default = "", Required = false)]
        public string ClassName { get; set; }

        [Option('t', "OutputType", HelpText = "One of the expected output types: Text, HtmlTable or HtmlDiv, ", Default = OutputType.Text)]
        public OutputType OutputType { get; set; }
    }
}
