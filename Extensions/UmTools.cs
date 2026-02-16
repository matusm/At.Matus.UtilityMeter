using System.Collections.Generic;

namespace At.Matus.UtilityMeter
{
    public static class UmTools
    {
        public static int GetNumberOfMeters(this IUtilityMeter meter)
        {
            HashSet<string> meterIDs = new HashSet<string>();
            foreach (var reading in meter.Readings)
            {
                meterIDs.Add(reading.MeterID);
            }
            return meterIDs.Count;
        }
    }
}
