using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderSolution.Data.Models
{
    [Table("VendorLevels")]
   public class VendorLevel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Level { get; set; }
        public int PostLimit { get; set; }
        public double Percentage { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
