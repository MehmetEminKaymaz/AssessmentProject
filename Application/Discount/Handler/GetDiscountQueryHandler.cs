using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.Discount.Queries;
using AssessmentProject.Data;

namespace AssessmentProject.Application.Discount.Handler
{
    public class GetDiscountQueryHandler
    {
        private readonly DataContext _context;
        
        public GetDiscountQueryHandler(DataContext context)
        {
            _context = context;
        }

        public BaseResponseModel<GetDiscountQuery> Handle(GetDiscountQuery query)
        {
            var invoiceWillBeDiscounted = _context.Invoices.FirstOrDefault(i => i.Id == query.InvoiceId);
            if (invoiceWillBeDiscounted == null)
            {
                return new BaseResponseModel<GetDiscountQuery>()
                {
                    Status = false,
                };
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == invoiceWillBeDiscounted.UserId);
            if (user == null)
            {
                return new BaseResponseModel<GetDiscountQuery>()
                {
                    Status = false,
                };
            }

            var affiliateDiscount = new AffiliateDiscount(_context);
            var employeeDiscount = new EmployeeDiscount(_context);
            var longTimeDiscount = new LongTimeDiscount(_context);
            var bulkDiscount = new BulkPurchaseDiscount(_context);

            var availableDiscountList = new List<int>();
            if (affiliateDiscount.IsApplicable(invoiceWillBeDiscounted))
            {
                availableDiscountList.Add((int)DiscountEnum.DiscountType.AffiliateDiscount);
            }

            if (employeeDiscount.IsApplicable(invoiceWillBeDiscounted))
            {
                availableDiscountList.Add((int)DiscountEnum.DiscountType.EmployeeDiscount);
            }

            if (longTimeDiscount.IsApplicable(invoiceWillBeDiscounted))
            {
                availableDiscountList.Add((int)DiscountEnum.DiscountType.LongTimeDiscount);
            }

            if (bulkDiscount.IsApplicable(invoiceWillBeDiscounted))
            {
                availableDiscountList.Add((int)DiscountEnum.DiscountType.BulkPurchaseDiscount);
            }

            query.AvailableDiscountIds = availableDiscountList.ToArray();
            


            return new BaseResponseModel<GetDiscountQuery>()
            {
                Status = true,
                Data = query
            };
        }
    }
}
