using IMTC.CodeTest.Domain.Dtos;

namespace IMTC.CodeTest.Domain.Interfaces.ApplicationServices
{
    public interface IYtwCalculatorService
    {
        Task<decimal?> CalculateYtwForBond(Bond bond);

        Task<decimal?> CalculateYtwForBond(Bond bond, DateTime settlementDate);
    }
}
