using System;
using System.Linq;
using NUnit.Framework;

namespace CoreTechs.Common.Std.Tests.Enumerable
{
    public class RangeTests
    {
        [Test]
        public void CanGenerateRangeOfInts()
        {
            var range = 1.To(5);

            CollectionAssert.AreEqual(new[]{1,2,3,4,5},range);
        }

        [Test]
        public void CanGenerateRangeOfIntsDescending()
        {
            var range = 10.To(5);

            CollectionAssert.AreEqual(new[]{10,9,8,7,6,5},range);
        }

        [Test]
        public void CanGenerateRangeOfDates()
        {
            var range = DateTime.Today.To(today => today + 3.Days(), 1.Days());

            CollectionAssert.AreEqual(new[]
            {
                DateTime.Today,
                DateTime.Today + 1.Days(),
                DateTime.Today + 2.Days(),
                DateTime.Today + 3.Days(),

            }, range);

        }

        [Test]
        public void CanGenerateRangeOfDatesDesc()
        {

            var range = DateTime.Today.To(today => today - 3.Days(), 1.Days());

            CollectionAssert.AreEqual(new[]
            {
                DateTime.Today,
                DateTime.Today - 1.Days(),
                DateTime.Today - 2.Days(),
                DateTime.Today - 3.Days(),

            }, range);

        }

        [Test]
        public void CanGenerateRangeOfAllChars()
        {
            var count = Characters.All.Count();

            Assert.AreEqual(65536, count);
        }

        [Test]
        public void CanGenerateRangeOfChars()
        {
            var range = 'a'.To('d');

            CollectionAssert.AreEqual(new[] {'a', 'b', 'c', 'd'}, range);
        }

        [Test]
        public void CanGenerateRangeOfCharsDesc()
        {
            var range = 'Z'.To('T');
            CollectionAssert.AreEqual(new[] {'Z', 'Y', 'X', 'W', 'V', 'U', 'T'}, range);
        }
    }
}