using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace NumberToWordsConverterGRLib
{
    public static class Converter
    {
        static int _hundredsMethodCounter = 0;
        static CultureInfo _greekCulture = new CultureInfo("el-GR");
        private static String ones(String Number, bool _numbersClassicWriting=true)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = _numbersClassicWriting ? "Ένα" : "Μία";
                    break;
                case 2:
                    name = "Δύο";
                    break;
                case 3:
                    name = _numbersClassicWriting ? "Τρία" : "Τρεις";
                    break;
                case 4:
                    name = _numbersClassicWriting ? "Τέσσερα" : "Τέσσερεις";
                    break;
                case 5:
                    name = "Πέντε";
                    break;
                case 6:
                    name = "Έξι";
                    break;
                case 7:
                    name = "Επτά";
                    break;
                case 8:
                    name = "Οχτώ";
                    break;
                case 9:
                    name = "Εννέα";
                    break;
            }
            return name;
        }


        private static String tens(String Number, bool _numbersClassicWriting= true)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Δέκα";
                    break;
                case 11:
                    name = "Έντεκα";
                    break;
                case 12:
                    name = "Δώδεκα";
                    break;
                case 13:
                    name = _numbersClassicWriting ? "Δεκατρία" : "Δεκατρείς";
                    break;
                case 14:
                    name = _numbersClassicWriting ? "Δεκατέσσερα" : "Δεκατέσσερεις";
                    break;
                case 15:
                    name = "Δεκαπέντε";
                    break;
                case 16:
                    name = "Δεκαέξι";
                    break;
                case 17:
                    name = "Δεκαεπτά";
                    break;
                case 18:
                    name = "Δεκαοχτώ";
                    break;
                case 19:
                    name = "Δεκαεννέα";
                    break;
                case 20:
                    name = "Είκοσι";
                    break;
                case 30:
                    name = "Τριάντα";
                    break;
                case 40:
                    name = "Σαράντα";
                    break;
                case 50:
                    name = "Πενήντα";
                    break;
                case 60:
                    name = "Εξήντα";
                    break;
                case 70:
                    name = "Εβδομήντα";
                    break;
                case 80:
                    name = "Ογδόντα";
                    break;
                case 90:
                    name = "Ενενήντα";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0", _numbersClassicWriting) + " " + ones(Number.Substring(1), _numbersClassicWriting);
                    }
                    break;
            }
            return name;
        }


        private static String hundreds(String Number, bool _numbersClassicWriting = true)
        {
            _hundredsMethodCounter++;
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 100:
                    if (_hundredsMethodCounter==1)
                    {
                        name = "Εκατό";
                    }
                    else
                    {
                        name = "Εκατόν";
                    }
                    
                    break;
                case 200:
                    name = _numbersClassicWriting ? "Διακόσια" : "Διακόσιες";
                    break;
                case 300:
                    name = _numbersClassicWriting ? "Τριακόσια" : "Τριακόσιες";
                    break;
                case 400:
                    name = _numbersClassicWriting ? "Τετρακόσια" : "Τετρακόσιες";
                    break;
                case 500:
                    name = _numbersClassicWriting ? "Πεντακόσια" : "Πεντακόσιες";
                    break;
                case 600:
                    name = _numbersClassicWriting ? "Εξακόσια" : "Εξακόσιες";
                    break;
                case 700:
                    name = _numbersClassicWriting ? "Επτακόσια" : "Επτακόσιες";
                    break;
                case 800:
                    name = _numbersClassicWriting ? "Οκτακόσια" : "Οκτακόσιες";
                    break;
                case 900:
                    name = _numbersClassicWriting ? "Εννιακόσια" : "Εννιακόσιες";
                    break;
                default:
                    if (_Number > 0)
                    {
                        string hundredsString = Number.Substring(0, 1) + "00";
                        string tensString = Number.Substring(1);
                        string onesString = Number.Substring(2);

                        name = hundreds(hundredsString, _numbersClassicWriting) + " " +  tens(tensString, _numbersClassicWriting);
                    }
                    break;
            }
            return name;
        }

        private static String thousands(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;


            //string hundredsString = Number.Substring(0, 1) + "00";
            //string tensString = Number.Substring(1);
            //string onesString = Number.Substring(2);
            //if (thousandsString == "1")
            //{
            //    word = " Χίλια ";
            //}
            //else
            //{
            //    word = " Χιλιάδες ";
            //}

            //word = hundreds(hundredsString) + " " + tens(tensString);
            string thousandsString = Number.Substring(Number.Length - 4, 1);
            string hundredsString = Number.Substring(Number.Length - 3, 3);

            if (Number.Length == 4)
            {

                if (thousandsString == "1")
                {
                    name = "Χίλια" + " " + hundreds(hundredsString);
                }
                else
                {
                    name = ones(thousandsString, false) + " " + "Χιλιάδες" + " " + hundreds(hundredsString);
                }
            }
            else if(Number.Length == 5)
            {
                string beforeThousandsString = Number.Substring(0, Number.Length - 3);
                name = tens(beforeThousandsString, false) + " " + "Χιλιάδες" + " " + hundreds(hundredsString);
            }
            else if (Number.Length == 6)
            {
                string beforeThousandsString = Number.Substring(0, Number.Length - 3);
                name = hundreds(beforeThousandsString, false) + " " + "Χιλιάδες" + " " + hundreds(hundredsString);
            }

            return name;
        }

        private static String ConvertWholeNumber(String Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX   
                bool isDone = false;//test if already translated   
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))   
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric   
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping   
                    String place = "";//digit grouping name:hundres,thousand,etc...   
                    switch (numDigits)
                    {
                        case 1://ones' range   

                            word = ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range   
                            word = tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range   
                            word = hundreds(Number);
                            isDone = true;
                            //place = " Εκατό ";
                            break;
                        case 4://thousands' range   
                        case 5:
                        case 6:
                            word = thousands(Number);
                            isDone = true;
                            break;
                        case 7://millions' range   
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            if(Number.Substring(Number.Length - 7, 1) == "1")
                            {
                                place = " Εκατομμύριο ";
                            }
                            else
                            {
                                place = " Εκατομμύρια ";
                            }
                            break;
                        case 10://Billions's range   
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            if (Number.Substring(Number.Length - 10, 1) == "1")
                            {
                                place = " Δισεκατομμύριο ";
                            }
                            else
                            {
                                place = " Δισεκατομμύρια ";
                            }
                            break;
                        case 13://Trillion's range   
                        case 14:
                        case 15:

                            pos = (numDigits % 13) + 1;
                            if (Number.Substring(Number.Length - 13, 1) == "1")
                            {
                                place = " Τρισεκατομμύριο ";
                            }
                            else
                            {
                                place = " Τρισεκατομμύρια ";
                            }
                            break;
                        //add extra case options for anything above Billion...   
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)   
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }


                    }
                    //ignore digit grouping names   
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
                else if (dblAmt==0)
                {
                    return "Μηδέν";
                }
            }
            catch { }
            return word.Trim();
        }

        public static bool CheckNumberFormat(string numb)
        {
            decimal numberChecked;
            bool isNumeric = decimal.TryParse(numb, NumberStyles.Any, _greekCulture, out numberChecked);

            bool hasLessDecimalPlacesThanTwo = CountDecimalPlaces(numberChecked) <= 2;

            return isNumeric && hasLessDecimalPlacesThanTwo;
        }

        public static bool NumbRegexMatch(string numb)
        {
            Regex rx = new Regex(@"^(?:(\-?)\d+|\d+\,\d{0,2}|\d{0,3}(.\d{3})+(\,\d{0,2})?)$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (rx.IsMatch(numb))
            {
                return CheckNumberFormat(numb);
            }
            else
            {
                return false;
            }

          
        }

        public static int CountDecimalPlaces(decimal numb)
        {
            if(numb.ToString().IndexOf(",") != -1)
            {
                string resultstr = numb.ToString().Substring(numb.ToString().IndexOf(",") + 1);
                return resultstr.Length;
            }
            else
            {
                return 0;
            }  
        }
        /// <summary>
        /// Converts to words.
        /// </summary>
        /// <param name="numb">The number that is going to be converted.</param>
        /// <param name="modeSelected">The mode selected.</param>
        /// <returns>An object of the ConvertionResult class</returns>
        public static ConvertionResult ConvertToWords(string numb, string modeSelected = "0")
        {
            int modeSelectedToInt;
            bool success = Int32.TryParse(modeSelected, out modeSelectedToInt);
            if (!success)
            {
                return new ConvertionResult
                {
                    ConvertionComplete = false,
                    Message = "Μη έγκυρη λειτουργία."
                };
            }
            else
            {
                List<int> numberOfModes = Currencies.GetNumberOfModes();
                bool isInList = numberOfModes.IndexOf(modeSelectedToInt) != -1;
                if (!isInList)
                {
                    return new ConvertionResult
                    {
                        ConvertionComplete = false,
                        Message = "Δεν υπάρχει τέτοια λειτουργία."
                    };
                }
            }
            

            if (NumbRegexMatch(numb))
            {
                numb = numb.Replace(@".", string.Empty);
                string minusStr = decimal.Parse(numb, _greekCulture) < 0 ? "Μείον " : string.Empty;
                numb = Math.Abs(decimal.Parse(numb, _greekCulture)).ToString();

                bool numberIsTooBig = double.Parse(numb) > 999999999999999.99;
                if (numberIsTooBig)
                {
                    return new ConvertionResult
                    {
                        ConvertionComplete = false,
                        Message = "Ο αριθμός είναι εκτός ορίων."
                    };
                }

                string val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
                

                try
                {
                    int decimalPlace = numb.IndexOf(",");
                    if (decimalPlace > 0)
                    {
                        wholeNo = numb.Substring(0, decimalPlace);
                        points = numb.Substring(decimalPlace + 1);
                        if (Convert.ToInt32(points) > 0)
                        {
                            andStr = " και ";// just to separate whole numbers from points/cents    
                            pointStr = ConvertDecimals(points);
                        }
                    }
                    var test = new Currencies(minusStr, ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, wholeNo!="1", points!="01");
                    val = test.ReturnFormattedValue(modeSelectedToInt);
                    //val = String.Format("{0}{1}{2}{3}", minusStr, ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr);
                }
                catch { }
                return new ConvertionResult
                {
                    ConvertionComplete = true,
                    Message = RemoveExtraWhiteSpaces(val)
                }; 
            }
            else
            {
                return new ConvertionResult
                {
                    ConvertionComplete = false,
                    Message = "Μη έγκυρος αριθμός."
                };
            }

        }

        private static string RemoveExtraWhiteSpaces(string val)
        {
            return val.Replace(@"  ", " ");
        }

        private static String ConvertDecimals(String number)
        {
            //Add trailing zero, if number has one digit
            number = number.Length == 1 ? number + "0" : number;
            return tens(number);
        }
    }
}
