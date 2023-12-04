using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.Invoice.Commands;
using AssessmentProject.Application.Invoice.Handler;
using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Application.Store.Handler;
using AssessmentProject.Application.User.Commands;
using AssessmentProject.Application.User.Handler;

namespace AssessmentProject.Application.Test.InvoiceUnitTest
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class DeleteInvoiceCommandHandlerUnitTest
    {
        private readonly DeleteInvoiceCommand _deleteInvoiceCommand;
        private readonly DeleteInvoiceCommandHandler _deleteInvoiceCommandHandler;
        private readonly CreateInvoiceCommand _createInvoiceCommand;
        private readonly CreateInvoiceCommandHandler _createInvoiceCommandHandler;
        private readonly CreateUserCommand _createUserCommand;
        private readonly CreateUserCommandHandler _createUserCommandHandler;
        private readonly CreateStoreCommand _createStoreCommand;
        private readonly CreateStoreCommandHandler _createStoreCommandHandler;
        public DeleteInvoiceCommandHandlerUnitTest(DeleteInvoiceCommand deleteInvoiceCommand, DeleteInvoiceCommandHandler deleteInvoiceCommandHandler, CreateInvoiceCommand createInvoiceCommand, CreateInvoiceCommandHandler createInvoiceCommandHandler, CreateUserCommand createUserCommand, CreateUserCommandHandler createUserCommandHandler, CreateStoreCommand createStoreCommand, CreateStoreCommandHandler createStoreCommandHandler)
        {
            _deleteInvoiceCommand = deleteInvoiceCommand;
            _deleteInvoiceCommandHandler = deleteInvoiceCommandHandler;
            _createInvoiceCommand = createInvoiceCommand;
            _createInvoiceCommandHandler = createInvoiceCommandHandler;
            _createUserCommand = createUserCommand;
            _createUserCommandHandler = createUserCommandHandler;
            _createStoreCommand = createStoreCommand;
            _createStoreCommandHandler = createStoreCommandHandler;
        }

        [Test]
        public void DeleteInvoiceCommandHandler_Handle_ShouldReturnFilledBaseResponseModel()
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

            if (createInvoiceResponse is { Data: not null }) _deleteInvoiceCommand.InvoiceId = createInvoiceResponse.Data.Id;
            var deleteInvoiceResponse = _deleteInvoiceCommandHandler.Handle(_deleteInvoiceCommand);
            if (deleteInvoiceResponse == null)
            {
                Assert.Fail();
            }

            Assert.Multiple(() =>
            {
                Assert.That(deleteInvoiceResponse?.GetType(), Is.EqualTo(new BaseResponseModel<DeleteInvoiceCommand>().GetType()));
                Assert.That(deleteInvoiceResponse?.Status, Is.EqualTo(true));
            });
            Assert.Pass();
        }

        [Test]
        public void DeleteInvoiceCommandHandler_Handle_ShouldReturnFalse()
        {
            _deleteInvoiceCommand.InvoiceId = Guid.NewGuid();
            var deleteInvoiceResponse = _deleteInvoiceCommandHandler.Handle(_deleteInvoiceCommand);
            if (deleteInvoiceResponse == null)
            {
                Assert.Fail();
            }

            Assert.Multiple(() =>
            {
                Assert.That(deleteInvoiceResponse?.GetType(), Is.EqualTo(new BaseResponseModel<DeleteInvoiceCommand>().GetType()));
                Assert.That(deleteInvoiceResponse?.Status, Is.EqualTo(false));
            });
            Assert.Pass();
        }
    }
}
