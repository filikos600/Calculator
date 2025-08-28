using MathNet.Numerics.RootFinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Operation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string OperationText {  get; set; }

        [Required]
        public DateTime Date {  get; set; }

        [Required]
        public double Result { get; set; }


        [Required]
        public int OperationTypeId { get; set; }
        public OperationType OperationType { get; set; }

        //public Operation() { }

        //public Operation(string operation, DateTime date, double result ,int operationType) 
        //{
        //    OperationText = operation;
        //    Date = date;
        //    Result = result;
        //    OperationTypeId = operationType;
        //}
    }
}
