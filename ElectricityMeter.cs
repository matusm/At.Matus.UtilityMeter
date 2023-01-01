using System;

namespace At.Matus.UtilityMeter
{
    public class ElectricityMeter : BaseUtilityMeter
    {
        public ElectricityMeter(string meterID, DateTime timeStamp, double reading) : base(meterID, timeStamp, reading)
        {
            Unit = "kWh";
        }

        internal ElectricityMeter(BaseUtilityMeter meter) : this(meter.MeterID, meter.TimeStamp, meter.Reading)
        {
            Comment = meter.Comment;
        }

        public static ElectricityMeter Interpolate(DateTime time, ElectricityMeter first, ElectricityMeter second)
        {
            return (ElectricityMeter)BaseUtilityMeter.Interpolate(time, first, second);
        }

    }
}
