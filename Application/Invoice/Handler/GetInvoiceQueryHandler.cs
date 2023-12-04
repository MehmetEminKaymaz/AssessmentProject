using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.Invoice.Commands;
using AssessmentProject.Application.Invoice.Queries;
using AssessmentProject.Data;

namespace AssessmentProject.Application.Invoice.Handler
{
    public class GetInvoiceQueryHandler
    {
        private readonly DataContext _context;
        public GetInvoiceQueryHandler(DataContext context)
        {
            _context = context;
        }

        public BaseResponseModel<CreateInvoiceCommand> Handle(GetInvoice query)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.Id == query.InvoiceId);
            if (invoice == null)
            {
                return new BaseResponseModel<CreateInvoiceCommand>()
                {
                    Status = false,
                };
            }

            return new BaseResponseModel<CreateInvoiceCommand>()
            {
                Status = true,
                Data = new CreateInvoiceCommand()
                {
                    InvoiceDate = invoice.InvoiceDate,
                    Cost = invoice.Cost,
                    FinalCost = invoice.FinalCost,
                    Id = invoice.Id,
                    UserId = invoice.UserId
                }
            };
        }
    }
}
