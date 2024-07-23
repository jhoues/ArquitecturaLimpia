using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTOs
{
    public class CertificateResponseDTO
    {
        public int Id { get; set; }
        public string? EmployeeName { get; set; }
        public string? CertificateTypeName { get; set; }
        public DateTime RequestDate { get; set; }
        public string? Status { get; set; }
    }
}
