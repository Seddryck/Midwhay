using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Midwhay.Core;
using Midwhay.Core.Interface;
using Midwhay.Graph;
using NUnit.Framework;

namespace Midwhay.Testing.Graph
{
    [TestFixture]
    public class GraphVizGeneratorTest
    {
        private readonly string pathGraphviz = @"C:\Program Files (x86)\Graphviz2.34\bin\";
        private readonly string fileExtension = "svg";
        private readonly bool openFile = true;

        private string GetFileName()
        {
            StackTrace stackTrace = new StackTrace();
            MethodBase methodBase = stackTrace.GetFrame(1).GetMethod();
            return @"\" + methodBase.Name + DateTime.Now.Ticks.ToString() + "." + fileExtension; 
        }

        [Test]
        public void Generate_ComplexModelSchema_ExistingFile()
        {
            //Define viewport
            var viewport = Model.Get();

            //Setup Graphviz objects
            var generator = new GraphVizGenerator(fileExtension, pathGraphviz);
            var filename = GetFileName();

            //Method to test
            generator.Generate(viewport, filename, openFile);

            //Assertions
            Assert.That(File.Exists(filename));
            Assert.That((new FileInfo(filename)).Length, Is.GreaterThan(0));
        }

    }
}
