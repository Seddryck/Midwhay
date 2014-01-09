using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Core.Relation
{
    class OutriggerRelation : BaseRelation, IOutriggerRelation
    {
        public OutriggerRelation(IDimension main, IDimension outrigger)
            : base(main, outrigger, "outrigger")
        {

        }
    }
}
