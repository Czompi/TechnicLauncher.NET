using System;

namespace TechnicLauncher.Model
{
	internal class LauncherInfo
	{
		public static Guid ClientId { get; set; } = Guid.NewGuid();
	}
}