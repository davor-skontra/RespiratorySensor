using System.Collections.Generic;
using JetBrains.Annotations;

namespace Panels
{
    [UsedImplicitly]
    public class PanelVisibilityManager
    {
        private List<PanelViewModel> _panels = new List<PanelViewModel>();

        public void RegisterPanel(PanelViewModel panelViewModel)
        {
            _panels.Add(panelViewModel);
        }

        public void SetVisiblePanel(PanelKind panelKind)
        {
            foreach (var panel in _panels)
            {
                panel.SetVisiblePanel(panelKind);
            }
        }
        
    }
}