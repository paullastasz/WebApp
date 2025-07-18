using FluentResults;
using System.Net.Http.Json;
using WebApp.Application.DTOs;
using WebApp.Application.Interfaces.Clients;
using WebApp.Domain.Entities;
using WebApp.Infrastructure.DubailandDTOs;

namespace WebApp.Infrastructure.Clients
{
    public class DubailandExternalApiClient : IDubailandExternalApiClient
    {
        private readonly HttpClient _client;
        public DubailandExternalApiClient(HttpClient httpClient)
        {
            _client = httpClient;
        }
        public async Task<Result<List<Transaction>>> GetTransactionsFromLast3Months(GetTransactionsRequestDTO dto)
        {
            var response = await _client.PostAsJsonAsync("transactions", dto);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<TransactionsDTO>();

                if (content is not null && content.responseCode == 200)
                {
                    return Result.Ok(content.response.result);
                }
                else
                    return Result.Fail($"DubailandClient Error: data error.");
            }

            return Result.Fail($"DubailandClient Error:\nStatus code: {response.StatusCode}\nReason: {response.ReasonPhrase}");
        }
    }
}
