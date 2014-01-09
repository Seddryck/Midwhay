using System;
using System.Linq;
using System.Text;
using Midwhay.Core.Interface;

namespace Midwhay.Graph.Formatter
{
    class BaseEdgeFormatter : IFormatter
    {
        private readonly IRelation relation;
        protected IRelation Value { get { return relation; } }

        public BaseEdgeFormatter(IRelation relation)
        {
            this.relation = relation;
        }

        public string GetFormat()
        {
            var output = new StringBuilder();
            output.AppendFormat(" [color={0}", "black");
            output.AppendFormatIfNotNull(", arrowhead={0}", GetArrowHead());
            output.AppendFormatIfNotNull(", arrowtail={0}", GetArrowTail());
            output.AppendFormatIfNotNull(", style={0}", GetStyle());
            output.AppendFormatIfNotNull(", label={0}", relation.Predicate);
            output.Append("];\n");

            return output.ToString();
        }

        protected virtual string GetArrowHead()
        {
            return "";
        }

        protected virtual string GetArrowTail()
        {
            return "";
        }

        protected virtual string GetStyle()
        {
            return "";
        }

        protected virtual string GetColor()
        {
            return "white";
        }
    }
}
