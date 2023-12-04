using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Application.Store.Handler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.Application.Test.StoreUnitTest
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class DeleteStoreCommandHandlerUnitTest
    {
        private readonly CreateStoreCommandHandler _createStoreCommandHandler;
        private readonly CreateStoreCommand _createStoreCommand;
        private readonly DeleteStoreCommandHandler _deleteStoreCommandHandler;
        private readonly DeleteStoreCommand _deleteStoreCommand;
        public DeleteStoreCommandHandlerUnitTest(DeleteStoreCommandHandler deleteStoreCommandHandler, DeleteStoreCommand deleteStoreCommand, CreateStoreCommandHandler createStoreCommandHandler, CreateStoreCommand createStoreCommand)
        {
            _deleteStoreCommandHandler = deleteStoreCommandHandler;
            _deleteStoreCommand = deleteStoreCommand;
            _createStoreCommandHandler = createStoreCommandHandler;
            _createStoreCommand = createStoreCommand;
        }

        [Test]
        public void DeleteStoreCommandHandler_Handle_ShouldReturnFilledBaseResponseModel()
        {
            _createStoreCommand.Name = "ShopTest";
            _createStoreCommand.IsGrocery = true;
            var createStoreCommand = _createStoreCommandHandler.Handle(_createStoreCommand).Data;
            if (createStoreCommand == null)
            {
                Assert.Fail("Store can not created before delete");
            }

            if (createStoreCommand != null) _deleteStoreCommand.StoreId = createStoreCommand.StoreId;
            var deleteStoreCommandResponse = _deleteStoreCommandHandler.Handle(_deleteStoreCommand);
            Assert.Multiple(() =>
            {
                Assert.That(deleteStoreCommandResponse.Status, Is.EqualTo(true));
                Assert.That(new BaseResponseModel<DeleteStoreCommand>().GetType(), Is.EqualTo(deleteStoreCommandResponse.GetType()));
            });
            Assert.Pass();
        }

        [Test]
        public void DeleteStoreCommandHandler_Handle_ShouldReturnStatusFalse()
        {
            _deleteStoreCommand.StoreId = Guid.NewGuid();//with wrong id
            var deleteStoreCommandResponse = _deleteStoreCommandHandler.Handle(_deleteStoreCommand);
            Assert.Multiple(() =>
            {
                Assert.That(deleteStoreCommandResponse.Status, Is.EqualTo(false));
                Assert.That(new BaseResponseModel<DeleteStoreCommand>().GetType(), Is.EqualTo(deleteStoreCommandResponse.GetType()));
            });
            Assert.Pass();
        }
    }
}
