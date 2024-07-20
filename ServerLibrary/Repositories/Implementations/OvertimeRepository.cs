using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;


namespace ServerLibrary.Repositories.Implementations
{
    public class OvertimeRepository : IGenericRepositoryInterface<Overtime>
    {
        private readonly AppDbContext _appDbContext;

        public OvertimeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await _appDbContext.Overtimes.FirstOrDefaultAsync(o => o.EmployeeId == id);
            if (item is null) return NotFound();

            _appDbContext.Overtimes.Remove(item);
            await Commit();
            return Success();
        }


        //public async Task<List<Overtime>> GetAll() => await _appDbContext
        //        .Overtimes
        //        .AsNoTracking().Include(o => o.OvertimeType)
        //        .ToListAsync();
        public async Task<List<Overtime>> GetAll()
        {
            return await _appDbContext.Overtimes
                .AsNoTracking()
                .Include(o => o.OvertimeType)
                .Select(o => new Overtime
                {
                    Id = o.Id,
                    EmployeeId = o.EmployeeId,
                    StartDate = o.StartDate,
                    EndDate = o.EndDate,
                    OvertimeType = o.OvertimeType,
                    OvertimeTypeId = o.OvertimeTypeId,
                    EmployeeName = _appDbContext.Employees.FirstOrDefault(u => u.Id == o.EmployeeId).Name,
                    EmployeeEmail = _appDbContext.Employees.FirstOrDefault(u => u.Id == o.EmployeeId).Email
                })
                .ToListAsync();
        }


        public async Task<List<Overtime>> GetByEmployeeEmail(string email)
        {
            return await _appDbContext.Overtimes
                .Where(o => _appDbContext.Employees.Any(e => e.Id == o.EmployeeId && e.Email == email))
                .Include(o => o.OvertimeType)
                .Select(o => new Overtime
                {
                    Id = o.Id,
                    EmployeeId = o.EmployeeId,
                    StartDate = o.StartDate,
                    EndDate = o.EndDate,
                    OvertimeType = o.OvertimeType,
                    OvertimeTypeId = o.OvertimeTypeId,
                    EmployeeName = _appDbContext.Employees.FirstOrDefault(u => u.Id == o.EmployeeId).Name,
                    EmployeeEmail = _appDbContext.Employees.FirstOrDefault(u => u.Id == o.EmployeeId).Email
                })
                .ToListAsync();
        }


        public async Task<GeneralResponse> Insert(Overtime item)
        {
            _appDbContext.Overtimes.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Overtime item)
        {
            var obj = await _appDbContext.Overtimes.FirstOrDefaultAsync(eid => eid.EmployeeId == item.EmployeeId);
            if (obj is null) return NotFound();
            obj.StartDate = item.StartDate;
            obj.EndDate = item.EndDate;
            obj.OvertimeTypeId = item.OvertimeTypeId;
            await Commit();
            return Success();
        }

        public async Task<Overtime> GetById(int id)
        {
            return await _appDbContext.Overtimes
                .Include(o => o.OvertimeType)
                .FirstOrDefaultAsync(o => o.EmployeeId == id);
        }

        private async Task Commit() => await _appDbContext.SaveChangesAsync();

        private static GeneralResponse NotFound() => new(false, "Sorry, data not found");
        private static GeneralResponse Success() => new(true, "Process completed");


       

    }
}
