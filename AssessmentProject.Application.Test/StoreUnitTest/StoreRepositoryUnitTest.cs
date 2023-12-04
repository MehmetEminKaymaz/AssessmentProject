using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Data;
using AssessmentProject.Data.Domain;

namespace AssessmentProject.Application.Test.StoreUnitTest
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class StoreRepositoryUnitTest
    {
        DataContext _context;
        StoreRepository _storeRepository;
        CreateStoreCommand _createStoreCommand;

        public StoreRepositoryUnitTest(DataContext context, StoreRepository storeRepository, CreateStoreCommand createStoreCommand)
        {
            _context = context;
            _storeRepository = storeRepository;
            _createStoreCommand = createStoreCommand;
        }

        [Test]
        public void StoreRepository_ShouldBeAddedToDataContext()
        {
            _createStoreCommand.IsGrocery = true;
            _createStoreCommand.Name = "StoreName";

            _storeRepository.Users = new List<UserRepository>();
            _storeRepository.IsGrocery = _createStoreCommand.IsGrocery;
            _storeRepository.Name = _createStoreCommand.Name;

            _context.Stores.Add(_storeRepository);
            _context.SaveChanges();

            var storeId = _storeRepository.Id;

            Assert.That(_createStoreCommand.IsGrocery, Is.EqualTo(_storeRepository.IsGrocery));
            Assert.That(_createStoreCommand.Name, Is.EqualTo(_storeRepository.Name));
            Assert.That(_storeRepository.Id, Is.EqualTo(storeId));
            Assert.Pass("Store Successfully Created With DataContext");
        }
    }
}
