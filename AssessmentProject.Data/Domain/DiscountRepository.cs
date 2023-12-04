using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.Data.Domain
{
    public class DiscountRepository
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsPercentageBased { get; set; }
        public decimal AppliedDiscountValue { get; set; }
        public string? Description { get; set; }
        public InvoiceRepository? Invoice { get; set; }
    }
}
