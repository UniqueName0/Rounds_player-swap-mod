using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace W_jump
{
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInProcess("Rounds.exe")]
    [BepInPlugin("uniquename.rounds.player-swap", "player-swap", "0.0.0.0")]
    public class player_swap : BaseUnityPlugin
    {

        public void Awake()
        {
            var harmony = new Harmony("uniquename.rounds.player-swap");
            harmony.PatchAll();
        }

        public const string modID = "uniquename.rounds.player-swap";
        public const string modName = "player-swap";
    }

    

    [HarmonyPatch(typeof(Block), "TryBlock")]
    public class Player_swap_patch : MonoBehaviour
    {
        [HarmonyPostfix]
        private void TryBlock_Patch(Block __instance)
        {
            Player target = PlayerManager.instance.GetOtherPlayer(base.GetComponentInParent<Player>());
            base.transform.root.transform.position = target.transform.position + (target.transform.position - base.transform.position).normalized;
        }
    }
}