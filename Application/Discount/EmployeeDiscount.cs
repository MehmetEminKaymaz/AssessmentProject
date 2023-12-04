using AssessmentProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Data.Domain;

namespace AssessmentProject.Application.Discount
{
    public sealed class EmployeeDiscount : Discount
    {
        private readonly DataContext _context;
        public EmployeeDiscount(DataContext context, string name = "Employee Discount", string description = "%30 Discount for employee of the store") : base(context)
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

            this.AppliedDiscountValue = (invoice.FinalCost * 30) / 100;
            var employeeDiscount = new DiscountRepository()
            {
                IsPercentageBased = this.IsPercentageBased,
                AppliedDiscountValue = (invoice.FinalCost * 30) / 100,
                Description = this.Description,
                Name = this.Name,
                Invoice = invoice
            };
            invoice.AppliedDiscounts ??= new List<DiscountRepository>();
            invoice.AppliedDiscounts.Add(employeeDiscount);
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
            var user = _context.Users.FirstOrDefault(u => u.Id == invoice.UserId);
            if (user == null)
            {
                return false;
            }

            if (!user.IsEmployee)
            {
                return false;
            }

            return true;
        }
    }
}
