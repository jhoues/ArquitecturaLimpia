using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using ClientLibrary.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientLibrary.Services.Implementations
{
    public class CertificateService : ICertificateService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/certificates"; // Ajusta esto según tu configuración
        public CertificateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Certificate> AuthorizeCertificate(int id)
        {
            var response = await _httpClient.PutAsync($"{_baseUrl}/{id}/authorize", null);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Certificate>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<byte[]> DownloadCertificate(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{id}/download");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<IEnumerable<CertificateResponseDTO>> GetPendingCertificates()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/pending");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<CertificateResponseDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Certificate> RequestCertificate(CertificateRequestDTO request)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl, request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Certificate>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
