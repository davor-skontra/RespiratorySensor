using System;
using System.Diagnostics;
using Localization;
using Measurement;
using Panels.ProgressiveText;
using Utilities.UpdateContainers;
using Zenject;

namespace Panels.MeasurementPanel
{
    public class MeasurementPanelModel : ITickable
    {
        private readonly LocalizedTexts _texts;
        private readonly LocalizedAudios _audios;
        private readonly IMeasurementService _measurementService;

        private readonly OnceEvery _measureOnceEvery;
        private readonly Stopwatch _stopwatch= new Stopwatch();

        public event Action<float> ProgressEvent;
        public event Action<float> DoneEvent;

        public MeasurementPanelModel(
            LocalizedTexts texts,
            LocalizedAudios audios,
            IMeasurementService measurementService
        )
        {
            _texts = texts;
            _audios = audios;
            _measurementService = measurementService;

            StartMeasuring();
            
            _measureOnceEvery = new UpdateContainerBuilder(Measure)
                .RunFirstInstant()
                .Every(TimeSpan.FromMilliseconds(1000));
            
            

        }

        private void Measure()
        {
            _measurementService.RecordMeasurement(0f, 0f, 0f, _stopwatch.ElapsedMilliseconds);
        }

        private void StartMeasuring()
        {
            _measurementService.Start();
        }

        public void Tick()
        {
            _measureOnceEvery.Update();
        }
    }
}