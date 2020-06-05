using FoodOrderSolution.Data.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderSolution.Data.Models
{
    [Table("MemberLevels")]
    public class MemberLevel : Partialtable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public double Point { get; set; }
        public int Rank { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(550)]
        public string Desc { get; set; }
    }
}
