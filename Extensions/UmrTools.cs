using System;

namespace At.Matus.UtilityMeter
{
    public static class UmrTools
    {
        public static string GetCsvLine(this IUtilityMeterReading first) => $"{first.TimeStamp.ToString("dd-MM-yyyy HH:mm")};{first.Reading},{first.Unit},{first.MeterID};{first.Comment}";

        public static int CompareTo(this IUtilityMeterReading first, IUtilityMeterReading other) => first.TimeStamp.CompareTo(other.TimeStamp);

        public static bool IsSameMeter(this IUtilityMeterReading first, IUtilityMeterReading other)
        {
            if (!IsSameType(first, other))
                return false;
            return string.Equals(other.MeterID, first.MeterID, StringComparison.InvariantCultureIgnoreCase); //TODO probably case should matter
        }

        public static bool IsSameType(this IUtilityMeterReading first, IUtilityMeterReading other) => other.GetType() == first.GetType();

    }
}

