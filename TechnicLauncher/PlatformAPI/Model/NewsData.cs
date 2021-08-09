using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TechnicLauncher.PlatformAPI.Model
{
	public class NewsData
	{
		[JsonPropertyName("articles")]
		public List<NewsArticle> Articles { get; set; }
	}
}
