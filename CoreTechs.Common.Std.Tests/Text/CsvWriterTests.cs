using System.IO;
using CoreTechs.Common.Std.Text;
using NUnit.Framework;

namespace CoreTechs.Common.Std.Tests.Text
{
    public class CsvWriterTests
    {
        [Test]
        public void CanWriteNullValue()
        {
            var writer = new StringWriter();
            var csv = new CsvWriter(writer);
            csv.AddFields(null, null);

            Assert.AreEqual(",", writer.ToString());

        }

    }
}
