
using thepat.Commands;
using thepat.Constants;
using thepat.Models;
using BusinessLogic.Models;
using BusinessLogic.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace thepat.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region private vars

        private readonly IEngineerService _engineerService;
        private readonly IDisplayService _displayService;

        #endregion

        #region menus

        private ObservableCollection<MenuItemModel> _menuItems;
        public ObservableCollection<MenuItemModel> MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value;
                RaisePropertyChange(nameof(MenuItems));
            }
        }

        #endregion

        #region GroupedDisplayData

        private DisplayGroupedData _groupedDisplayData;
        public DisplayGroupedData GroupedDisplayData
        {
            get { return _groupedDisplayData; }
            set
            {
                _groupedDisplayData = value;
                RaisePropertyChange(nameof(GroupedDisplayData));
            }
        }

        #endregion

        #region ctor

        public MainViewModel(
            IEngineerService engineerService,
            IDisplayService displayService)
        {
            _engineerService = engineerService;
            _displayService = displayService;
        }

        #endregion

        #region overrides

        public override void OnNavigatedTo(object navigationParameter = null)
        {
            InitializeViewModel();

            base.OnNavigatedTo(navigationParameter);
        }

        public override void OnNavigatedFrom()
        {
            base.OnNavigatedFrom();
        }

        #endregion

        #region private methods

        private void InitializeViewModel()
        {
            MenuItems = CreateMenus();
        }

        private ObservableCollection<MenuItemModel> CreateMenus()
        {
            var menuItem = new MenuItemModel
            {
                Text = UiConstants.MENU_FILE
            };

            var childMenuItem = new MenuItemModel
            {
                Text = UiConstants.MENU_OPEN_FILE,
                Command = new RelayCommand(OpenFileCommand)
            };

            menuItem.MenuItems.Add(childMenuItem);

            var menus = new ObservableCollection<MenuItemModel>
            {
                menuItem
            };

            return menus;
        }

        private async void OpenFileCommand(object arg)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            var volumetricData = await _engineerService.CalculateVolumetricDataAsync(openFileDialog.FileName);  
            if (volumetricData is null)
            {
                MessageBox.Show(
                    UiConstants.MESSAGE_BODY_FILE_ERROR,
                    UiConstants.MESSAGE_HEADER_ERROR,
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return;
            }

            GroupedDisplayData = _displayService.FormatVolumetricData(volumetricData);
        }

        #endregion
    }
}
