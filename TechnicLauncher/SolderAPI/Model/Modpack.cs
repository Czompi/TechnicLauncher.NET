using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TechnicLauncher.SolderAPI.Model
{
	public class Modpack
	{
		[JsonPropertyName("minecraft")]
		public string Minecraft { get; set; }

		[JsonPropertyName("java")]
		public string Java { get; set; }

		[JsonPropertyName("memory")]
		public string Memory { get; set; }

		[JsonPropertyName("mods")]
		public List<Mod> Mods { get; set; }
	}
}