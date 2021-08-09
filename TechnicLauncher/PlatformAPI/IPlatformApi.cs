
using TechnicLauncher.PlatformAPI.Model;

namespace TechnicLauncher.PlatformAPI
{
	public interface IPlatformApi
	{
		public string GetPlatformUri(string packSlug);

		public PlatformPackInfo? GetPlatformPackInfoForBulk(string packSlug);

		public PlatformPackInfo? GetPlatformPackInfo(string packSlug);

		public void IncrementPackRuns(string packSlug);

		public void IncrementPackInstalls(string packSlug);

		public NewsData? GetNews();
	}
}