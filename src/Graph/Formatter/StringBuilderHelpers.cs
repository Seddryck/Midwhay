using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midwhay.Graph.Formatter
{
    public static class StringBuilderHelpers
    {
        public static StringBuilder AppendFormatIfNotNull(this StringBuilder sb, string format, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return sb;

            return sb.AppendFormat(format, value);
        }
    }
}
