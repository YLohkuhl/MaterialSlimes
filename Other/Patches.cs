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

                // material losalfosal

                // wood (50%)
                list2.Add(ModdedIds.woodIds.WOOD_SLIME);
                list2.Add(ModdedIds.woodIds.WOOD_SLIME);
                list2.Add(ModdedIds.woodIds.WOOD_SLIME);
                list2.Add(ModdedIds.woodIds.WOOD_SLIME);
                list2.Add(ModdedIds.woodIds.WOOD_SLIME);

                // glue (20%)
                list2.Add(ModdedIds.glueIds.GLUE_SLIME);
                list2.Add(ModdedIds.glueIds.GLUE_SLIME);
                list2.Add(ModdedIds.glueIds.GLUE_SLIME);

                // concrete (20%)
                list2.Add(ModdedIds.concreteIds.CONCRETE_SLIME);
                list2.Add(ModdedIds.concreteIds.CONCRETE_SLIME);
                list2.Add(ModdedIds.concreteIds.CONCRETE_SLIME);

                // cotton (20%)
                list2.Add(ModdedIds.cottonIds.COTTON_SLIME);
                list2.Add(ModdedIds.cottonIds.COTTON_SLIME);
                list2.Add(ModdedIds.cottonIds.COTTON_SLIME);

                // copper (15%)
                list2.Add(ModdedIds.copperIds.COPPER_SLIME);
                list2.Add(ModdedIds.copperIds.COPPER_SLIME);

                // ice (12%)
                list2.Add(ModdedIds.iceIds.ICE_SLIME);
                list2.Add(ModdedIds.iceIds.ICE_SLIME);

                // glass (10%)
                list2.Add(ModdedIds.glassIds.GLASS_SLIME);
                list2.Add(ModdedIds.glassIds.GLASS_SLIME);

                // metal (9%)
                list2.Add(ModdedIds.metalIds.METAL_SLIME);
                list2.Add(ModdedIds.metalIds.METAL_SLIME);

                // plastic (8%)
                list2.Add(ModdedIds.plasticIds.PLASTIC_SLIME);
                list2.Add(ModdedIds.plasticIds.PLASTIC_SLIME);

                // exclusive sliemmssdnashf (1-2%(?))
                list2.Add(ModdedIds.lightIds.LIGHT_SLIME);
                list2.Add(ModdedIds.darkIds.DARK_SLIME);

                em.producesId = list2.RandomObject<Identifiable.Id>();
            }

            return true;
        }
    }
}