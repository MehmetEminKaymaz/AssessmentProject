using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Application.Store.Handler;
using AssessmentProject.Application.User.Commands;
using AssessmentProject.Application.User.Handler;

namespace AssessmentProject.Application.Test.UserUnitTest
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class UpdateUserCommandHandlerUnitTest
    {
        private readonly UpdateUserCommandHandler _updateUserCommandHandler;
        private readonly UpdateUserCommand _updateUserCommand;
        private readonly CreateUserCommand _createUserCommand;
        private readonly CreateUserCommandHandler _createUserCommandHandler;
        private readonly CreateStoreCommandHandler _createStoreCommandHandler;
        private readonly CreateStoreCommand _createStoreCommand;
        public UpdateUserCommandHandlerUnitTest(UpdateUserCommandHandler updateUserCommandHandler, UpdateUserCommand updateUserCommand, CreateUserCommand createUserCommand, CreateUserCommandHandler createUserCommandHandler, CreateStoreCommandHandler createStoreCommandHandler, CreateStoreCommand createStoreCommand)
        {
            _updateUserCommandHandler = updateUserCommandHandler;
            _updateUserCommand = updateUserCommand;
            _createUserCommand = createUserCommand;
            _createUserCommandHandler = createUserCommandHandler;
            _createStoreCommandHandler = createStoreCommandHandler;
            _createStoreCommand = createStoreCommand;
        }

        [Test]
        public void UpdateUserCommandHandler_Handle_ShouldReturnFilledBaseResponseModel()
        {
            _createStoreCommand.Name = "ShopTest";
            _createStoreCommand.IsGrocery = true;
            var createdStore = _createStoreCommandHandler.Handle(_createStoreCommand);
            if (createdStore == null)
            {
                Assert.Fail("Store can not be created for test");
            }
            _createUserCommand.Name = "Username";
            _createUserCommand.IsAffiliate = true;
            _createUserCommand.IsEmployee = false;
            _createUserCommand.Surname = "Test";
            if (createdStore is { Data: not null }) _createUserCommand.StoreId = createdStore.Data.StoreId;
            var createdUserResponse = _createUserCommandHandler.Handle(_createUserCommand);
            if (createdUserResponse == null)
            {
                Assert.Fail();
            }

            if (createdUserResponse is { Data: not null }) _updateUserCommand.UserId = createdUserResponse.Data.UserId;
            _updateUserCommand.IsAffiliate = true;
            _updateUserCommand.IsEmployee = false;
            _updateUserCommand.Surname = "Test";
            _updateUserCommand.Name = "TestName";
            var updateUserResponse = _updateUserCommandHandler.Handle(_updateUserCommand);
            if (updateUserResponse == null)
            {
                Assert.Fail();
            }

            Assert.Multiple(() =>
            {
                Assert.That(updateUserResponse?.GetType(), Is.EqualTo(new BaseResponseModel<UpdateUserCommand>().GetType()));
                Assert.That(updateUserResponse?.Status, Is.EqualTo(true));
            });

            Assert.Pass();
        }

        [Test]
        public void UpdateUserCommandHandler_Handle_ShouldReturnFalse()
        {
            _updateUserCommand.UserId = Guid.NewGuid();
            _updateUserCommand.IsAffiliate = true;
            _updateUserCommand.IsEmployee = false;
            _updateUserCommand.Surname = "Test";
            _updateUserCommand.Name = "TestName";
            var updateUserResponse = _updateUserCommandHandler.Handle(_updateUserCommand);
            if (updateUserResponse == null)
            {
                Assert.Fail();
            }

            Assert.Multiple(() =>
            {
                Assert.That(updateUserResponse?.GetType(), Is.EqualTo(new BaseResponseModel<UpdateUserCommand>().GetType()));
                Assert.That(updateUserResponse?.Status, Is.EqualTo(false));
            });

            Assert.Pass();
        }
    }
}
