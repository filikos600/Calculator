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
    public class NbpAPIabuser
    {
        static public async Task<(Dictionary<string, double>,DateTime?)> RequestData()
        {
            var dictRates = new Dictionary<string, double>();

            string apiLink = "https://api.nbp.pl/api/exchangerates/tables/A?format=xml";

            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await Task.Run(()=> client.GetAsync(apiLink));
                response.EnsureSuccessStatusCode();

                using var xmlResponse = await Task.Run(() => response.Content.ReadAsStreamAsync());

                XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfExchangeRatesTable));
                var result = (ArrayOfExchangeRatesTable)serializer.Deserialize(xmlResponse);

                var exchangeRatesTable = result.ExchangeRatesTable;

                List<CurrencyRate> curerncyList = new List<CurrencyRate>();
                dictRates.Add("PLN", 1d);
                foreach (var rate in exchangeRatesTable.Rates)
                {
                    dictRates.Add(rate.Code, Decimal.ToDouble(rate.Mid));
                }

                DateTime rateTime = exchangeRatesTable.EffectiveDate;

                return (dictRates, rateTime);
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error: {ex.Message}");
            }
            return (new Dictionary<string, double>(), null);
        }

    }
}
