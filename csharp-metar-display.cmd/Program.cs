using CommandLine;
using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace csharp_metar_display.cmd
{
    class Program
    {
        // --Metar "CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019"

        static void Main(string[] args)
        {
            var parser = new Parser(config => { config.HelpWriter = Console.Out; config.CaseInsensitiveEnumValues = true; });
            var result = parser.ParseArguments<Options>(args)
            .WithParsed(options =>
            {
                DisplayMetar(options);
            });
        }

        private static void DisplayMetar(Options options)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(options.Culture);
            Display(options.Culture, MetarDisplay.GetWeatherMessage(options.Metar, options.OutputType));
        }

        private static void Display(string header, string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(header);
            Console.ResetColor();
            Console.WriteLine(message);
            Console.WriteLine();
        }
    }
}
