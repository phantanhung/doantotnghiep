﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSolution.Data.Models
{
    [Table("Promotions")]
    public   class Promotion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [MaxLength(6)]
        public string Code { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        public string Avatar { get; set; }
        [MaxLength(350)]
        public string Desc { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Limit { get; set; }
        public int StartAge { get; set; }
        public int EndAge { get; set; }
        /// <summary>
        /// 0 Only For Woman | 1 Only For Men | -1 Is Not limit
        /// </summary>
        public int Gender { get; set; }
        public int MemberLevel { get; set; }
        public double MemberPoint { get; set; }
        /// <summary>
        /// Exp:1|2|3|4  : 1 Is Limited the number of participants | 2 Limited Age | 3 Limited Gender | 4 Limited Member Level | 5 Limited Member Point 
        /// </summary>
        public string Type { get; set; }
        public long Vendor { get; set; }
        public bool Status { get; set; }
    }
}
