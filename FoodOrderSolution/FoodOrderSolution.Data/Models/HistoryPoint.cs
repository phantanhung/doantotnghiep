using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSolution.Data.Models
{
    [Table("HistoryPoints")]
    public class HistoryPoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Member { get; set; }
        public double Point { get; set; }
        [MaxLength(850)]
        public string Desc { get; set; }
        public DateTime Date { get; set; }
    }
}
