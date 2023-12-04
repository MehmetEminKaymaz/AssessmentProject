using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Data;
using AssessmentProject.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace AssessmentProject.Application.Discount
{
    public class Discount : IDiscount
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsPercentageBased { get; set; } = false;
        public decimal AppliedDiscountValue { get; set; } = 0m;
        public string? Description { get; set; }

        private readonly DataContext _context;
        public Discount(DataContext context)
        {
            _context = context;
        }

        public virtual bool ApplyDiscount(InvoiceRepository invoice)
        {
            throw new NotImplementedException();
        }

        public virtual bool CheckDiscount(InvoiceRepository invoice)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsApplicable(InvoiceRepository invoice)
        {
            throw new NotImplementedException();
        }

        public bool CheckForStaticRules(InvoiceRepository invoice)
        {
            var user = _context.Users.Include(userRepository => userRepository.Store).FirstOrDefault(u => u.Id == invoice.UserId);
            if (user == null)
            {
                return false;
            }

            if (this.IsPercentageBased && user.Store.IsGrocery)
            {
                return false;
            }

            if (invoice.AppliedDiscounts != null && this.IsPercentageBased && invoice.AppliedDiscounts.Any(d => d.IsPercentageBased))
            {
                return false;
            }

            return true;
        }
    }
}
