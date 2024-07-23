using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class CertificateRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Certificate>, ICertificateRepository
    {
        public async Task<Certificate> AuthorizeCertificate(int id, int authorizedById)
        {
            var certificate = await appDbContext.Certificates.FindAsync(id);
            if (certificate != null)
            {
                certificate.Status = "Autorizado";
                certificate.AuthorizationDate = DateTime.Now;
                certificate.AuthorizedById = authorizedById;
                await appDbContext.SaveChangesAsync();
            }
            return certificate!;
        }

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var certificate = await appDbContext.Certificates.FindAsync(id);
            if (certificate == null)
            {
                return new GeneralResponse(false, "Certificate not found.");
            }

            appDbContext.Certificates.Remove(certificate);
            await appDbContext.SaveChangesAsync();
            return new GeneralResponse(true, "Certificate deleted successfully.");
        }

        public async Task<List<Certificate>> GetAll()
        {
            return await appDbContext.Certificates
                 .Include(c => c.EmployeeId)
                 .Include(c => c.CertificateTypeId)
                 .ToListAsync();
        }

        public Task<List<Certificate>> GetByEmployeeEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Certificate> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Certificate>> GetPendingCertificates()
        {
            return await appDbContext.Certificates.Where(c => c.Status == "Pendiente").ToListAsync();
        }

        public Task<GeneralResponse> Insert(Certificate item)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse> Update(Certificate item)
        {
            throw new NotImplementedException();
        }
    }
}
