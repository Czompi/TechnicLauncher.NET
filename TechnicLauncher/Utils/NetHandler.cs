using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TechnicLauncher.Utils
{
	internal class NetHandler
	{
		#region SendRequest
		public static ResponseData SendRequest(Uri uri, RequestMethod method, string? user_agent = null, string? content_type = null, string? post = null, params string[] additional_headers)
		{
			Debug.WriteLine($"{uri}");
			HttpClientHandler handler = new()
			{
				UseProxy = true,
				Proxy = HttpClient.DefaultProxy
			};
			HttpClient httpClient = new(handler);
			HttpRequestMessage httpRequestMessage = new()
			{
				Method = new HttpMethod($"{method}"),
				RequestUri = uri
			};

			string? result;


			if (user_agent != null)
			{
				httpRequestMessage.Headers.UserAgent.Clear();
				httpRequestMessage.Headers.UserAgent.ParseAdd(user_agent);
			}

			if (post != null) httpRequestMessage.Content = new StringContent(post, System.Text.Encoding.UTF8, content_type ?? "text/plain");

			if (additional_headers.Length > 0 && additional_headers.Length % 2 == 0)
			{
				for (int i = 0; i < additional_headers.Length; i += 2)
				{
					if (additional_headers[i].ToLower() == "content-type") continue;
					if (additional_headers[i].ToLower() == "user-agent") continue;
					httpRequestMessage.Headers.Add(additional_headers[i], additional_headers[i + 1]);
				}
			}
			var response = httpClient.SendAsync(httpRequestMessage).GetAwaiter().GetResult();
			result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return new ResponseData
			{
				Result = result,
				Headers = response.Headers,
				StatusCode = response.StatusCode
			};
		}
		public static ResponseData SendRequest(string uri, RequestMethod method, string? user_agent = null, string? content_type = null, string? post = null, params string[] additional_headers) => SendRequest(new Uri(uri), method, user_agent, content_type, post, additional_headers);
		#endregion
		
		#region SendRequestGet
		public static ResponseData SendRequestGet(Uri uri, string? user_agent = null, params string[] additional_headers) => SendRequest(uri, RequestMethod.GET, user_agent, null, null, additional_headers);
		public static ResponseData SendRequestGet(string uri, string? user_agent = null, params string[] additional_headers) => SendRequestGet(new Uri(uri), user_agent, additional_headers);
		#endregion
	}
}
