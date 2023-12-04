using AssessmentProject.Application.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Data;
using AssessmentProject.Data.Domain;

namespace AssessmentProject.Application.Discount
{
    public sealed class AffiliateDiscount : Discount
    {
        private readonly DataContext _context;
        public AffiliateDiscount(DataContext context,string name = "Affiliate discount", string description = "%10 discount for affiliate of the store") : base(context)
        {
            this.Name = name;
            this.Description = description;
            this.IsPercentageBased = true;
            _context = context;
        }

        public override bool ApplyDiscount(InvoiceRepository invoice)
        {
            if (!IsApplicable(invoice))
            {
                return false;
            }

            this.AppliedDiscountValue = (invoice.FinalCost * 10) / 100;
            var affiliateDiscount = new DiscountRepository()
            {
                IsPercentageBased = this.IsPercentageBased,
                AppliedDiscountValue = (invoice.FinalCost * 10) / 100,
                Description = this.Description,
                Name = this.Name,
                Invoice = invoice
            };
            invoice.AppliedDiscounts ??= new List<DiscountRepository>();
            invoice.AppliedDiscounts.Add(affiliateDiscount);
            _context.SaveChanges();

            return true;
        }

        public override bool IsApplicable(InvoiceRepository invoice)
        {
            if (!CheckForStaticRules(invoice) || !this.CheckDiscount(invoice))
            {
                return false;
            }

            return true;
        }

        public override bool CheckDiscount(InvoiceRepository invoice)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == invoice.UserId);
            if (user == null)
            {
                return false;
            }

            if (!user.IsAffiliate)
            {
                return false;
            }

            return true;
        }
    }
}
