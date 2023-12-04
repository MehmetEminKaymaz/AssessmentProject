using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.Discount.Handler;
using AssessmentProject.Application.Discount.Queries;
using AssessmentProject.Application.Invoice.Commands;
using AssessmentProject.Application.Invoice.Handler;
using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Application.Store.Handler;
using AssessmentProject.Application.User.Commands;
using AssessmentProject.Application.User.Handler;

namespace AssessmentProject.Application.Test.DiscountTest
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class GetDiscountQueryHandlerUnitTest
    {
        private readonly GetDiscountQueryHandler _getDiscountQueryHandler;
        private readonly GetDiscountQuery _getDiscountQuery;
        private readonly CreateInvoiceCommand _createInvoiceCommand;
        private readonly CreateInvoiceCommandHandler _createInvoiceCommandHandler;
        private readonly CreateUserCommand _createUserCommand;
        private readonly CreateUserCommandHandler _createUserCommandHandler;
        private readonly CreateStoreCommand _createStoreCommand;
        private readonly CreateStoreCommandHandler _createStoreCommandHandler;
        public GetDiscountQueryHandlerUnitTest(GetDiscountQueryHandler getDiscountQueryHandler, GetDiscountQuery getDiscountQuery, CreateInvoiceCommand createInvoiceCommand, CreateInvoiceCommandHandler createInvoiceCommandHandler, CreateUserCommand createUserCommand, CreateUserCommandHandler createUserCommandHandler, CreateStoreCommand createStoreCommand, CreateStoreCommandHandler createStoreCommandHandler)
        {
            _getDiscountQueryHandler = getDiscountQueryHandler;
            _getDiscountQuery = getDiscountQuery;
            _createInvoiceCommand = createInvoiceCommand;
            _createInvoiceCommandHandler = createInvoiceCommandHandler;
            _createUserCommand = createUserCommand;
            _createUserCommandHandler = createUserCommandHandler;
            _createStoreCommand = createStoreCommand;
            _createStoreCommandHandler = createStoreCommandHandler;
        }

        [Test]
        public void GetDiscountQueryHandler_Handle_ShouldReturnFilledBaseResponseModel()
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

            _createInvoiceCommand.Cost = 500;
            _createInvoiceCommand.FinalCost = 300;
            _createInvoiceCommand.InvoiceDate = DateTimeOffset.Now;
            if (createdUserResponse.Data != null) _createInvoiceCommand.UserId = createdUserResponse.Data.UserId;
            var createInvoiceResponse = _createInvoiceCommandHandler.Handle(_createInvoiceCommand);
            if (createInvoiceResponse == null)
            {
                Assert.Fail();
            }

            if (createInvoiceResponse is { Data: not null })
                _getDiscountQuery.InvoiceId = createInvoiceResponse.Data.Id;
            var getDiscountResponse = _getDiscountQueryHandler.Handle(_getDiscountQuery);
            if (getDiscountResponse == null)
            {
                Assert.Fail();
            }

            Assert.Multiple(() =>
            {
                Assert.That(getDiscountResponse?.GetType(), Is.EqualTo(new BaseResponseModel<GetDiscountQuery>().GetType()));
                Assert.That(getDiscountResponse?.Status, Is.EqualTo(true));
                Assert.That(getDiscountResponse?.Data?.InvoiceId, Is.EqualTo(createInvoiceResponse?.Data?.Id));
            });
            Assert.Pass();
        }

        [Test]
        public void GetDiscountQueryHandler_Handle_ShouldReturnFalse()
        {

            _getDiscountQuery.InvoiceId = Guid.NewGuid();
            var getDiscountResponse = _getDiscountQueryHandler.Handle(_getDiscountQuery);
            if (getDiscountResponse == null)
            {
                Assert.Fail();
            }

            Assert.Multiple(() =>
            {
                Assert.That(getDiscountResponse?.GetType(), Is.EqualTo(new BaseResponseModel<GetDiscountQuery>().GetType()));
                Assert.That(getDiscountResponse?.Status, Is.EqualTo(false));
            });
            Assert.Pass();
        }
    }
}
