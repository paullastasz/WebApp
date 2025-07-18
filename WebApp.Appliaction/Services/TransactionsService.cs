using WebApp.Application.Interfaces.Clients;
using WebApp.Application.Interfaces.Repositories;
using WebApp.Application.Interfaces.Services;
using WebApp.Domain.Entities;
using FluentResults;
using System.Globalization;
using WebApp.Application.DTOs;

namespace WebApp.Application.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IDubailandExternalApiClient _dubailandClient;

        public TransactionsService(ITransactionsRepository transactionsRepository, IDubailandExternalApiClient dubailandClient)
        {
            _transactionsRepository = transactionsRepository;
            _dubailandClient = dubailandClient;
        }
        public async Task<Result<List<Transaction>>> GetFromLast3Months(GetTransactionsRequestDTO dto)
        {
            DateTime P_TO_DATE = DateOnly.FromDateTime(DateTime.UtcNow).ToDateTime(TimeOnly.MaxValue, DateTimeKind.Unspecified);
            DateTime P_FROM_DATE = P_TO_DATE.AddMonths(-3);

            var transactions =  _transactionsRepository.GetByDate(dto, P_TO_DATE, P_FROM_DATE);

            if (!transactions.Any())
            {
                dto.P_TO_DATE = P_TO_DATE.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                dto.P_FROM_DATE = P_FROM_DATE.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                var result = await _dubailandClient.GetTransactionsFromLast3Months(dto);

                if (result.IsSuccess && result.Value.Any())
                {
                    try
                    {
                        await _transactionsRepository.AddRangeAsync(result.Value);
                        await _transactionsRepository.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        Result.Fail($"TransactionsService Error: {ex.Message}");
                    }

                    return result;
                }
                else
                    return result;
            }

            return Result.Ok(transactions);
        }
    }
}
