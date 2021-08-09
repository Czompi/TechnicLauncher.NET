using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicLauncher.Utils
{
	internal class NetApiHandler
	{
		#region SendRequest
		public static ResponseData SendRequest(Uri uri, RequestMethod method, string? content_type = null, string? post = null, params string[] additional_headers) => NetHandler.SendRequest(uri, method, LauncherConstants.GetUserAgent(), content_type, post, additional_headers);
		public static ResponseData SendRequest(string uri, RequestMethod method, string? content_type = null, string? post = null, params string[] additional_headers) => NetHandler.SendRequest(new Uri(uri), method, LauncherConstants.GetUserAgent(), content_type, post, additional_headers);
		#endregion

		#region SendRequestGet
		public static ResponseData SendRequestGet(Uri uri, params string[] additional_headers) => NetHandler.SendRequest(uri, RequestMethod.GET, LauncherConstants.GetUserAgent(), null, null, additional_headers);

		internal static Stream? GetStream(string? url) => GetStream(new Uri(url));
		internal static Stream? GetStream(Uri url)
		{
			try
			{
				return new MemoryStream(new System.Net.WebClient().DownloadData(url));
			}
			catch (Exception)
			{
				return null;
			}

		}

		public static ResponseData SendRequestGet(string uri, params string[] additional_headers) => NetHandler.SendRequestGet(new Uri(uri), LauncherConstants.GetUserAgent(), additional_headers);

		#endregion

		internal static bool PingURL(string url)
		{
			var conn = NetHandler.SendRequest(url, RequestMethod.HEAD, LauncherConstants.GetUserAgent());

			var responseCode = (int)conn.StatusCode;
			var responseFamily = responseCode / 100;

			if (responseFamily == 3)
			{
				Uri? redirectUrl = conn.Headers.Location;
				if (redirectUrl != null)
				{
					conn = NetHandler.SendRequest(redirectUrl, RequestMethod.HEAD, LauncherConstants.GetUserAgent());
					responseCode = (int)conn.StatusCode;
					responseFamily = responseCode / 100;
				}
			}

			return responseFamily == 2;
		}
	}
}
