# gr_numbertowordscurrencyconverter
Convert numbers to words in Greek (display currency written in full text).
Written in C#.

## Thousand separators are optional.
eg:
`
1000000,00 => correct
1.000.000,00 > correct
`
## Numbers must be written following the Greek locale
eg
`
100,00 => correct
100.00 => wrong
`
## Ranges
Numbers must be between -999.999.999.999.999,99 and 999.999.999.999.999,99

## Modes
Currently, there are 4 modes available
[0]: eg: 1000,00 => Χίλια, 1000,55 => Χίλια και Πενήντα Πέντε
[1]: eg: 1000,00 => Χίλια, 1000,55 => Χίλια και Πενήντα Πέντε Λεπτά
[2]: eg: 1000,00 => Χίλια Ευρώ, 1000,55 => Χίλια Ευρώ και Πενήντα Πέντε Λεπτά
[3]: eg: 1000,00 => Χίλια Δολάρια, 1000,55 => Χίλια Δολάρια και Πενήντα Πέντε Λεπτά

## Usage
*Include NumberToWordsConverterGRLib.dll into your project.
*Available methods
** Currencies.GetNumberOfModes();
Displays an integer for each and every one mode (currently 4).
** Converter.ConvertToWords({selected_number}.ToString(), {selected_mode})
Returns the following response:
*** ConvertionComplete: boolean
*** Message: string

## The repository includes a console app for testing purposes.
Clone or download the full solution and run it locally for testing purposes.