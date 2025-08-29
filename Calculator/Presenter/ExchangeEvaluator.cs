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
    /// <summary>
    /// Interface used for test mocking - for more info check <see cref="ExchangeEvaluator"/.
    /// </summary>
    public interface IExchangeEvaluator
    {
        DateTime GetLastRateDate();
        Dictionary<string, double> GetRates();
        Task<List<CurrencyRate>> GetUpdatesFromDB();
        Task<List<CurrencyRate>> GetUpdatedExchangesFromDbOrApi();
        Task UpdateExchangesFromApi();

        double Evaluate(string value, string currencyFrom, string currencyTo);

        double GetRate(string firstCurrency, string secondCurrency);

        Task SaveExchangeToDb(string value, string currencyFrom, string currencyTo, string result);
    }

    /// <summary>
    /// Class reponsible for keeping the rates in emmory, updating then when needed or asked. It also calculate between given currencies.
    /// </summary>
    public class ExchangeEvaluator : IExchangeEvaluator
    {
        private Dictionary<string,double> rates;
        private  DateTime lastRate;

        private readonly IDatabaseManager databaseManager;

        public ExchangeEvaluator(IDatabaseManager databaseManager)
        {
            rates = new Dictionary<string, double>();
            getExchangeFromXml();

            this.databaseManager = databaseManager;
        }

        /// <summary>
        /// Returns the day of the most recent rate update.
        /// </summary>
        /// <returns>Day of the most recent rate update</returns>
        public DateTime GetLastRateDate()
        {
            return lastRate;
        }

        /// <summary>
        /// Returns the currenct exchange rates as a dictionary.
        /// </summary>
        /// <returns>Dictionary where currency code is a key and exhcnage rate a value.</returns>
        public Dictionary<string, double> GetRates()
        {
            return rates;
        }

        /// <summary>
        /// Get's called just after creating object of this class. It populates the data using given .XML file.
        /// </summary>
        private void getExchangeFromXml()
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
        }

        /// <summary>
        /// Asks the db for updated exchange rate and then returns them .
        /// </summary>
        /// <returns>A task contains the list of <see cref="CurrencyRateDate"/.</returns>
        public async Task<List<CurrencyRate>> GetUpdatesFromDB()
        {
            return await Task.Run(() => databaseManager.GetExchange());
        }

        /// <summary>
        /// Asks the db for updated exchange rate. If doesn't recieve them asks API instead. If recived proper rates from either - it returns them.
        /// </summary>
        /// <returns>A task contains the <see cref="CurrencyRateDate"/.</returns>
        public async Task<List<CurrencyRate>> GetUpdatedExchangesFromDbOrApi()
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

        /// <summary>
        /// Calls API to recieve updated exchange rates
        /// </summary>
        /// <returns>No object or value is returned by this method when it completes.</returns>
        public async Task UpdateExchangesFromApi()
        {
            Dictionary<string, double> ratesDict;
            (ratesDict, lastRate) = await Task.Run(() => NbpApiRequester.RequestData());
            await Task.Run(() => databaseManager.AddExchangeRates(ratesDict, lastRate));
        }

        /// <summary>
        /// IT evaluate value based on given currencies and first currency's value.
        /// </summary>
        /// <param name="value">First currency's value.</param>
        /// <param name="currencyFrom">First currency's code.</param>
        /// <param name="currencyTo">Target currency's code.</param>
        /// <returns>Calculated value in target currency.</returns>
        public double Evaluate(string value, string currencyFrom, string currencyTo)
        {
            var val = Convert.ToDouble(value);

            return rates[currencyFrom] * val / rates[currencyTo];
        }

        /// <summary>
        /// Gives the exchange rate between two currencies.
        /// </summary>
        /// <param name="firstCurrency">First currency's code.</param>
        /// <param name="secondCurrency">Second currency's code.</param>
        /// <returns>Calcualted exchange rate</returns>
        public double GetRate(string firstCurrency, string secondCurrency)
        {
            return rates[firstCurrency]/rates[secondCurrency];
        }

        /// <summary>
        /// It calles the database manager to save given exchange to data base.
        /// </summary>
        /// <param name="value">First currency's value.</param>
        /// <param name="currencyFrom">First currency's code.</param>
        /// <param name="currencyTo">Second currency's code.</param>
        /// <param name="result">Second currency's value.</param>
        /// <returns>No object or value is returned by this method when it completes.</returns>
        public async Task SaveExchangeToDb(string value, string currencyFrom, string currencyTo, string result)
        {
            var operationText = $"{value} {currencyFrom} => {currencyTo}";
            await Task.Run(() => (databaseManager.AddOperation(operationText, Convert.ToDouble(result), DBOperationTypes.currency.ToString())));
        }
    }
}
