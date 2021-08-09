using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TechnicLauncher.Model;

namespace TechnicLauncher.PlatformAPI.Model
{
	public class PlatformPackInfo
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("displayName")]
		public string DisplayName { get; set; }

		[JsonPropertyName("user")]
		public string User { get; set; }

		[JsonPropertyName("url")]
		public string Url { get; set; }

		[JsonPropertyName("platformUrl")]
		public string PlatformUrl { get; set; }

		[JsonPropertyName("minecraft")]
		public string Minecraft { get; set; }

		[JsonPropertyName("ratings")]
		public int Ratings { get; set; }

		[JsonPropertyName("downloads")]
		public int Downloads { get; set; }

		[JsonPropertyName("runs")]
		public int Runs { get; set; }

		[JsonPropertyName("description")]
		public string Description { get; set; }

		[JsonPropertyName("tags")]
		public string Tags { get; set; }

		[JsonPropertyName("isServer")]
		public bool IsServer { get; set; }

		[JsonPropertyName("isOfficial")]
		public bool IsOfficial { get; set; }

		[JsonPropertyName("version")]
		public string Version { get; set; }

		[JsonPropertyName("forceDir")]
		public bool ForceDir { get; set; }

		[JsonPropertyName("feed")]
		public List<Feed> Feed { get; set; }

		[JsonPropertyName("icon")]
		public Resource Icon { get; set; }

		[JsonPropertyName("logo")]
		public Resource Logo { get; set; }

		[JsonPropertyName("background")]
		public Resource Background { get; set; }

		[JsonPropertyName("discordServerId")]
		public string DiscordServerId { get; set; }

		[JsonPropertyName("serverPackUrl")]
		public string ServerPackUrl { get; set; }

		[JsonPropertyName("solder")]
		public string Solder { get; set; }

	}
}
