using IMTC.CodeTest.Domain.Dtos;

namespace IMTC.CodeTest.Domain.Interfaces.InfraServices
{
    public interface IIndexProvider
    {
        Task<int> GetIndex(string indexCode, DateTime date);
    }
}
