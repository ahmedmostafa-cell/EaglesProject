using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbItemCategory
    {
        public Guid ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }
        public double? ItemWeight { get; set; }
        public Guid? WeightCategoryId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CurrentState { get; set; }
        public string Notes { get; set; }
    }
}
