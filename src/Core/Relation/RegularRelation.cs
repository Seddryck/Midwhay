using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Core.Relation
{
    class RegularRelation : BaseRelation
    {
        public RegularRelation(IFact fact, IDimension dimension)
            : base(fact, dimension, string.Empty)
        {

        }

        public RegularRelation(IFactlessFact factlessFact, IFact fact)
            : base(factlessFact, fact, string.Empty)
        {

        }
    }
}
