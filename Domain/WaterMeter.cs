using System;
using System.Collections.Generic;

namespace At.Matus.UtilityMeter
{
    public class WaterMeter : IUtilityMeter
    {
        private readonly List<IUtilityMeterReading> _readings = new List<IUtilityMeterReading>();
        private readonly WaterMeterReading _dummyReading = new WaterMeterReading(DateTime.Now, 0, string.Empty);

        public string Name { get; }
        public IUtilityMeterReading[] Readings => _readings.ToArray();
        public int NumberOfReadings => _readings.Count;

        public WaterMeter(string name)
        {
            Name = name.Trim();
        }

        public void AddReading(IUtilityMeterReading reading)
        {
            if (reading == null) return;
            if (reading.IsOfSameTypeAs(_dummyReading))
            {
                _readings.Add(reading);
                _readings.Sort();
            }
        }

    }
}
