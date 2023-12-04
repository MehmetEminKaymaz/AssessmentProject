using AssessmentProject.Application.Invoice.Commands;
using AssessmentProject.Application.Invoice.Handler;
using AssessmentProject.Application.Invoice.Queries;
using AssessmentProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly CreateInvoiceCommandHandler _createInvoiceCommandHandler;
        private readonly DeleteInvoiceCommandHandler _deleteInvoiceCommandHandler;
        private readonly UpdateInvoiceCommandHandler _updateInvoiceCommandHandler;
        private readonly GetInvoiceQueryHandler _getInvoiceQueryHandler;

        public InvoicesController(CreateInvoiceCommandHandler createInvoiceCommandHandler, DeleteInvoiceCommandHandler deleteInvoiceCommandHandler, UpdateInvoiceCommandHandler updateInvoiceCommandHandler, GetInvoiceQueryHandler getInvoiceQueryHandler)
        {
            _createInvoiceCommandHandler = createInvoiceCommandHandler;
            _deleteInvoiceCommandHandler = deleteInvoiceCommandHandler;
            _updateInvoiceCommandHandler = updateInvoiceCommandHandler;
            _getInvoiceQueryHandler = getInvoiceQueryHandler;
        }

        [HttpPost]
        public IActionResult Post(CreateInvoiceCommand createInvoiceCommand)
        {
            return Ok(_createInvoiceCommandHandler.Handle(createInvoiceCommand));
        }

        [HttpDelete]
        public IActionResult Delete(DeleteInvoiceCommand command)
        {
            return Ok(_deleteInvoiceCommandHandler.Handle(command));
        }

        [HttpGet]
        public IActionResult Get(GetInvoice query)
        {
            return Ok(_getInvoiceQueryHandler.Handle(query));
        }

        [HttpPut]
        public IActionResult Put(UpdateInvoiceCommand command)
        {
            return Ok(_updateInvoiceCommandHandler.Handle(command));
        }

    }
}
