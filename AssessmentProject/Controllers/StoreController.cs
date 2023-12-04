using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Application.Store.Handler;
using AssessmentProject.Application.Store.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentProject.Api.Controllers
{
    public class StoreController : Controller
    {
        private readonly CreateStoreCommandHandler _createStoreCommandHandler;
        private readonly DeleteStoreCommandHandler _deleteStoreCommandHandler;
        private readonly UpdateStoreCommandHandler _updateStoreCommandHandler;
        private readonly GetStoreQueryHandler _getStoreQueryHandler;

        public StoreController(CreateStoreCommandHandler createStoreCommandHandler, DeleteStoreCommandHandler deleteStoreCommandHandler, UpdateStoreCommandHandler updateStoreCommandHandler, GetStoreQueryHandler getStoreQueryHandler)
        {
            _createStoreCommandHandler = createStoreCommandHandler;
            _deleteStoreCommandHandler = deleteStoreCommandHandler;
            _updateStoreCommandHandler = updateStoreCommandHandler;
            _getStoreQueryHandler = getStoreQueryHandler;
        }

        [HttpPost]
        public IActionResult Post(CreateStoreCommand command)
        {
            return Ok(_createStoreCommandHandler.Handle(command));
        }

        [HttpDelete]
        public IActionResult Delete(DeleteStoreCommand command)
        {
            return Ok(_deleteStoreCommandHandler.Handle(command));
        }

        [HttpGet]
        public IActionResult Get(GetStoreQuery query)
        {
            return Ok(_getStoreQueryHandler.Handle(query));
        }

        [HttpPut]
        public IActionResult Put(UpdateStoreCommand command)
        {
            return Ok(_updateStoreCommandHandler.Handle(command));
        }
    }
}
