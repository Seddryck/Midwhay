using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Graph.Formatter
{
    class FactlessFactFormatter : BaseShapeFormatter
    {
        protected new IFactlessFact Value { get { return (IFactlessFact)base.Value; } }

        public FactlessFactFormatter(IFactlessFact factlessFact)
            : base(factlessFact)
        {

        }

        protected override string GetShape()
        {
            return "octagon";
        }

        protected override string GetColor()
        {
            return "coral";
        }
    }
}
