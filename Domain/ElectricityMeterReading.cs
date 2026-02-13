using System;

namespace At.Matus.UtilityMeter
{
    public class ElectricityMeterReading : IUtilityMeterReading
    {
        public DateTime TimeStamp { get; }
        public double Reading { get; }
        public string Unit { get; }
        public string MeterID { get; }
        public string Comment { get; }

        DateTime IUtilityMeterReading.TimeStamp => throw new NotImplementedException();

        double IUtilityMeterReading.Reading => throw new NotImplementedException();

        string IUtilityMeterReading.Unit => throw new NotImplementedException();

        string IUtilityMeterReading.MeterID => throw new NotImplementedException();

        string IUtilityMeterReading.Comment => throw new NotImplementedException();

        public ElectricityMeterReading(DateTime timeStamp, double reading, string meterID) : this(timeStamp, reading, meterID, string.Empty){}

        public ElectricityMeterReading(DateTime timeStamp, double reading, string meterID, string comment)
        {
            Unit = "kWh";
            TimeStamp = timeStamp;
            Reading = reading;
            MeterID = meterID.Trim();
            Comment = comment.Trim();
        }

        public string GetCsvLine() => $"{TimeStamp.ToString("dd-MM-yyyy HH:mm")};{Reading};{Unit},{MeterID};{Comment}";

        public int CompareTo(IUtilityMeterReading other) => TimeStamp.CompareTo(other.TimeStamp);

        public bool IsSameMeter(IUtilityMeterReading other)
        {
            return string.Equals(other.MeterID, MeterID, StringComparison.InvariantCultureIgnoreCase); //TODO probably case should matter
        }
    }
}
