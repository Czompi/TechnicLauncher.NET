using System;
using System.Runtime.Serialization;

namespace TechnicLauncher.Exceptions
{
	[Serializable]
	internal class BuildInaccessibleException : Exception
	{
		private string modpackSlug;
		private string build;

		public BuildInaccessibleException()
		{
		}

		public BuildInaccessibleException(string? message) : base(message)
		{
		}

		public BuildInaccessibleException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		public BuildInaccessibleException(string displayName, string build, Exception? innerException=null) : base((innerException != null) ?
			$"An error was raised while attempting to read pack info for modpack {displayName}, build {build}: {innerException.Message}" :
			$"The pack host returned unrecognizable garbage while attempting to read pack info for modpack {displayName}, build {build}.")
		{
		}

		protected BuildInaccessibleException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}