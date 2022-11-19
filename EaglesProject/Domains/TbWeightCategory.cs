using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbWeightCategory
    {
        public Guid WeightCategoryId { get; set; }
        public string WeightCategoryName { get; set; }
        public double? WeightPrice { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CurrentState { get; set; }
        public string Notes { get; set; }
    }
}
