

namespace AssessmentProject.Application.Discount.Commands
{
    public class DeleteDiscountCommand
    {
        public Guid InvoiceId { get; set; }
        public Guid DiscountId { get; set;}
    }
}
