using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.User.Commands;
using AssessmentProject.Data;
using AssessmentProject.Data.Domain;

namespace AssessmentProject.Application.User.Handler
{
    public class CreateUserCommandHandler
    {
        private readonly DataContext _context;
        public CreateUserCommandHandler(DataContext context)
        {
            _context = context;
        }

        public BaseResponseModel<CreateUserCommand> Handle(CreateUserCommand command)
        {
            var store = _context.Stores.FirstOrDefault(s => s.Id == command.StoreId);
            if (store == null)
            {
                return new BaseResponseModel<CreateUserCommand>()
                {
                    Status = false,
                };
            }

            var userWillBeCreate = new UserRepository()
            {
                IsAffiliate = command.IsAffiliate,
                IsEmployee = command.IsEmployee,
                Store = store,
                Name = command.Name,
                Surname = command.Surname
            };

            _context.Users.Add(userWillBeCreate);
            _context.SaveChanges();
            _context.Dispose();

            command.UserId = userWillBeCreate.Id;

            return new BaseResponseModel<CreateUserCommand>()
            {
                Data = command,
                Status = true
            };
        }

    }
}
