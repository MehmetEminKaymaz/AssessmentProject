using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Data.Domain;
using AssessmentProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.Application.Store.Handler
{
    public class DeleteStoreCommandHandler
    {
        private readonly DataContext _context;
        public DeleteStoreCommandHandler(DataContext context) => _context = context;

        public BaseResponseModel<DeleteStoreCommand> Handle(DeleteStoreCommand command)
        {
            var storeWillBeDelete = _context.Stores.FirstOrDefault(s => s.Id == command.StoreId);
            if (storeWillBeDelete == null)
            {
                return new BaseResponseModel<DeleteStoreCommand>()
                {
                    Status = false,
                };
            }

            _context.Remove(storeWillBeDelete);
            _context.SaveChanges();

            return new BaseResponseModel<DeleteStoreCommand>()
            {
                Status = true,
                Data = command,
            };
        }
    }
}
