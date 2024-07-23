using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Services.Contracts
{
    public interface ICertificateService
    {
        Task<Certificate> RequestCertificate(CertificateRequestDTO request);
        Task<IEnumerable<CertificateResponseDTO>> GetPendingCertificates();
        Task<Certificate> AuthorizeCertificate(int id);
        Task<byte[]> DownloadCertificate(int id);
    }
}
