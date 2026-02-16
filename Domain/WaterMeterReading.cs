using System;

namespace At.Matus.UtilityMeter
{
    internal class WaterMeterReading : IUtilityMeterReading
    {
        public DateTime TimeStamp { get; }
        public double Reading { get; }
        public string UnitSymbol { get; } = "m^3";
        public string MeterID { get; }
        public string Comment { get; }

        public WaterMeterReading(DateTime timeStamp, double reading, string meterID) : this(timeStamp, reading, meterID, string.Empty) { }

        public WaterMeterReading(DateTime timeStamp, double reading, string meterID, string comment)
        {
            TimeStamp = timeStamp;
            Reading = reading;
            MeterID = meterID.Trim();
            Comment = comment.Trim();
        }

        public int CompareTo(IUtilityMeterReading other) => this.CompareToBase(other);

        public override string ToString() => this.GetDescription();
    }
}
