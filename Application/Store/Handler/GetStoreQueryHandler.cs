using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Application.Store.Queries;

namespace AssessmentProject.Application.Store.Handler
{
    public class GetStoreQueryHandler
    {
        private readonly DataContext _context;
        public GetStoreQueryHandler(DataContext context) => _context = context;

        public BaseResponseModel<CreateStoreCommand> Handle(GetStoreQuery command)
        {
            var store = _context.Stores.FirstOrDefault(s => s.Id == command.StoreId);
            if (store == null)
            {
                return new BaseResponseModel<CreateStoreCommand>()
                {
                    Status = false,
                };
            }
            _context.Dispose();

            return new BaseResponseModel<CreateStoreCommand>()
            {
                Status = true,
                Data = new CreateStoreCommand()
                {
                    IsGrocery = store.IsGrocery,
                    Name = store.Name,
                    StoreId = store.Id
                },
            };
        }
    }
}
