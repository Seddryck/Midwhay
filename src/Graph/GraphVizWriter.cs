using System;
using System.IO;
using System.Linq;
using System.Text;
using Midwhay.Core.Interface;
using Midwhay.Graph.Formatter;

namespace Midwhay.Graph
{
    /// <summary>
    /// A Writer which generates GraphViz DOT Format files from an Midwhay schema
    /// </summary>
    public class GraphVizWriter
    {
        protected FormatterFactory Formatter { get; set; }

        public GraphVizWriter()
        {
            Formatter = new FormatterFactory();
        }
        /// <summary>
        /// Saves a Viewport into GraphViz DOT Format
        /// </summary>
        /// <param name="g">Viewport to save</param>
        /// <param name="filename">File to save to</param>
        public void Save(IViewport viewport, string filename)
        {
            //Open the Stream for the File
            StreamWriter output = new StreamWriter(filename);

            //Call the other version of Save to do the actual work
            this.Save(viewport, output);
        }

        /// <summary>
        /// Saves a Viewport into GraphViz DOT Format
        /// </summary>
        /// <param name="g">Viewport to save</param>
        /// <param name="output">Stream to save to</param>
        public void Save(IViewport viewport, TextWriter output)
        {
            //Start the Viewport digraph
            output.WriteLine("digraph G {");

            BaseWriterContext context = new BaseWriterContext(viewport, output);

            //Write all the SchemaObject to the Viewport digraph
            foreach (ISchemaObject obj in viewport.Objects)
                output.WriteLine(this.SchemaObjectToDot(obj, context));

            foreach (IRelation relation in viewport.Relations)
                output.WriteLine(this.RelationToDot(relation, context));

            //End the Viewport digraph
            output.WriteLine("}");

            output.Close();
        }

        /// <summary>
        /// Internal Helper Method for converting a SchemaObject into DOT notation
        /// </summary>
        /// <param name="obj">SchemaObject to convert</param>
        /// <param name="context">Writer Context</param>
        /// <returns></returns>
        private String SchemaObjectToDot(ISchemaObject obj, BaseWriterContext context)
        {
            var output = new StringBuilder();

            output.Append(this.SchemaObjectToDot(obj.Name, context));
            var f = Formatter.GetFormatter(obj);
            output.Append(f.GetFormat());
            

            return output.ToString();
        }

        /// <summary>
        /// Internal Helper Method for converting a Relation into DOT notation
        /// </summary>
        /// <param name="t">Triple to convert</param>
        /// <param name="context">Writer Context</param>
        /// <returns></returns>
        private String RelationToDot(IRelation relation, BaseWriterContext context)
        {
            StringBuilder output = new StringBuilder();

            //Output the actual lines that state the relationship between the SchemaObjects
            output.Append(this.SchemaObjectToDot(relation.Origin.Name, context));
            output.Append(" -> ");
            output.Append(this.SchemaObjectToDot(relation.Destination.Name, context));
            var f = Formatter.GetFormatter(relation);
            output.Append(f.GetFormat());

            return output.ToString();
        }

        /// <summary>
        /// Internal Helper method for converting a Node into DOT notation
        /// </summary>
        /// <param name="name">The name Convert</param>
        /// <param name="context">Writer Context</param>
        /// <returns></returns>
        private String SchemaObjectToDot(string name, BaseWriterContext context)
        {
            StringBuilder output = new StringBuilder();
            output.Append("\"");
            //Use the Name
            output.Append(name);
            output.Append("\"");

            return output.ToString();
        }

        /// <summary>
        /// Gets the String representation of the writer which is a description of the syntax it produces
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "GraphViz DOT";
        }
    }
}
