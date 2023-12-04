using AssessmentProject.Application.User.Commands;
using AssessmentProject.Application.User.Handler;
using AssessmentProject.Application.User.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentProject.Api.Controllers
{
    public class UserController : Controller
    {
        private readonly CreateUserCommandHandler _createUserCommandHandler;
        private readonly DeleteUserCommandHandler _deleteUserCommandHandler;
        private readonly UpdateUserCommandHandler _updateUserCommandHandler;
        private readonly GetUserQueryHandler _getUserQueryHandler;

        public UserController(CreateUserCommandHandler createUserCommandHandler, DeleteUserCommandHandler deleteUserCommandHandler, UpdateUserCommandHandler updateUserCommandHandler, GetUserQueryHandler getUserQueryHandler)
        {
            _createUserCommandHandler = createUserCommandHandler;
            _deleteUserCommandHandler = deleteUserCommandHandler;
            _updateUserCommandHandler = updateUserCommandHandler;
            _getUserQueryHandler = getUserQueryHandler;
        }

        [HttpPost]
        public IActionResult Post(CreateUserCommand command)
        {
            return Ok(_createUserCommandHandler.Handle(command));
        }

        [HttpDelete]
        public IActionResult Delete(DeleteUserCommand command)
        {
            return Ok(_deleteUserCommandHandler.Handle(command));
        }

        [HttpGet]
        public IActionResult Get(GetUserQuery query)
        {
            return Ok(_getUserQueryHandler.Handle(query));
        }

        [HttpPut]
        public IActionResult Put(UpdateUserCommand command)
        {
            return Ok(_updateUserCommandHandler.Handle(command));
        }
    }
}
