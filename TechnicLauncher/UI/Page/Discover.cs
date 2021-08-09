using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TechnicLauncher.PlatformAPI;
using TechnicLauncher.PlatformAPI.Model;
using TechnicLauncher.Utils;

namespace TechnicLauncher.UI.Page
{
	internal class Discover
	{
		internal static ICollection<PlatformPackInfo> ObtainPackList(string url, IPlatformApi platformApi)
		{
			List<PlatformPackInfo> packs = new(), cachedPacks = new();
			List<string> cachedPackNames = new();

			#region Get and clean modpack ids
			string modpackUrl = "https://www.technicpack.net/modpack/";
			string[] html = NetApiHandler.SendRequestGet(url).Result.Split("\n").Select(x=>x.Trim()).ToArray();

			var ids = html.Where(x => x.Contains(modpackUrl, StringComparison.OrdinalIgnoreCase));
			ids = ids.Select(x => string.Join("", x.SkipWhile(x => x != '"').Skip(1).TakeWhile(x => x != '"'))); // get the full url from attribute
			ids = ids.Select(x => x.Replace(modpackUrl, "", StringComparison.OrdinalIgnoreCase).Split(".")[0]); // remove the unnecessary parts from url to get the pack id
			#endregion

			if (File.Exists(LauncherConstants.Files.FeaturedModpacksFile))
			{
				cachedPacks = JsonSerializer.Deserialize<List<PlatformPackInfo>>(File.ReadAllText(LauncherConstants.Files.FeaturedModpacksFile));
				cachedPackNames = cachedPacks.Select(x => x.Name.ToLower()).ToList();
			}

			bool hasChanged = false;
			// Check for changes in cached featured modpack list.
			foreach (var id in ids) if (!cachedPackNames.Contains(id.ToLower())) hasChanged = true;

			if (hasChanged)
			{
				foreach (var id in ids) packs.Add(platformApi.GetPlatformPackInfo(id));
				File.WriteAllText(LauncherConstants.Files.FeaturedModpacksFile, JsonSerializer.Serialize(packs, LauncherConstants.JsonSerializerOptions));
			}
			else packs = cachedPacks;

			return packs;
		}
	}
}