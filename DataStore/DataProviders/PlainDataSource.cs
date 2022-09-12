using System;
using System.IO;
using System.Linq;
using DataStore.Models;
using Helpers;

namespace DataStore.DataProviders
{
    public class PlainDataSource : IDataSource
    {
        #region public methods

        //  we need load and convert all plain data in metric system for univerasal aproaching

        public SourceData ImportData(string fileName)
        {
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (fileName == string.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(fileName));
            }

            var options = GetImportOptions();

            var cellSizeH = options.CellSizeUnit == Enum.DimensionUnit.Feet 
                ? UnitConverter.LinearFeetsToLinearMeters(options.CellSizeH) 
                : options.CellSizeH;

            var cellSizeW = options.CellSizeUnit == Enum.DimensionUnit.Feet 
                ? UnitConverter.LinearFeetsToLinearMeters(options.CellSizeW) 
                : options.CellSizeW;

            var fluidLevel = options.FluidLevelUnit == Enum.DimensionUnit.Feet 
                ? UnitConverter.LinearFeetsToLinearMeters(options.FluidLevel) 
                : options.FluidLevel;

            var topHeightMap = new double[options.GridDimensionH, options.GridDimensionW];
            var baseHeightMap = new double[options.GridDimensionH, options.GridDimensionW];

            var sourceData = new SourceData(
                options.GridDimensionW, 
                options.GridDimensionH, 
                cellSizeW, 
                cellSizeH, 
                fluidLevel, 
                baseHeightMap, 
                topHeightMap);

            var dataLines = File.ReadLines(fileName).ToArray();
            var lineCount = dataLines.Count();

            for (int wOffset = 0; wOffset < lineCount; wOffset++)
            {
                if (wOffset >= options.GridDimensionW)
                {
                    break;
                }

                var values = dataLines[wOffset].Split(options.Separator);
                var lenght = values.Count();

                for (int hOffset = 0; hOffset < lenght; hOffset++)
                {
                    if (hOffset >= options.GridDimensionH)
                    {
                        break;
                    }

                    var height = double.Parse(values[hOffset]);
                    var metricHeight = options.DepthUnit == Enum.DimensionUnit.Feet 
                        ? UnitConverter.LinearFeetsToLinearMeters(height) 
                        : height;

                    //Because we are using a universal interface for a simple data provider, 
                    //we need to emulate the second horizon from the plain data of the first horizon.

                    topHeightMap[hOffset, wOffset] = metricHeight;
                    baseHeightMap[hOffset, wOffset] = metricHeight + options.BaseHorizonOffset;
                }
            }

            return sourceData;
        }

        #endregion

        #region private methods

        private PlainImportOptions GetImportOptions()
        {
            //TO DO: get import options from a dialog 

            //Application.Current.Dispatcher.Invoke(() => {
            //    var dialog = new PlainSettingsWindow();
            //    dialog.ShowDialog();
            //});

            var options = new PlainImportOptions
            {
                GridDimensionH = 16,
                GridDimensionW = 26,
                CellSizeH = 200,
                CellSizeW = 200,
                CellSizeUnit = Enum.DimensionUnit.Feet,
                BaseHorizonOffset = 100,
                HorizonOffsetUnit = Enum.DimensionUnit.Meter,
                FluidLevel = 3000,
                FluidLevelUnit = Enum.DimensionUnit.Meter,
                DepthUnit = Enum.DimensionUnit.Feet,
                Separator = Constants.DataConstants.PLAIN_SEPARATOR_SPACE
            };

            return options;
        }

        #endregion
    }
}
