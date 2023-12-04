using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.Application.User.Commands
{
    public class UpdateUserCommand
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public required bool IsEmployee { get; set; }
        public required bool IsAffiliate { get; set; }
    }
}
