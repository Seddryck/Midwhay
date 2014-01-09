using System;
using System.Collections.Generic;
using System.Linq;
using Midwhay.Core.Interface;
using Midwhay.Core.Relation;

namespace Midwhay.Core.Viewport
{
	public class LogicalViewport : ConceptualViewport
	{
		public LogicalViewport(string label)
            : base(label)
		{
		}

		
        public IFactlessFact AddFactlessFact(string name)
        {
            var fact = new FactlessFact(name);
            objects.Add(name, fact);

            return fact;
        }


        public IEnumerable<IRelation> AddBridgeRelation(IFact fact, IFactlessFact factlessFact, IDimension dimension)
        {
            var relationBetweenFacts = new RegularRelation(factlessFact, fact);
            var relationWithDimension = new RegularRelation(factlessFact, dimension);
            relations.Add(relationBetweenFacts);
            relations.Add(relationWithDimension);

            return new List<IRelation>() {relationBetweenFacts,relationWithDimension};
        }
        
        public IRelation AddSnowflakeRelation(IDimension fineGrainedDimension, IDimension coarseGrainedDimension)
        {
            var relation = new SnowflakeRelation(fineGrainedDimension, coarseGrainedDimension);
            relations.Add(relation);

            return relation;
        }

        public IEnumerable<IRelation> AddSnowflakeRelation(IDimension fineGrainedDimension, IDimension middleGrainedDimension, IDimension coarseGrainedDimension)
        {
            var firstRelation = AddSnowflakeRelation(fineGrainedDimension, middleGrainedDimension);
            var secondRelation = AddSnowflakeRelation(middleGrainedDimension, coarseGrainedDimension);

            return new List<IRelation>() { firstRelation, secondRelation };
        }

        public IEnumerable<IRelation> AddSnowflakeRelation(IEnumerable<IDimension> dimensions)
        {
            IDimension previousDim = null;
            var tempRelations = new List<IRelation>();
            foreach (var dim in dimensions)
            {
                if (previousDim != null)
                    tempRelations.Add(AddSnowflakeRelation(previousDim, dim));
                previousDim = dim;
            }

            return tempRelations;
        }

        public IRelation AddOutriggerRelation(IDimension main, IDimension outrigger)
        {
            var relation = new OutriggerRelation(main, outrigger);
            relations.Add(relation);

            return relation;
        }

        public IRelation AddJunkRelation(IDimension junk, IDimension component)
        {
            var relation = new JunkRelation(junk, component);
            relations.Add(relation);

            return relation;
        }

        public IEnumerable<IRelation> AddJunkRelation(IDimension junk, IEnumerable<IDimension> components)
        {
            return AddRelations(junk, components, AddJunkRelation);
        }

        private IEnumerable<IRelation> AddRelations(IDimension root, IEnumerable<IDimension> components, Func<IDimension, IDimension, IRelation> addRelation)
        {
            var tempRelations = new List<IRelation>();
            foreach (var dim in components)
                tempRelations.Add(addRelation(root, dim));

            return tempRelations;
        }
    }
}
