using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.Invoice.Commands;
using AssessmentProject.Data;
using AssessmentProject.Data.Domain;

namespace AssessmentProject.Application.Invoice.Handler
{
    public class UpdateInvoiceCommandHandler
    {
        private readonly DataContext _context;
        public UpdateInvoiceCommandHandler(DataContext context)
        {
            _context = context;
        }
        public BaseResponseModel<UpdateInvoiceCommand> Handle(UpdateInvoiceCommand command)
        {
            var invoiceWillBeUpdate = _context.Invoices.FirstOrDefault(i => i.Id == command.InvoiceId);
            if (invoiceWillBeUpdate == null)
            {
                return new BaseResponseModel<UpdateInvoiceCommand>
                {
                    Status = false,
                };
            }

            invoiceWillBeUpdate.FinalCost = command.FinalCost;
            invoiceWillBeUpdate.Cost = command.Cost;
            invoiceWillBeUpdate.InvoiceDate = command.InvoiceDate;
            _context.SaveChanges();
            _context.Dispose();

            return new BaseResponseModel<UpdateInvoiceCommand>
            {
                Status = true,
                Data = command,
            };
        }
    }
}
