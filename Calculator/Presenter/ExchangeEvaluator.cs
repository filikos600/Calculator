using Calculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Calculator.Presenter
{
    public class ExchangeEvaluator
    {
        public Dictionary<string,double> rates;
        private DateTime? lastRate;

        private DatabaseManager databaseManager;

        public ExchangeEvaluator()
        {
            rates = new Dictionary<string, double>();
            rates = getExchangeFromXml();

            databaseManager = new DatabaseManager();
        }

        public Dictionary<string, double> getExchangeFromXml()
        {
            Console.WriteLine("started loading");
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("Calculator.Resources.startingExchange.xml");

            var dictRates = new Dictionary<string, double>();

            XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfExchangeRatesTable));
            var result = (ArrayOfExchangeRatesTable)serializer.Deserialize(stream);

            var exchangeRatesTable = result.ExchangeRatesTable;

            DateTime rateTime = exchangeRatesTable.EffectiveDate;
            foreach (var rate in exchangeRatesTable.Rates)
            {
                rates.Add(rate.Code, Decimal.ToDouble(rate.Mid));
            }

            return rates;
        }

        public async Task<List<CurrencyRate>> UpdateExchanges()
        {
            var rates = databaseManager.GetExchange();
            if (rates.Count == 0)
            {
                return await Task.Run(() => UpdateExchangesFromApi());
            }

            var dayToday = DateTime.Today;
            foreach (var rate in rates)
            {
                if (rate.CurrencyRateDate.rateDate != dayToday)
                {
                    return await Task.Run(() => UpdateExchangesFromApi());
                }
            }
            return rates;
        }

        public async Task<List<CurrencyRate>> UpdateExchangesFromApi()
        {
            Dictionary<string, double> ratesDict;
            (ratesDict, lastRate) = await Task.Run(() => NbpAPIabuser.RequestData());
            if (lastRate == null)
            {
                return new List<CurrencyRate>();
            }
            var dateId = databaseManager.AddExchangeRateDate(lastRate.Value);

            return databaseManager.AddExchangeRates(ratesDict, dateId);
        }

        public double Evaluate(double value, CurrencyRate currencyFrom, CurrencyRate currencyTo)
        {
            return currencyFrom.exchangeRate * value / currencyTo.exchangeRate;
        }

        public double Evaluate(string value, string currencyFrom, string currencyTo)
        {
            var val = Convert.ToDouble(value);

            return rates[currencyFrom] * val / rates[currencyTo];
        }

    }
}
