using AssessmentProject.Application.Invoice;
using AssessmentProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace AssessmentProject.Application.Discount
{
    public sealed class LongTimeDiscount : Discount
    {
        private readonly DataContext _context;
        public LongTimeDiscount(DataContext context, string name = "LongTime Discount", string description = "%5 discount for over 2 years") : base(context)
        {
            _context = context;
            this.Name = name;
            this.Description = description;
            this.IsPercentageBased = true;
        }

        public override bool ApplyDiscount(InvoiceRepository invoice)
        {
            if (!IsApplicable(invoice))
            {
                return false;
            }

            this.AppliedDiscountValue = (invoice.FinalCost * 5) / 100;
            var longTimeDiscount = new DiscountRepository()
            {
                IsPercentageBased = this.IsPercentageBased,
                AppliedDiscountValue = (invoice.FinalCost * 5) / 100,
                Description = this.Description,
                Name = this.Name,
                Invoice = invoice
            };
            invoice.AppliedDiscounts ??= new List<DiscountRepository>();
            invoice.AppliedDiscounts.Add(longTimeDiscount);
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
            var user = _context.Users.Include(userRepository => userRepository.Invoices).FirstOrDefault(u => u.Id == invoice.UserId);
            if (user == null)
            {
                return false;
            }

            if (user.Invoices != null && user.Invoices.MinBy(i => i.InvoiceDate)!.InvoiceDate > DateTimeOffset.Now.AddYears(-2))
            {
                return false;
            }

            return true;
        }
    }
}
