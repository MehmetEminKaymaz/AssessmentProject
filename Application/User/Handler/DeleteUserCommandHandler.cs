using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.User.Commands;
using AssessmentProject.Data;

namespace AssessmentProject.Application.User.Handler
{
    public class DeleteUserCommandHandler
    {
        private readonly DataContext _context;

        public DeleteUserCommandHandler(DataContext context)
        {
            _context = context;
        }

        public BaseResponseModel<DeleteUserCommand> Handle(DeleteUserCommand command)
        {
            var userWillBeDelete = _context.Users.FirstOrDefault(u => u.Id == command.UserId);
            if (userWillBeDelete == null)
            {
                return new BaseResponseModel<DeleteUserCommand>()
                {
                    Status = false,
                };
            }

            _context.Remove(userWillBeDelete);
            _context.SaveChanges();
            _context.Dispose();

            return new BaseResponseModel<DeleteUserCommand>()
            {
                Status = true,
                Data = command
            };
        }
    }
}
