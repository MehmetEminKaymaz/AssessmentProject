using AssessmentProject.Application.Invoice.Commands;
using AssessmentProject.Data.Domain;
using AssessmentProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.Store.Commands;

namespace AssessmentProject.Application.Store.Handler
{
    public class UpdateStoreCommandHandler
    {
        private readonly DataContext _context;
        public UpdateStoreCommandHandler(DataContext context) => _context = context;

        public BaseResponseModel<UpdateStoreCommand> Handle(UpdateStoreCommand command)
        {
            var storeWillBeUpdate = _context.Stores.FirstOrDefault(s => s.Id == command.StoreId);

            if (storeWillBeUpdate == null)
            {
                return new BaseResponseModel<UpdateStoreCommand>()
                {
                    Status = false,
                };
            }

            storeWillBeUpdate.Name = command.Name;
            storeWillBeUpdate.IsGrocery = command.IsGrocery;


            return new BaseResponseModel<UpdateStoreCommand>()
            {
                Data = command,
                Status = true,
            };
        }
    }
}
