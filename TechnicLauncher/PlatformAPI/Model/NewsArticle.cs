using System.Text.Json.Serialization;

namespace TechnicLauncher.PlatformAPI.Model
{
	public class NewsArticle
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("username")]
		public string Username { get; set; }
		
		[JsonPropertyName("avatar")]
		public string Avatar { get; set; }
		
		[JsonPropertyName("title")]
		public string Title { get; set; }
		
		[JsonPropertyName("content")]
		public string Content { get; set; }
		
		[JsonPropertyName("date")]
		public long Date { get; set; }

		[JsonPropertyName("url")]
		public string Url { get; set; }
	}
}