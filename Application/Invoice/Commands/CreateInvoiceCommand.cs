using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.Application.Invoice.Commands
{
    public class CreateInvoiceCommand
    {
        public Guid Id { get; set; }
        public decimal Cost { get; set; }
        public decimal FinalCost { get; set; }
        public required DateTimeOffset InvoiceDate { get; set; }
        public Guid UserId { get; set; }
    }
}
