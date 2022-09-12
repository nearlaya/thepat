using Helpers;

namespace BusinessLogic.Models
{
    // a model with calculated gas & oil volumetric data

    public class VolumetricData
    {
        #region public vars

        public double CubicMeters { get; private set; }
        public double CubicFeets { get; private set; }
        public double Barrels { get; private set; }

        #endregion

        #region public methods

        public VolumetricData(double metricValue)
        {
            CubicMeters = metricValue;
            CubicFeets = UnitConverter.CubicMetersToCubicFeets(metricValue);
            Barrels = UnitConverter.CubicMetersToBarrels(metricValue);
        }

        #endregion
    }
}
