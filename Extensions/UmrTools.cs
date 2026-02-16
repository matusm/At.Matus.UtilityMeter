using System;

namespace At.Matus.UtilityMeter
{
    public static class UmrTools
    {
        public static string GetDescription(this IUtilityMeterReading first) => $"[{first.GetType().Name}: {first.TimeStamp.ToString("dd-MM-yyyy HH:mm")} {first.Reading} {first.UnitSymbol} MeterID: {first.MeterID} {first.Comment}]";

        public static string GetCsvHeader(this IUtilityMeterReading first) => $"TimeStamp;Reading,UnitSymbol,MeterID;Comment";

        public static string GetCsvLine(this IUtilityMeterReading first) => $"{first.TimeStamp.ToString("dd-MM-yyyy HH:mm")};{first.Reading},{first.UnitSymbol},{first.MeterID};{first.Comment}";

        public static bool IsTheSameMeter(this IUtilityMeterReading first, IUtilityMeterReading other)
        {
            if (!IsOfSameTypeAs(first, other))
                return false;
            //TODO probably case should matter
            //TODO should we also compare unit symbol?
            return string.Equals(other.MeterID, first.MeterID, StringComparison.InvariantCultureIgnoreCase); 
        }

        public static bool IsOfSameTypeAs(this IUtilityMeterReading first, IUtilityMeterReading other) => other.GetType() == first.GetType();

        public static int CompareToBase(this IUtilityMeterReading first, IUtilityMeterReading other) => first.TimeStamp.CompareTo(other.TimeStamp);

        public static IUtilityMeterReading Interpolate(DateTime time, IUtilityMeterReading first, IUtilityMeterReading second)
        {
            if (!first.IsTheSameMeter(second))
                return null;
            double y0 = first.Reading;
            double y1 = second.Reading;
            DateTimeOffset t0 = new DateTimeOffset(first.TimeStamp);
            DateTimeOffset t1 = new DateTimeOffset(second.TimeStamp);
            DateTimeOffset t = new DateTimeOffset(time);
            double interval = (t - t0).TotalSeconds;
            double fullInterval = (t1 - t0).TotalSeconds;
            double y = y0 + (interval * (y1 - y0) / fullInterval);

            IUtilityMeterReading meter = null;
            var comment = $"interpolated value [{first.TimeStamp.ToString("dd-MM-yyyy")} {second.TimeStamp.ToString("dd-MM-yyyy")}]";
            // this is clumsy!
            if (first is WaterMeterReading)
            {
                meter = new WaterMeterReading(time, y, first.MeterID, comment);
            }
            if (first is HeatMeterReading)
            {
                meter = new HeatMeterReading(time, y, first.MeterID, comment);
            }
            if (first is ElectricityMeterReading)
            {
                meter = new ElectricityMeterReading(time, y, first.MeterID, comment);
            }
            return meter;
        }

    }
}

