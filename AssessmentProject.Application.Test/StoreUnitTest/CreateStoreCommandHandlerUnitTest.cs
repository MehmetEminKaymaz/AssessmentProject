using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Application.Store.Handler;
using AssessmentProject.Application.User.Handler;

namespace AssessmentProject.Application.Test.StoreUnitTest
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class Tests
    {
        private readonly CreateStoreCommandHandler _createStoreCommandHandler;
        private readonly CreateStoreCommand _createStoreCommand;

        public Tests(CreateStoreCommand createStoreCommand, CreateStoreCommandHandler createStoreCommandHandler)
        {
            _createStoreCommandHandler = createStoreCommandHandler;
            _createStoreCommand = createStoreCommand;
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreateStoreCommandHandler_Handle_ShouldReturnFilledBaseResponseModel()
        {
            _createStoreCommand.Name = "ShopTest";
            _createStoreCommand.IsGrocery = true;
            var createdStoreResponse = _createStoreCommandHandler.Handle(_createStoreCommand);

            Assert.Multiple(() =>
            {
                Assert.That(createdStoreResponse.Data, Is.Not.Null);
                Assert.That(new BaseResponseModel<CreateStoreCommand>().GetType(), Is.EqualTo(createdStoreResponse.GetType()));
            });
            Assert.Pass("CreateStoreCommandHandler's Handle Method Return Correct Type of Object");
        }

        [Test]
        public void CreateStoreCommandHandler_Handle_ShouldCreateWithoutName()
        {
            _createStoreCommand.IsGrocery = true;
            var createdStoreResponse = _createStoreCommandHandler.Handle(_createStoreCommand);
            Assert.Multiple(() =>
            {
                Assert.That(createdStoreResponse.Data, Is.Not.Null);
                Assert.That(new BaseResponseModel<CreateStoreCommand>().GetType(), Is.EqualTo(createdStoreResponse.GetType()));
            });
            Assert.Pass("CreateStoreCommandHandler's Handle Method Create Store Without Name");
        }

        [Test]
        public void CreateStoreCommandHandler_Handle_ShouldGroceryValueTrue()
        {
            _createStoreCommand.IsGrocery = true;
            var createdStoreResponse = _createStoreCommandHandler.Handle(_createStoreCommand);
            Assert.Multiple(() =>
            {
                Assert.That(createdStoreResponse.Data, Is.Not.Null);
                Assert.That(new BaseResponseModel<CreateStoreCommand>().GetType(), Is.EqualTo(createdStoreResponse.GetType()));
                Assert.That(createdStoreResponse.Data is { IsGrocery: true }, Is.EqualTo(true));
            });
            Assert.Pass("CreateStoreCommandHandler's Handle Method Create Store With True Grocery Value");
        }
    }
}