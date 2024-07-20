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
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ServerLibrary.Repositories.Implementations
{
    public class DoctorRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Doctor>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.Doctors.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
            if (item is null) return NotFound();

            appDbContext.Doctors.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Insert(Doctor item)
        {
            appDbContext.Doctors.Add(item);
            await Commit();
            return Success();
        }
        public async Task<GeneralResponse> Update(Doctor item)
        {
            var obj = await appDbContext.Doctors
            .FirstOrDefaultAsync(eid => eid.EmployeeId == item.EmployeeId);
            if (obj is null) return NotFound();
            obj.MedicalRecommendation = item.MedicalRecommendation;
            obj.MedicalDiagnose = item.MedicalDiagnose;
            obj.Date = item.Date;
            await Commit();
            return Success();
        }

        //public async Task<List<Doctor>> GetAll() => await appDbContext
        //    .Doctors
        //    .AsNoTracking()
        //    .ToListAsync();
        public async Task<List<Doctor>> GetAll()
        {
            return await appDbContext.Doctors
                .AsNoTracking()
                
                .Select(o => new Doctor
                {
                    Id = o.Id,
                    EmployeeId = o.EmployeeId,
                    EmployeeName = appDbContext.Employees.FirstOrDefault(u => u.Id == o.EmployeeId).Name,
                    EmployeeEmail = appDbContext.Employees.FirstOrDefault(u => u.Id == o.EmployeeId).Email
                })
                .ToListAsync();
        }

        public async Task<Doctor> GetById(int id) =>
        await appDbContext.Doctors.FirstOrDefaultAsync(eid => eid.EmployeeId == id);

        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry data not found");
        private static GeneralResponse Success() => new(true, "Process completed");

        public Task<List<Doctor>> GetByEmployeeId(int employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Doctor>> GetByEmployeeEmail(string email)
        {
            return await appDbContext.Doctors
                .Where(o => appDbContext.Employees.Any(e => e.Id == o.EmployeeId && e.Email == email))
                .Select(o => new Doctor
                {
                    Id = o.Id,
                    EmployeeId = o.EmployeeId,
                    Date = o.Date,
                    MedicalDiagnose = o.MedicalDiagnose,
                    MedicalRecommendation = o.MedicalRecommendation,
                    EmployeeName = appDbContext.Employees.FirstOrDefault(u => u.Id == o.EmployeeId).Name,
                    EmployeeEmail = appDbContext.Employees.FirstOrDefault(u => u.Id == o.EmployeeId).Email
                })
                .ToListAsync();
        }
    }
}
