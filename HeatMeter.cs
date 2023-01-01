using System;

namespace At.Matus.UtilityMeter
{
    public class HeatMeter : BaseUtilityMeter
    {
        public HeatMeter(string meterID, DateTime timeStamp, double reading) : base(meterID, timeStamp, reading)
        {
            Unit = "MWh";
        }

        internal HeatMeter(BaseUtilityMeter meter) : this(meter.MeterID, meter.TimeStamp, meter.Reading)
        {
            Comment = meter.Comment;
        }

        public static HeatMeter Interpolate(DateTime time, HeatMeter first, HeatMeter second)
        {
            return (HeatMeter)BaseUtilityMeter.Interpolate(time, first, second);
        }

    }
}
