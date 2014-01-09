using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midwhay.Core.Interface
{
    public interface IRelation
    {
        ISchemaObject Origin { get; }
        ISchemaObject Destination { get; }
        string Predicate { get; }
    }

    public interface ISnowflakeRelation : IRelation {}
    public interface IOutriggerRelation : IRelation { }
    public interface IJunkRelation : IRelation { }
}
