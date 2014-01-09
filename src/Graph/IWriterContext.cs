using System;
using System.IO;
using System.Linq;
using Midwhay.Core.Interface;

namespace Midwhay.Graph
{
    public interface IWriterContext
    {
        /// <summary>
        /// Gets the Viewport being written
        /// </summary>
        IViewport Viewport
        {
            get;
        }

        /// <summary>
        /// Gets the TextWriter being written to
        /// </summary>
        TextWriter Output
        {
            get;
        }

    }
}
