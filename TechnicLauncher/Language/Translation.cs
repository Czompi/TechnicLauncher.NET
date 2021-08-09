using TechnicLauncher.Model;

namespace TechnicLauncher.Language
{
	public class Translation : Properties
	{
		internal static Translation Parse(Properties properties)
		{
			Translation translation = new Translation();

			translation.Property = properties.Property;

			return translation;
		}
	}
}
