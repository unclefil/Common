﻿using NUnit.Framework;

namespace CoreTechs.Common.Std.Tests
{
    public class DelegateEqualityComparerTests
    {
        [Test]
        public void CanMakeEqualityTest()
        {
            var first = new ExampleClass {Number = 1, Word = "Hat"};
            var second = new ExampleClass {Number = 1, Word = "Sock"};
            var comparer = new DelegateEqualityComparer<ExampleClass>((c1, c2) => c1.Number == c2.Number);

            var defaultEquals = first == second;
            var result = comparer.Equals(first, second);

            Assume.That(defaultEquals, Is.False);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanAlsoRecognizeInequality()
        {
            var first = new ExampleClass { Number = 1, Word = "Hat" };
            var second = new ExampleClass { Number = 2, Word = "Hat" };
            var comparer = new DelegateEqualityComparer<ExampleClass>((c1, c2) => c1.Number == c2.Number);

            var defaultEquals = first == second;
            var result = comparer.Equals(first, second);

            Assume.That(defaultEquals, Is.False);
            Assert.That(result, Is.False);
        }

        [Test]
        public void CanComputeHashOfClass()
        {
            var first = new ExampleClass();
            var comparer = new DelegateEqualityComparer<ExampleClass>((c1, c2) => false, c => 1);

            var result = comparer.GetHashCode(first);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void NullWithNonNullIsAlwaysUnequal()
        {
            var otherClass = new ExampleClass();
            var trueComparer = new DelegateEqualityComparer<ExampleClass>((c1, c2) => true);

            var result = trueComparer.Equals(null, otherClass);

            Assert.That(result, Is.False);
        }

        [Test]
        public void NullsAreEqual()
        {
            var falseComparer = new DelegateEqualityComparer<ExampleClass>((c1, c2) => false);

            var result = falseComparer.Equals(null, null);

            Assert.That(result, Is.True);
        }

        [Test]
        public void SelfIsAlwaysEqualWithSelf()
        {
            var self = new ExampleClass();
            var falseComparer = new DelegateEqualityComparer<ExampleClass>((c1, c2) => false);

            var result = falseComparer.Equals(self, self);

            Assert.That(result, Is.True);
        }

        [Test]
        public void NullsHaveHashOfZero()
        {
            var comparer = new DelegateEqualityComparer<ExampleClass>((c1, c2) => false, c => 1);

            var result = comparer.GetHashCode(null);

            Assert.That(result, Is.EqualTo(0));
        }

        private class ExampleClass
        {
            public int Number { get; set; }
            public string Word { get; set; }
        }
    }
}
