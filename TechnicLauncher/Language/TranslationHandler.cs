using Avalonia;
using Avalonia.Input;
using Avalonia.Platform;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using TechnicLauncher.Model;
using TechnicLauncher.Model.Helpers;

namespace TechnicLauncher.Language
{
	public class TranslationHandler
	{
		public static Translation? Translation { get; internal set; }
		static internal void Load()
		{
			var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
			var files = assets.GetAssets(new Uri("avares://TechnicLauncher/Resources/Lang/"), null).Select(x => $"{x}").ToList();
			var cc = CultureInfo.CurrentCulture;
			//var cc = CultureInfo.GetCultureInfo("zh-CN");
			var currentLang = (files.Contains($"avares://TechnicLauncher/Resources/Lang/UIText_{cc.Name.Replace("-", "_")}.xml") ? cc.Name : cc.Parent.Name).Replace("-", "_");
			Stream fileStream = assets.Open(new Uri("avares://TechnicLauncher/Resources/Lang/UIText.xml"));
			try
			{
				fileStream = assets.Open(new Uri($"avares://TechnicLauncher/Resources/Lang/UIText_{currentLang}.xml"));
			}
			catch (Exception)
			{
				fileStream = assets.Open(new Uri("avares://TechnicLauncher/Resources/Lang/UIText.xml"));
			}
			string contents = "";
			using (var sr = new StreamReader(fileStream))
			{
				contents = sr.ReadToEnd();
			}
			Translation = Translation.Parse(contents.ToXml<Properties>());
		}
		//public static string Get(string key) => Translation?.Property.FirstOrDefault(x => x.Name.Equals(key, StringComparison.OrdinalIgnoreCase)).Value;
		public static string Get(string key)
		{
			Debug.WriteLine($"key => {key}");
			string data;
			if (Translation.Property.Where(x => x.Name.Equals(key, StringComparison.OrdinalIgnoreCase)).Count() == 1)
				data = Translation?.Property.FirstOrDefault(x => x.Name.Equals(key, StringComparison.OrdinalIgnoreCase)).Value;
			else data = key;
			Debug.WriteLine($"data => {data}");
			return data;
		}
		
	}
}