using System;

namespace Persistence
{
	public class StorageException : Exception
	{
		public StorageException(string message) : base(message) { }
	}
}