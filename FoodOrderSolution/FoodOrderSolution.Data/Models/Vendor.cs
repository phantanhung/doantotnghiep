using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderSolution.Data.Models
{
    [Table("Vendors")]
    public class Vendor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(350)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(150)]
        public string Mail { get; set; }
        [MaxLength(50)]
        public string TaxCode { get; set; }
        [MaxLength(850)]
        public string Desc { get; set; }
        [MaxLength(350)]
        public string ContractCode { get; set; }
        public int Status { get; set; }
        public int Level { get; set; }
        [MaxLength(50)]
        public string Account { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
