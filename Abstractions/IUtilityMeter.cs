namespace At.Matus.UtilityMeter
{
    public interface IUtilityMeter
    {
        string Name { get; }
        IUtilityMeterReading[] Readings { get; }
        int NumberOfReadings { get; }
        void AddReading(IUtilityMeterReading reading);
    }
}
