using System;
using System.IO;
using System.Threading.Tasks;
using BusinessLogic.Models;
using DataStore.DataProviders;
using DataStore.Models;

namespace BusinessLogic.Services
{
    public class EngineerService : IEngineerService
    {
        #region ctor

        public EngineerService()
        {

        }

        #endregion

        #region interface implementation

        public Task<VolumetricData> CalculateVolumetricDataAsync(string filename)
        {
            if (filename is null)
            {
                throw new ArgumentNullException(nameof(filename));
            }

            if (filename == string.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(filename));
            }

            var extension = Path.GetExtension(filename);
            var dataSource = DataSourceFabric.GetDataSourceByFileType(extension);
            if (dataSource is null)
            {
                return Task.FromResult<VolumetricData>(null);
            }
            else
            {
                return Task.Run(() => LoadAndCalculate(dataSource, filename));
            }
        }

        #endregion

        #region private methods

        private VolumetricData LoadAndCalculate(IDataSource dataSource, string filename)
        {
            var sourceData = dataSource.ImportData(filename);
            var result = CalculateVolumetricData(sourceData);

            return result;
        }

        private VolumetricData CalculateVolumetricData(SourceData sourceData)
        {
            var totalMetricVolume = 0d;
            var cellSquare = sourceData.CellSizeH * sourceData.CellSizeW;

            for (int wOffset = 0; wOffset < sourceData.DimensionW; wOffset++)
            {
                for (int hOffset = 0; hOffset < sourceData.DimensionH; hOffset++)
                {
                    var fluidLevel = sourceData.FluidLevel;
                    var topLevel = sourceData.TopHeightMap[hOffset, wOffset];
                    var baseLevel = sourceData.BaseHeightMap[hOffset, wOffset];
                    
                    if (topLevel >= fluidLevel && baseLevel >= fluidLevel)
                    {
                        continue;
                    }

                    var volume = (Math.Min(fluidLevel, baseLevel) - Math.Min(fluidLevel, topLevel)) * cellSquare;
                    if (volume > 0)
                    {
                        totalMetricVolume += volume;
                    }
                }
            }

            return new VolumetricData(totalMetricVolume);
        }

        #endregion
    }
}
