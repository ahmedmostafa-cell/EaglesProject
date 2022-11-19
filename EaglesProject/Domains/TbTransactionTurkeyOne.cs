using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbTransactionTurkeyOne
    {
        public Guid TransactionTurkeyOneId { get; set; }
        public Guid? CustomerId { get; set; }
        public string ItemImagePath { get; set; }
        public double? BasicCostLira { get; set; }
        public double? BasicCostEgp { get; set; }
        public Guid? ItemCategoryId { get; set; }
        public Guid? WeightCategoryId { get; set; }
        public double? ItemWeight { get; set; }
        public double? WeightPrice { get; set; }
        public int? PieceCost { get; set; }
        public int? MarginPercent { get; set; }
        public double? MarginValue { get; set; }
        public double? SalesPrice { get; set; }
        public string Size { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CurrentState { get; set; }
        public string Notes { get; set; }
        public int? DepositValue { get; set; }
    }
}
