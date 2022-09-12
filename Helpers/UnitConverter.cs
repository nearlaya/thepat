using System;

namespace Helpers
{
    public static class UnitConverter
    {
        //3.280839895
        private const double METER_TO_FEET_RATIO = 0.3048;
        private const double BARREL_TO_CUBIC_METER_RATIO = 6.2898107704;
        private const double CUBIC_FEET_TO_CUBIC_METER_RATIO = 35.3147;

        public static double LinearFeetsToLinearMeters(double feets)
        {
            if (feets < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(feets));
            }

            return feets *  METER_TO_FEET_RATIO;
        }

        public static double LinearMetersToLinearFeets(double meters)
        {
            if (meters < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(meters));
            }

            return meters / METER_TO_FEET_RATIO;
        }

        public static double CubicMetersToBarrels(double meters)
        {
            if (meters < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(meters));
            }

            return meters * BARREL_TO_CUBIC_METER_RATIO;
        }

        public static double CubicMetersToCubicFeets(double meters)
        {
            if (meters < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(meters));
            }

            return meters * CUBIC_FEET_TO_CUBIC_METER_RATIO;
        }
    }
}
