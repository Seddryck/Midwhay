using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Core.Relation
{
    class JunkRelation : BaseRelation, IJunkRelation
    {
        public JunkRelation(IDimension junk, IDimension component)
            : base(junk, component, "junk")
        {

        }
    }
}
