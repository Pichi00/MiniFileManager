using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.ViewModel
{
    public class MainViewModel
    {
        private PanelViewModel leftPanel;
        private PanelViewModel rightPanel;

        public PanelViewModel LeftPanel
        {
            get { return leftPanel; }
        }
        public PanelViewModel RightPanel
        {
            get { return rightPanel; }
        }

        public MainViewModel()
        {
            leftPanel = new PanelViewModel();
            rightPanel = new PanelViewModel();
        }
    }
}
