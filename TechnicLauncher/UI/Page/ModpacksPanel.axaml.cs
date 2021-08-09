using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace TechnicLauncher.UI.Page
{
	public partial class ModpacksPanel : Panel
	{
		private MainWindow MainWindow { get; }
		private string Arguments { get; }

		public ModpacksPanel()
		{
			InitializeComponent();
		}
		public ModpacksPanel(MainWindow mainWindow, string args = "") : this()
		{
			this.MainWindow = mainWindow;
			this.Arguments = args;
			if (Arguments != null && Arguments.Length >= 3) IgniteSearch(Arguments);
		}

		private void IgniteSearch(string arguments)
		{
			throw new NotImplementedException();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
