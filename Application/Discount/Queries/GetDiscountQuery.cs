using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.Application.Discount.Queries
{
    public class GetDiscountQuery
    {
        public Guid InvoiceId { get; set; }
        public int[] AvailableDiscountIds { get; set; }
    }
}
