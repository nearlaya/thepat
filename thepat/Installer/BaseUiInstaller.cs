using thepat.ViewModels;
using SimpleInjector;

namespace thepat.Installer
{
    public class BaseUiInstaller
    {
        public void Install(Container container)
        {
            container.Register(typeof(MainViewModel));
        }
    }
}
