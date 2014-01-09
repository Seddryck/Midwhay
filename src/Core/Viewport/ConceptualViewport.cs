using System;
using System.Collections.Generic;
using System.Linq;
using Midwhay.Core.Interface;
using Midwhay.Core.Relation;

namespace Midwhay.Core.Viewport
{
	public class ConceptualViewport : BaseViewport
	{
		public ConceptualViewport(string label)
			: base(label)
		{
		}

		public IDimension AddDimension(string name)
		{
			var dimension = new Dimension(name);
			objects.Add(name, dimension);

			return dimension;
		}

		public IDimension AddDimension(string name, DimensionClassification classification)
		{
			var dimension = new Dimension(name, classification);
			objects.Add(name, dimension);

			return dimension;
		}

		public IFact AddFact(string name)
		{
			var fact = new Fact(name);
			objects.Add(name, fact);

			return fact;
		}

		public IRelation AddRelation(IFact fact, IDimension dimension)
		{
            if (fact == null)
                throw new ArgumentException();
            if (dimension == null)
                throw new ArgumentException();

			var relation = new RegularRelation(fact, dimension);
			relations.Add(relation);

			return relation;
		}

		public IRelation AddRelation(string factName, string dimensionName)
		{
			if (Exists(factName) && !(FindObject(factName) is IFact))
				throw new ArgumentException();
			if (Exists(dimensionName) && !(FindObject(dimensionName) is IDimension))
				throw new ArgumentException();

			IFact fact = (IFact)FindObject(factName);
			if (fact==null)
				fact = AddFact(factName);

			IDimension dimension = (IDimension)FindObject(dimensionName);
			if (dimension == null)
				dimension = AddDimension(dimensionName);

			return AddRelation(fact, dimension);
		}

	}
}
