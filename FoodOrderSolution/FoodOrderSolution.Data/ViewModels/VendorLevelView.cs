using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSolution.Data.ViewModels
{
   public class VendorLevelView
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập dữ liệu này")]
        public int Level { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu này")]
        public int PostLimit { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu này")]
        public double Percentage { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu này")]
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
