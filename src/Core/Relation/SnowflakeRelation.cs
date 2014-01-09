using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Core.Relation
{
    class SnowflakeRelation : BaseRelation, ISnowflakeRelation
    {
        public SnowflakeRelation(IDimension fineGrainedDimension, IDimension coarseGrainedDimension)
            : base(fineGrainedDimension, coarseGrainedDimension, string.Empty)
        {

        }
    }
}
