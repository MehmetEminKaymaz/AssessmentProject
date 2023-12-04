using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Data.Domain;

namespace AssessmentProject.Application.Discount
{
    public interface IDiscount
    {
        bool ApplyDiscount(InvoiceRepository invoice);
        bool CheckDiscount(InvoiceRepository invoice);
        bool IsApplicable(InvoiceRepository invoice);

    }
}
