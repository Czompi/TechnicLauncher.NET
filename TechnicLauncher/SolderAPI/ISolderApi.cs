using System.Collections.Generic;
using TechnicLauncher.SolderAPI.Model;

namespace TechnicLauncher.SolderAPI
{
	public interface ISolderApi
	{
		public ISolderPackApi GetSolderPack(string solderRoot, string modpackSlug, string mirrorUrl);

		public ICollection<SolderPackInfo> GetPublicSolderPacks(string solderRoot);

		public ICollection<SolderPackInfo> InternalPublicSolderPacks(string solderRoot, ISolderApi packFactory);
	}
}