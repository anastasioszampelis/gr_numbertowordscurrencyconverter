using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberToWordsConverterGRLib
{
    public class Currencies
    {
        private string _minusString;

        public string MinusString { get; set; }

        public string WholeNo { get; set; }

        public string PointStr { get; set; }

        public string AndStr { get; set; }

        public bool CurrencyPlural { get; set; }

        public bool FractionalUnitPlural { get; set; }

        public Currencies(string minusString, string wholeNo, string andStr, string pointStr, bool currencyPlural, bool fractionalUnitPlural)
        {
            this.MinusString = minusString;
            this.WholeNo = wholeNo;
            this.AndStr = andStr;
            this.PointStr = pointStr;
            this.CurrencyPlural = currencyPlural;
            this.FractionalUnitPlural = fractionalUnitPlural;
        }

        public string ReturnFormattedValue(int selectedMode)
        {
            var selectedCurrency = this.GetCurrency(selectedMode);
            string currency = this.CurrencyPlural ? selectedCurrency.Children["CurrencyPlural"].ToString() : selectedCurrency.Children["Currency"].ToString();
            string fractionalUnit = this.PointStr != string.Empty ? this.FractionalUnitPlural ? selectedCurrency.Children["FractionalUnitPlural"].ToString() : selectedCurrency.Children["FractionalUnit"].ToString() : string.Empty;

            return String.Format("{0}{1}{2}{3}{4}{5}", this.MinusString, this.WholeNo, currency, this.AndStr, this.PointStr, fractionalUnit);
        }

        private static List<Currency>GetListOfCurrencies()
        {
            var ListCurrencies = new List<Currency>()
                {
                    new Currency
                    {
                        Value = 0,
                        Children = new Dictionary<string, string>()
                        {
                            {"Currency",""},
                            {"CurrencyPlural",""},
                            {"FractionalUnit", ""},
                            {"FractionalUnitPlural", ""},
                        }
                    },
                    new Currency
                    {
                        Value = 1,
                        Children = new Dictionary<string, string>()
                        {
                            {"Currency",""},
                            {"CurrencyPlural",""},
                            {"FractionalUnit", " Λεπτό"},
                            {"FractionalUnitPlural", " Λεπτά"},
                        }
                    },
                    new Currency
                    {
                        Value = 2,
                        Children = new Dictionary<string, string>()
                        {
                            {"Currency"," Ευρώ"},
                            {"CurrencyPlural"," Ευρώ"},
                            {"FractionalUnit", " Λεπτό"},
                            {"FractionalUnitPlural", " Λεπτά"},
                        }
                    },
                    new Currency
                    {
                        Value = 3,
                        Children = new Dictionary<string, string>()
                        {
                            {"Currency"," Δολάριο"},
                            {"CurrencyPlural"," Δολάρια"},
                            {"FractionalUnit", " Λεπτό"},
                            {"FractionalUnitPlural", " Λεπτά"},
                        }
                    },

                };
            return ListCurrencies;

        }

        /// <summary>
        /// Gets the currency (mode) selected by the user.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>An object of the Currency class</returns>
        private Currency GetCurrency(int value)
        {
            var listOfCurrencies = Currencies.GetListOfCurrencies();

            return listOfCurrencies.Where(d => d.Value == value).FirstOrDefault();
        }

        /// <summary>
        /// Gets the number of modes.
        /// </summary>
        /// <returns>An integer</returns>
        public static List<int> GetNumberOfModes()
        {
            List<int> modesList = new List<int>();
            var listOfCurrencies = Currencies.GetListOfCurrencies();
            foreach(Currency curr in listOfCurrencies)
            {
                modesList.Add(curr.Value);
            }
            return modesList;
        }
    }
}
