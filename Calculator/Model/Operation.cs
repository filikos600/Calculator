using MathNet.Numerics.RootFinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Data
{
    /// <summary>
    /// Saves operations including: text of operation, it's result, time at wchich it happened and koreign key to operation type
    /// </summary>
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
    }
}
