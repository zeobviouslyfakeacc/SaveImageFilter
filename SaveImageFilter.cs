using MelonLoader;
using UnityEngine;

namespace SaveImageFilter {
	internal class SaveImageFilter : MelonMod {
		public override void OnApplicationStart() {
			Settings.Init(this);
			Debug.Log($"[{Info.Name}] version {Info.Version} loaded!");
		}
	}
}
