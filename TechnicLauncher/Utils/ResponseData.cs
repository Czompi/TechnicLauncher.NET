using System.Net.Http.Headers;

namespace TechnicLauncher.Utils
{
	internal class ResponseData
	{
		public string Result { get; set; }
		public object StatusCode { get; set; }
		public HttpResponseHeaders Headers { get; internal set; }
	}
}