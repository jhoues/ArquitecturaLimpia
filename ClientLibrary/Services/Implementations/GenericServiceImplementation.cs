using BaseLibrary.Responses;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Services.Implementations
{
    public class GenericServiceImplementation<T>(GetHttpClient getHttpClient) : IGenericServiceInterface<T>
    {
        
        public async Task<GeneralResponse> Insert(T item, string baseUrl)
        {
            try
            {
                var httpClient = await getHttpClient.GetPrivateHttpClient();
                var response = await httpClient.PostAsJsonAsync($"{baseUrl}/add", item);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
                return result!;
            }
            catch (Exception ex)
            {
                // Manejar excepciones y registrar errores
                return new GeneralResponse(false, ex.Message);
            }
        }

        //read all
        public async Task<List<T>> GetAll(string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var results = await httpClient.GetFromJsonAsync<List<T>>($"{baseUrl}/all");
            return results!;
        }
        //Read Single {id}
        public async Task<T> GetById(int id, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var result = await httpClient.GetFromJsonAsync<T>($"{baseUrl}/single/{id}");
            return result!;
        }

        public async Task<GeneralResponse> DeleteById(int id, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.DeleteAsync($"{baseUrl}/delete/{id}");
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }

        public async Task<GeneralResponse> UpDate(T item, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.PutAsJsonAsync($"{baseUrl}/update", item);
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }

        public async Task<List<T>> GetByEmployeeId(int employeeId, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var results = await httpClient.GetFromJsonAsync<List<T>>($"{baseUrl}/employee/{employeeId}");
            return results!;
        }

        // Nuevo método para obtener horas extras por correo electrónico del empleado
        public async Task<List<T>> GetByEmployeeEmail(string email, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var results = await httpClient.GetFromJsonAsync<List<T>>($"{baseUrl}/employee/{email}");
            return results!;
        }

    }
}
