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
    public class CreateUserCommandHandlerUnitTest
    {
        private readonly CreateStoreCommandHandler _createStoreCommandHandler;
        private readonly CreateStoreCommand _createStoreCommand;
        private readonly CreateUserCommandHandler _createUserCommandHandler;
        private readonly CreateUserCommand _createUserCommand;

        public CreateUserCommandHandlerUnitTest(CreateUserCommandHandler createUserCommandHandler, CreateUserCommand createUserCommand, CreateStoreCommandHandler createStoreCommandHandler, CreateStoreCommand createStoreCommand)
        {
            _createUserCommandHandler = createUserCommandHandler;
            _createUserCommand = createUserCommand;
            _createStoreCommandHandler = createStoreCommandHandler;
            _createStoreCommand = createStoreCommand;
        }

        [Test]
        public void CreateUserCommandHandler_Handle_ShouldReturnFilledBaseResponseModel()
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
            Assert.That(createdUserResponse, Is.Not.Null);
            Assert.That(createdUserResponse.Status, Is.EqualTo(true));
            if (createdUserResponse.Data != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(createdUserResponse.GetType(), Is.EqualTo(new BaseResponseModel<CreateUserCommand>().GetType()));
                    Assert.That(createdUserResponse.Data.Name, Is.EqualTo(_createUserCommand.Name));
                    Assert.That(createdUserResponse.Data.Surname, Is.EqualTo(_createUserCommand.Surname));
                    Assert.That(createdUserResponse.Data.IsAffiliate, Is.EqualTo(_createUserCommand.IsAffiliate));
                    Assert.That(createdUserResponse.Data.IsEmployee, Is.EqualTo(_createUserCommand.IsEmployee));
                });
            }
            else
            {
                Assert.Fail();
            }
            Assert.Pass("User Created Successfully");
        }

        [Test]
        public void CreateUserCommandHandler_Handle_ShouldReturnFalse()
        {
            _createUserCommand.Name = "Username";
            _createUserCommand.IsAffiliate = true;
            _createUserCommand.IsEmployee = false;
            _createUserCommand.Surname = "Test";
            _createUserCommand.StoreId = Guid.NewGuid(); // test with wrong store id
            var createUserResponse = _createUserCommandHandler.Handle(_createUserCommand);
            Assert.That(createUserResponse.Status, Is.EqualTo(false));
        }
    }
}
