using WebApp.Domain.Entities;
using WebApp.Application.Interfaces.Repositories;
using WebApp.Infrastructure.Contexts;
using WebApp.Application.DTOs;

namespace WebApp.Infrastructure.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly AppDbContext _context;
        public TransactionsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<Transaction> transactions)
        {
            await _context.Transactions.AddRangeAsync(transactions);
        }

        public List<Transaction> GetByDate(GetTransactionsRequestDTO dto, DateTime P_TO_DATE, DateTime P_FROM_DATE)
        { 

            return _context.Transactions.AsEnumerable()
                                        .Where(c => P_FROM_DATE >= DateTime.Parse(c.INSTANCE_DATE) && DateTime.Parse(c.INSTANCE_DATE) <= P_TO_DATE)
                                        .Skip(int.Parse(dto.P_SKIP))
                                        .Take(int.Parse(dto.P_TAKE))
                                        .ToList();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
