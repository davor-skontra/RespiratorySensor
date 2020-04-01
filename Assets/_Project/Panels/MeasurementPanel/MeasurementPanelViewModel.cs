using System;
using Zenject;

namespace Panels.MeasurementPanel
{
    public class MeasurementPanelViewModel: PanelViewModel, IDisposable
    {
        [Inject] private MeasurementPanelModel _model;
        
        public event Action<float> ProgressEvent;
        public override PanelKind PanelKind => PanelKind.Measurement;
        public MeasurementPanelViewModel()
        {
            _model.ProgressEvent += ProgressEvent;
            _model.ReadyEvent += ShowScore;
        }
        
        public void OnBecameVisible()
        {
            _model.StartMeasuring();
        }

        public void ShowScore(float score)
        {
            SetVisiblePanel(PanelKind.Score);
            // TODO: stash score to a score handler of some kind

        }

        public void Dispose()
        {
            _model.ProgressEvent -= ProgressEvent;
            _model.ReadyEvent -= ShowScore;
        }
    }
}