using AssessmentProject.Application.Discount.Commands;
using AssessmentProject.Data;
using Microsoft.EntityFrameworkCore;

namespace AssessmentProject.Application.Discount.Handler
{
    public class DeleteDiscountCommandHandler
    {
        private readonly DataContext _context;
        public DeleteDiscountCommandHandler(DataContext context)
        {
            _context = context;
        }

        public BaseResponseModel<DeleteDiscountCommand> Handle(DeleteDiscountCommand command)
        {
            var invoice = _context.Invoices.Include(invoiceRepository => invoiceRepository.AppliedDiscounts).FirstOrDefault(i => i.Id == command.InvoiceId);

            if (invoice == null || invoice.AppliedDiscounts == null)
            {
                return new BaseResponseModel<DeleteDiscountCommand>()
                {
                    Status = false,
                };
            }

            var appliedDiscount = invoice.AppliedDiscounts.FirstOrDefault(d => d.Id == command.DiscountId);
            if (appliedDiscount == null)
            {
                return new BaseResponseModel<DeleteDiscountCommand>()
                {
                    Status = false,
                };
            }

            invoice.FinalCost += appliedDiscount.AppliedDiscountValue;
            invoice.AppliedDiscounts.Remove(appliedDiscount);
            _context.SaveChanges();

            return new BaseResponseModel<DeleteDiscountCommand>() { Status = true, Data = new DeleteDiscountCommand()
            {
                DiscountId = appliedDiscount.Id,
                InvoiceId = invoice.Id
            }};
        }
    }
}
