using BaseLibrary.Responses;
using System.Collections.Generic;

namespace ClientLibrary.Services.Contracts
{
    public interface IGenericServiceInterface<T>
    {
        Task<List<T>> GetAll(string baseUrl);
        Task<T> GetById(int id, string baseUrl);
        Task<GeneralResponse> Insert(T item, string baseUrl);
        Task<GeneralResponse> UpDate(T item, string baseUrl);
        Task<GeneralResponse> DeleteById(int id, string baseUrl);
        Task<List<T>> GetByEmployeeEmail(string email, string baseUrl); // Nuevo método


    }
}
