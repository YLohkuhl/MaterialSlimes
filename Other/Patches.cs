using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using HarmonyLib;
using ModdedIds;
using UnityEngine;

namespace Patches
{

    [HarmonyPatch(typeof(SlimeEat), "EatAndProduce")]
    internal class Patch_SlimeEatProduce_Discovery
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

                // soil (20%)
                list2.Add(ModdedIds.soilIds.SOIL_SLIME);
                list2.Add(ModdedIds.soilIds.SOIL_SLIME);
                list2.Add(ModdedIds.soilIds.SOIL_SLIME);

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
                list2.Add(ModdedIds.providerIds.PROVIDER_SLIME);

                em.producesId = list2.RandomObject<Identifiable.Id>();
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(SlimeEat), "EatAndProduce")]
    internal class Patch_SlimeEatProduce_Newbuck
    {
        // Token: 0x06000036 RID: 54 RVA: 0x00006058 File Offset: 0x00004258
        private static bool Prefix(SlimeEat __instance, SlimeDiet.EatMapEntry em)
        {

            bool flag5 = __instance.slimeDefinition.Matches(ModdedIds.newbuckIds.NEWBUCK_SLIME);
            if (flag5)
            {
                List<Identifiable.Id> list2 = new List<Identifiable.Id>();

                list2.Add(ModdedIds.newbuckIds.NEWBUCK_PLORT);
                list2.Add(ModdedIds.newbuckIds.NEWBUCK_PLORT);
                list2.Add(ModdedIds.newbuckIds.NEWBUCK_PLORT);
                list2.Add(ModdedIds.newbuckIds.NEWBUCK_PLORT);
                list2.Add(ModdedIds.newbuckIds.NEWBUCK_PLORT);
                list2.Add(ModdedIds.newbuckIds.NEWBUCK_PLORT);
                list2.Add(ModdedIds.newbuckIds.NEWBUCK_PLORT);
                list2.Add(ModdedIds.newbuckIds.NEWBUCK_PLORT);
                list2.Add(ModdedIds.newbuckIds.NEWBUCK_PLORT);

                list2.Add(ModdedIds.newbuckIds.RICH_NEWBUCK_PLORT);
                list2.Add(ModdedIds.newbuckIds.RICH_NEWBUCK_PLORT);
                list2.Add(ModdedIds.newbuckIds.RICH_NEWBUCK_PLORT);

                list2.Add(ModdedIds.newbuckIds.RICHER_NEWBUCK_PLORT);
                list2.Add(ModdedIds.newbuckIds.RICHER_NEWBUCK_PLORT);

                em.producesId = list2.RandomObject<Identifiable.Id>();
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(SlimeEat), "EatAndProduce")]
    internal class Patch_SlimeEatProduce_Provider
    {
        // Token: 0x06000036 RID: 54 RVA: 0x00006058 File Offset: 0x00004258
        private static bool Prefix(SlimeEat __instance, SlimeDiet.EatMapEntry em)
        {

            bool flag5 = __instance.slimeDefinition.Matches(ModdedIds.providerIds.PROVIDER_SLIME);
            if (flag5)
            {
                List<Identifiable.Id> list2 = new List<Identifiable.Id>();

                // VEGGIES

                list2.Add(Identifiable.Id.CARROT_VEGGIE);
                list2.Add(Identifiable.Id.CARROT_VEGGIE);
                list2.Add(Identifiable.Id.CARROT_VEGGIE);
                list2.Add(Identifiable.Id.CARROT_VEGGIE);
                list2.Add(Identifiable.Id.CARROT_VEGGIE);

                list2.Add(Identifiable.Id.BEET_VEGGIE);
                list2.Add(Identifiable.Id.BEET_VEGGIE);
                list2.Add(Identifiable.Id.BEET_VEGGIE);
                list2.Add(Identifiable.Id.BEET_VEGGIE);
                list2.Add(Identifiable.Id.BEET_VEGGIE);

                list2.Add(Identifiable.Id.OCAOCA_VEGGIE);
                list2.Add(Identifiable.Id.OCAOCA_VEGGIE);
                list2.Add(Identifiable.Id.OCAOCA_VEGGIE);

                list2.Add(Identifiable.Id.PARSNIP_VEGGIE);
                list2.Add(Identifiable.Id.PARSNIP_VEGGIE);
                list2.Add(Identifiable.Id.PARSNIP_VEGGIE);

                list2.Add(Identifiable.Id.ONION_VEGGIE);
                list2.Add(Identifiable.Id.ONION_VEGGIE);
                list2.Add(Identifiable.Id.ONION_VEGGIE);

                list2.Add(Identifiable.Id.GINGER_VEGGIE);

                // FRUITS

                list2.Add(Identifiable.Id.CUBERRY_FRUIT);
                list2.Add(Identifiable.Id.CUBERRY_FRUIT);
                list2.Add(Identifiable.Id.CUBERRY_FRUIT);
                list2.Add(Identifiable.Id.CUBERRY_FRUIT);
                list2.Add(Identifiable.Id.CUBERRY_FRUIT);

                list2.Add(Identifiable.Id.POGO_FRUIT);
                list2.Add(Identifiable.Id.POGO_FRUIT);
                list2.Add(Identifiable.Id.POGO_FRUIT);
                list2.Add(Identifiable.Id.POGO_FRUIT);
                list2.Add(Identifiable.Id.POGO_FRUIT);

                list2.Add(Identifiable.Id.LEMON_FRUIT);
                list2.Add(Identifiable.Id.LEMON_FRUIT);
                list2.Add(Identifiable.Id.LEMON_FRUIT);

                list2.Add(Identifiable.Id.MANGO_FRUIT);
                list2.Add(Identifiable.Id.MANGO_FRUIT);
                list2.Add(Identifiable.Id.MANGO_FRUIT);

                list2.Add(Identifiable.Id.PEAR_FRUIT);
                list2.Add(Identifiable.Id.PEAR_FRUIT);
                list2.Add(Identifiable.Id.PEAR_FRUIT);

                list2.Add(Identifiable.Id.KOOKADOBA_FRUIT);

                // MEAT
                list2.Add(Identifiable.Id.HEN);
                list2.Add(Identifiable.Id.HEN);
                list2.Add(Identifiable.Id.HEN);
                list2.Add(Identifiable.Id.HEN);
                list2.Add(Identifiable.Id.HEN);

                list2.Add(Identifiable.Id.STONY_HEN);
                list2.Add(Identifiable.Id.STONY_HEN);
                list2.Add(Identifiable.Id.STONY_HEN);
                list2.Add(Identifiable.Id.STONY_HEN);
                list2.Add(Identifiable.Id.STONY_HEN);

                list2.Add(Identifiable.Id.BRIAR_HEN);
                list2.Add(Identifiable.Id.BRIAR_HEN);
                list2.Add(Identifiable.Id.BRIAR_HEN);
                list2.Add(Identifiable.Id.BRIAR_HEN);
                list2.Add(Identifiable.Id.BRIAR_HEN);

                list2.Add(Identifiable.Id.PAINTED_HEN);
                list2.Add(Identifiable.Id.PAINTED_HEN);
                list2.Add(Identifiable.Id.PAINTED_HEN);

                list2.Add(Identifiable.Id.ROOSTER);
                list2.Add(Identifiable.Id.ROOSTER);
                list2.Add(Identifiable.Id.ROOSTER);

                list2.Add(Identifiable.Id.ELDER_HEN);
                list2.Add(Identifiable.Id.ELDER_HEN);
                list2.Add(Identifiable.Id.ELDER_HEN);

                list2.Add(Identifiable.Id.ELDER_ROOSTER);
                list2.Add(Identifiable.Id.ELDER_ROOSTER);
                list2.Add(Identifiable.Id.ELDER_ROOSTER);

                // SPECIAL ITEMS
                list2.Add(itemIds.MATERIAL_SQUEEZE_CRAFT);
                list2.Add(itemIds.MATERIAL_SQUEEZE_CRAFT);
                list2.Add(itemIds.MATERIAL_SQUEEZE_CRAFT);

                list2.Add(itemIds.FERTILIZER_CRAFT);
                list2.Add(itemIds.FERTILIZER_CRAFT);
                list2.Add(itemIds.FERTILIZER_CRAFT);

                em.producesId = list2.RandomObject<Identifiable.Id>();
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(SlimeEat), "EatAndProduce")]
    internal class Patch_SlimeEatProduce_SoilAndGrass
    {
        // Token: 0x06000036 RID: 54 RVA: 0x00006058 File Offset: 0x00004258
        private static bool Prefix(SlimeEat __instance, SlimeDiet.EatMapEntry em)
        {

            bool flag5 = __instance.slimeDefinition.Matches(ModdedIds.soilIds.SOIL_SLIME);
            if (flag5)
            {
                List<Identifiable.Id> list2 = new List<Identifiable.Id>();

                list2.Add(ModdedIds.soilIds.SOIL_PLORT);
                list2.Add(ModdedIds.soilIds.SOIL_PLORT);
                list2.Add(ModdedIds.soilIds.SOIL_PLORT);

                list2.Add(ModdedIds.soilIds.ACTUAL_ROCK_PLORT);
                list2.Add(ModdedIds.soilIds.ACTUAL_ROCK_PLORT);
                list2.Add(ModdedIds.soilIds.ACTUAL_ROCK_PLORT);

                em.producesId = list2.RandomObject<Identifiable.Id>();
            }
            bool flag6 = __instance.slimeDefinition.Matches(ModdedIds.grassIds.GRASS_SLIME);
            if (flag6)
            {
                List<Identifiable.Id> list2 = new List<Identifiable.Id>();

                list2.Add(ModdedIds.grassIds.GRASS_PLORT);
                list2.Add(ModdedIds.grassIds.GRASS_PLORT);
                list2.Add(ModdedIds.grassIds.GRASS_PLORT);

                list2.Add(ModdedIds.grassIds.PLANT_PLORT);
                list2.Add(ModdedIds.grassIds.PLANT_PLORT);
                list2.Add(ModdedIds.grassIds.PLANT_PLORT);

                em.producesId = list2.RandomObject<Identifiable.Id>();
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(SlimeEat), "EatAndTransform")]
    class EatMapPatch_Fertilizer
    {
        static void Postfix(SlimeEat __instance, SlimeDiet.EatMapEntry em)
        {
            if (__instance.slimeDefinition.Matches(soilIds.SOIL_SLIME))
            {
                List<Identifiable.Id> list2 = new List<Identifiable.Id>();

                // VEGGIES

                list2.Add(Identifiable.Id.CARROT_VEGGIE);
                list2.Add(Identifiable.Id.CARROT_VEGGIE);
                list2.Add(Identifiable.Id.CARROT_VEGGIE);
                list2.Add(Identifiable.Id.CARROT_VEGGIE);
                list2.Add(Identifiable.Id.CARROT_VEGGIE);

                list2.Add(Identifiable.Id.BEET_VEGGIE);
                list2.Add(Identifiable.Id.BEET_VEGGIE);
                list2.Add(Identifiable.Id.BEET_VEGGIE);
                list2.Add(Identifiable.Id.BEET_VEGGIE);
                list2.Add(Identifiable.Id.BEET_VEGGIE);

                list2.Add(Identifiable.Id.OCAOCA_VEGGIE);
                list2.Add(Identifiable.Id.OCAOCA_VEGGIE);
                list2.Add(Identifiable.Id.OCAOCA_VEGGIE);

                list2.Add(Identifiable.Id.PARSNIP_VEGGIE);
                list2.Add(Identifiable.Id.PARSNIP_VEGGIE);
                list2.Add(Identifiable.Id.PARSNIP_VEGGIE);

                list2.Add(Identifiable.Id.ONION_VEGGIE);
                list2.Add(Identifiable.Id.ONION_VEGGIE);
                list2.Add(Identifiable.Id.ONION_VEGGIE);

                list2.Add(Identifiable.Id.GINGER_VEGGIE);

                // FRUITS

                list2.Add(Identifiable.Id.CUBERRY_FRUIT);
                list2.Add(Identifiable.Id.CUBERRY_FRUIT);
                list2.Add(Identifiable.Id.CUBERRY_FRUIT);
                list2.Add(Identifiable.Id.CUBERRY_FRUIT);
                list2.Add(Identifiable.Id.CUBERRY_FRUIT);

                list2.Add(Identifiable.Id.POGO_FRUIT);
                list2.Add(Identifiable.Id.POGO_FRUIT);
                list2.Add(Identifiable.Id.POGO_FRUIT);
                list2.Add(Identifiable.Id.POGO_FRUIT);
                list2.Add(Identifiable.Id.POGO_FRUIT);

                list2.Add(Identifiable.Id.LEMON_FRUIT);
                list2.Add(Identifiable.Id.LEMON_FRUIT);
                list2.Add(Identifiable.Id.LEMON_FRUIT);

                list2.Add(Identifiable.Id.MANGO_FRUIT);
                list2.Add(Identifiable.Id.MANGO_FRUIT);
                list2.Add(Identifiable.Id.MANGO_FRUIT);

                list2.Add(Identifiable.Id.PEAR_FRUIT);
                list2.Add(Identifiable.Id.PEAR_FRUIT);
                list2.Add(Identifiable.Id.PEAR_FRUIT);

                list2.Add(Identifiable.Id.KOOKADOBA_FRUIT);

                if (em.eats == itemIds.FERTILIZER_CRAFT)
                    em.becomesId = list2.RandomObject();
                // em.becomesId = Randoms.SHARED.Pick(Identifiable.FRUIT_CLASS.Union(Identifiable.VEGGIE_CLASS).ToArray());
            }
        }
    }
    [HarmonyPatch(typeof(SlimeEat), "EatAndTransform")]
    class EatMapPatch_SpiritualMaterial
    {
        static void Postfix(SlimeEat __instance, SlimeDiet.EatMapEntry em)
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

            // soil (20%)
            list2.Add(ModdedIds.soilIds.SOIL_SLIME);
            list2.Add(ModdedIds.soilIds.SOIL_SLIME);
            list2.Add(ModdedIds.soilIds.SOIL_SLIME);

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

            if (em.eats == itemIds.SPIRITUAL_MATERIAL_CRAFT)
                em.becomesId = list2.RandomObject();
            // em.becomesId = Randoms.SHARED.Pick(Identifiable.FRUIT_CLASS.Union(Identifiable.VEGGIE_CLASS).ToArray());
        }
    }
}