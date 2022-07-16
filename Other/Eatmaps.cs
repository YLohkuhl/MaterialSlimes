using HarmonyLib;
using System.Linq;
using ModdedIds;
using System.Collections.Generic;

namespace Eatmaps
{
    [HarmonyPatch(typeof(SlimeDiet), "RefreshEatMap")]
    class EatMapPatc_Fragments
    {
        static void Postfix(SlimeDiet __instance, SlimeDefinitions definitions, SlimeDefinition definition)
        {
            if (definition.IdentifiableId != otherIds.FRAGMENT_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == otherIds.DANGEROUS_PLORT);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = otherIds.FRAGMENT_SLIME,
                    eats = otherIds.DANGEROUS_PLORT,
                    minDrive = 1.5f
                });
            }
        }
    }
    [HarmonyPatch(typeof(SlimeDiet), "RefreshEatMap")]
    class EatMapPatch_SoilAndGrass
    {
        static void Postfix(SlimeDiet __instance, SlimeDefinitions definitions, SlimeDefinition definition)
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
            if (definition.IdentifiableId == soilIds.SOIL_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == Identifiable.Id.DEEP_BRINE_CRAFT);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = grassIds.GRASS_SLIME,
                    eats = Identifiable.Id.DEEP_BRINE_CRAFT,
                    minDrive = 1
                });
            }
            if (definition.IdentifiableId == grassIds.GRASS_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == soilIds.SOIL_PLORT);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = soilIds.SOIL_SLIME,
                    eats = soilIds.SOIL_PLORT,
                    minDrive = 1
                });
            }
            if (definition.IdentifiableId == soilIds.SOIL_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == itemIds.FERTILIZER);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = list2.RandomObject(),
                    eats = itemIds.FERTILIZER,
                    minDrive = 1
                });
            }
            if (definition.IdentifiableId == soilIds.SOIL_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == itemIds.FERTILIZER);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = Identifiable.Id.CARROT_VEGGIE,
                    eats = itemIds.FERTILIZER,
                    minDrive = 1
                });
            }
        }
    }
}