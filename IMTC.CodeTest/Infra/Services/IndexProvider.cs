using IMTC.CodeTest.Domain.Interfaces.InfraServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    public class SimulateData
    {
        public int Index { get; private set; }
        public string IndexCode { get; private set; }
        public DateTime Date { get; private set; }

        public SimulateData(int index, string indexCode)
        {
            Index = index;
            IndexCode = indexCode;
            Date = DateTime.UtcNow;
        }
    }
}
