using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Calculator
{
    public  class SQLiteDbContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }

        public string DbPath { get; }

        public SQLiteDbContext() {
            var path = AppContext.BaseDirectory;
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "calc.db");

            InitializeDB();
        }

        private void InitializeDB()
        {
            Database.EnsureCreated();

            if (!OperationTypes.Any())
            {
                OperationTypes.AddRange(
                    new OperationType { OperationName = "math" },
                    new OperationType { OperationName = "currency" }
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
