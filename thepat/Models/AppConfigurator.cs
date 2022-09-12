using BusinessLogic.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thepat.Models
{
    public sealed class AppConfigurator
    {
        #region private vars

        private static AppConfigurator _default;

        #endregion

        #region public vars

        public Container Container { get; private set; }

        #endregion

        #region ctor

        public static AppConfigurator Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new AppConfigurator();
                }
                return _default;
            }
        }

        #endregion

        #region public methods

        public void RegisterContainer(Container container)
        {
            if (container is null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            Container = container;
        }

        #endregion
    }
}
