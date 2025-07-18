using WebApp.Application.DTOs;
using WebApp.Domain.Entities;

namespace WebApp.Application.Interfaces.Repositories
{
    public interface ITransactionsRepository
    {
        public Task AddRangeAsync(List<Transaction> transactions);
        public Task CommitAsync();
        public List<Transaction> GetByDate(GetTransactionsRequestDTO dto, DateTime P_TO_DATE, DateTime P_FROM_DATE);
    }
}
