using BaseLibrary.Entities;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    public class BranchController(IGenericRepositoryInterface<Branch> genericRepositoryInterface)
        : GenericController<Branch>(genericRepositoryInterface)
    {
    }
}
