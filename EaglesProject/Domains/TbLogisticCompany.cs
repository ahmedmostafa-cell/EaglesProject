using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbLogisticCompany
    {
        public Guid LogisticCompanyId { get; set; }
        public string LogisticCompanyName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CurrentState { get; set; }
        public string Notes { get; set; }
    }
}
