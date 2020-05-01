using NUnit.Framework;

namespace Persistence.Tests
{
    [TestFixture]
    public class PersistentVariableTests
    {
        private IStorage _storage;
        private IVariable<int> _variable;

        [SetUp]
        public void SetUp()
        {
            _storage = new MemoryStorage();
            _variable = new IntVariable(VariableName, DefaultValue);
        }

        [Test]
        public void Get_WasNotSet_ReturnsDefaultValue()
        {
            var variable1 = new IntVariable("Var1", 1);
            var variable2 = new StringVariable("Var2", "default");
            
            Assert.That(variable1.DefaultValue, Is.EqualTo(1));
            Assert.That(variable1.Get(_storage), Is.EqualTo(variable1.DefaultValue));
            
            Assert.That(variable2.DefaultValue, Is.EqualTo("default"));
            Assert.That(variable2.Get(_storage), Is.EqualTo(variable2.DefaultValue));
        }

        [Test]
        [TestCase(0), TestCase(1), TestCase(-1)]
        public void Get_WasSet_ReturnsSetValue(int value)
        {
            _variable.Set(_storage, value);
            
            Assert.That(_variable.Get(_storage), Is.EqualTo(value));
        }

        [Test]
        [TestCase(0), TestCase(1), TestCase(-1)]
        public void Get_WasSet_StorageReturnsValue(int value)
        {
            _variable.Set(_storage, value);
            
            Assert.That(_storage.GetInt(_variable.Name), Is.EqualTo(value));
        }

        [Test]
        public void Ctor_NullName_ThrowsArgumentNullException()
        {
            Assert.That(() => new IntVariable(null), Throws.ArgumentNullException);
            Assert.That(() => new BoolVariable(null), Throws.ArgumentNullException);
            Assert.That(() => new FloatVariable(null), Throws.ArgumentNullException);
            Assert.That(() => new StringVariable(null), Throws.ArgumentNullException);
        }

        private const string VariableName = "Var";
        private const int DefaultValue = 1;
    }
}