using FluentResults;
using WebApp.Application.DTOs;
using WebApp.Domain.Entities;

namespace WebApp.Application.Interfaces.Services
{
    public interface ITransactionsService
    {
        public Task<Result<List<Transaction>>> GetFromLast3Months(GetTransactionsRequestDTO dto);
    }
}
