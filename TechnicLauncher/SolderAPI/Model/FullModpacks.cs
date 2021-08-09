using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TechnicLauncher.SolderAPI.Model
{
	/// <summary>
	/// Model for <i>https://solder.technicpack.net/api/modpack?include=full&amp;cid=[RETRACTED]</i>.
	/// </summary>
	public class FullModpacks
	{
		[JsonPropertyName("modpacks")]
		public Dictionary<string, SolderPackInfo> Modpacks { get; set; }

		[JsonPropertyName("mirror_url")]
		public string MirrorUrl { get; set; }
	}
}
