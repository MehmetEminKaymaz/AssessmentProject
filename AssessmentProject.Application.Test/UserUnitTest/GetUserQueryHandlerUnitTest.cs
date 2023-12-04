using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Application.Store.Handler;
using AssessmentProject.Application.User.Commands;
using AssessmentProject.Application.User.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.User.Queries;

namespace AssessmentProject.Application.Test.UserUnitTest
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class GetUserQueryHandlerUnitTest
    {
        private readonly CreateUserCommand _createUserCommand;
        private readonly CreateUserCommandHandler _createUserCommandHandler;
        private readonly CreateStoreCommandHandler _createStoreCommandHandler;
        private readonly CreateStoreCommand _createStoreCommand;
        private readonly GetUserQueryHandler _getUserQueryHandler;
        private readonly GetUserQuery _getUserQuery;
        public GetUserQueryHandlerUnitTest(CreateUserCommand createUserCommand, CreateUserCommandHandler createUserCommandHandler, CreateStoreCommandHandler createStoreCommandHandler, CreateStoreCommand createStoreCommand, GetUserQueryHandler getUserQueryHandler, GetUserQuery getUserQuery)
        {
            _createUserCommand = createUserCommand;
            _createUserCommandHandler = createUserCommandHandler;
            _createStoreCommandHandler = createStoreCommandHandler;
            _createStoreCommand = createStoreCommand;
            _getUserQueryHandler = getUserQueryHandler;
            _getUserQuery = getUserQuery;
        }

        [Test]
        public void GetUserQueryHandler_Handle_ShouldReturnFilledBaseResponseModel()
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

            if (createdUserResponse is { Data: not null }) _getUserQuery.UserId = createdUserResponse.Data.UserId;
            var getUserResponse = _getUserQueryHandler.Handle(_getUserQuery);
            if (getUserResponse == null)
            {
                Assert.Fail();
            }
            
            Assert.Multiple(() =>
            {
                Assert.That(getUserResponse?.GetType(), Is.EqualTo(new BaseResponseModel<CreateUserCommand>().GetType()));
                Assert.That(getUserResponse?.Status, Is.EqualTo(true));
            });

            Assert.Pass();
        }

        [Test]
        public void GetUserQueryHandler_Handle_ShouldReturnFalse()
        {
            _getUserQuery.UserId = Guid.NewGuid();
            var getUserResponse = _getUserQueryHandler.Handle(_getUserQuery);
            if (getUserResponse == null)
            {
                Assert.Fail();
            }

            Assert.Multiple(() =>
            {
                Assert.That(getUserResponse?.GetType(), Is.EqualTo(new BaseResponseModel<CreateUserCommand>().GetType()));
                Assert.That(getUserResponse?.Status, Is.EqualTo(false));
            });
            Assert.Pass();
        }
    }
}
