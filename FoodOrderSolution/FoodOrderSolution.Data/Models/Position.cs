using FoodOrderSolution.Data.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderSolution.Data.Models
{
    [Table("Positions")]
   public class Position : Partialtable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(550)]
        public string Desc { get; set; }
    }
}
