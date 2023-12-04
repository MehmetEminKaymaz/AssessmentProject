using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.Discount.Commands;
using AssessmentProject.Application.Discount.Handler;
using AssessmentProject.Application.Discount.Queries;
using AssessmentProject.Application.Invoice.Commands;
using AssessmentProject.Application.Invoice.Handler;
using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Application.Store.Handler;
using AssessmentProject.Application.User.Commands;
using AssessmentProject.Application.User.Handler;
using AssessmentProject.Data;

namespace AssessmentProject.Application.Test.DiscountTest
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class DeleteDiscountCommandHandlerUnitTest
    {
        private readonly GetDiscountQueryHandler _getDiscountQueryHandler;
        private readonly GetDiscountQuery _getDiscountQuery;
        private readonly CreateInvoiceCommand _createInvoiceCommand;
        private readonly CreateInvoiceCommandHandler _createInvoiceCommandHandler;
        private readonly CreateUserCommand _createUserCommand;
        private readonly CreateUserCommandHandler _createUserCommandHandler;
        private readonly CreateStoreCommand _createStoreCommand;
        private readonly CreateStoreCommandHandler _createStoreCommandHandler;
        private readonly CreateDiscountCommandHandler _createDiscountCommandHandler;
        private readonly CreateDiscountCommand _createDiscountCommand;
        private readonly DeleteDiscountCommand _deleteDiscountCommand;
        private readonly DeleteDiscountCommandHandler _deleteDiscountCommandHandler;
        public DeleteDiscountCommandHandlerUnitTest(DataContext context, GetDiscountQueryHandler getDiscountQueryHandler, GetDiscountQuery getDiscountQuery, CreateInvoiceCommand createInvoiceCommand, CreateInvoiceCommandHandler createInvoiceCommandHandler, CreateUserCommand createUserCommand, CreateUserCommandHandler createUserCommandHandler, CreateStoreCommand createStoreCommand, CreateStoreCommandHandler createStoreCommandHandler, CreateDiscountCommandHandler createDiscountCommandHandler, CreateDiscountCommand createDiscountCommand, DeleteDiscountCommand deleteDiscountCommand, DeleteDiscountCommandHandler deleteDiscountCommandHandler)
        {
            _getDiscountQueryHandler = getDiscountQueryHandler;
            _getDiscountQuery = getDiscountQuery;
            _createInvoiceCommand = createInvoiceCommand;
            _createInvoiceCommandHandler = createInvoiceCommandHandler;
            _createUserCommand = createUserCommand;
            _createUserCommandHandler = createUserCommandHandler;
            _createStoreCommand = createStoreCommand;
            _createStoreCommandHandler = createStoreCommandHandler;
            _createDiscountCommandHandler = createDiscountCommandHandler;
            _createDiscountCommand = createDiscountCommand;
            _deleteDiscountCommand = deleteDiscountCommand;
            _deleteDiscountCommandHandler = deleteDiscountCommandHandler;
        }

        [Test]
        public void DeleteDiscountQueryHandler_Handle_ShouldReturnFilledBaseResponseModel()
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

            _createDiscountCommand.InvoiceId = getDiscountResponse.Data.InvoiceId;
            _createDiscountCommand.DiscountId = getDiscountResponse.Data.AvailableDiscountIds.FirstOrDefault();

            var createDiscountResponse = _createDiscountCommandHandler.Handle(_createDiscountCommand);
            if (createDiscountResponse == null)
            {
                Assert.Fail();
            }

            if (createDiscountResponse != null)
            {
                if (createDiscountResponse.Data != null)
                {
                    _deleteDiscountCommand.DiscountId = createDiscountResponse.Data.AppliedDiscountId;
                    _deleteDiscountCommand.InvoiceId = createDiscountResponse.Data.InvoiceId;
                }

                var deleteDiscountResponse = _deleteDiscountCommandHandler.Handle(_deleteDiscountCommand);
                Assert.Multiple(() =>
                {
                    Assert.That(deleteDiscountResponse?.GetType(),
                        Is.EqualTo(new BaseResponseModel<DeleteDiscountCommand>().GetType()));
                    Assert.That(deleteDiscountResponse?.Status, Is.EqualTo(true));
                });
                Assert.Pass();
            }
        }

        [Test]
        public void DeleteDiscountQueryHandler_Handle_ShouldReturnFalse()
        {
            _deleteDiscountCommand.DiscountId = Guid.NewGuid();
            _deleteDiscountCommand.InvoiceId = Guid.NewGuid();

            var deleteDiscountResponse = _deleteDiscountCommandHandler.Handle(_deleteDiscountCommand);
            Assert.Multiple(() =>
            {
                Assert.That(deleteDiscountResponse?.GetType(),
                    Is.EqualTo(new BaseResponseModel<DeleteDiscountCommand>().GetType()));
                Assert.That(deleteDiscountResponse?.Status, Is.EqualTo(false));
            });
            Assert.Pass();
        }
    }
}
