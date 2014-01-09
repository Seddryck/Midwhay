using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midwhay.Dsl
{
    public class RoleObject
    {
        public QualifierType Qualifier { get; set; }
        public IEnumerable<string> Objects { get; set; }

        public RoleObject(QualifierType qualifier, IEnumerable<string> obj)
        {
            Qualifier = qualifier;
            Objects = obj;
        }
    }
}
