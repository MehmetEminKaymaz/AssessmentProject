using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Application.Store.Handler;
using AssessmentProject.Application.Store.Queries;

namespace AssessmentProject.Application.Test.StoreUnitTest
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class GetStoreQueryHandlerUnitTest
    {
        private readonly CreateStoreCommand _createStoreCommand;
        private readonly CreateStoreCommandHandler _createStoreCommandHandler;
        private readonly GetStoreQueryHandler _getStoreQueryHandler;
        private readonly GetStoreQuery _getStoreQuery;
        public GetStoreQueryHandlerUnitTest(CreateStoreCommand createStoreCommand, CreateStoreCommandHandler createStoreCommandHandler, GetStoreQueryHandler getStoreQueryHandler, GetStoreQuery getStoreQuery)
        {
            _createStoreCommand = createStoreCommand;
            _createStoreCommandHandler = createStoreCommandHandler;
            _getStoreQueryHandler = getStoreQueryHandler;
            _getStoreQuery = getStoreQuery;
        }

        [Test]
        public void GetStoreQueryHandler_Handle_ShouldReturnFilledBaseResponseModel()
        {
            _createStoreCommand.IsGrocery = false;
            _createStoreCommand.Name = "ShopTest";
            var createdStore = _createStoreCommandHandler.Handle(_createStoreCommand);
            if (createdStore.Data != null)
                _getStoreQuery.StoreId = createdStore.Data.StoreId;
            var getStoreQueryResponse = _getStoreQueryHandler.Handle(_getStoreQuery);
            Assert.Multiple(() =>
            {
                Assert.That(getStoreQueryResponse.GetType(), Is.EqualTo(new BaseResponseModel<CreateStoreCommand>().GetType()));
                Assert.That(getStoreQueryResponse.Data?.IsGrocery, Is.EqualTo(_createStoreCommand.IsGrocery));
                Assert.That(getStoreQueryResponse.Data?.Name, Is.EqualTo(_createStoreCommand.Name));
                Assert.That(getStoreQueryResponse.Data?.StoreId, Is.EqualTo(_createStoreCommand.StoreId));
            });
            Assert.Pass();
        }

        [Test]
        public void GetStoreQueryHandler_Handle_ShouldReturnFalse()
        {

            _getStoreQuery.StoreId = Guid.NewGuid();
            var getStoreQueryResponse = _getStoreQueryHandler.Handle(_getStoreQuery);
            Assert.Multiple(() =>
            {
                Assert.That(getStoreQueryResponse.GetType(), Is.EqualTo(new BaseResponseModel<CreateStoreCommand>().GetType()));
                Assert.That(getStoreQueryResponse.Status, Is.EqualTo(false));
            });
            Assert.Pass();
        }
    }
}
