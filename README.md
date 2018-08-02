C# METAR display
=================
[![Build status](https://ci.appveyor.com/api/projects/status/y4f8f4u14ulvxty2?svg=true)](https://ci.appveyor.com/project/SafranCassiopee/csharp-metar-display/branch/master)
[![Coverage Status](https://coveralls.io/repos/github/SafranCassiopee/csharp-metar-display/badge.svg)](https://coveralls.io/github/SafranCassiopee/csharp-metar-display)
[![Latest Stable Version NuGet](https://img.shields.io/nuget/v/csharp-metar-display.svg)](https://www.nuget.org/packages/csharp-metar-display/)


A .NET library to display METARs in human-readable strings, fully unit tested (100% code coverage)

They use csharp-metar-display in production:

- [Safran AGS ](https://www.safran-electronics-defense.com/aerospace/commercial-aircraft/information-system/analysis-ground-station-ags) (private)
- Your service here ? Submit a pull request or open an issue !

Introduction
------------

This piece of software is a library package that translates METAR to human-readable strings.

METAR is a format made for weather information reporting. METAR weather reports are predominantly used by pilots and by meteorologists, who use it to assist in weather forecasting.
Raw METAR format is highly standardized through the International Civil Aviation Organization (ICAO).
  
*    [METAR definition on wikipedia](http://en.wikipedia.org/wiki/METAR)
*    [METAR format specification](http://www.wmo.int/pages/prog/www/WMOCodes/WMO306_vI1/VolumeI.1.html)
*    [METAR documentation](http://meteocentre.com/doc/metar.html)

Requirements
------------

This library package only requires .NET >= 4.5

It is currently tested automatically for .NET >= 4.5 using [nUnit 3.10.1](http://nunit.org/).

Although this is provided as a library project, a command line version (csharp-metar-display.cmd) is also included that can be used as both an example and a starting point.
csharp-metar-display.cmd requires [CommandLineParser](https://github.com/commandlineparser/commandline).

Usage:

```shell
csharp-metar-display.cmd.exe --Metar "CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019"

Observation Date: 27 day of the month at 15:15 UTC
Wind: from 320 degrees (northeast) at 17 knots
Visibility: 4828.02 meters
Temperatures: temperature -29°C (-20.2°F), dew point: -34°C (-29.2°F)
Pressure: 1001 hPa (30 inHg)
Clouds: broken at 4000 feet (1219 meters)
```

```shell
csharp-metar-display.cmd.exe --Metar "CYFB 271515Z 32017KT 3SM DRSN BKN040 M29/M34 A2957 RMK SC7 SLP019" --Culture "fr-FR"

Date d'observation: Jour 27 du mois à 15:15 UTC
Vent: de 320 degrés (nord-est) à 17 nouds
Visibilité: 4828.02 mètres
Températures: température -29°C (-20.2°F), point de rosée: -34°C (-29.2°F)
Pression: 1001 hectopascal (30 millimètres de mercure)
Nuages: fragmenté à 1219 mètres (4000 pieds)
```

If you want to integrate the library easily in your project, you should consider using the official nuget package available from https://www.nuget.org/.

```
nuget install csharp-metar-display
```

It is not mandatory though.

Setup
-----

- With nuget.exe *(recommended)*

From the Package Manager Console in Visual Studio

```shell
nuget install csharp-metar-display
```

Add a reference to the library, then add the following using directives:

```csharp
using csharp-metar-display;
```

- By hand

Download the latest release from [github](https://github.com/SafranCassiopee/csharp-metar-display/releases)

Extract it wherever you want in your project. The library itself is in the csharp-metar-display/ directory, the other directories are not mandatory for the library to work.

Add the csharp-metar-display project to your solution, then add a reference to it in your own project. Finally, add the same using directives than above.

Usage
-----

Call the MetarDisplay.GetWeatherMessage with your METAR as the first parameter (other parameters are optional and should be self-explanatory anyway). 
The returned string is your METAR in a human-readable form.

Contribute
----------

If you find a valid METAR that is badly parsed by this library, please open a github issue with all possible details:

- the full METAR causing problem
- the parsing exception returned by the library
- how you expected the decoder to behave
- anything to support your proposal (links to official websites appreciated)

If you want to improve or enrich the test suite, fork the repository and submit your changes with a pull request.

If you have any other idea to improve the library, please use github issues or directly pull requests depending on what you're more comfortable with.

In order to contribute to the codebase, you must fork the repository on github, than clone it locally with:

```shell
git clone https://github.com/<username>/csharp-metar-display
```

Install all the dependencies using nuget :

```shell
nuget restore csharp-metar-display\
```

You're ready to launch the test suite with:

```shell
nunit-console.exe /xml:results.xml csharp-metar-display.tests\bin\debug\csharp-metar-display.tests.dll
```

This library is fully unit tested, and uses [nUnit]((http://nunit.org/)) to launch the tests.

Appveyor is used for continuous integration, which triggers tests for .NET 4.5 for each push to the repo.
