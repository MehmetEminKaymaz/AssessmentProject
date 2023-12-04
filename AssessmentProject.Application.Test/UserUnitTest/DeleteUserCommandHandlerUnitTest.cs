using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Application.Store.Handler;
using AssessmentProject.Application.User.Commands;
using AssessmentProject.Application.User.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.Application.Test.UserUnitTest
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class DeleteUserCommandHandlerUnitTest
    {
        private readonly CreateUserCommandHandler _createUserCommandHandler;
        private readonly CreateUserCommand _createUserCommand;
        private readonly DeleteUserCommandHandler _deleteUserCommandHandler;
        private readonly DeleteUserCommand _deleteUserCommand;
        private readonly CreateStoreCommandHandler _createStoreCommandHandler;
        private readonly CreateStoreCommand _createStoreCommand;
        public DeleteUserCommandHandlerUnitTest(CreateUserCommandHandler createUserCommandHandler, CreateUserCommand createUserCommand, DeleteUserCommandHandler deleteUserCommandHandler, DeleteUserCommand deleteUserCommand, CreateStoreCommandHandler createStoreCommandHandler, CreateStoreCommand createStoreCommand)
        {
            _createUserCommandHandler = createUserCommandHandler;
            _createUserCommand = createUserCommand;
            _deleteUserCommandHandler = deleteUserCommandHandler;
            _deleteUserCommand = deleteUserCommand;
            _createStoreCommandHandler = createStoreCommandHandler;
            _createStoreCommand = createStoreCommand;
        }

        [Test]
        public void DeleteUserCommandHandler_Handle_ShouldReturnFilledBaseResponseModel()
        {
            _createStoreCommand.Name = "ShopTest";
            _createStoreCommand.IsGrocery = true;
            var createdStore = _createStoreCommandHandler.Handle(_createStoreCommand);
            if (createdStore == null)
            {
                Assert.Fail("Store can not be created for test");
            }

            _createUserCommand.Name = "UserName";
            _createUserCommand.Surname = "surname";
            _createUserCommand.IsAffiliate = true;
            _createUserCommand.IsEmployee = true;
            if (createdStore is { Data: not null }) _createUserCommand.StoreId = createdStore.Data.StoreId;
            var createdUserResponse = _createUserCommandHandler.Handle(_createUserCommand);
            if (createdUserResponse == null)
            {
                Assert.Fail();
            }

            if (createdUserResponse is { Data: not null }) _deleteUserCommand.UserId = createdUserResponse.Data.UserId;
            var deleteUserResponse = _deleteUserCommandHandler.Handle(_deleteUserCommand);
            if (deleteUserResponse == null)
            {
                Assert.Fail();
            }

            Assert.Multiple(() =>
            {
                Assert.That(deleteUserResponse?.GetType(), Is.EqualTo(new BaseResponseModel<DeleteUserCommand>().GetType()));
                Assert.That(deleteUserResponse?.Status, Is.EqualTo(true));
            });

            Assert.Pass();
        }

        [Test]
        public void DeleteUserCommandHandler_Handle_ShouldReturnFalse()
        {
            _deleteUserCommand.UserId = Guid.NewGuid();
            var deleteUserResponse = _deleteUserCommandHandler.Handle(_deleteUserCommand);
            if (deleteUserResponse == null)
            {
                Assert.Fail();
            }

            Assert.That(deleteUserResponse is { Status: true }, Is.EqualTo(false));
            Assert.Pass();
        }
    }
}
