using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CertificateTypeController : GenericController<CertificateType>
{
    public CertificateTypeController(IGenericRepositoryInterface<CertificateType> genericRepositoryInterface)
        : base(genericRepositoryInterface)
    {
    }
}