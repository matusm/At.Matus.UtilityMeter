using System;

namespace At.Matus.UtilityMeter
{
    public interface IUtilityMeterReading : IComparable<IUtilityMeterReading>
    {
        DateTime TimeStamp { get; }
        double Reading { get; }
        string Unit { get; }
        string MeterID { get; }
        string Comment { get; }
        
        string GetCsvLine();
        bool IsSameMeter(IUtilityMeterReading other);
    }
}
