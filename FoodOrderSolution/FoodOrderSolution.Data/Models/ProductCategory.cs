using FoodOrderSolution.Data.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderSolution.Data.Models
{
    [Table("ProductCategorys")]
    public class ProductCategory : Partialtable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(350)]
        public string Desc { get; set; }
        public int Rank { get; set; }
        public string Avatar { get; set; }

    }
}
