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
        private readonly SQLiteDbContext db;
        
        public DatabaseManager(SQLiteDbContext context) {
            db = context;
        }

        public async Task AddOperation(string operationText, double result, string operationName)
        {
            var operationType = await db.OperationTypes.FirstAsync(t => t.OperationName == operationName);

            db.Operations.Add(new Operation {
                OperationText=operationText,
                Date = DateTime.Now,
                Result = result,
                OperationTypeId = operationType.Id});
            db.SaveChanges();
        }

        public async Task<List<Operation>> GetOperations()
        {
            return await db.Operations
                     .OrderByDescending(o => o.Id)
                     .ToListAsync();
        }

        /// <summary>
        /// Adds a new exchange rate date to CurrencyRateDates db and returns the Id of newly created tuple.
        /// If the date already exists returns its Id instead
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public async Task<CurrencyRateDate> AddExchangeRateDate(DateTime time)
        {

            var existingRateDate = await db.CurrencyRateDates.FirstOrDefaultAsync(t => t.rateDate == time);

            if (existingRateDate != null) {
                return existingRateDate;
            }

            var newRateDate = new CurrencyRateDate { rateDate = time };

            db.CurrencyRateDates.Add(newRateDate);
            db.SaveChanges();
            return newRateDate;
        }

        public async Task<CurrencyRateCode> AddExchangeRateCode(string code)
        {
            var currencyCode = await db.CurrencyRateCodes.FirstOrDefaultAsync(c => c.rateCode == code);
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
        public async Task<List<CurrencyRate>> AddExchangeRates(Dictionary<string,double> rateDict, DateTime date)
        {
            var currencies = new List<CurrencyRate>();

            var currencyRateDate = await Task.Run(() => AddExchangeRateDate(date));

            foreach (var rD in rateDict) {
                var code = rD.Key;
                var rate = rD.Value;

                var currencyRateCode = await Task.Run(() => AddExchangeRateCode(code));

                var existingCurrency = await db.CurrencyRates.
                    FirstOrDefaultAsync(c => c.CurrencyRateDateId == currencyRateDate.Id && currencyRateCode.rateCode == code);

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

        public async Task<List<CurrencyRate>> GetExchange()
        {
            var latestDate = await db.CurrencyRateDates
                .OrderByDescending(d => d.rateDate)
                .FirstOrDefaultAsync();

            if (latestDate == null)
                return new List<CurrencyRate>();

            return await db.CurrencyRates
                .Include(r => r.CurrencyRateDate) 
                .Include(r => r.CurrencyRateCode)
                .Where(r => r.CurrencyRateDateId == latestDate.Id)
                .ToListAsync();
        }

        public async Task<(string, DateTime)> GetBestRateFromPeriod(string currencyFrom, string currencyTo, DateTime startPeriod, DateTime endPeriod)
        {
            var currencyCodeFrom = await db.CurrencyRateCodes.FirstOrDefaultAsync(c => c.rateCode == currencyFrom);
            var currencyCodeTo = await db.CurrencyRateCodes.FirstOrDefaultAsync(c => c.rateCode == currencyTo);

            var allRates = await db.CurrencyRates
                .Include(r => r.CurrencyRateDate)
                .Include(r => r.CurrencyRateCode)
                .Where(r => r.CurrencyRateDate.rateDate.Date >= startPeriod.Date && r.CurrencyRateDate.rateDate.Date <= endPeriod.Date)
                .ToListAsync();

            var bestResult = allRates
                .GroupBy(r => r.CurrencyRateDate.rateDate)
                .Select(g =>
                {
                    var fromRate = g.FirstOrDefault(r => r.CurrencyRateCode.rateCode == currencyFrom);
                    var toRate = g.FirstOrDefault(r => r.CurrencyRateCode.rateCode == currencyTo);
                    string rate = (fromRate.exchangeRate / toRate.exchangeRate).ToString("F2");
                    return (rate , g.Key);
                })
                .Where(x => x.Item1 != "")
                .OrderByDescending(x => x.Item1)
                .FirstOrDefault();

            if (bestResult.Item1 != "")
                return bestResult;
            else
                return ("", DateTime.MinValue);

        }
    }
}
