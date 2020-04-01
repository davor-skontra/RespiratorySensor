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
        private const float FrequencyHz = 30f;
        private const int MillisInSecond = 1000;
        
        private readonly LocalizedTexts _texts;
        private readonly LocalizedAudios _audios;
        private readonly IMeasurementService _measurementService;
        private readonly IGravityDirectionProvider _gravityDirectionProvider;

        private readonly OnceEvery _measureOnceEvery;
        private readonly Stopwatch _stopwatch= new Stopwatch();
        public event Action<float> ProgressEvent;
        public event Action<float> ReadyEvent;

        public MeasurementPanelModel(
            LocalizedTexts texts,
            LocalizedAudios audios,
            IMeasurementService measurementService,
            IGravityDirectionProvider gravityDirectionProvider
        )
        {
            _texts = texts;
            _audios = audios;
            _measurementService = measurementService;
            _gravityDirectionProvider = gravityDirectionProvider;

            _measurementService.ReadyEvent += ReadyEvent;

            StartMeasuring();
            
            _measureOnceEvery = new UpdateContainerBuilder(Measure)
                .RunFirstInstant()
                .Every(TimeSpan.FromMilliseconds(MillisInSecond / FrequencyHz));
            
        }

        private Vector3 Gravity => _gravityDirectionProvider.Down;

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