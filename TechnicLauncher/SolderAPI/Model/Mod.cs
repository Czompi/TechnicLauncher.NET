using System.Text.Json.Serialization;
using TechnicLauncher.Model;

namespace TechnicLauncher.SolderAPI.Model
{
	public class Mod : Resource
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("version")]
		public string Version { get; set; }
	}
}