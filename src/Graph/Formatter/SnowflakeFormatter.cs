using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Graph.Formatter
{
    class SnowflakeFormatter : BaseEdgeFormatter
    {
        public SnowflakeFormatter(ISnowflakeRelation relation)
            : base(relation)
        {

        }

        protected override string GetArrowHead()
        {
 	         return "invempty";
        }

        protected override string GetStyle()
        {
            return "dashed";
        }
    }
}
