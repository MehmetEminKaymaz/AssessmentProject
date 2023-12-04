using AssessmentProject.Application.Invoice.Commands;
using AssessmentProject.Application.Invoice.Handler;
using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Application.Store.Handler;
using AssessmentProject.Application.User.Commands;
using AssessmentProject.Application.User.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.Application.Test.InvoiceUnitTest
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class UpdateInvoiceCommandHandlerUnitTest
    {
        private readonly CreateInvoiceCommand _createInvoiceCommand;
        private readonly CreateInvoiceCommandHandler _createInvoiceCommandHandler;
        private readonly CreateUserCommand _createUserCommand;
        private readonly CreateUserCommandHandler _createUserCommandHandler;
        private readonly CreateStoreCommand _createStoreCommand;
        private readonly CreateStoreCommandHandler _createStoreCommandHandler;
        private readonly UpdateInvoiceCommand _updateInvoiceCommand;
        private readonly UpdateInvoiceCommandHandler _updateInvoiceCommandHandler;
        public UpdateInvoiceCommandHandlerUnitTest(CreateInvoiceCommand createInvoiceCommand, CreateInvoiceCommandHandler createInvoiceCommandHandler, CreateUserCommand createUserCommand, CreateUserCommandHandler createUserCommandHandler, CreateStoreCommand createStoreCommand, CreateStoreCommandHandler createStoreCommandHandler, UpdateInvoiceCommand updateInvoiceCommand, UpdateInvoiceCommandHandler updateInvoiceCommandHandler)
        {
            _createInvoiceCommand = createInvoiceCommand;
            _createInvoiceCommandHandler = createInvoiceCommandHandler;
            _createUserCommand = createUserCommand;
            _createUserCommandHandler = createUserCommandHandler;
            _createStoreCommand = createStoreCommand;
            _createStoreCommandHandler = createStoreCommandHandler;
            _updateInvoiceCommand = updateInvoiceCommand;
            _updateInvoiceCommandHandler = updateInvoiceCommandHandler;
        }

        [Test]
        public void UpdateInvoiceCommandHandler_Handle_ShouldReturnFilledBaseResponseModel()
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

            _updateInvoiceCommand.FinalCost = 100;
            _updateInvoiceCommand.Cost = 50;
            _updateInvoiceCommand.InvoiceDate = DateTimeOffset.Now;
            if (createInvoiceResponse is { Data: not null }) _updateInvoiceCommand.InvoiceId = createInvoiceResponse.Data.Id;
            var updateInvoiceResponse = _updateInvoiceCommandHandler.Handle(_updateInvoiceCommand);
            if (updateInvoiceResponse == null)
            {
                Assert.Fail();
            }

            Assert.Multiple(() =>
            {
                Assert.That(updateInvoiceResponse?.GetType(), Is.EqualTo(new BaseResponseModel<UpdateInvoiceCommand>().GetType()));
                Assert.That(updateInvoiceResponse?.Status, Is.EqualTo(true));
                Assert.That(updateInvoiceResponse?.Data?.FinalCost,Is.EqualTo(_updateInvoiceCommand.FinalCost));
                Assert.That(updateInvoiceResponse?.Data?.Cost, Is.EqualTo(_updateInvoiceCommand.Cost));
                Assert.That(updateInvoiceResponse?.Data?.InvoiceDate, Is.EqualTo(_updateInvoiceCommand.InvoiceDate));
            });
            Assert.Pass();
        }

        [Test]
        public void UpdateInvoiceCommandHandler_Handle_ShouldReturnFalse()
        {
            _updateInvoiceCommand.FinalCost = 100;
            _updateInvoiceCommand.Cost = 50;
            _updateInvoiceCommand.InvoiceDate = DateTimeOffset.Now;
            _updateInvoiceCommand.InvoiceId = Guid.NewGuid();
            var updateInvoiceResponse = _updateInvoiceCommandHandler.Handle(_updateInvoiceCommand);
            if (updateInvoiceResponse == null)
            {
                Assert.Fail();
            }

            Assert.Multiple(() =>
            {
                Assert.That(updateInvoiceResponse?.GetType(), Is.EqualTo(new BaseResponseModel<UpdateInvoiceCommand>().GetType()));
                Assert.That(updateInvoiceResponse?.Status, Is.EqualTo(false));
            });
            Assert.Pass();
        }
    }
}
