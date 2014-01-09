using System;
using System.IO;
using Midwhay.Core.Interface;

namespace Midwhay.Graph
{
    /// <summary>
    /// Base Class for Writer Context Objects
    /// </summary>
    /// <remarks>
    /// This is not an abstract class since some writers will require only this information or possibly less
    /// </remarks>
    public class BaseWriterContext
        : IWriterContext
    {
        private readonly IViewport viewport;
        /// <summary>
        /// TextWriter being written to
        /// </summary>
        private readonly TextWriter output;
               
        /// <summary>
        /// Creates a new Base Writer Context with default settings
        /// </summary>
        /// <param name="g">Viewport being written</param>
        /// <param name="output">TextWriter being written to</param>
        public BaseWriterContext(IViewport viewport, TextWriter output)
        {
            this.viewport = viewport;
            this.output = output;
        }

        /// <summary>
        /// Gets the Viewport being written
        /// </summary>
        public IViewport Viewport
        {
            get
            {
                return this.viewport;
            }
        }

        /// <summary>
        /// Gets the TextWriter being written to
        /// </summary>
        public TextWriter Output
        {
            get
            {
                return this.output;
            }
        }

    }
}
