using IMTC.CodeTest.Domain.Dtos;
using IMTC.CodeTest.Domain.Interfaces.InfraServices;

namespace IMTC.CodeTest.Infra.Services
{
    public class ImtcCalculator : IImtcCalculator
    {
        public decimal CalculateYtw(Bond bond, DateTime settlementDate, int index)
        {
            // It is necessary to apply the rules in order to calculate and return the result
            return 10M;
        }
    }
}
