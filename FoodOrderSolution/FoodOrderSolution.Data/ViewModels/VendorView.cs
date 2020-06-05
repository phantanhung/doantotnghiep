using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSolution.Data.ViewModels
{
   public class VendorView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string TaxCode { get; set; }
        public string Desc { get; set; }
        public string ContractCode { get; set; }
        public int Level { get; set; }
        public string Account { get; set; }
        public int Status { get; set; }
    }
}
