using Calculator.Data;
using Calculator.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Presenter
{
    public class DatabaseManager
    {
        
        public void AddOperation(string operationText, double result, string operationName)
        {
            using var db = new SQLiteDbContext();

            var operationTypeId = db.OperationTypes.First(t => t.OperationName == operationName).Id;

            db.Operations.Add(new Operation {
                OperationText=operationText,
                Date = DateTime.Now,
                Result = result,
                OperationTypeId = operationTypeId});
            db.SaveChanges();
        }

        public List<Operation> GetOperations()
        {
            using var db = new SQLiteDbContext();
            return db.Operations
                     .OrderByDescending(o => o.Id)
                     .ToList();
        }

        /// <summary>
        /// Adds a new exchange rate date to CurrencyRateDates db and returns the Id of newly created tuple.
        /// If the date already exists returns its Id instead
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public CurrencyRateDate AddExchangeRateDate(DateTime time)
        {
            using var db = new SQLiteDbContext();

            var existingRateDate = db.CurrencyRateDates.FirstOrDefault(t => t.rateDate == time);

            if (existingRateDate != null) {
                return existingRateDate;
            }

            var newRateDate = new CurrencyRateDate { rateDate = time };

            db.CurrencyRateDates.Add(newRateDate);
            db.SaveChanges();
            return newRateDate;
        }

        public CurrencyRateCode AddExchangeRateCode(string code)
        {
            using var db = new SQLiteDbContext();
            var currencyCode = db.CurrencyRateCodes.FirstOrDefault(c => c.rateCode == code);
            if (currencyCode == null)
            {
                currencyCode = new CurrencyRateCode { rateCode = code };
                db.CurrencyRateCodes.Add(currencyCode);
                db.SaveChanges();
            }
            return currencyCode;
        }

        /// <summary>
        /// For each item in dictionary it searches the db for CurrencyRateCode with matching code (if it finds none it creates new one), then searches for exchange rate with todays date (if finds none it adds one). 
        /// If it finds a rate with todays date it gets updates with new rate
        /// Adds a number of currency rates with given dateId to a db and returns them as List. If cares with this date exist, they are updated instead.
        /// </summary>
        /// <param name="rateDict"></param>
        /// <param name="dateId"></param>
        /// <returns></returns>
        public List<CurrencyRate> AddExchangeRates(Dictionary<string,double> rateDict, DateTime date)
        {
            var currencies = new List<CurrencyRate>();
            using var db = new SQLiteDbContext();

            var currencyRateDate = AddExchangeRateDate(date);

            foreach (var rD in rateDict) {
                var code = rD.Key;
                var rate = rD.Value;

                var currencyRateCode = AddExchangeRateCode(code);

                var existingCurrency = db.CurrencyRates.
                    FirstOrDefault(c => c.CurrencyRateDateId == currencyRateDate.Id && currencyRateCode.rateCode == code);

                if (existingCurrency != null) {
                    existingCurrency.exchangeRate = rD.Value;
                    db.CurrencyRates.Update(existingCurrency);
                    db.CurrencyRates.Add(existingCurrency);
                }
                else
                {
                    var newCurrencyRate = new CurrencyRate
                    {
                        CurrencyRateCodeId = currencyRateCode.Id,
                        exchangeRate = rate,
                        CurrencyRateDateId = currencyRateDate.Id
                    };
                    currencies.Add(newCurrencyRate);
                    db.CurrencyRates.Add(newCurrencyRate);
                }
            }
            db.SaveChanges();

            return currencies;
        }

        public List<CurrencyRate> GetExchange()
        {
            using var db = new SQLiteDbContext();

            var latestDate = db.CurrencyRateDates
                .OrderByDescending(d => d.rateDate)
                .FirstOrDefault();

            if (latestDate == null)
                return new List<CurrencyRate>();

            return db.CurrencyRates
                .Include(r => r.CurrencyRateDate) 
                .Include(r => r.CurrencyRateCode)
                .Where(r => r.CurrencyRateDateId == latestDate.Id)
                .ToList();
        }
    }
}
