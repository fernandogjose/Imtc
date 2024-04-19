using IMTC.CodeTest.Domain.Dtos;

namespace IMTC.CodeTest.Domain.Interfaces.InfraServices
{
    public interface IImtcCalculator
    {
        decimal CalculateYtw(Bond bond, DateTime settlementDate, int index);
    }
}
