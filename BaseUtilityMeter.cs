using System;

namespace At.Matus.UtilityMeter
{
    public class BaseUtilityMeter : IComparable<BaseUtilityMeter>
    {
        //protected string comment;

        public DateTime TimeStamp { get; protected set; }
        public double Reading { get; protected set; }
        public string Unit { get; protected set; }
        public string MeterID { get; protected set; }
        public string Comment { get; protected set; }

        internal BaseUtilityMeter(string meterID, DateTime timeStamp, double reading)
        {
            MeterID = meterID.Trim();
            TimeStamp = timeStamp;
            Reading = reading;
            Unit = "a.u.";
            Comment = string.Empty;
        }

        protected static BaseUtilityMeter Interpolate(DateTime time,  BaseUtilityMeter first, BaseUtilityMeter second )
        {
            if (!first.IsSameMeter(second))
                return null;
            double y0 = first.Reading;
            double y1 = second.Reading;
            DateTimeOffset t0 = new DateTimeOffset(first.TimeStamp);
            DateTimeOffset t1 = new DateTimeOffset(second.TimeStamp);
            DateTimeOffset t = new DateTimeOffset(time);
            double interval = (t - t0).TotalSeconds;
            double fullInterval = (t1 - t0).TotalSeconds;
            double y = y0 + (interval * (y1 - y0) / fullInterval);

            BaseUtilityMeter meter = new BaseUtilityMeter(first.MeterID, time, y);
            meter.Comment = $"interpolated value [{first.TimeStamp.ToString("dd-MM-yyyy")} {second.TimeStamp.ToString("dd-MM-yyyy")}]";
            // this is clumsy!
            if (first is WaterMeter)
            {
                meter = new WaterMeter(meter);
            }
            if (first is HeatMeter)
            {
                meter = new HeatMeter(meter);
            }
            if (first is ElectricityMeter)
            {
                meter = new ElectricityMeter(meter);
            }
            return meter;
        }

        public bool IsSameType(BaseUtilityMeter other)
        {
            if (other.GetType() == this.GetType())
                return true;
            return false;
        }

        public bool IsSameMeter(BaseUtilityMeter other)
        {
            if (!IsSameType(other))
                return false;
            return string.Equals(other.MeterID, this.MeterID, StringComparison.InvariantCultureIgnoreCase); //TODO probably case should matter
        }

        public override string ToString()
        {
            return $"[{GetType().Name}: TimeStamp={TimeStamp}, Reading={Reading}, Unit={Unit}, ID={MeterID}, Comment={Comment}]";
        }

        public int CompareTo(BaseUtilityMeter other)
        {
            return TimeStamp.CompareTo(other.TimeStamp);
        }
    }
}
