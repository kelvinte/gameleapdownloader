using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLeapDownloader.ViewModels
{
    class DashboardViewModel : Conductor<object>
    {
        private DownloaderViewModel _downloaderViewModel;
        public DashboardViewModel(DownloaderViewModel downloaderViewModel)
        {
            _downloaderViewModel = downloaderViewModel;
        }

        protected override void OnActivate()
        {
            ActivateItem(_downloaderViewModel);
            base.OnActivate();
        }
    }
}
