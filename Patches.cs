using System;
using System.Collections.Generic;
using Extensions;
using HarmonyLib;
using UnityEngine;

namespace Patches
{

    [HarmonyPatch(typeof(SlimeEat), "EatAndProduce")]
    internal class Patch_SlimeEatProduce
    {
        // Token: 0x06000036 RID: 54 RVA: 0x00006058 File Offset: 0x00004258
        private static bool Prefix(SlimeEat __instance, SlimeDiet.EatMapEntry em)
        {

            bool flag5 = __instance.slimeDefinition.Matches(ModdedIds.discoveryIds.DISCOVERY_SLIME);
            if (flag5)
            {
                List<Identifiable.Id> list2 = new List<Identifiable.Id>();
                list2.Add(ModdedIds.glueIds.GLUE_SLIME);
                list2.Add(ModdedIds.plasticIds.PLASTIC_SLIME);
                list2.Add(ModdedIds.glassIds.GLASS_SLIME);
                list2.Add(ModdedIds.metalIds.METAL_SLIME);
                list2.Add(ModdedIds.woodIds.WOOD_SLIME);

                em.producesId = list2.RandomObject<Identifiable.Id>();
            }

            return true;
        }
    }
}