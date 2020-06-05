using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSolution.Data.Models
{
    [Table("HistoryVouchers")]
    public class HistoryVoucher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public   string Voucher { get; set; }
        public int Member { get; set; }
        public long Product { get; set; }
        public string Bill { get; set; }
        public DateTime Date { get; set; }
        public double AmountReduced { get; set; }
    }
}
