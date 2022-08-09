using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class SilverSlime
{
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
        SlimeDefinition silverDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.CRYSTAL_SLIME);
        SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(silverDefinition);
        slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
        slimeDefinition.Diet.Produces = new Identifiable.Id[1]
        {
            itemIds.SILVER_SHARD_CRAFT
        };
        slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[0];
        slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[5]
        {
            Identifiable.Id.SLIME_FOSSIL_CRAFT,
            Identifiable.Id.STRANGE_DIAMOND_CRAFT,
            ModdedIds.metalIds.METAL_SLIME,
            ModdedIds.concreteIds.CONCRETE_SLIME,
            itemIds.MATERIAL_SQUEEZE_CRAFT
        };
        slimeDefinition.Diet.Favorites = new Identifiable.Id[2]
        {
            Identifiable.Id.STRANGE_DIAMOND_CRAFT,
            itemIds.MATERIAL_SQUEEZE_CRAFT
        };
        slimeDefinition.Diet.EatMap?.Clear();
        slimeDefinition.CanLargofy = false;
        slimeDefinition.FavoriteToys = new Identifiable.Id[0];
        slimeDefinition.Name = "Silver Slime";
        slimeDefinition.IdentifiableId = ModdedIds.silverIds.SILVER_SLIME;
        // OBJECT
        GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.CRYSTAL_SLIME));
        slimeObject.name = "slimeSilver";
        slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<Identifiable>().id = ModdedIds.silverIds.SILVER_SLIME;
        UnityEngine.Object.Destroy(slimeObject.GetComponent<CrystalAppearance>());
        UnityEngine.Object.Destroy(slimeObject.GetComponent<CrystalSpikesLifecycle>());
        UnityEngine.Object.Destroy(slimeObject.GetComponent<CrystalSlimeLaunch>());
        UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
        // APPEARANCE
        var SilverColor = new Color32(192, 192, 192, 255);
        var LightSilverColor = new Color32(200, 200, 200, 255);
        SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(silverDefinition.AppearancesDefault[0]);
        slimeDefinition.AppearancesDefault[0] = slimeAppearance;
        SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
        foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
        {
            Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
            if (defaultMaterials != null && defaultMaterials.Length != 0)
            {
                Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.CRYSTAL_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                material.SetColor("_TopColor", SilverColor);
                material.SetColor("_MiddleColor", LightSilverColor);
                material.SetColor("_BottomColor", SilverColor);
                material.SetColor("_SpecColor", LightSilverColor);
                material.SetFloat("_Shininess", 1f);
                material.SetFloat("_Gloss", 1f);
                slimeAppearanceStructure.DefaultMaterials[0] = material;
                Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(ModdedIds.glueIds.GLUE_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                material2.SetColor("_TopColor", SilverColor);
                material2.SetColor("_MiddleColor", LightSilverColor);
                material2.SetColor("_BottomColor", SilverColor);
                slimeAppearance.Structures[1].DefaultMaterials[0] = material2;
            }
        }
        SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
        for (int k = 0; k < expressionFaces.Length; k++)
        {
            SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
            if ((bool)slimeExpressionFace.Mouth)
            {
                slimeExpressionFace.Mouth.SetColor("_MouthBot", Color.black);
                slimeExpressionFace.Mouth.SetColor("_MouthMid", Color.black);
                slimeExpressionFace.Mouth.SetColor("_MouthTop", Color.black);
            }
            if ((bool)slimeExpressionFace.Eyes)
            {   /*
                slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(205, 190, 255, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(182, 170, 226, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(182, 170, 205, 255));
                */
                slimeExpressionFace.Eyes.SetColor("_EyeRed", Color.black);
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", Color.black);
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", Color.black);
            }
        }
        slimeAppearance.Icon = CreateSprite(LoadImage("Assets.Slimes.Silver.silver_slime.png"));
        slimeAppearance.Face.OnEnable();
        slimeAppearance.ColorPalette = new SlimeAppearance.Palette
        {
            Top = SilverColor,
            Middle = SilverColor,
            Bottom = SilverColor,
            Ammo = SilverColor
        };
        PediaRegistry.RegisterIdEntry(ModdedIds.silverIds.SILVER_ENTRY, CreateSprite(LoadImage("Assets.Slimes.Silver.silver_slime.png")));
        slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
        return (slimeDefinition, slimeObject);
    }
}