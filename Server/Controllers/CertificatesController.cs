using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;
using System.Security.Claims;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private readonly ICertificateRepository _certificateRepository;
        public CertificatesController(ICertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }
        [HttpPost]
        [Authorize(Roles = "Empleado")]
        public async Task<IActionResult> RequestCertificate(CertificateRequestDTO request)
        {
            var certificate = new Certificate
            {
                EmployeeId = request.EmployeeId,
                CertificateTypeId = request.CertificateTypeId,
                RequestDate = DateTime.Now,
                Status = "Pendiente"
            };

            await _certificateRepository.Insert(certificate);
            return Ok(certificate);
        }
        [HttpGet("pending")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetPendingCertificates()
        {
            var certificates = await _certificateRepository.GetPendingCertificates();
            return Ok(certificates);
        }
        [HttpPut("{id}/authorize")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> AuthorizeCertificate(int id)
        {
            var adminId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var certificate = await _certificateRepository.AuthorizeCertificate(id, adminId);
            if (certificate == null)
                return NotFound();
            return Ok(certificate);
        }
        [HttpGet("{id}/download")]
        [Authorize(Roles = "Empleado")]
        public async Task<IActionResult> DownloadCertificate(int id)
        {
            var certificate = await _certificateRepository.GetById(id);
            if (certificate == null || certificate.Status != "Listo")
                return NotFound();

            // Aquí iría la lógica para generar el PDF
            var pdfContent = GeneratePdfContent(certificate);
            return File(pdfContent, "application/pdf", $"Certificado_{id}.pdf");
        }
        private byte[] GeneratePdfContent(Certificate certificate)
        {
            // Implementa la lógica para generar el PDF aquí
            // Puedes usar librerías como iTextSharp o PdfSharp
            throw new NotImplementedException();
        }
    }
}
