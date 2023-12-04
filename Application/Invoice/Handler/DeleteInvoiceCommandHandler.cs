using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.Invoice.Commands;
using AssessmentProject.Data;

namespace AssessmentProject.Application.Invoice.Handler
{
    public class DeleteInvoiceCommandHandler
    {
        private readonly DataContext _context;
        public DeleteInvoiceCommandHandler(DataContext context)
        {
            _context = context;
        }

        public BaseResponseModel<DeleteInvoiceCommand> Handle(DeleteInvoiceCommand command)
        {
            var invoiceWillBeDelete = _context.Invoices.FirstOrDefault(i => i.Id == command.InvoiceId);
            if (invoiceWillBeDelete == null)
            {
                return new BaseResponseModel<DeleteInvoiceCommand>
                {
                    Status = false,
                    Data = command,
                };
            }
            _context.Remove(invoiceWillBeDelete);
            _context.SaveChanges();
            _context.Dispose();

            return new BaseResponseModel<DeleteInvoiceCommand>
            {
                Status = true,
                Data = command
            };
        }

    }
}
