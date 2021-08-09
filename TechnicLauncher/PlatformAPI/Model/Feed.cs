using System.Text.Json.Serialization;

namespace TechnicLauncher.PlatformAPI.Model
{
	public class Feed
	{
		[JsonPropertyName("user")]
		public string User { get; set; }

		[JsonPropertyName("date")]
		public int Date { get; set; }

		[JsonPropertyName("content")]
		public string Content { get; set; }

		[JsonPropertyName("avatar")]
		public string Avatar { get; set; }

		[JsonPropertyName("url")]
		public string Url { get; set; }
	}


}
