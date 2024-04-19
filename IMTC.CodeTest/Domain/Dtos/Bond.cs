using IMTC.CodeTest.Domain.Enums;

namespace IMTC.CodeTest.Domain.Dtos
{
    public class Bond
    {
        public CouponType CouponType { get; private set; }
        public BondType BondType { get; private set; }

        public Bond(CouponType couponType, BondType bondType)
        {
            CouponType = couponType;
            BondType = bondType;
        }
    }
}
