using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Graph.Formatter
{
    class JunkFormatter : BaseEdgeFormatter
    {
        public JunkFormatter(IJunkRelation relation)
            : base(relation)
        {

        }

        protected override string GetArrowTail()
        {
 	         return "crow";
        }

        protected override string GetStyle()
        {
            return "dashed";
        }
    }
}
