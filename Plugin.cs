﻿using BepInEx;
using BepInEx.Logging;
using CMGodModeMod.Patches;
using HarmonyLib;
using GameNetcodeStuff;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMGodModeMod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class GodModeModBase : BaseUnityPlugin
    {
        private const string modGUID = "Christianm.CMGodModeMod";
        private const string modName = "God Mode Mod";
        private const string modVersion = "1.3.0.0";

        Harmony harmony = new Harmony(modGUID);

        internal ManualLogSource mls;

        void Awake()
        {
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("GOD MOD IS ACTIVE!"); //Displays in console whatever is typed in the LogInfo parenthesis.

            harmony.PatchAll(typeof(GodModeModBase)); //Patch main class
            mls.LogInfo("Successfully Patched Main Class.");

            harmony.PatchAll(typeof(PlayerControllerBPatch)); //Patch infinite sprint and change jump height
            mls.LogInfo("Successfully Patched Player Movement.");

            harmony.PatchAll(typeof(infiniteTimeToDeadline)); //Patch the quota variables
            mls.LogInfo("Successfully Patched Quota Variables.");
        }

        [HarmonyPatch(typeof(TimeOfDay), "Awake")]

        class infiniteTimeToDeadline
        {
            private static void Postfix(ref TimeOfDay __instance)
            {
                int StartingCredits = 9999;
                int DaysLeft = 9999;

                __instance.quotaVariables.startingCredits = StartingCredits; //Start with 9999 credits
                __instance.quotaVariables.deadlineDaysAmount = DaysLeft; //Have 9999 days remaining before quota is due
            }
        }
    }
}
