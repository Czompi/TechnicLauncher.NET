using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TechnicLauncher.UI.Page
{
	public partial class NewsPanel : Panel
	{
		private MainWindow MainWindow { get; }
		private string Arguments { get; }

		public NewsPanel()
		{
			InitializeComponent();
		}
		public NewsPanel(MainWindow mainWindow, string args = "") : this()
		{
			this.MainWindow = mainWindow;
			this.Arguments = args;
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
