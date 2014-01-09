using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Graph.Formatter
{
    class OutriggerFormatter : BaseEdgeFormatter
    {
        public OutriggerFormatter(IOutriggerRelation relation)
            : base(relation)
        {

        }

        protected override string GetArrowHead()
        {
 	         return "diamond";
        }

        protected override string GetStyle()
        {
            return "dashed";
        }
    }
}
