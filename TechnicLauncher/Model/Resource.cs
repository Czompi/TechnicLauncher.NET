using System.Text.Json.Serialization;

namespace TechnicLauncher.Model
{
	public class Resource
	{
		[JsonPropertyName("url")]
		public string Url { get; set; }

		[JsonPropertyName("md5")]
		public string Md5 { get; set; }
	}


}
