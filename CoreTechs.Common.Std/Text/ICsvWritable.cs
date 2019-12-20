using System.Collections.Generic;

namespace CoreTechs.Common.Std.Text
{
    public interface ICsvWritable
    {
        IEnumerable<object> GetCsvHeadings();
        IEnumerable<object> GetCsvFields();
    }
}