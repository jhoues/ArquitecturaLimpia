using BaseLibrary.Entities;
using BaseLibrary.Responses;
using BaseLibrary.DTOs;


namespace ServerLibrary.Repositories.Contracts
{
    public interface ICertificateRepository: IGenericRepositoryInterface<Certificate>
    {
        Task<IEnumerable<Certificate>> GetPendingCertificates();
        Task<Certificate> AuthorizeCertificate(int id, int authorizedById);
    }
}
