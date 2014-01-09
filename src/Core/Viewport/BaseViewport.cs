using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Core.Viewport
{
	public abstract class BaseViewport : IViewport
	{
		private readonly string label;
		protected readonly Dictionary<string, ISchemaObject> objects;
		protected readonly HashSet<IRelation> relations;


		public IEnumerable<ISchemaObject> Objects
		{
			get
			{
				return objects.Values.ToArray();
			}
		}

		public IEnumerable<IRelation> Relations
		{
			get
			{
				return relations;
			}
		}

		public string Label
		{
			get
			{
				return label;
			}
		}

		public BaseViewport(string label)
		{
			this.label = label;
			objects = new Dictionary<string, ISchemaObject>();
			relations = new HashSet<IRelation>();
		}

		public IEnumerable<IRelation> FindRelations(ISchemaObject obj)
		{
			var origRel = relations.Where(r => r.Origin == obj);
			var destRel = relations.Where(r => r.Destination == obj);

			return origRel.Concat(destRel);
		}

		public IEnumerable<IRelation> FindRelations(string name)
		{
			if (!Exists(name))
				throw new ArgumentException();

			return FindRelations(FindObject(name));
		}

		public ISchemaObject FindObject(string name)
		{
			if (objects.ContainsKey(name))
				return objects[name];
			else
				return null;
		}

		public bool Exists(string name)
		{
			return objects.ContainsKey(name);
		}
	}
}
