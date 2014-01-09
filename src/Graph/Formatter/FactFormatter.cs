using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Graph.Formatter
{
    class FactFormatter : BaseShapeFormatter
    {
        protected new IFact Value { get { return (IFact)base.Value; } }

        public FactFormatter(IFact fact)
            : base(fact)
        {

        }

        protected override string GetShape()
        {
            return "ellipse";
        }

        protected override string GetColor()
        {
            return "orange";
        }
    }
}
