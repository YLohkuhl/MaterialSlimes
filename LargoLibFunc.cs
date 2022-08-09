using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ModdedIds;
using SRML.Utils;
using SRML.SR;
using static SRML.SR.SlimeRegistry;
using SRML.SR.Utils;

class LargoLibFunc
{
    public class SlimeID
    {
        public static Identifiable.Id Discovery = discoveryIds.DISCOVERY_SLIME;
        public static Identifiable.Id Wood = woodIds.WOOD_SLIME;
        public static Identifiable.Id Glue = glueIds.GLUE_SLIME;
        public static Identifiable.Id Plastic = plasticIds.PLASTIC_SLIME;
        public static Identifiable.Id Metal = metalIds.METAL_SLIME;
        public static Identifiable.Id Concrete = concreteIds.CONCRETE_SLIME;
        public static Identifiable.Id Dark = darkIds.DARK_SLIME;
        public static Identifiable.Id Light = lightIds.LIGHT_SLIME;
        public static Identifiable.Id Cotton = cottonIds.COTTON_SLIME;
        public static Identifiable.Id Glass = glassIds.GLASS_SLIME;
        public static Identifiable.Id Copper = copperIds.COPPER_SLIME;
        public static Identifiable.Id Ice = iceIds.ICE_SLIME;
        public static Identifiable.Id Provider = providerIds.PROVIDER_SLIME;
        public static Identifiable.Id Newbuck = newbuckIds.NEWBUCK_SLIME;
        public static Identifiable.Id Fragment = otherIds.FRAGMENT_SLIME;
        public static Identifiable.Id Soil = soilIds.SOIL_SLIME;
        public static Identifiable.Id Grass = grassIds.GRASS_SLIME;
        public static Identifiable.Id Silver = silverIds.SILVER_SLIME;
    }
    // prop functiosn and all lol
    public static GameObject CreateLargoProp1(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
    {
        LargoProps array =
        LargoProps.REPLACE_BASE_MAT_AS_SLIME2 |
        LargoProps.RECOLOR_BASE_MAT_AS_SLIME1 |
        LargoProps.SWAP_EYES |
        LargoProps.SWAP_MOUTH |
        LargoProps.GENERATE_NAME;

        CraftLargo(largoId, slime1, slime2, array, out SlimeDefinition largoDef, out SlimeAppearance largoApp, out GameObject largoObj);

        SlimeDefinition baseSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(slime1);
        SlimeDefinition additionalSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(slime2);

        baseSlimeDefinition.AddEatMapEntry(new SlimeDiet.EatMapEntry()
        {
            becomesId = largoId,
            driver = SlimeEmotions.Emotion.AGITATION,
            minDrive = 0.5f,
            eats = additionalSlimeDefinition.Diet.Produces[0]
        });

        additionalSlimeDefinition.AddEatMapEntry(new SlimeDiet.EatMapEntry()
        {
            becomesId = largoId,
            driver = SlimeEmotions.Emotion.AGITATION,
            minDrive = 0.5f,
            eats = baseSlimeDefinition.Diet.Produces[0]
        });

        return largoObj;
    }

    public static GameObject CreateLargoProp2(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
    {
        LargoProps array =
        LargoProps.RECOLOR_BASE_MAT_AS_SLIME2 |
        LargoProps.REPLACE_BASE_MAT_AS_SLIME2 |
        LargoProps.SWAP_EYES |
        LargoProps.SWAP_MOUTH |
        LargoProps.GENERATE_NAME;

        CraftLargo(largoId, slime1, slime2, array, out SlimeDefinition largoDef, out SlimeAppearance largoApp, out GameObject largoObj);

        SlimeDefinition baseSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(slime1);
        SlimeDefinition additionalSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(slime2);

        baseSlimeDefinition.AddEatMapEntry(new SlimeDiet.EatMapEntry()
        {
            becomesId = largoId,
            driver = SlimeEmotions.Emotion.AGITATION,
            minDrive = 0.5f,
            eats = additionalSlimeDefinition.Diet.Produces[0]
        });

        additionalSlimeDefinition.AddEatMapEntry(new SlimeDiet.EatMapEntry()
        {
            becomesId = largoId,
            driver = SlimeEmotions.Emotion.AGITATION,
            minDrive = 0.5f,
            eats = baseSlimeDefinition.Diet.Produces[0]
        });


        return largoObj;
    }

    public static GameObject CreateLargoProp3(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
    {
        LargoProps array =
        LargoProps.RECOLOR_BASE_MAT_AS_SLIME1 |
        LargoProps.REPLACE_BASE_MAT_AS_SLIME1 |
        LargoProps.SWAP_EYES |
        LargoProps.SWAP_MOUTH |
        LargoProps.GENERATE_NAME;

        CraftLargo(largoId, slime1, slime2, array, out SlimeDefinition largoDef, out SlimeAppearance largoApp, out GameObject largoObj);

        SlimeDefinition baseSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(slime1);
        SlimeDefinition additionalSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(slime2);

        baseSlimeDefinition.AddEatMapEntry(new SlimeDiet.EatMapEntry()
        {
            becomesId = largoId,
            driver = SlimeEmotions.Emotion.AGITATION,
            minDrive = 0.5f,
            eats = additionalSlimeDefinition.Diet.Produces[0]
        });

        additionalSlimeDefinition.AddEatMapEntry(new SlimeDiet.EatMapEntry()
        {
            becomesId = largoId,
            driver = SlimeEmotions.Emotion.AGITATION,
            minDrive = 0.5f,
            eats = baseSlimeDefinition.Diet.Produces[0]
        });

        return largoObj;
    }

    public static GameObject CreateProviderNewbuckLargo(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
    {
        LargoProps array =
        LargoProps.REPLACE_BASE_MAT_AS_SLIME2 |
        LargoProps.RECOLOR_BASE_MAT_AS_SLIME1 |
        LargoProps.SWAP_EYES |
        LargoProps.SWAP_MOUTH |
        LargoProps.GENERATE_NAME;

        CraftLargo(largoId, slime1, slime2, array, out SlimeDefinition largoDef, out SlimeAppearance largoApp, out GameObject largoObj);

        largoDef.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[] { SlimeEat.FoodGroup.FRUIT, SlimeEat.FoodGroup.NONTARRGOLD_SLIMES };
        largoDef.Diet.Produces = new Identifiable.Id[] { newbuckIds.RICH_NEWBUCK_PLORT, providerIds.PROVIDED_PLORT };

        SlimeDefinition baseSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(slime1);
        SlimeDefinition additionalSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(slime2);

        baseSlimeDefinition.AddEatMapEntry(new SlimeDiet.EatMapEntry()
        {
            becomesId = largoId,
            driver = SlimeEmotions.Emotion.AGITATION,
            minDrive = 0.5f,
            eats = additionalSlimeDefinition.Diet.Produces[0]
        });

        additionalSlimeDefinition.AddEatMapEntry(new SlimeDiet.EatMapEntry()
        {
            becomesId = largoId,
            driver = SlimeEmotions.Emotion.AGITATION,
            minDrive = 0.5f,
            eats = baseSlimeDefinition.Diet.Produces[0]
        });

        return largoObj;
    }
    // load largos
    static public void LoadLargos()
    {
        WoodLargos();
        ConcreteLargos();
        MetalLargos();
        IceLargos();
        SoilLargos();
        GrassLargos();
        OtherLargos();

        return;
    }

    // WOOD
    static public void WoodLargos()
    {
        // wood largos
        CreateLargoProp1(SlimeID.Wood, SlimeID.Metal, largoIds.WOOD_METAL_LARGO);
        CreateLargoProp1(SlimeID.Wood, SlimeID.Glue, largoIds.WOOD_GLUE_LARGO);
        CreateLargoProp1(SlimeID.Wood, SlimeID.Concrete, largoIds.WOOD_CONCRETE_LARGO);
        CreateLargoProp1(SlimeID.Wood, SlimeID.Ice, largoIds.WOOD_ICE_LARGO);
        CreateLargoProp1(SlimeID.Wood, SlimeID.Soil, largoIds.WOOD_SOIL_LARGO);
        CreateLargoProp1(SlimeID.Wood, SlimeID.Grass, largoIds.WOOD_GRASS_LARGO);
    }

    // CONCRETE
    static public void ConcreteLargos()
    {
        // concrete largos
        CreateLargoProp1(SlimeID.Concrete, SlimeID.Metal, largoIds.CONCRETE_METAL_LARGO);
        CreateLargoProp1(SlimeID.Concrete, SlimeID.Glue, largoIds.CONCRETE_GLUE_LARGO);
        CreateLargoProp1(SlimeID.Concrete, SlimeID.Ice, largoIds.CONCRETE_ICE_LARGO);
        CreateLargoProp1(SlimeID.Concrete, SlimeID.Soil, largoIds.CONCRETE_SOIL_LARGO);
        CreateLargoProp1(SlimeID.Concrete, SlimeID.Grass, largoIds.CONCRETE_GRASS_LARGO);
    }

    // METAL
    static public void MetalLargos()
    {
        // metal largos
        CreateLargoProp1(SlimeID.Metal, SlimeID.Glue, largoIds.METAL_GLUE_LARGO);
        CreateLargoProp1(SlimeID.Metal, SlimeID.Ice, largoIds.METAL_ICE_LARGO);
        CreateLargoProp1(SlimeID.Metal, SlimeID.Soil, largoIds.METAL_SOIL_LARGO);
        CreateLargoProp1(SlimeID.Metal, SlimeID.Grass, largoIds.METAL_GRASS_LARGO);
    }

    // ICE
    static public void IceLargos()
    {
        // ice largos
        CreateLargoProp1(SlimeID.Ice, SlimeID.Glue, largoIds.ICE_GLUE_LARGO);
        CreateLargoProp1(SlimeID.Ice, SlimeID.Soil, largoIds.ICE_SOIL_LARGO);
        CreateLargoProp1(SlimeID.Ice, SlimeID.Grass, largoIds.ICE_GRASS_LARGO);
    }

    // SOIL
    static public void SoilLargos()
    {
        // soil largos
        CreateLargoProp1(SlimeID.Soil, SlimeID.Glue, largoIds.SOIL_GLUE_LARGO);
    }

    // GRASS
    static public void GrassLargos()
    {
        // grass largos
        CreateLargoProp1(SlimeID.Grass, SlimeID.Glue, largoIds.GRASS_GLUE_LARGO);
    }

    // OTHER
    static public void OtherLargos()
    {
        // provider/newbuck largos
        CreateProviderNewbuckLargo(SlimeID.Provider, SlimeID.Newbuck, largoIds.PROVIDER_NEWBUCK_LARGO);

        // silver/crystal largos
        CreateLargoProp1(SlimeID.Silver, Identifiable.Id.CRYSTAL_SLIME, largoIds.SILVER_CRYSTAL_LARGO);
    }
}