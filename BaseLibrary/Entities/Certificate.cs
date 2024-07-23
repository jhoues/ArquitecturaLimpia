using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Certificate
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public CertificateType? CertificateType { get; set; }
        public int CertificateTypeId { get; set; }
        public DateTime RequestDate { get; set; }
        public string? Status { get; set; } // Pendiente, Autorizado, Listo
        public DateTime? AuthorizationDate { get; set; }
        public int? AuthorizedById { get; set; }
    }
}
