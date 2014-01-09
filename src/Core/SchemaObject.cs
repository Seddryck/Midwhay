using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Core
{
	abstract class SchemaObject : ISchemaObject
	{
		private readonly string name;

		public string Name
		{
			get
			{
				return name;
			}
		}

        public SchemaObject(string name)
		{
			this.name = name;
		}
	}
}
