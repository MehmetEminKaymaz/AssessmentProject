using AssessmentProject.Application.Discount.Commands;
using AssessmentProject.Data;
using Microsoft.EntityFrameworkCore;

namespace AssessmentProject.Application.Discount.Handler
{
    public class CreateDiscountCommandHandler
    {
        private readonly DataContext _context;
        public CreateDiscountCommandHandler(DataContext context)
        {
            _context = context;
        }

        public BaseResponseModel<CreateDiscountCommand> Handle(CreateDiscountCommand command)
        {
            var invoiceWillBeDiscounted = _context.Invoices
                .Include(invoiceRepository => invoiceRepository.AppliedDiscounts).FirstOrDefault(i => i.Id == command.InvoiceId);

            if (invoiceWillBeDiscounted == null)
            {
                return new BaseResponseModel<CreateDiscountCommand>()
                {
                    Status = false,
                };
            }

            var discountResult = false;

            switch (command.DiscountId)
            {
                case (int)DiscountEnum.DiscountType.AffiliateDiscount:
                    var affiliateDiscount = new AffiliateDiscount(_context);
                    discountResult = affiliateDiscount.ApplyDiscount(invoiceWillBeDiscounted);
                    break;
                case (int)DiscountEnum.DiscountType.EmployeeDiscount:
                    var employeeDiscount = new EmployeeDiscount(_context);
                    discountResult = employeeDiscount.ApplyDiscount(invoiceWillBeDiscounted);
                    break;
                case (int)DiscountEnum.DiscountType.BulkPurchaseDiscount:
                    var bulkPurchaseDiscount = new BulkPurchaseDiscount(_context);
                    discountResult = bulkPurchaseDiscount.ApplyDiscount(invoiceWillBeDiscounted);
                    break;
                case (int)DiscountEnum.DiscountType.LongTimeDiscount:
                    var longTimeDiscount = new LongTimeDiscount(_context);
                    discountResult = longTimeDiscount.ApplyDiscount(invoiceWillBeDiscounted);
                    break;
            }
            Guid? appliedDiscount = Guid.Empty;

            if (invoiceWillBeDiscounted is { AppliedDiscounts: not null })
            {
                appliedDiscount = invoiceWillBeDiscounted.AppliedDiscounts.LastOrDefault()?.Id;
            }

            if (!discountResult)
            {
                return new BaseResponseModel<CreateDiscountCommand>()
                {
                    Status = false,
                };
            }

            return new BaseResponseModel<CreateDiscountCommand>()
            {
                Data = new CreateDiscountCommand()
                {
                    InvoiceId = invoiceWillBeDiscounted.Id,
                    DiscountId = command.DiscountId,
                    AppliedDiscountId = appliedDiscount ?? Guid.Empty,
                },
                Status = true,
            };
        }
    }
}
