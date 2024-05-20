using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberNet.DTO
{
    internal class FoodDTO
    {
        public string food_name { get; set; }
        public int food_price { get; set; }  
        public DateTime food_date { get; set; }
        public string food_status { get; set; }
    }
}
