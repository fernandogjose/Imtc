using IMTC.CodeTest.Domain.Interfaces.InfraServices;

namespace IMTC.CodeTest.Infra.Services
{
    public class IndexProvider : IIndexProvider
    {
        private readonly SimulateDataInDb _simulateDataInDb;

        public IndexProvider()
        {
            _simulateDataInDb = new SimulateDataInDb();
        }

        public Task<int>? GetIndex(string indexCode, DateTime date)
        {
            var response = _simulateDataInDb.SimulateDatas.FirstOrDefault(x => x.IndexCode == indexCode && x.Date.Date == date);
            return response is null ? null : Task.FromResult(response.Index);
        }
    }

    public class SimulateDataInDb
    {
        public List<SimulateData> SimulateDatas = [
            new SimulateData(1, "USTR_CMT"),
            new SimulateData(2, "MuniAAA")
        ];
    }

    public class SimulateData(int index, string indexCode)
    {
        public int Index { get; private set; } = index;
        public string IndexCode { get; private set; } = indexCode;
        public DateTime Date { get; private set; } = DateTime.UtcNow;
    }
}
