using FluentResults;
using WebApp.Application.DTOs;
using WebApp.Domain.Entities;

namespace WebApp.Application.Interfaces.Clients
{
    public interface IDubailandExternalApiClient
    {
        public Task<Result<List<Transaction>>> GetTransactionsFromLast3Months(GetTransactionsRequestDTO dto);
    }
}
