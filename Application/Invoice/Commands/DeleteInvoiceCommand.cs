using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.Application.Invoice.Commands
{
    public class DeleteInvoiceCommand
    {
        public Guid InvoiceId { get; set; }
    }
}
