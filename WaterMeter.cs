using System;

namespace At.Matus.UtilityMeter
{
    public class WaterMeter : BaseUtilityMeter
    {
        public WaterMeter(string meterID, DateTime timeStamp, double reading) : base(meterID, timeStamp, reading)
        {
            Unit = "m^3";
        }

        internal WaterMeter(BaseUtilityMeter meter) : this(meter.MeterID, meter.TimeStamp, meter.Reading)
        {
            Comment = meter.Comment;
        }

        public static WaterMeter Interpolate(DateTime time, WaterMeter first, WaterMeter second)
        {
            return (WaterMeter)BaseUtilityMeter.Interpolate(time, first, second);
        }

    }
}
