using System;

namespace Measurement
{
    public interface IMeasurementService
    {
        event Action<float> ReadyEvent;
        event Action MeasurementFailureEvent;

        void Start();
        void RecordMeasurement(float x, float y, float z, long timestampMillis);
        float Progress { get; }
    }
}