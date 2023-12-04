using AssessmentProject.Application.Invoice.Commands;
using AssessmentProject.Data;
using AssessmentProject.Data.Domain;

namespace AssessmentProject.Application.Invoice.Handler
{
    public class CreateInvoiceCommandHandler
    {
        private readonly DataContext _context;
        public CreateInvoiceCommandHandler(DataContext context) => _context = context;

        public BaseResponseModel<CreateInvoiceCommand> Handle(CreateInvoiceCommand command)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == command.UserId);
            if (user == null)
            {
                return new BaseResponseModel<CreateInvoiceCommand>()
                {
                    Status = false
                };
            }

            var createdInvoice = new InvoiceRepository()
            {
                InvoiceDate = DateTimeOffset.Now,
                UserId = user.Id,
                FinalCost = command.FinalCost,
                Cost = command.Cost,
                AppliedDiscounts = new List<DiscountRepository>()
            };

            _context.Invoices.Add(createdInvoice);
            _context.SaveChanges();

            return new BaseResponseModel<CreateInvoiceCommand>
            {
                Data = new CreateInvoiceCommand()
                {
                    Id = createdInvoice.Id,
                    InvoiceDate = createdInvoice.InvoiceDate,
                    UserId = createdInvoice.UserId,
                    FinalCost = createdInvoice.FinalCost,
                    Cost = createdInvoice.Cost,
                },
                Status = true
            };
        }
    }
}
