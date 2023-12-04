using AssessmentProject.Application.Discount;
using AssessmentProject.Data.Domain;
using AssessmentProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.Application.Test.DiscountTest
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class EmployeeDiscountUnitTest
    {
        private readonly DataContext _context;
        private readonly UserRepository _userRepository;
        private readonly InvoiceRepository _invoiceRepository;
        private readonly StoreRepository _storeRepository;
        public EmployeeDiscountUnitTest(DataContext context, UserRepository userRepository, InvoiceRepository invoiceRepository, StoreRepository storeRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _invoiceRepository = invoiceRepository;
            _storeRepository = storeRepository;
        }

        [Test]
        public void EmployeeDiscount_WithEmployee_ShouldReturnTrue()
        {
            var store = new StoreRepository()
            {
                Id = Guid.NewGuid(),
                Name = "ShopTest",
                IsGrocery = false,
                Users = new List<UserRepository>()
            };

            var user = new UserRepository()
            {
                Id = Guid.NewGuid(),
                IsAffiliate = false,
                IsEmployee = true,
                Store = store,
                Invoices = new List<InvoiceRepository>()
            };

            store.Users.Add(user);

            var invoice = new InvoiceRepository()
            {
                Id = Guid.NewGuid(),
                FinalCost = 200,
                Cost = 200,
                UserId = user.Id,
                InvoiceDate = DateTimeOffset.Now
            };
            _context.Stores.Add(store);
            _context.Users.Add(user);
            _context.Invoices.Add(invoice);
            user.Invoices?.Add(invoice);
            _context.SaveChanges();

            var employeeDiscount = new EmployeeDiscount(_context);
            var isApplicable = employeeDiscount.IsApplicable(invoice);
            if (!isApplicable)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }

        [Test]
        public void EmployeeDiscount_WithoutEmployee_ShouldReturnFalse()
        {
            var store = new StoreRepository()
            {
                Id = Guid.NewGuid(),
                Name = "ShopTest",
                IsGrocery = false,
                Users = new List<UserRepository>()
            };

            var user = new UserRepository()
            {
                Id = Guid.NewGuid(),
                IsAffiliate = false,
                IsEmployee = false,
                Store = store,
                Invoices = new List<InvoiceRepository>()
            };

            store.Users.Add(user);

            var invoice = new InvoiceRepository()
            {
                Id = Guid.NewGuid(),
                FinalCost = 200,
                Cost = 200,
                UserId = user.Id,
                InvoiceDate = DateTimeOffset.Now
            };
            _context.Stores.Add(store);
            _context.Users.Add(user);
            _context.Invoices.Add(invoice);
            user.Invoices?.Add(invoice);
            _context.SaveChanges();

            var employeeDiscount = new EmployeeDiscount(_context);
            var isApplicable = employeeDiscount.IsApplicable(invoice);
            if (isApplicable)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }
    }
}
