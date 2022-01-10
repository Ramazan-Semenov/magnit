using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Nikita.ViewModel
{
   public class CurrentWindow: Base.BaseViewModel
    {
        private Page PageChief = new Views.ChiefViews.ChiefViewPage();
        private Page PageCorrdinator = new Views.coordinatorView.CoordinatorViewPage();
        private Page AllQuery = new Views.Pages.ListTask();
        private Page DiagramPage = new Views.Pages.ListTask();
        private Page PageCurrent = new Page();
        public double FrameOpacity { get; set; } = 1;
        public Page CurrentPage { get=>PageCurrent; set { PageCurrent = value; OnPropertyChanged(nameof(CurrentPage)); } }
        public CurrentWindow()
        {
            PageCurrent = AllQuery;

            OpenChiefPage = new RelayCommand(()=> { PageCurrent = PageChief; OnPropertyChanged(nameof(CurrentPage)); });
            OpenCoordinatorPage = new RelayCommand(() => { PageCurrent = PageCorrdinator; OnPropertyChanged(nameof(CurrentPage)); });
            OpenAllQueryPage = new RelayCommand(() => { PageCurrent = AllQuery; OnPropertyChanged(nameof(CurrentPage)); });
            OpenDiagramPage = new RelayCommand(() => { PageCurrent = PageChief; OnPropertyChanged(nameof(CurrentPage)); });

        }



        public RelayCommand OpenChiefPage
        {
            get;
        }
        public RelayCommand OpenCoordinatorPage { get; }
      public RelayCommand OpenAllQueryPage { get; }
       public RelayCommand OpenDiagramPage { get; }


    }
}
