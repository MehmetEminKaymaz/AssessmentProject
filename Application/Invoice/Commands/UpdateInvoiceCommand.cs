using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.Application.Invoice.Commands
{
    public class UpdateInvoiceCommand
    {
        public Guid InvoiceId { get; set; }
        public decimal Cost { get; set; }
        public decimal FinalCost { get; set; }
        public required DateTimeOffset InvoiceDate { get; set; }
    }
}
