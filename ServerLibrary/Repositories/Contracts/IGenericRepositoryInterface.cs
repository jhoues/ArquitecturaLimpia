using BaseLibrary.Responses;

public interface IGenericRepositoryInterface<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task<GeneralResponse> Insert(T item);
    Task<GeneralResponse> Update(T item);
    Task<GeneralResponse> DeleteById(int id);
    Task<List<T>> GetByEmployeeEmail(string email); // Nuevo método
}
