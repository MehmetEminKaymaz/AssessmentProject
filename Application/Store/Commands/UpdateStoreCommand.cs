using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.Application.Store.Commands
{
    public class UpdateStoreCommand
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public bool IsGrocery { get; set; }
    }
}
