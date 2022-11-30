using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class VwWeightPrice
    {
        public Guid ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }
        public double? ItemWeight { get; set; }
        public Guid? WeightCategoryId { get; set; }
       
        public string WeightCategoryName { get; set; }
        public double? WeightPrice { get; set; }
       
    }
}
