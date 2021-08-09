using System;
using System.Text.Json;
using TechnicLauncher.Exceptions;
using TechnicLauncher.Utils;

namespace TechnicLauncher.SolderAPI.Model
{
	internal class SolderPackApi : ISolderPackApi
	{
		private string BaseUrl { get; }
		private string ModpackSlug { get; }
		private Guid ClientId { get; }
		private string MirrorUrl { get; }

		public SolderPackApi(string baseUrl, string modpackSlug, Guid clientId, string mirrorUrl)
		{
			BaseUrl = baseUrl;
			ModpackSlug = modpackSlug;
			ClientId = clientId;
			MirrorUrl = mirrorUrl;
		}

		public SolderPackInfo? GetPackInfoForBulk() => GetPackInfo();

		public SolderPackInfo? GetPackInfo()
		{
			SolderPackInfo? info = JsonSerializer.Deserialize<SolderPackInfo>(NetApiHandler.SendRequestGet($"{BaseUrl}modpack/{ModpackSlug}?cid={ClientId:D}").Result);
			info?.SetSolder(this);
			return info;
		}

		public Modpack GetPackBuild(string build)
		{
			try
			{
				Modpack? pack = JsonSerializer.Deserialize<Modpack>(NetApiHandler.SendRequestGet($"{BaseUrl}modpack/{ModpackSlug}/{build}?cid={ClientId:D}").Result);
				
				if (pack != null)
				{
					return pack;
				}
			}
			catch (Exception ex)
			{
				throw new BuildInaccessibleException(ModpackSlug, build, ex);
			}

			throw new BuildInaccessibleException(ModpackSlug, build);
		}
	}
}