using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.User.Commands;
using AssessmentProject.Data;

namespace AssessmentProject.Application.User.Handler
{
    public class UpdateUserCommandHandler
    {
        private readonly DataContext _context;
        public UpdateUserCommandHandler(DataContext context)
        {
            _context = context;
        }

        public BaseResponseModel<UpdateUserCommand> Handle(UpdateUserCommand command)
        {
            var userWillBeUpdate = _context.Users.FirstOrDefault(u => u.Id == command.UserId);
            if (userWillBeUpdate == null)
            {
                return new BaseResponseModel<UpdateUserCommand>()
                {
                    Status = false,
                };
            }

            userWillBeUpdate.Name = command.Name;
            userWillBeUpdate.Surname = command.Surname;
            userWillBeUpdate.IsAffiliate = command.IsAffiliate;
            userWillBeUpdate.IsEmployee = command.IsEmployee;

            _context.SaveChanges();
            _context.Dispose();

            return new BaseResponseModel<UpdateUserCommand>()
            {
                Status = true,
                Data = command
            };
        }
    }
}
