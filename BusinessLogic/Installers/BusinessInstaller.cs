
using BusinessLogic.Services;
using SimpleInjector;

namespace BusinessLogic.Installers
{
    // a installer for business logic

    public class BusinessInstaller
    {
        public void Install(Container container)
        {
            container.Register<IEngineerService, EngineerService>();
            container.Register<IDisplayService, DisplayService>();
        }
    }
}
