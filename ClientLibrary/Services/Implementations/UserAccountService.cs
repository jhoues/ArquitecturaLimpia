﻿using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Responses;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClientLibrary.Services.Implementations
{
    public class UserAccountService(GetHttpClient getHttpClient) : IUserAccountService
    {
        public const string AuthUrl = "api/authentication";
        public async Task<GeneralResponse> CreateAsync(Register user)
        {
            var httpClient = getHttpClient.GetPublicHttpClient();
            var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/register", user);
            if (!result.IsSuccessStatusCode) return new GeneralResponse(false, "Error ocurred");

            return await result.Content.ReadFromJsonAsync<GeneralResponse>()!;

        }

        public async Task<LoginResponse> SignInAsync(Login user)
        {
            var httpClient = getHttpClient.GetPublicHttpClient();
            var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/login", user);
            if (!result.IsSuccessStatusCode) return new LoginResponse(false, "Error ocurred");

            return await result.Content.ReadFromJsonAsync<LoginResponse>()!;
        }

        public async Task<LoginResponse> RefreshTokenAsync(RefreshToken token)
        {
            var httpClient = getHttpClient.GetPublicHttpClient();
            var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/refresh-token", token);
            if (!result.IsSuccessStatusCode) return new LoginResponse(false, "Error ocurred");

            return await result.Content.ReadFromJsonAsync<LoginResponse>()!;
        }


        public async Task<List<ManageUser>> GetUsers()
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var result = await httpClient.GetFromJsonAsync<List<ManageUser>>($"{AuthUrl}/users");
            return result!;
        }

        public async Task<GeneralResponse> UpdateUser(ManageUser user)
        {
            var httpClient = getHttpClient.GetPublicHttpClient();
            var result = await httpClient.PutAsJsonAsync($"{AuthUrl}/update-user", user);
            if (!result.IsSuccessStatusCode) return new GeneralResponse(false, "Error ocurred");

            return await result.Content.ReadFromJsonAsync<GeneralResponse>()!;
        }

        public async Task<List<SystemRole>> GetRoles()
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var result = await httpClient.GetFromJsonAsync<List<SystemRole>>($"{AuthUrl}/roles");
            return result!;
        }

        public async Task<GeneralResponse> DeleteUser(int id)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var result = await httpClient.DeleteAsync($"{AuthUrl}/delete-user/{id}");
            if (!result.IsSuccessStatusCode) return new GeneralResponse(false, "Error ocurred");

            return await result.Content.ReadFromJsonAsync<GeneralResponse>()!;
        }
        public async Task<string> GetPlainPassword(string email)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.GetFromJsonAsync<string>($"{AuthUrl}/get-plain-password?email={email}");
            return response!;
        }

        public async Task<GeneralResponse> ChangePassword(ChangePasswordRequest request)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var result = await httpClient.PutAsJsonAsync($"{AuthUrl}/change-password", request);
            if (!result.IsSuccessStatusCode) return new GeneralResponse(false, "Error occurred");

            return await result.Content.ReadFromJsonAsync<GeneralResponse>()!;
        }


    }
}
