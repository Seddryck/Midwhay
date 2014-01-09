using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Core.Relation
{
    abstract class BaseRelation : IRelation
    {
        private readonly ISchemaObject origin;
        private readonly ISchemaObject destination;
        private readonly string predicate;

        public ISchemaObject Origin
        {
            get
            {
                return origin;
            }
        }

        public ISchemaObject Destination
        {
            get
            {
                return destination;
            }
        }

        public string Predicate
        {
            get
            {
                return predicate;
            }
        }

        public BaseRelation(ISchemaObject origin, ISchemaObject destination, string predicate)
        {
            this.origin = origin;
            this.destination = destination;
            this.predicate = predicate;
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1}", origin.Name, destination.Name);
        }
    }
}
