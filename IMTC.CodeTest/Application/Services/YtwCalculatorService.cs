using IMTC.CodeTest.Domain.Dtos;
using IMTC.CodeTest.Domain.Enums;
using IMTC.CodeTest.Domain.Interfaces.ApplicationServices;
using IMTC.CodeTest.Domain.Interfaces.InfraServices;

namespace IMTC.CodeTest.Application.Services
{
    public class YtwCalculatorService : IYtwCalculatorService
    {
        private readonly IImtcCalculator _calculator;
        private readonly IIndexProvider _indexProvider;

        public YtwCalculatorService(IImtcCalculator calculator, IIndexProvider indexProvider)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
            _indexProvider = indexProvider ?? throw new ArgumentNullException(nameof(calculator));
        }

        public async Task<decimal?> CalculateYtwForBond(Bond bond)
        {
            var settlementDate = DateTime.UtcNow.Date;
            return await CalculateYtwForBond(bond, settlementDate);
        }

        public async Task<decimal?> CalculateYtwForBond(Bond bond, DateTime settlementDate)
        {
            ArgumentNullException.ThrowIfNull(bond);

            var indexCode = bond switch
            {
                Bond b when b.CouponType == CouponType.Variable => IndexNames.USTR_CMT,
                Bond b when b.BondType == BondType.Municipal => IndexNames.MuniAAA,
                _ => IndexNames.USTR_CMT
            };

            var index = await _indexProvider.GetIndex(indexCode, settlementDate);
            ArgumentNullException.ThrowIfNull(index);

            return _calculator.CalculateYtw(bond, settlementDate, index);
        }
    }
}