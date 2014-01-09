using System;
using System.Linq;
using System.Text;
using Midwhay.Core.Interface;

namespace Midwhay.Graph.Formatter
{
    public class BaseShapeFormatter : IFormatter
    {
        private readonly ISchemaObject obj;
        protected ISchemaObject Value { get { return obj; } }

        public BaseShapeFormatter(ISchemaObject obj)
        {
            this.obj = obj;
        }

        public string GetFormat()
        {
            var output = new StringBuilder();
            output.AppendFormat(" [shape={0}", GetShape());
            if (!String.IsNullOrWhiteSpace(GetStyle()))
                output.AppendFormat(", style={0}", GetStyle());
            if (!String.IsNullOrWhiteSpace(GetColor()))
                output.AppendFormat(", color={0}", GetColor());
            output.Append("];\n");

            return output.ToString();
        }

        protected virtual string GetShape()
        {
            return "point";
        }

        protected virtual string GetStyle()
        {
            return "filled";
        }

        protected virtual string GetColor()
        {
            return "white";
        }
    }
}
