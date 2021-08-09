using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechnicLauncher.SolderAPI.Model;
using TechnicLauncher.Utils;

namespace TechnicLauncher.SolderAPI.Http
{
	public class HttpSolderApi : ISolderApi
	{
		public string PlatformUrl { get; }
		public Guid ClientId { get; }

		public HttpSolderApi(string platformUrl, Guid clientId)
		{
			PlatformUrl = platformUrl;
			ClientId = clientId;
		}

		public ISolderPackApi GetSolderPack(string solderRoot, string modpackSlug, string mirrorUrl) => new SolderPackApi(solderRoot, modpackSlug, ClientId, mirrorUrl);
		public ICollection<SolderPackInfo> GetPublicSolderPacks(string solderRoot) => InternalPublicSolderPacks(solderRoot, this);
		public ICollection<SolderPackInfo> InternalPublicSolderPacks(string solderRoot, ISolderApi packFactory)
		{
			List<SolderPackInfo> allPackApis = new();

			FullModpacks? technic = JsonSerializer.Deserialize<FullModpacks>(NetApiHandler.SendRequestGet($"{solderRoot}modpack?include=full&cid={ClientId}").Result);
			foreach (SolderPackInfo info in technic?.Modpacks?.Values)
			{
				ISolderPackApi solder = packFactory.GetSolderPack(solderRoot, info.Name, technic.MirrorUrl);
				info.SetSolder(solder);
				allPackApis.Add(info);
			}

			return allPackApis;
		}
	}
}
