using MelonLoader;
using MelonLoader.TinyJSON;
using System;
using System.IO;

namespace SaveImageFilter {
	internal static class Settings {
		private static string jsonPath = null;

		internal static void Init(MelonMod modInstance) {
			if (jsonPath != null) throw new InvalidOperationException("Init called multiple times");
			jsonPath = Path.Combine(Path.GetDirectoryName(modInstance.Location), modInstance.Info.Name + ".json");
		}

		internal static bool Load(out SettingsStruct settings) {
			if (jsonPath == null) throw new InvalidOperationException("Init not called");
			if (!File.Exists(jsonPath)) {
				settings = default;
				return false;
			}

			string json = File.ReadAllText(jsonPath, System.Text.Encoding.UTF8);
			settings = JSON.Load(json).Make<SettingsStruct>();
			return true;
		}

		internal static void Save(SettingsStruct settings) {
			if (jsonPath == null) throw new InvalidOperationException("Init not called");

			string json = JSON.Dump(settings, EncodeOptions.NoTypeHints);
			File.WriteAllText(jsonPath, json, System.Text.Encoding.UTF8);
		}
	}

	internal struct SettingsStruct {
		public CameraEffects.ImageFilterType filter;
	}
}
