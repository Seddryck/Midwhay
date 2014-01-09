using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Core
{
	class Fact : SchemaObject, IFact
	{
		public Fact(string name)
			: base(name)
		{
		}
	}
}
