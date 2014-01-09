using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Graph
{
    /// <summary>
    /// A Class which creates GraphViz Graphs entirely dynamically
    /// </summary>
    public class GraphVizGenerator
    {
        private String format = "svg";
        private String graphvizdir = String.Empty;

        /// <summary>
        /// Creates a new GraphVizGenerator
        /// </summary>
        /// <param name="format">Format for the Output (svg is default)</param>
        /// <remarks>Only use this form if you're certain that dot.exe is in your PATH otherwise the code will throw an error</remarks>
        public GraphVizGenerator(String format)
        {
            this.LocateGraphViz();
            this.format = format;
        }

        /// <summary>
        /// Creates a new GraphVizGenerator
        /// </summary>
        /// <param name="format">Format for the Output</param>
        /// <param name="gvdir">Directory in which GraphViz is installed</param>
        public GraphVizGenerator(String format, String gvdir)
            : this(format)
        {
            if (gvdir.LastIndexOf('\\') != gvdir.Length)
            {
                this.graphvizdir = gvdir + "\\";
            }
            else
            {
                this.graphvizdir = gvdir;
            }
        }

        /// <summary>
        /// Gets/Sets the Format for the Output
        /// </summary>
        public String Format
        {
            get
            {
                return this.format;
            }
            set
            {
                this.format = value;
            }
        }

        /// <summary>
        /// Generates GraphViz Output for the given Viewport
        /// </summary>
        /// <param name="g">Viewport to generated GraphViz Output for</param>
        /// <param name="filename">File you wish to save the Output to</param>
        /// <param name="open">Whether you want to open the Output in the default application (according to OS settings) for the filetype after it is Created</param>
        public void Generate(IViewport report, String filename, bool open)
        {
            //Prepare the Process
            ProcessStartInfo start = new ProcessStartInfo();
            if (!graphvizdir.Equals(String.Empty))
            {
                start.FileName = this.graphvizdir + "dot.exe";
            }
            else
            {
                start.FileName = "dot.exe";
            }
            start.Arguments = "-T" + this.format;
            start.UseShellExecute = false;
            start.RedirectStandardInput = true;
            start.RedirectStandardOutput = true;

            //Prepare the GraphVizWriter and Streams
            GraphVizWriter gvzwriter = new GraphVizWriter();
            using (BinaryWriter writer = new BinaryWriter(new FileStream(filename, FileMode.Create)))
            {
                //Start the Process
                Process gvz = new Process();
                gvz.StartInfo = start;
                gvz.Start();

                //Write to the Standard Input
                gvzwriter.Save(report, gvz.StandardInput);

                //Read the Standard Output
                byte[] buffer = new byte[4096];
                using (BinaryReader reader = new BinaryReader(gvz.StandardOutput.BaseStream))
                {
                    while (true)
                    {
                        int read = reader.Read(buffer, 0, buffer.Length);
                        if (read == 0) break;
                        writer.Write(buffer, 0, read);
                    }
                    reader.Close();
                }
                writer.Close();
                gvz.Close();
            }

            //Open if requested
            if (open)
            {
                Process.Start(filename);
            }
        }

        /// <summary>
        /// Internal Helper Method for locating the GraphViz Directory using the PATH Environment Variable
        /// </summary>
        private void LocateGraphViz()
        {
            String path = Environment.GetEnvironmentVariable("path");
            String[] folders = path.Split(';');
            foreach (String folder in folders)
            {
                if (File.Exists(folder + "dot.exe"))
                {
                    this.graphvizdir = folder;
                    return;
                }
                else if (File.Exists(folder + "\\dot.exe"))
                {
                    this.graphvizdir = folder + "\\";
                    return;
                }
            }
        }
    }
}