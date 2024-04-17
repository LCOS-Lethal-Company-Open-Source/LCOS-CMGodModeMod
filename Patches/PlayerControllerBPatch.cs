using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CMGodModeMod.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void increaseMovementSpeed(ref float ___movementSpeed)
        {
            if (GameNetworkManager.Instance.isHostingGame) //Checks to make sure user is hosting the game.
            {
                ___movementSpeed = 10f; //Increase the movement speed of the player.
            }
        }


        [HarmonyPatch("Update")]
        [HarmonyPostfix]

        static void infiniteSprintPatch(ref float ___sprintMeter)
        {
            if (GameNetworkManager.Instance.isHostingGame) //Checks to make sure user is hosting the game.
            {
                ___sprintMeter = 1f; //Keep the sprint meter full at every tick so that the player can sprint infinitely without stopping
            }
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]

        static void increasedJumpForcePatch(ref float ___jumpForce)
        {
            if (GameNetworkManager.Instance.isHostingGame) //Checks to make sure user is hosting the game.
            {
                ___jumpForce = 15f; //Change the height and duration of each jump.
            }
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]

        static void fullHealthPatch(ref int ___health)
        {
            if (GameNetworkManager.Instance.isHostingGame) //Checks to make sure user is hosting the game.
            {
                ___health = 1000000000; //Set health to 1000000000 so that the player never dies
            }
        }
    }
}
