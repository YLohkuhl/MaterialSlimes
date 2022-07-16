// using Behaviours;
using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

class SelfDiscoverySlime
{
    /*public static Identifiable.Id RandomSlime()
    {
        var slimeArray = new Identifiable.Id[5]
        {
            // SLIME ARRAY \\
            ModdedIds.glueIds.GLUE_SLIME,
            ModdedIds.plasticIds.PLASTIC_SLIME,
            ModdedIds.glassIds.GLASS_SLIME,
            ModdedIds.metalIds.METAL_SLIME,
            ModdedIds.woodIds.WOOD_SLIME
            // SLIME ARRAY \\
        };
        Random random = new Random();
        int randomIndex = random.Next(0, slimeArray.Length);
        // int randomIndex = UnityEngine.Random.Range(0, slimeArray.Length);
        var randomSlime = slimeArray[randomIndex];

        return randomSlime;
    }*/

    public static Texture2D LoadImage(string filename)
    {
        var a = Assembly.GetExecutingAssembly();
        var spriteData = a.GetManifestResourceStream(a.GetName().Name + "." + filename);
        var rawData = new byte[spriteData.Length];
        spriteData.Read(rawData, 0, rawData.Length);
        var tex = new Texture2D(1, 1);
        tex.LoadImage(rawData);
        tex.filterMode = FilterMode.Bilinear;
        return tex;
    }
    public static Sprite CreateSprite(Texture2D texture) => Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 1);
    public static (SlimeDefinition, GameObject) CreateSlime(Identifiable.Id SlimeId, String SlimeName)
    {
        // DEFINE
        SlimeDefinition goldSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME);
        SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(goldSlimeDefinition);
        slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
        slimeDefinition.Diet.Produces = new Identifiable.Id[1]
        {
            ModdedIds.woodIds.WOOD_SLIME
        };
        slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[0];
        slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[2]
        {
            Identifiable.Id.KOOKADOBA_FRUIT,
            Identifiable.Id.LEMON_FRUIT
        };
        slimeDefinition.Diet.Favorites = new Identifiable.Id[0];
        slimeDefinition.Diet.EatMap?.Clear();
        slimeDefinition.CanLargofy = false;
        slimeDefinition.FavoriteToys = new Identifiable.Id[0];
        slimeDefinition.Name = "Self Discovery Slime";
        slimeDefinition.IdentifiableId = ModdedIds.discoveryIds.DISCOVERY_SLIME;
        // OBJECT
        GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.GOLD_SLIME));
        slimeObject.name = "slimeDiscovery";
        slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<Identifiable>().id = ModdedIds.discoveryIds.DISCOVERY_SLIME;
        // slimeObject.AddComponent<GoldSlimeFlee>();
        slimeObject.AddComponent<SlimeHover>();
        slimeObject.AddComponent<MaterialDecay>();
        UnityEngine.Object.Destroy(slimeObject.GetComponent<FleeThreats>());
        UnityEngine.Object.Destroy(slimeObject.GetComponent<GoldSlimeProducePlorts>());
        UnityEngine.Object.Destroy(slimeObject.GetComponent<GoldSlimeFlee>());
        UnityEngine.Object.Destroy(slimeObject.GetComponent<SlimeFlee>());
        UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
        // APPEARANCE
        SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(goldSlimeDefinition.AppearancesDefault[0]);
        slimeDefinition.AppearancesDefault[0] = slimeAppearance;
        SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
        foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
        {
            Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
            if (defaultMaterials != null && defaultMaterials.Length != 0)
            {
                Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                material.SetColor("_TopColor", new Color32(255, 153, 0, 255));
                material.SetColor("_MiddleColor", new Color32(255, 191, 94, 255));
                material.SetColor("_BottomColor", new Color32(255, 153, 0, 255));
                material.SetColor("_SpecColor", new Color32(255, 191, 94, 255));
                material.SetFloat("_Shininess", 1f);
                material.SetFloat("_Gloss", 1f);
                slimeAppearanceStructure.DefaultMaterials[0] = material;
            }
        }
        SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
        for (int k = 0; k < expressionFaces.Length; k++)
        {
            SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
            if ((bool)slimeExpressionFace.Mouth)
            {
                slimeExpressionFace.Mouth.SetColor("_MouthBot", Color.white);
                slimeExpressionFace.Mouth.SetColor("_MouthMid", Color.white);
                slimeExpressionFace.Mouth.SetColor("_MouthTop", Color.white);
            }
            if ((bool)slimeExpressionFace.Eyes)
            {   /*
                slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(205, 190, 255, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(182, 170, 226, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(182, 170, 205, 255));
                */
                slimeExpressionFace.Eyes.SetColor("_EyeRed", Color.white);
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", Color.white);
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", Color.white);
            }
        }
        slimeAppearance.Icon = CreateSprite(LoadImage("Assets.Slimes.Discovery.selfdiscovery_slime.png"));
        slimeAppearance.Face.OnEnable();
        slimeAppearance.ColorPalette = new SlimeAppearance.Palette
        {
            Top = new Color32(255, 204, 128, 255),
            Middle = new Color32(255, 191, 94, 255),
            Bottom = new Color32(255, 204, 128, 255)
        };
        PediaRegistry.RegisterIdEntry(ModdedIds.discoveryIds.DISCOVERY_ENTRY, CreateSprite(LoadImage("Assets.Slimes.Discovery.selfdiscovery_slime.png")));
        slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
        return (slimeDefinition, slimeObject);
    }
}