using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Measurement
{
    public class PlaceholderMeasurementService: IMeasurementService
    {
        public event Action<float> ReadyEvent;
        public event Action MeasurementFailureEvent;

        public void Start()
        {
            Debug.Log("Start");
        }

        public void RecordMeasurement(float x, float y, float z, long timestampMillis)
        {
            Debug.Log($"x:{x}, y:{y}, z:{z}, timeStamp:{timestampMillis}");
        }

        public float Progress => 3f;
    }
}