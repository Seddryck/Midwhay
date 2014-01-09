using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Core
{
	class FactlessFact : SchemaObject, IFactlessFact
	{
		public FactlessFact(string name)
			: base(name)
		{
		}
	}
}
