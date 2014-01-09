using System;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Core
{
	class Dimension : SchemaObject, IDimension
	{
		private readonly DimensionClassification classification;
		public DimensionClassification Classification
		{
			get
			{
				return classification;
			}
		}
		
		public Dimension (string name)
			: this(name, DimensionClassification.Unspecified)
		{
		}

		public Dimension(string name, DimensionClassification classification)
			: base(name)
		{
			this.classification= classification;
		}
		
	}
}
