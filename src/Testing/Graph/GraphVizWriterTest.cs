using System;
using System.IO;
using System.Linq;
using Midwhay.Core.Viewport;
using Midwhay.Graph;
using NUnit.Framework;

namespace Midwhay.Testing.Graph
{
    [TestFixture]
    public class GraphVizWriterTest
    {
        [Test]
        public void Save_OneDimension_OneBoxWithLabel()
        {
            var viewport = new LogicalViewport("First viewport");
            viewport.AddDimension("Customer");
            var writer = new GraphVizWriter();
            var text = new StringWriter();

            writer.Save(viewport, text);
            
            Assert.That(text.ToString(), Is.StringContaining("box"));
            Assert.That(text.ToString(), Is.StringContaining("Customer"));
        }

        [Test]
        public void Save_OneDimension_OneEllipseWithLabel()
        {
            var viewport = new LogicalViewport("First viewport");
            viewport.AddFact("Internet Sales");
            var writer = new GraphVizWriter();
            var text = new StringWriter();

            writer.Save(viewport, text);

            Assert.That(text.ToString(), Is.StringContaining("ellipse"));
            Assert.That(text.ToString(), Is.StringContaining("Internet Sales"));
        }

        [Test]
        public void Save_TwoDimensionsAndOneFactWithRelations_ExistingFile()
        {
            var viewport = new LogicalViewport("First viewport");
            var dimProduct = viewport.AddDimension("Product");
            var dimPromotion = viewport.AddDimension("Promotion");
            var factInternetSales = viewport.AddFact("Internet Sales");
            viewport.AddRelation(factInternetSales, dimProduct);
            viewport.AddRelation(factInternetSales, dimPromotion);
            var writer = new GraphVizWriter();

            var text = new StringWriter();

            writer.Save(viewport, text);

            Assert.That(text.ToString(), Is.StringContaining("\"Internet Sales\" -> \"Product\""));
            Assert.That(text.ToString(), Is.StringContaining("\"Internet Sales\" -> \"Promotion\""));
        }
    }
}
