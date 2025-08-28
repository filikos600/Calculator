using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
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
    }
}
