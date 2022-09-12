namespace DataStore.Models
{
    // a model with loaded depth-data (in metric system)

    public class SourceData
    {
        public int DimensionW { get; private set; }
        public int DimensionH { get; private set; }

        public double CellSizeW { get; private set; }
        public double CellSizeH { get; private set; }
        public double FluidLevel { get; private set; }

        public double[,] BaseHeightMap { get; private set; }
        public double[,] TopHeightMap { get; private set; }

        public SourceData(int dimensionW, int dimensionH, double cellSizeW, double cellSizeH, double fluidLevel, double[,] baseHeightMap, double[,] topHeightMap)
        {
            DimensionW = dimensionW;
            DimensionH = dimensionH;
            CellSizeW = cellSizeW;
            CellSizeH = cellSizeH;
            FluidLevel = fluidLevel;
            BaseHeightMap = baseHeightMap;
            TopHeightMap = topHeightMap;
        }
    }
}
