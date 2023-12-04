using AssessmentProject.Application.User.Commands;
using AssessmentProject.Application.User.Queries;
using AssessmentProject.Data;

namespace AssessmentProject.Application.User.Handler
{
    public class GetUserQueryHandler
    {
        private readonly DataContext _context;
        public GetUserQueryHandler(DataContext context)
        {
            _context = context;
        }

        public BaseResponseModel<CreateUserCommand> Handle(GetUserQuery query)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == query.UserId);
            if (user == null)
            {
                return new BaseResponseModel<CreateUserCommand>()
                {
                    Status = false,
                };
            }

            return new BaseResponseModel<CreateUserCommand>() { Status = true, Data = new CreateUserCommand()
            {
                Name = user.Name,
                Surname = user.Surname,
                UserId = user.Id,
                IsAffiliate = user.IsAffiliate,
                IsEmployee = user.IsEmployee
            }};
        }
    }
}
