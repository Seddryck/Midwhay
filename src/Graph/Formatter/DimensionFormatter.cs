using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Graph.Formatter
{
    class DimensionFormatter : BaseShapeFormatter
    {
        protected new IDimension Value { get { return (IDimension)base.Value; } }

        public DimensionFormatter(IDimension dimension)
            : base(dimension)
        {

        }

        protected override string GetShape()
        {
            return "box";
        }

        protected override string GetColor()
        {
            switch (Value.Classification)
            {
                case DimensionClassification.Unspecified:
                    return "green";
                case DimensionClassification.When:
                    return "darkgreen";
                case DimensionClassification.Who:
                    return "olivedrab";
                case DimensionClassification.Where:
                    return "lawngreen";
                case DimensionClassification.What:
                    return "forestgreen";
                case DimensionClassification.How:
                    return "seagreen";
                case DimensionClassification.Why:
                    return "palegreen";
                default:
                    return "green";
            }
        }
    }
}
