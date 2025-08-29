using Calculator.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Calculator.Presenter
{
    /// <summary>
    /// Method that correspond for sending and processign API calls
    /// </summary>
    public static class NbpApiRequester
    {
        /// <summary>
        /// It sends an api request at nbp.pl to recieve table A with exchange rates. Then deserialize recieved XML into a dictionary where currency code is a key and exhcnage rate a value. It also reads date of the exchange.
        /// </summary>
        /// <returns>A task contains the touple of: Dictionary where currency code is a key and exhcnage rate a value; time of the exchange</returns>
        static public async Task<(Dictionary<string, double>,DateTime)> RequestData()
        {
            var dictRates = new Dictionary<string, double>();

            string apiLink = "https://api.nbp.pl/api/exchangerates/tables/A?format=xml";

            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await Task.Run(()=> client.GetAsync(apiLink));
            response.EnsureSuccessStatusCode();

            using var xmlResponse = await Task.Run(() => response.Content.ReadAsStreamAsync());

            XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfExchangeRatesTable));
            var result = (ArrayOfExchangeRatesTable)serializer.Deserialize(xmlResponse);

            var exchangeRatesTable = result.ExchangeRatesTable;

            dictRates.Add("PLN", 1d);
            foreach (var rate in exchangeRatesTable.Rates)
            {
                dictRates.Add(rate.Code, Decimal.ToDouble(rate.Mid));
            }

            DateTime rateTime = exchangeRatesTable.EffectiveDate;

            return (dictRates, rateTime);
        }

    }
}
