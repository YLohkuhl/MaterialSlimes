using LargoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static LargoLibrary.LargoGenerator;
using ModdedIds;
using SRML.Utils;

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
        LargoProperties[] array = new LargoProperties[6]
        {
            LargoProperties.RECOLOR_BASE_MATS,
            LargoProperties.REPLACE_BASE_MATS,
            LargoProperties.SWAP_FACES,
            LargoProperties.GENERATE_LARGO_NAME,
            LargoProperties.GENERATE_BASE_TRANSFORMATION,
            LargoProperties.GENERATE_ADDON_TRANSFORMATION,
        };

        GameObject largoObject = CreateLargo(slime1, slime2, largoId, array);
        SlimeDefinition largoDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(largoId);
        largoDefinition.Diet.FavoriteProductionCount = 2;
        largoDefinition.Diet.RefreshEatMap(GameContext.Instance.SlimeDefinitions, largoDefinition);

        return largoObject;
    }

    public static GameObject CreateLargoProp2(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
    {
        LargoProperties[] array = new LargoProperties[8]
        {
            LargoProperties.RECOLOR_BASE_MATS,
            LargoProperties.REPLACE_BASE_MATS,
            LargoProperties.SWAP_FACES,
            LargoProperties.GENERATE_LARGO_NAME,
            LargoProperties.REPLACE_SLIME2_MATS,
            LargoProperties.RECOLOR_SLIME2_MATS,
            LargoProperties.GENERATE_BASE_TRANSFORMATION,
            LargoProperties.GENERATE_ADDON_TRANSFORMATION,
        };

        GameObject largoObject = CreateLargo(slime1, slime2, largoId, array);
        SlimeDefinition largoDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(largoId);
        largoDefinition.Diet.FavoriteProductionCount = 2;
        largoDefinition.Diet.RefreshEatMap(GameContext.Instance.SlimeDefinitions, largoDefinition);

        return largoObject;
    }

    public static GameObject CreateLargoProp3(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
    {
        LargoProperties[] array = new LargoProperties[8]
        {
            LargoProperties.RECOLOR_BASE_MATS,
            LargoProperties.REPLACE_BASE_MATS,
            LargoProperties.SWAP_FACES,
            LargoProperties.GENERATE_LARGO_NAME,
            LargoProperties.REPLACE_SLIME1_MATS,
            LargoProperties.RECOLOR_SLIME1_MATS,
            LargoProperties.GENERATE_BASE_TRANSFORMATION,
            LargoProperties.GENERATE_ADDON_TRANSFORMATION
        };

        GameObject largoObject = CreateLargo(slime1, slime2, largoId, array);
        SlimeDefinition largoDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(largoId);
        largoDefinition.Diet.FavoriteProductionCount = 2;
        largoDefinition.Diet.RefreshEatMap(GameContext.Instance.SlimeDefinitions, largoDefinition);

        return largoObject;
    }

    public static GameObject CreateLargoProp4(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
    {
        LargoProperties[] array = new LargoProperties[7]
        {
            LargoProperties.RECOLOR_BASE_MATS,
            LargoProperties.REPLACE_BASE_MATS,
            LargoProperties.SWAP_FACES,
            LargoProperties.GENERATE_LARGO_NAME,
            LargoProperties.REPLACE_SLIME1_MATS,
            LargoProperties.RECOLOR_SLIME1_MATS,
            LargoProperties.GENERATE_BASE_TRANSFORMATION
        };

        GameObject largoObject = CreateLargo(slime1, slime2, largoId, array);
        SlimeDefinition largoDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(largoId);
        largoDefinition.Diet.FavoriteProductionCount = 2;
        largoDefinition.Diet.RefreshEatMap(GameContext.Instance.SlimeDefinitions, largoDefinition);

        return largoObject;
    }

    public static GameObject CreateLargoProp5(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
    {
        LargoProperties[] array = new LargoProperties[7]
        {
            LargoProperties.RECOLOR_BASE_MATS,
            LargoProperties.REPLACE_BASE_MATS,
            LargoProperties.SWAP_FACES,
            LargoProperties.GENERATE_LARGO_NAME,
            LargoProperties.REPLACE_SLIME1_MATS,
            LargoProperties.RECOLOR_SLIME1_MATS,
            LargoProperties.GENERATE_ADDON_TRANSFORMATION
        };

        GameObject largoObject = CreateLargo(slime1, slime2, largoId, array);
        SlimeDefinition largoDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(largoId);
        largoDefinition.Diet.FavoriteProductionCount = 2;
        largoDefinition.Diet.RefreshEatMap(GameContext.Instance.SlimeDefinitions, largoDefinition);

        return largoObject;
    }

    public static GameObject CreateLargoProp6(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
    {
        LargoProperties[] array = new LargoProperties[7]
        {
            LargoProperties.RECOLOR_BASE_MATS,
            LargoProperties.REPLACE_BASE_MATS,
            LargoProperties.SWAP_FACES,
            LargoProperties.GENERATE_LARGO_NAME,
            LargoProperties.RECOLOR_BASE_MATS,
            LargoProperties.REPLACE_BASE_MATS,
            LargoProperties.GENERATE_ADDON_TRANSFORMATION
        };

        GameObject largoObject = CreateLargo(slime1, slime2, largoId, array);
        SlimeDefinition largoDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(largoId);
        largoDefinition.Diet.FavoriteProductionCount = 2;
        largoDefinition.Diet.RefreshEatMap(GameContext.Instance.SlimeDefinitions, largoDefinition);

        return largoObject;
    }
    // load largos
    static public void LoadLargos()
    {
        WoodLargos();
        PlasticLargos();
        ConcreteLargos();
        MetalLargos();
        GlassLargos();
        CopperLargos();
        CottonLargos();
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
        CreateLargoProp1(SlimeID.Wood, SlimeID.Cotton, largoIds.WOOD_COTTON_LARGO);
        CreateLargoProp1(SlimeID.Wood, SlimeID.Concrete, largoIds.WOOD_CONCRETE_LARGO);
        // had to use prop2
        CreateLargoProp2(SlimeID.Wood, SlimeID.Glass, largoIds.WOOD_GLASS_LARGO);
        CreateLargoProp2(SlimeID.Wood, SlimeID.Plastic, largoIds.WOOD_PLASTIC_LARGO);
        CreateLargoProp2(SlimeID.Wood, SlimeID.Ice, largoIds.WOOD_ICE_LARGO);
        CreateLargoProp2(SlimeID.Wood, SlimeID.Copper, largoIds.WOOD_COPPER_LARGO);
        CreateLargoProp2(SlimeID.Wood, SlimeID.Soil, largoIds.WOOD_SOIL_LARGO);
        CreateLargoProp2(SlimeID.Wood, SlimeID.Grass, largoIds.WOOD_GRASS_LARGO);
    }

    // PLASTIC
    static public void PlasticLargos()
    {
        // plastic largos
        CreateLargoProp1(SlimeID.Plastic, SlimeID.Metal, largoIds.PLASTIC_METAL_LARGO);
        CreateLargoProp1(SlimeID.Plastic, SlimeID.Glue, largoIds.PLASTIC_GLUE_LARGO);
        CreateLargoProp1(SlimeID.Plastic, SlimeID.Cotton, largoIds.PLASTIC_COTTON_LARGO);
        // had to use prop2
        CreateLargoProp2(SlimeID.Plastic, SlimeID.Glass, largoIds.PLASTIC_GLASS_LARGO);
        CreateLargoProp2(SlimeID.Plastic, SlimeID.Ice, largoIds.PLASTIC_ICE_LARGO);
        CreateLargoProp2(SlimeID.Plastic, SlimeID.Copper, largoIds.PLASTIC_COPPER_LARGO);
        CreateLargoProp2(SlimeID.Plastic, SlimeID.Soil, largoIds.PLASTIC_SOIL_LARGO);
        CreateLargoProp2(SlimeID.Plastic, SlimeID.Grass, largoIds.PLASTIC_GRASS_LARGO);
        // had to use prop3
        CreateLargoProp3(SlimeID.Plastic, SlimeID.Concrete, largoIds.PLASTIC_CONCRETE_LARGO);
    }

    // CONCRETE
    static public void ConcreteLargos()
    {
        // concrete largos
        // had to use prop2
        CreateLargoProp2(SlimeID.Concrete, SlimeID.Metal, largoIds.CONCRETE_METAL_LARGO);
        CreateLargoProp2(SlimeID.Concrete, SlimeID.Glue, largoIds.CONCRETE_GLUE_LARGO);
        CreateLargoProp2(SlimeID.Concrete, SlimeID.Ice, largoIds.CONCRETE_ICE_LARGO);
        CreateLargoProp2(SlimeID.Concrete, SlimeID.Copper, largoIds.CONCRETE_COPPER_LARGO);
        CreateLargoProp2(SlimeID.Concrete, SlimeID.Glass, largoIds.CONCRETE_GLASS_LARGO);
        CreateLargoProp2(SlimeID.Concrete, SlimeID.Cotton, largoIds.CONCRETE_COTTON_LARGO);
        CreateLargoProp2(SlimeID.Concrete, SlimeID.Soil, largoIds.CONCRETE_SOIL_LARGO);
        CreateLargoProp2(SlimeID.Concrete, SlimeID.Grass, largoIds.CONCRETE_GRASS_LARGO);
    }

    // METAL
    static public void MetalLargos()
    {
        // metal largos
        // had to use prop2s
        CreateLargoProp2(SlimeID.Metal, SlimeID.Glue, largoIds.METAL_GLUE_LARGO);
        CreateLargoProp2(SlimeID.Metal, SlimeID.Ice, largoIds.METAL_ICE_LARGO);
        CreateLargoProp2(SlimeID.Metal, SlimeID.Copper, largoIds.METAL_COPPER_LARGO);
        CreateLargoProp2(SlimeID.Metal, SlimeID.Glass, largoIds.METAL_GLASS_LARGO);
        CreateLargoProp2(SlimeID.Metal, SlimeID.Cotton, largoIds.METAL_COTTON_LARGO);
        CreateLargoProp2(SlimeID.Metal, SlimeID.Soil, largoIds.METAL_SOIL_LARGO);
        CreateLargoProp2(SlimeID.Metal, SlimeID.Grass, largoIds.METAL_GRASS_LARGO);
    }

    // GLASS
    static public void GlassLargos()
    {
        // glass largos
        // had to use prop2s
        CreateLargoProp2(SlimeID.Glass, SlimeID.Glue, largoIds.GLASS_GLUE_LARGO);
        CreateLargoProp2(SlimeID.Glass, SlimeID.Ice, largoIds.GLASS_ICE_LARGO);
        CreateLargoProp2(SlimeID.Glass, SlimeID.Copper, largoIds.GLASS_COPPER_LARGO);
        CreateLargoProp2(SlimeID.Glass, SlimeID.Cotton, largoIds.GLASS_COTTON_LARGO);
        CreateLargoProp2(SlimeID.Glass, SlimeID.Soil, largoIds.GLASS_SOIL_LARGO);
        CreateLargoProp2(SlimeID.Glass, SlimeID.Grass, largoIds.GLASS_GRASS_LARGO);
    }

    // COPPER
    static public void CopperLargos()
    {
        // copper largos
        // had to use prop2s
        CreateLargoProp2(SlimeID.Copper, SlimeID.Glue, largoIds.COPPER_GLUE_LARGO);
        CreateLargoProp2(SlimeID.Copper, SlimeID.Ice, largoIds.COPPER_ICE_LARGO);
        CreateLargoProp2(SlimeID.Copper, SlimeID.Cotton, largoIds.COPPER_COTTON_LARGO);
        CreateLargoProp2(SlimeID.Copper, SlimeID.Soil, largoIds.COPPER_SOIL_LARGO);
        CreateLargoProp2(SlimeID.Copper, SlimeID.Grass, largoIds.COPPER_GRASS_LARGO);
    }

    // COTTON
    static public void CottonLargos()
    {
        // cotton largos
        // had to use prop2s
        CreateLargoProp2(SlimeID.Cotton, SlimeID.Ice, largoIds.COTTON_ICE_LARGO);
        CreateLargoProp2(SlimeID.Cotton, SlimeID.Glue, largoIds.COTTON_GLUE_LARGO);
        CreateLargoProp2(SlimeID.Cotton, SlimeID.Soil, largoIds.COTTON_SOIL_LARGO);
        CreateLargoProp2(SlimeID.Cotton, SlimeID.Grass, largoIds.COTTON_GRASS_LARGO);
    }

    // ICE
    static public void IceLargos()
    {
        // ice largos
        // had to use prop2s
        CreateLargoProp2(SlimeID.Ice, SlimeID.Glue, largoIds.ICE_GLUE_LARGO);
        CreateLargoProp2(SlimeID.Ice, SlimeID.Soil, largoIds.ICE_SOIL_LARGO);
        CreateLargoProp2(SlimeID.Ice, SlimeID.Grass, largoIds.ICE_GRASS_LARGO);
    }

    // SOIL
    static public void SoilLargos()
    {
        // soil largos
        // had to use prop2s
        CreateLargoProp2(SlimeID.Soil, SlimeID.Glue, largoIds.SOIL_GLUE_LARGO);
    }

    // GRASS
    static public void GrassLargos()
    {
        // grass largos
        // had to use prop2s
        CreateLargoProp2(SlimeID.Grass, SlimeID.Glue, largoIds.GRASS_GLUE_LARGO);
    }

    // OTHER
    static public void OtherLargos()
    {
        // provider/newbuck largos
        // had to use prop4s
        // CreateLargoProp4(SlimeID.Provider, SlimeID.Newbuck, largoIds.PROVIDER_NEWBUCK_LARGO);

        // silver/crystal largos
        // had to use prop6s
        CreateLargoProp6(SlimeID.Silver, Identifiable.Id.CRYSTAL_SLIME, largoIds.SILVER_CRYSTAL_LARGO);
    }
}