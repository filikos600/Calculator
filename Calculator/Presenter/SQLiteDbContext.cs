using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Data;
using Calculator.Model;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Presenter
{
    public  class SQLiteDbContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }

        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        public DbSet<CurrencyRateCode> CurrencyRateCodes { get; set; }
        public DbSet<CurrencyRateDate> CurrencyRateDates { get; set; }

        public string DbPath { get; }

        public SQLiteDbContext() {
            var path = AppContext.BaseDirectory;
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "calc.db");

            InitializeDB();
        }

        private void InitializeDB()
        {
            Database.EnsureCreated();

            if (!OperationTypes.Any())
            {
                OperationTypes.AddRange(
                    new OperationType { OperationName = DBOperationTypes.math.ToString() },
                    new OperationType { OperationName = DBOperationTypes.currency.ToString() }
                );
                SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"FileName={DbPath}");
        }
    }
}
