using System;
using System.Linq;
using Midwhay.Core.Interface;
using Midwhay.Core.Viewport;
using NUnit.Framework;

namespace Dwyter.Test.Core.Viewport
{
    [TestFixture]
    public class ConceptualViewportTest
    {
        [Test]
        public void AddRelation_TwoStringsWithEmptyViewport_TwoObjectsCreated()
        {
            var viewport = new ConceptualViewport("no label");
            viewport.AddRelation("my fact", "my dimension");

            Assert.That(viewport.FindObject("my dimension"), Is.Not.Null);
            Assert.That(viewport.FindObject("my dimension"), Is.InstanceOf<IDimension>());
            Assert.That(viewport.FindObject("my fact"), Is.Not.Null);
            Assert.That(viewport.FindObject("my fact"), Is.InstanceOf<IFact>());
        }

        [Test]
        public void AddRelation_TwoStringsWithEmptyViewport_CreateTheTwoObjects()
        {
            var viewport = new ConceptualViewport("no label");
            viewport.AddRelation("my fact", "my dimension");

            Assert.That(viewport.FindRelations("my dimension").Count(), Is.EqualTo(1));
            Assert.That(viewport.FindRelations("my fact").Count(), Is.EqualTo(1));
        }
    }
}
