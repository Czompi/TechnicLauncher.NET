using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechnicLauncher.PlatformAPI.Model;
using TechnicLauncher.Utils;

namespace TechnicLauncher.PlatformAPI.Http
{
	public class HttpPlatformApi: IPlatformApi
	{
		private string PlatformUrl { get; }
		private int LauncherBuild { get; }

		public HttpPlatformApi(string platformUrl, int launcherBuild)
		{
			PlatformUrl = platformUrl;
			LauncherBuild = launcherBuild;
		}

		public string GetPlatformUri(string packSlug) => $"{PlatformUrl}modpack/{packSlug}?build={LauncherBuild}";

		public PlatformPackInfo? GetPlatformPackInfoForBulk(string packSlug) => GetPlatformPackInfo(packSlug);

		public PlatformPackInfo? GetPlatformPackInfo(string packSlug) => JsonSerializer.Deserialize<PlatformPackInfo>(NetApiHandler.SendRequestGet(GetPlatformUri(packSlug)).Result);

		public void IncrementPackRuns(string packSlug) => NetApiHandler.PingURL($"{PlatformUrl}modpack/{packSlug}/stat/run?build={LauncherBuild}");

		public void IncrementPackInstalls(string packSlug) => NetApiHandler.PingURL($"{PlatformUrl}modpack/{packSlug}/stat/install?build={LauncherBuild}");

		public NewsData? GetNews() => JsonSerializer.Deserialize<NewsData>(NetApiHandler.SendRequestGet($"{PlatformUrl}news?build={LauncherBuild}").Result);
	}
}
