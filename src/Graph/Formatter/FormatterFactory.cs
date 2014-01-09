using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Graph.Formatter
{
    public class FormatterFactory
    {
        public IFormatter GetFormatter(ISchemaObject obj)
        {
            //A factlessfact is represented as an octagon
            if (obj is IFactlessFact)
                return new FactlessFactFormatter((IFactlessFact)obj);
            //A dimension is represented as a box
            else if (obj is IDimension)
                return new DimensionFormatter((IDimension)obj);
            //A fact is represented as an ellipse
            else if (obj is IFact)
                return new FactFormatter((IFact)obj);

            return new BaseShapeFormatter(obj);
        }

        public IFormatter GetFormatter(IRelation relation)
        {
            if (relation is ISnowflakeRelation)
                return new SnowflakeFormatter((ISnowflakeRelation)relation);
            else if (relation is IOutriggerRelation)
                return new OutriggerFormatter((IOutriggerRelation)relation);
            else if (relation is IJunkRelation)
                return new JunkFormatter((IJunkRelation)relation);
            
            return new BaseEdgeFormatter(relation);
        }
    }
}
