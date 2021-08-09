using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TechnicLauncher.SolderAPI.Model
{
	public class SolderPackInfo
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("display_name")]
		public string DisplayName { get; set; }

		[JsonPropertyName("url")]
		public string Url { get; set; }

		[JsonPropertyName("icon")]
		public string Icon { get; set; }

		[JsonPropertyName("icon_md5")]
		public string IconMd5 { get; set; }

		[JsonPropertyName("logo")]
		public string Logo { get; set; }

		[JsonPropertyName("logo_md5")]
		public string LogoMd5 { get; set; }

		[JsonPropertyName("background")]
		public string Background { get; set; }

		internal void SetSolder(ISolderPackApi solderPackApi)
		{
			//throw new NotImplementedException();
		}

		[JsonPropertyName("background_md5")]
		public string BackgroundMd5 { get; set; }

		[JsonPropertyName("recommended")]
		public string Recommended { get; set; }

		[JsonPropertyName("latest")]
		public string Latest { get; set; }

		[JsonPropertyName("builds")]
		public List<string> Builds { get; set; }
	}
}
