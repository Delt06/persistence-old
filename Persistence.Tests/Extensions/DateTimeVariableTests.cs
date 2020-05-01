using System;
using NUnit.Framework;
using Persistence.Extensions;

namespace Persistence.Tests.Extensions
{
    [TestFixture]
    public class DateTimeVariableTests
    {
        private IStorage _storage;

        [SetUp]
        public void SetUp()
        {
            _storage = new MemoryStorage();
        }
        
        [Test]
        [TestCase(1960, 5, 3, 7, 1, 15)]
        [TestCase(2000, 1, 1, 0, 0, 0)]
        [TestCase(2010, 5, 10, 13, 24, 10)]
        public void VariableGet_WhenWasNotSet_ReturnsDefaultValue(int year, int month, int day, int hour, int minute, int second)
        {
            var defaultValue = new DateTime(year, month, day, hour, minute, second);
            var variable = new DateTimeVariable("Var", defaultValue);
            
            Assert.That(variable.Get(_storage), Is.EqualTo(defaultValue));
        }

        [Test]
        [TestCase(1960, 5, 3, 7, 1, 15)]
        [TestCase(2000, 1, 1, 0, 0, 0)]
        [TestCase(2010, 5, 10, 13, 24, 10)]
        public void VariableGet_WhenSet_ReturnsSetValue(int year, int month, int day, int hour, int minute, int second)
        {
            var variable = new DateTimeVariable("Var");

            var setValue = new DateTime(year, month, day, hour, minute, second);
            variable.Set(_storage, setValue);
            
            Assert.That(variable.Get(_storage), Is.EqualTo(setValue));
        }
    }
}