

namespace AssessmentProject.Application.Discount.Commands
{
    public class CreateDiscountCommand
    {
        public int DiscountId { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid AppliedDiscountId { get; set; }
    }
}
