
using AssessmentProject.Data;
using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Data.Domain;

namespace AssessmentProject.Application.Store.Handler
{
    public class CreateStoreCommandHandler
    {
        private readonly DataContext _context;
        public CreateStoreCommandHandler(DataContext context) => _context = context;

        public BaseResponseModel<CreateStoreCommand> Handle(CreateStoreCommand command)
        {
            var createdStore = new StoreRepository()
            {
                IsGrocery = command.IsGrocery,
                Name = command.Name,
                Users = new List<UserRepository>()
            };

            _context.Stores.Add(createdStore);
            _context.SaveChanges();

            command.StoreId = createdStore.Id;

            return new BaseResponseModel<CreateStoreCommand>()
            {
                Status = true,
                Data = command,
            };
        }
    }
}
