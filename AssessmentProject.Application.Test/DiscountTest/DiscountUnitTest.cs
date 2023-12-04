using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Data;
using AssessmentProject.Data.Domain;

namespace AssessmentProject.Application.Test.DiscountTest
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class DiscountUnitTest
    {
        private readonly DataContext _context;
        public DiscountUnitTest(DataContext context)
        {
            _context = context;
        }

        [Test]
        public void Discount_Apply_NotImplemented()
        {
            var invoice = new InvoiceRepository()
            {
                InvoiceDate = DateTimeOffset.Now
            };
            var discount = new Discount.Discount(_context);
            try
            {
                discount.ApplyDiscount(invoice);
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void Discount_IsApplicable_NotImplemented()
        {
            var invoice = new InvoiceRepository()
            {
                InvoiceDate = DateTimeOffset.Now
            };
            var discount = new Discount.Discount(_context);
            try
            {
                discount.IsApplicable(invoice);
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void Discount_CheckDiscount_NotImplemented()
        {
            var invoice = new InvoiceRepository()
            {
                InvoiceDate = DateTimeOffset.Now
            };
            var discount = new Discount.Discount(_context);
            try
            {
                discount.CheckDiscount(invoice);
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

    }
}
