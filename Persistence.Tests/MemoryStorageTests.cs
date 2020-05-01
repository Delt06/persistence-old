namespace Persistence.Tests
{
    public sealed class MemoryStorageTests : StorageTests
    {
        protected override IStorage CreateStorage()
        {
            return new MemoryStorage();
        }
    }
}