using NUnit.Framework;

namespace CoreTechs.Common.Std.Tests
{
    public class BeepScopeTests
    {
        [Test]
        public void CanDisposeQuickly()
        {
            for (var i = 0; i < 100; i++)
                using (new BeepScope()) { }
        }
        
    }
}