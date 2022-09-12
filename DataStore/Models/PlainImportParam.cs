using DataStore.Enum;

namespace DataStore.Models
{
    // we need ершы учекф options to correctly load plain data

    public class PlainImportOptions
    {
        public int GridDimensionW { get; set; }
        public int GridDimensionH { get; set; }
        public double CellSizeW { get; set; }
        public double CellSizeH { get; set; }
        public double BaseHorizonOffset { get; set; }
        public double FluidLevel { get; set; }

        public DimensionUnit CellSizeUnit { get; set; }
        public DimensionUnit DepthUnit { get; set; }
        public DimensionUnit HorizonOffsetUnit { get; set; }
        public DimensionUnit FluidLevelUnit { get; set; }

        public char Separator { get; set; }
    }
}
