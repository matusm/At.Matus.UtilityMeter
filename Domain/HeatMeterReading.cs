using System;

namespace At.Matus.UtilityMeter
{
    public class HeatMeterReading : IUtilityMeterReading
    {
        public DateTime TimeStamp { get; }
        public double Reading { get; }
        public string Unit { get; } = "MWh";
        public string MeterID { get; }
        public string Comment { get; }

        public HeatMeterReading(DateTime timeStamp, double reading, string meterID) : this(timeStamp, reading, meterID, string.Empty) { }

        public HeatMeterReading(DateTime timeStamp, double reading, string meterID, string comment)
        {
            TimeStamp = timeStamp;
            Reading = reading;
            MeterID = meterID.Trim();
            Comment = comment.Trim();
        }

        public string GetCsvLine() => this.GetCsvLine();

        public int CompareTo(IUtilityMeterReading other) => this.CompareTo(other);

        public bool IsSameMeter(IUtilityMeterReading other) => this.IsSameMeter(other);

    }
}
