using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Application.Store.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.Application.Test.StoreUnitTest
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class UpdateStoreCommandHandlerUnitTest
    {
        private readonly CreateStoreCommandHandler _createStoreCommandHandler;
        private readonly CreateStoreCommand _createStoreCommand;
        private readonly UpdateStoreCommandHandler _updateStoreCommandHandler;
        private readonly UpdateStoreCommand _updateStoreCommand;
        public UpdateStoreCommandHandlerUnitTest(CreateStoreCommandHandler createStoreCommandHandler, CreateStoreCommand createStoreCommand, UpdateStoreCommandHandler updateStoreCommandHandler, UpdateStoreCommand updateStoreCommand)
        {
            _createStoreCommandHandler = createStoreCommandHandler;
            _createStoreCommand = createStoreCommand;
            _updateStoreCommandHandler = updateStoreCommandHandler;
            _updateStoreCommand = updateStoreCommand;
        }

        [Test]
        public void UpdateStoreCommandHandler_Handle_ShouldReturnFilledBaseResponseModel()
        {
            _createStoreCommand.Name = "ShopTest";
            _createStoreCommand.IsGrocery = true;


            var createStoreCommand = _createStoreCommandHandler.Handle(_createStoreCommand).Data;
            if (createStoreCommand != null)
                _updateStoreCommand.StoreId = createStoreCommand.StoreId;
            _updateStoreCommand.IsGrocery = false;
            _updateStoreCommand.Name = "ShopTest2";

            var updatedStoreResponse = _updateStoreCommandHandler.Handle(_updateStoreCommand);
            Assert.Multiple(() =>
            {
                Assert.That(updatedStoreResponse.Status, Is.EqualTo(true));
                Assert.That(new BaseResponseModel<UpdateStoreCommand>().GetType(), Is.EqualTo(updatedStoreResponse.GetType()));
            });
            Assert.Pass();
        }

        [Test]
        public void UpdateStoreCommandHandler_Handle_ShouldReturnFalse()
        {
            _updateStoreCommand.StoreId = Guid.NewGuid();
            _updateStoreCommand.IsGrocery = false;
            _updateStoreCommand.Name = "ShopTest2";

            var updatedStoreResponse = _updateStoreCommandHandler.Handle(_updateStoreCommand);
            Assert.Multiple(() =>
            {
                Assert.That(updatedStoreResponse.Status, Is.EqualTo(false));
                Assert.That(new BaseResponseModel<UpdateStoreCommand>().GetType(), Is.EqualTo(updatedStoreResponse.GetType()));
            });
            Assert.Pass();
        }
    }
}
