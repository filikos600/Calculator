using Calculator.Data;
using Calculator.Model;
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
        public  DateTime lastRate;

        private readonly DatabaseManager databaseManager;

        public ExchangeEvaluator(DatabaseManager databaseManager)
        {
            rates = new Dictionary<string, double>();
            getExchangeFromXml();

            this.databaseManager = databaseManager;
        }

        public void getExchangeFromXml()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("Calculator.Resources.startingExchange.xml");

            var dictRates = new Dictionary<string, double>();

            XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfExchangeRatesTable));
            var result = (ArrayOfExchangeRatesTable)serializer.Deserialize(stream);

            var exchangeRatesTable = result.ExchangeRatesTable;

            lastRate = exchangeRatesTable.EffectiveDate;

            DateTime rateTime = exchangeRatesTable.EffectiveDate;

            rates.Add("PLN", 1d);
            foreach (var rate in exchangeRatesTable.Rates)
            {
                rates.Add(rate.Code, Decimal.ToDouble(rate.Mid));
            }

            return;
        }

        public async Task<List<CurrencyRate>> GetUpdatesFromDB()
        {
            return await Task.Run(() => databaseManager.GetExchange());
        }

        public async Task<List<CurrencyRate>> GetUpdatedExchanges()
        {
            var rates = await Task.Run(() => databaseManager.GetExchange());
            if (rates.Count == 0)
            {
                await Task.Run(() => UpdateExchangesFromApi());
                return await Task.Run(() => databaseManager.GetExchange());
            }
            else
            {
                var dayToday = DateTime.Today;
                foreach (var rate in rates)
                {
                    if (rate.CurrencyRateDate.rateDate != dayToday)
                    {
                        await Task.Run(() => UpdateExchangesFromApi());
                        return await Task.Run(() => databaseManager.GetExchange());
                    }
                }
            }
            return rates;
        }

        public async Task UpdateExchangesFromApi()
        {
            Dictionary<string, double> ratesDict;
            (ratesDict, lastRate) = await Task.Run(() => NbpAPIabuser.RequestData());
            await Task.Run(() => databaseManager.AddExchangeRates(ratesDict, lastRate));
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


        public async Task SaveExchangeToDb(string value, string currencyFrom, string currencyTo, string result)
        {
            var operationText = $"{value} {currencyFrom} => {currencyTo}";
            await Task.Run(() => (databaseManager.AddOperation(operationText, Convert.ToDouble(result), DBOperationTypes.currency.ToString())));
        }
    }
}
