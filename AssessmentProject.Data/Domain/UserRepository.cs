using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.Data.Domain
{
    public class UserRepository
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public required bool IsEmployee { get; set; }
        public required bool IsAffiliate { get; set; }
        public virtual ICollection<InvoiceRepository>? Invoices { get; set; }
        public required StoreRepository Store { get; set; }
    }
}
