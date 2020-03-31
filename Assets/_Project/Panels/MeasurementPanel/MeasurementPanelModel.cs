using System;
using System.Diagnostics;
using System.Numerics;
using Localization;
using Measurement;
using Utilities.UpdateContainers;
using Zenject;
using Vector3 = UnityEngine.Vector3;

namespace Panels.MeasurementPanel
{
    public class MeasurementPanelModel : ITickable, IDisposable
    {
        private readonly LocalizedTexts _texts;
        private readonly LocalizedAudios _audios;
        private readonly IMeasurementService _measurementService;
        private readonly IGyroService _gyroService;

        private readonly OnceEvery _measureOnceEvery;
        private readonly Stopwatch _stopwatch= new Stopwatch();
        public event Action<float> ProgressEvent;
        public event Action<float> ReadyEvent;

        public MeasurementPanelModel(
            LocalizedTexts texts,
            LocalizedAudios audios,
            IMeasurementService measurementService,
            IGyroService gyroService
        )
        {
            _texts = texts;
            _audios = audios;
            _measurementService = measurementService;
            _gyroService = gyroService;

            _measurementService.ReadyEvent += ReadyEvent;

            StartMeasuring();
            
            _measureOnceEvery = new UpdateContainerBuilder(Measure)
                .RunFirstInstant()
                .Every(TimeSpan.FromMilliseconds(100));
            
        }

        private Vector3 Gravity => _gyroService.Gravity;

        private void Measure()
        {
            _measurementService.RecordMeasurement(Gravity.x, Gravity.y, Gravity.z, _stopwatch.ElapsedMilliseconds);
        }

        private void StartMeasuring()
        {
            _stopwatch.Restart();
            _measurementService.Start();
        }

        public void Tick()
        {
            _measureOnceEvery.Update();
            ProgressEvent?.Invoke(_measurementService.Progress);
        }

        public void Dispose()
        {
            _measurementService.ReadyEvent -= ReadyEvent;
        }
    }
}