using System;

namespace At.Matus.UtilityMeter
{
    public interface IUtilityMeterReading : IComparable<IUtilityMeterReading>
    {
        DateTime TimeStamp { get; }
        double Reading { get; }
        string UnitSymbol { get; }
        string MeterID { get; }
        string Comment { get; }
    }
}
