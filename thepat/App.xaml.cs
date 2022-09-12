using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SimpleInjector;
using thepat.Constants;
using System.Windows;
using System.Windows.Threading;
using thepat.Installer;
using BusinessLogic.Installers;
using thepat.Models;

namespace thepat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region ctor

        public App()
        {
            DispatcherUnhandledException += OnException;
        }

        #endregion

        #region overrides

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            InitializeApplication();
            InitializeMainWindow();
        }

        #endregion

        #region private methods

        private void OnException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(
                UiConstants.MESSAGE_BODY_EXCEPTION, 
                UiConstants.MESSAGE_HEADER_ERROR, 
                MessageBoxButton.OK, 
                MessageBoxImage.Error);

            e.Handled = true;
        }

        private void InitializeApplication()
        {
            var container = new Container();

            new BaseUiInstaller().Install(container);
            new BusinessInstaller().Install(container);

#if DEBUG
            container.Verify();
#endif

            AppConfigurator.Default.RegisterContainer(container);
        }

        private void InitializeMainWindow()
        {
            MainWindow = new MainWindow();
        }

        #endregion
    }
}
