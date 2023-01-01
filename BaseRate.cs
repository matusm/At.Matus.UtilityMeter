using System;

namespace At.Matus.UtilityMeter
{
    public class BaseRate : IComparable<BaseRate>
    {
        private const string invalidBaseRate = "invalid";

        protected string comment;

        public DateTime TimeStamp { get; protected set; }
        public double Rate { get; protected set; }
        public string Unit { get; protected set; }
        public string MeterID { get; protected set; }
        public string Comment { get { return comment; } set { comment = value.Trim(); } }

        public BaseRate(string meterID, DateTime timeStamp, double rate)
        {
            MeterID = meterID;
            TimeStamp = timeStamp;
            Rate = rate;
            Unit = "a.u./s";
            comment = string.Empty;
        }

        public BaseRate(BaseUtilityMeter first, BaseUtilityMeter second)
        {
            if (first.IsSameMeter(second))
            {
                double y0 = first.Reading;
                double y1 = second.Reading;
                DateTimeOffset t0 = new DateTimeOffset(first.TimeStamp);
                DateTimeOffset t1 = new DateTimeOffset(second.TimeStamp);
                TimeSpan ts = t1 - t0;
                double interval = ts.TotalSeconds;
                long midPoint = ts.Ticks / 2;
                MeterID = first.MeterID;
                TimeStamp = first.TimeStamp + new TimeSpan(midPoint);
                Rate = (y1 - y0) / interval;
                Unit = $"{first.Unit}/s";
                comment = $"";
            }
            else
            {
                MeterID = invalidBaseRate;
                TimeStamp = first.TimeStamp;
                Rate = double.NaN;
                Unit = invalidBaseRate;
                comment = invalidBaseRate;
            }

        }

        public bool IsSameType(BaseRate other)
        {
            if (other.GetType() == this.GetType())
                return true;
            return false;
        }

        public bool IsSameMeter(BaseRate other)
        {
            if (!IsSameType(other))
                return false;
            return string.Equals(other.MeterID, this.MeterID, StringComparison.InvariantCultureIgnoreCase); // probably case should matter
        }

        public override string ToString()
        {
            return $"[{GetType().Name}: TimeStamp={TimeStamp}, Rate={Rate}, Unit={Unit}, ID={MeterID}, Comment={Comment}]";
        }

        public int CompareTo(BaseRate other)
        {
            return TimeStamp.CompareTo(other.TimeStamp);
        }
    }
}
