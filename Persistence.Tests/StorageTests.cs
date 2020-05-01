using NUnit.Framework;

namespace Persistence.Tests
{
    [TestFixture]
    public abstract class StorageTests
    {
        private IStorage _storage;

        [SetUp]
        public void SetUp()
        {
            _storage = CreateStorage();
        }
        
        protected abstract IStorage CreateStorage();

        [Test]
        [TestCase(0), TestCase(1), TestCase(-1)]
        public void GetInt_NotSet_ReturnsDefault(int defaultValue)
        {
            Assert.That(_storage.GetInt("key", defaultValue), Is.EqualTo(defaultValue));
        }
        
        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        public void GetInt_WasSet_ReturnsSetValue(int defaultValue, int setValue)
        {
            _storage.SetInt("key", setValue);
            
            Assert.That(_storage.GetInt("key", defaultValue), Is.EqualTo(setValue));
        }
        
        [Test]
        [TestCase(true), TestCase(false)]
        public void GetBool_NotSet_ReturnsDefault(bool defaultValue)
        {
            Assert.That(_storage.GetBool("key", defaultValue), Is.EqualTo(defaultValue));
        }
        
        [Test]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void GetBool_WasSet_ReturnsSetValue(bool defaultValue, bool setValue)
        {
            _storage.SetBool("key", setValue);
            
            Assert.That(_storage.GetBool("key", defaultValue), Is.EqualTo(setValue));
        }
        
        [Test]
        [TestCase(0f), TestCase(-1f), TestCase(1f)]
        public void GetFloat_NotSet_ReturnsDefault(float defaultValue)
        {
            Assert.That(_storage.GetFloat("key", defaultValue), Is.EqualTo(defaultValue));
        }
        
        [Test]
        [TestCase(0f, 0f)]
        [TestCase(0f, 1f)]
        [TestCase(1f, 0f)]
        public void GetFloat_WasSet_ReturnsSetValue(float defaultValue, float setValue)
        {
            _storage.SetFloat("key", setValue);

            Assert.That(_storage.GetFloat("key", defaultValue), Is.EqualTo(setValue));
        }
        
        [Test]
        [TestCase(""), TestCase(" "), TestCase("abc")]
        public void GetString_NotSet_ReturnsDefault(string defaultValue)
        {
            Assert.That(_storage.GetString("key", defaultValue), Is.EqualTo(defaultValue));
        }
        
        [Test]
        [TestCase("a", "a")]
        [TestCase("", "a")]
        [TestCase("a", "")]
        public void GetFloat_WasSet_ReturnsSetValue(string defaultValue, string setValue)
        {
            _storage.SetString("key", setValue);

            Assert.That(_storage.GetString("key", defaultValue), Is.EqualTo(setValue));
        }


        [Test]
        public void Get_NullKey_ThrowsArgumentNullException()
        {
            Assert.That(() => _storage.GetInt(null), Throws.ArgumentNullException);
            Assert.That(() => _storage.GetBool(null), Throws.ArgumentNullException);
            Assert.That(() => _storage.GetFloat(null), Throws.ArgumentNullException);
            Assert.That(() => _storage.GetString(null), Throws.ArgumentNullException);
        }
        
        [Test]
        public void Set_NullKey_ThrowsArgumentNullException()
        {
            Assert.That(() => _storage.SetInt(null, default), Throws.ArgumentNullException);
            Assert.That(() => _storage.SetBool(null, default), Throws.ArgumentNullException);
            Assert.That(() => _storage.SetFloat(null, default), Throws.ArgumentNullException);
            Assert.That(() => _storage.SetString(null, default), Throws.ArgumentNullException);
        }
    }
}