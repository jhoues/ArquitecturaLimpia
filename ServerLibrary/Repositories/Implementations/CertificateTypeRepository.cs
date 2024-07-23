using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;

namespace ServerLibrary.Repositories.Implementations
{
    public class CertificateTypeRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<CertificateType>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.CertificateTypes.FindAsync(id);
            if (item is null) return NotFound();

            appDbContext.CertificateTypes.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<CertificateType>> GetAll() => await appDbContext
            .CertificateTypes
            .AsNoTracking()
            .ToListAsync();
        

        public Task<List<CertificateType>> GetByEmployeeEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<CertificateType> GetById(int id) =>
        await appDbContext.CertificateTypes.FindAsync(id);

        public async Task<GeneralResponse> Insert(CertificateType item)
        {
            if (!await CheckName(item.Name!))
                return new GeneralResponse(false, "Overtime Type Already added");
            appDbContext.CertificateTypes.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(CertificateType item)
        {
            var obj = await appDbContext.CertificateTypes.FindAsync(item.Id);
            if (obj is null) return NotFound();
            obj.Name = item.Name;
            await Commit();
            return Success();
        }
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry data not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.CertificateTypes.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
