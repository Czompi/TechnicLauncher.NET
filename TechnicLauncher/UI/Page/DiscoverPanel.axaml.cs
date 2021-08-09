using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using TechnicLauncher.Utils;

namespace TechnicLauncher.UI.Page
{
	public partial class DiscoverPanel : Panel
	{
		private MainWindow MainWindow { get; }
		private string Arguments { get; }
		public ObservableCollection<FeaturedModpack> FeaturedModpacks { get; } = new();
		public ListBox Featured { get; }

		public DiscoverPanel()
		{
			InitializeComponent();
			Featured = this.FindControl<ListBox>("Featured");

		}
		public DiscoverPanel(MainWindow mainWindow, string args = "") : this()
		{
			this.MainWindow = mainWindow;
			this.Arguments = args;

			var packs = Discover.ObtainPackList(LauncherConstants.DiscoverUrl, MainWindow.HttpPlatformApi);
			foreach (var pack in packs)
			{
				FeaturedModpacks.Add(new() { Id = pack.Name, Name = pack.DisplayName, Image = new Bitmap(NetApiHandler.GetStream(pack.Logo.Url ?? "")) });
			}
			if (packs.Count > 3) FeaturedModpacks.SkipLast(packs.Count - 3);
			Featured.Items = FeaturedModpacks;
		}

		private void InitializeComponent() => AvaloniaXamlLoader.Load(this);

		public void OnTrendingItemClick(object sender, RoutedEventArgs e) => MainWindow.NavigateMenu(EMenuItem.Modpacks, ((FeaturedModpack)((Button) sender).Tag).Id);
	}
}
