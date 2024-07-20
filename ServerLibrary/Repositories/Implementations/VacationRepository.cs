using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Implementations
{
    public class VacationRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Vacation>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.Vacations.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
            if (item is null) return NotFound();

            appDbContext.Vacations.Remove(item);
            await Commit();
            return Success();
        }
        public async Task<GeneralResponse> Insert(Vacation item)
        {
            appDbContext.Vacations.Add(item);
            await Commit();
            return Success();
        }
        public async Task<GeneralResponse> Update(Vacation item)
        {
            var obj = await appDbContext.Vacations
            .FirstOrDefaultAsync(eid => eid.EmployeeId == item.EmployeeId);
            if (obj is null) return NotFound();
            obj.StartDate = item.StartDate;
            obj.NumberOfDays = item.NumberOfDays;
            obj.VacationTypeId = item.VacationTypeId;
            await Commit();
            return Success();
        }

        //public async Task<List<Vacation>> GetAll() => await appDbContext
        //    .Vacations
        //    .AsNoTracking().Include(t=>t.VacationType)
        //    .ToListAsync();

        public async Task<List<Vacation>> GetAll()
        {
            return await appDbContext.Vacations
                .AsNoTracking()
                .Include(o => o.VacationType)
                .Select(o => new Vacation
                {
                    Id = o.Id,
                    EmployeeId = o.EmployeeId,
                    StartDate = o.StartDate,
                    NumberOfDays = o.NumberOfDays,
                    VacationType = o.VacationType,
                    VacationTypeId = o.VacationTypeId,
                    EmployeeName = appDbContext.Employees.FirstOrDefault(u => u.Id == o.EmployeeId).Name,
                    EmployeeEmail = appDbContext.Employees.FirstOrDefault(u => u.Id == o.EmployeeId).Email
                })
                .ToListAsync();
        }

        public async Task<Vacation> GetById(int id) =>
        await appDbContext.Vacations.FirstOrDefaultAsync(eid => eid.EmployeeId == id);

        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry data not found");
        private static GeneralResponse Success() => new(true, "Process completed");

        
       
        public async Task<List<Vacation>> GetByEmployeeEmail(string email)
        {
            return await appDbContext.Vacations
                .Where(o => appDbContext.Employees.Any(e => e.Id == o.EmployeeId && e.Email == email))
                .Include(o => o.VacationType)
                .Select(o => new Vacation
                {
                    Id = o.Id,
                    EmployeeId = o.EmployeeId,
                    StartDate = o.StartDate,
                    EndDate = o.EndDate,
                    VacationType = o.VacationType,
                    VacationTypeId = o.VacationTypeId,
                    EmployeeName = appDbContext.Employees.FirstOrDefault(u => u.Id == o.EmployeeId).Name,
                    EmployeeEmail = appDbContext.Employees.FirstOrDefault(u => u.Id == o.EmployeeId).Email
                })
                .ToListAsync();
        }
    }
}
