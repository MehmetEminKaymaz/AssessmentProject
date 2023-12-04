using AssessmentProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Data.Domain;

namespace AssessmentProject.Application.Discount
{
    public sealed class BulkPurchaseDiscount : Discount
    {
        private readonly DataContext _context;
        public BulkPurchaseDiscount(DataContext context, string name = "BulkPurchase Discount", string description = "$5 discount for every $100") : base(context)
        {
            _context = context;
            this.Name = name;
            this.Description = description;
        }

        public override bool ApplyDiscount(InvoiceRepository invoice)
        {
            if (!IsApplicable(invoice))
            {
                return false;
            }

            this.AppliedDiscountValue = (invoice.FinalCost / 100) * 5;

            var bulkDiscount = new DiscountRepository()
            {
                IsPercentageBased = this.IsPercentageBased,
                AppliedDiscountValue = (invoice.FinalCost / 100) * 5,
                Description = this.Description,
                Name = this.Name,
                Invoice = invoice
            };
            invoice.AppliedDiscounts ??= new List<DiscountRepository>();
            invoice.AppliedDiscounts.Add(bulkDiscount);
            _context.SaveChanges();

            return true;
        }
        public override bool IsApplicable(InvoiceRepository invoice)
        {
            if (!CheckForStaticRules(invoice) || !CheckDiscount(invoice))
            {
                return false;
            }

            return true;
        }

        public override bool CheckDiscount(InvoiceRepository invoice)
        {
            return true;
        }
    }
}
