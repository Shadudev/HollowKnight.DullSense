using Modding;

namespace DullSenseMod
{
    public class DullSense : Mod, ITogglableMod
    {
        public DullSense Instance { get; private set; }

		public override void Initialize()
		{
			if (Instance != null)
			{
				LogWarn("Initialized twice... Stop that.");
				return;
			}

			Instance = this;

			RandomizerMod.GiveItemActions.ExternItemHandlers.Add(DropWorldSense);
		}

		private static bool DropWorldSense(RandomizerMod.GiveItemActions.GiveAction action,
			string item, string location, int geo)
        {
			if (item == "World_Sense")
			{
				RandomizerMod.RandoLogger.LogItemToTracker(item, location);
				RandomizerMod.RandomizerMod.Instance.Settings.MarkItemFound(item);
				RandomizerMod.RandomizerMod.Instance.Settings.MarkLocationFound(location);
				RandomizerMod.RandoLogger.UpdateHelperLog();

				return true;
			}

			return false;
        }

		public override string GetVersion()
        {
            string ver = "0.0.2";
            return ver;
        }

        public void Unload()
        {
			RandomizerMod.GiveItemActions.ExternItemHandlers.Remove(DropWorldSense);
		}
    }
}
