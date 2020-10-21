using Harmony;

namespace SaveImageFilter {
	internal static class Patches {

		[HarmonyPatch(typeof(CameraEffects), "Start")]
		private static class LoadChosenImageFilter {
			public static void Postfix(CameraEffects __instance) {
				if (Settings.Load(out SettingsStruct settings)) {
					__instance.SwitchImageFilter(settings.filter);
				}
			}
		}

		// OnConfirmImageFilter gets inlined into OnConfirmDisplay
		[HarmonyPatch(typeof(Panel_OptionsMenu), "OnConfirmDisplay")]
		private static class SaveChosenImageFilter {
			public static void Postfix() {
				SettingsStruct settings = new SettingsStruct {
					filter = GameManager.GetCameraEffects().m_ActiveFilter
				};
				Settings.Save(settings);
			}
		}
	}
}
