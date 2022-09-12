using System;
using System.Collections.Generic;
using BusinessLogic.Models;

namespace BusinessLogic.Services
{
    public class DisplayService : IDisplayService
    {
        #region ctor

        public DisplayService()
        {

        }

        #endregion

        #region interface implementation

        public DisplayGroupedData FormatVolumetricData(VolumetricData data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var listValues = new List<string>
            {
                Constants.Constants.UNIT_CUBIC_METER + RoundDouble(data.CubicMeters),
                Constants.Constants.UNIT_CUBIC_FEET  + RoundDouble(data.CubicFeets),
                Constants.Constants.UNIT_BARREL  + RoundDouble(data.Barrels)
            };

            return new DisplayGroupedData(Constants.Constants.VOLUMETRIC_DATA, listValues);
        }

        #endregion

        #region private methods

        private double RoundDouble(double value)
        {
            return Math.Floor(value);
        }

        #endregion
    }
}
