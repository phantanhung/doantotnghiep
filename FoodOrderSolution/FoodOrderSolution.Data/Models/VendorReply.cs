using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSolution.Data.Models
{
    [Table("VendorReplys")]
   public class VendorReply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public long Feedback { get; set; }
        public string Comment { get; set; }

    }
}
