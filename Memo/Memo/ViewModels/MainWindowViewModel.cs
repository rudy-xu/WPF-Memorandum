using Memo.Helper;
using Memo.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;

namespace Memo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Private
        private readonly IRegionManager _regionManager;
        private IRegionNavigationJournal _navigationJournal;
        #endregion

        #region Property
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<MenuBar> _menuBars;

        public ObservableCollection<MenuBar> MenuBars
        {
            get { return _menuBars; }
            set { SetProperty(ref _menuBars, value); }
        }
        #endregion

        
        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            MenuBars = new ObservableCollection<MenuBar>();
            CreateMenuBar();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            GoBackCommand = new DelegateCommand(GeoBack);
            GoForwardCommand = new DelegateCommand(GoForward);
        }

        #region Command
        private void GoForward()
        {
            if (_navigationJournal != null && _navigationJournal.CanGoForward) 
            {
                _navigationJournal.GoForward();
            }
        }

        private void GeoBack()
        {
            if (_navigationJournal != null && _navigationJournal.CanGoBack)
            {
                _navigationJournal.GoBack();
            }
        }

        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.Navigation)) return;

            _regionManager.RequestNavigate(RegionNames.MainViewRegion, obj.Navigation, callback => {
                _navigationJournal = callback.Context.NavigationService.Journal;
            });
        }
        #endregion

        /// <summary>
        /// 访问修饰符 默认 internal 
        /// </summary>
        void CreateMenuBar()
        {
            string[] icons = { "Home", "NotebookOutline", "NotebookPlus", "Cog" };
            string[] titles = { "首页", "待办事项", "备忘录", "设置" };
            string[] navigationIndex = { "IndexView", "ToDoView", "MemoView", "SettingsView" };

            for (int i = 0; i < 4; ++i)
            {
                MenuBars.Add(new MenuBar() { Icon = icons[i], Title = titles[i], Navigation = navigationIndex[i] });
            }
        }
    }
}
