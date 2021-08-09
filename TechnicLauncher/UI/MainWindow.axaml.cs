using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Diagnostics;
using TechnicLauncher.Model;
using TechnicLauncher.PlatformAPI.Http;
using TechnicLauncher.SolderAPI.Http;
using TechnicLauncher.UI.Page;
using TechnicLauncher.Utils;

namespace TechnicLauncher.UI
{
	public partial class MainWindow : Window
	{
		#region Controls
		private Panel ContentPanel;
		#endregion

		#region Properties
		internal HttpPlatformApi HttpPlatformApi { get; }
		internal HttpSolderApi HttpSolderApi { get; }
		internal ModpacksPanel CachedModpacksPanel { get; set; }
		internal DiscoverPanel CachedDiscoverPanel { get; set; }
		internal NewsPanel CachedNewsPanel { get; set; }
		#endregion

		public MainWindow()
		{
			InitializeComponent();
			HttpPlatformApi = new HttpPlatformApi(LauncherConstants.PlatformApiUrl, LauncherConstants.BuildNumber);
			HttpSolderApi = new HttpSolderApi(LauncherConstants.SolderApiUrl, LauncherInfo.ClientId);

			ContentPanel = this.FindControl<Panel>("ContentPanel");
			NavigateMenu();
#if DEBUG
			this.AttachDevTools();
#endif
		}

		public void OnTitlebarPointerMoved(object sender, PointerPressedEventArgs e) => BeginMoveDrag(e);
		private void InitializeComponent() => AvaloniaXamlLoader.Load(this);

		public void OnOptionsClick(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("OnOptionsClick");
		}

		public void OnDiscoverMenuItemClick(object sender, RoutedEventArgs e) => NavigateMenu(EMenuItem.Discover);
		public void OnModpacksMenuItemClick(object sender, RoutedEventArgs e) => NavigateMenu(EMenuItem.Modpacks);
		public void OnNewsMenuItemClick(object sender, RoutedEventArgs e) => NavigateMenu(EMenuItem.News);

		internal void NavigateMenu(EMenuItem menuItem = EMenuItem.Discover, string args="", bool forceReload = false)
		{
			ContentPanel.Children.Clear();
			switch (menuItem)
			{
				case EMenuItem.Modpacks:
					CachedModpacksPanel ??= new ModpacksPanel(this);
					if(forceReload || !string.IsNullOrEmpty(args)) CachedModpacksPanel = new ModpacksPanel(this);
					ContentPanel.Children.Add(CachedModpacksPanel);
					break;
				case EMenuItem.Discover:
					CachedDiscoverPanel ??= new DiscoverPanel(this, args);
					if (forceReload || !string.IsNullOrEmpty(args)) CachedDiscoverPanel = new DiscoverPanel(this, args);
					ContentPanel.Children.Add(CachedDiscoverPanel);
					break;
				case EMenuItem.News:
					CachedNewsPanel ??= new NewsPanel(this, args);
					if (forceReload || !string.IsNullOrEmpty(args)) CachedNewsPanel = new NewsPanel(this, args);
					ContentPanel.Children.Add(CachedNewsPanel);
					break;
				default:
					throw new System.InvalidOperationException($"Menu item {menuItem} not a valid menu element.");
			}
		}
	}
	public enum EMenuItem
	{
		Modpacks,
		Discover,
		News
	}
}
