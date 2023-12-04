using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AssessmentProject.Data.Domain
{
    public class InvoiceRepository
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public decimal Cost { get; set; }
        public decimal FinalCost { get; set; }
        public required DateTimeOffset InvoiceDate { get; set; }
        public virtual ICollection<DiscountRepository>? AppliedDiscounts { get; set; }
        public Guid UserId { get; set; }
    }
}
