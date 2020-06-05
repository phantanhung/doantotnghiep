using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderSolution.Data.Models
{
    [Table("Contracts")]
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Code { get; set; }
        public string FileScan { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }

    }
}
