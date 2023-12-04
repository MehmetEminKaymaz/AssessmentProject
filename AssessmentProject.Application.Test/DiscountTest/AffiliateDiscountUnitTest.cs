using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.Discount;
using AssessmentProject.Data;
using AssessmentProject.Data.Domain;

namespace AssessmentProject.Application.Test.DiscountTest
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class AffiliateDiscountUnitTest
    {
        private readonly DataContext _context;
        private readonly UserRepository _userRepository;
        private readonly InvoiceRepository _invoiceRepository;
        private readonly StoreRepository _storeRepository;
        public AffiliateDiscountUnitTest(DataContext context, AffiliateDiscount affiliateDiscount, UserRepository userRepository, InvoiceRepository invoiceRepository, StoreRepository storeRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _invoiceRepository = invoiceRepository;
            _storeRepository = storeRepository;
        }

        [Test]
        public void AffiliateDiscount_WithAffiliate_ShouldReturnTrue()
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
                IsAffiliate = true,
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

            var affiliateDiscount = new AffiliateDiscount(_context);
            var isApplicable = affiliateDiscount.IsApplicable(invoice);
            if (!isApplicable)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }

        [Test]
        public void AffiliateDiscount_Apply_ShouldReturnFalse()
        {
            _userRepository.IsEmployee = true;
            _userRepository.IsAffiliate = false;
            _storeRepository.IsGrocery = false;
            _invoiceRepository.FinalCost = 100;
            _invoiceRepository.UserId = _userRepository.Id;
            _context.Stores.Add(_storeRepository);
            _userRepository.Store = _storeRepository;
            _context.Users.Add(_userRepository);
            _context.Invoices.Add(_invoiceRepository);
            _context.SaveChanges();
            var affiliateDiscount = new AffiliateDiscount(_context);
            var isApplicable = affiliateDiscount.IsApplicable(_invoiceRepository);
            if (isApplicable)
            {
                Assert.Fail();
            }

            var applied = affiliateDiscount.ApplyDiscount(_invoiceRepository);
            if (applied)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }

        [Test]
        public void AffiliateDiscount_WithEmploye_ShouldReturnFalse()
        {
            var affiliateDiscount = new AffiliateDiscount(_context);
            _userRepository.IsEmployee = true;
            _userRepository.IsAffiliate = false;
            _invoiceRepository.FinalCost = 100;
            _invoiceRepository.UserId = _userRepository.Id;
            var isApplicable = affiliateDiscount.IsApplicable(_invoiceRepository);
            if (isApplicable)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }
    }
}
