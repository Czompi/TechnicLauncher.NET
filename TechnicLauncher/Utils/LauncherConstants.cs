using System;
using System.IO;
using System.Text.Json;

namespace TechnicLauncher.Utils
{
	internal class LauncherConstants
	{
		internal static int BuildNumber => 696;
		internal static string? GetUserAgent() => "Mozilla/5.0 (Java) TechnicLauncher.NET/4." + BuildNumber;

		#region Urls
		public static string TechnicURL => "https://mirror.technicpack.net/Technic/";
		public static string TechnicVersions => $"{TechnicURL}version/";
		public static string TechnicFmlLibRepo => $"{TechnicURL}lib/fml/";
		public static string TechnicForgeRepoUrl => $"{TechnicURL}lib/";

		public static string PlatformApiUrl => "https://api.technicpack.net/";

		public static string SolderApiUrl => "https://solder.technicpack.net/api/";

		public static string DiscoverUrl => $"{PlatformApiUrl}/discover";

		public static JsonSerializerOptions JsonSerializerOptions => new()
		{
			WriteIndented = true
		};

		#endregion

		public static class Files
		{
			public static string HomeDirectory => $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".technic")}{Path.DirectorySeparatorChar}";
			public static string CacheDirectory => $"{Path.Combine(HomeDirectory, "cache")}{Path.DirectorySeparatorChar}";
			public static string FeaturedModpacksFile => $"{CacheDirectory}featuredmodpacks.json";
		}
	}
}