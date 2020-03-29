using System;
using Panels.PanelManagement;

namespace Panels
{
    public abstract class PanelViewModel
    {
        public abstract PanelKind PanelKind { get; }

        public event Action<bool> ShouldBeVisibleEvent;

        public void SetVisiblePanel(PanelKind kind)
        {
            ShouldBeVisibleEvent?.Invoke(kind == PanelKind);
        }
    }
}