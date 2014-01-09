using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midwhay.Core.Interface
{
    public interface IViewport
    {
        string Label { get; }
        IEnumerable<IRelation> Relations { get; }
        IEnumerable<ISchemaObject> Objects { get; }
        ISchemaObject FindObject(string name);
        IEnumerable<IRelation> FindRelations(ISchemaObject obj);
    }
}
