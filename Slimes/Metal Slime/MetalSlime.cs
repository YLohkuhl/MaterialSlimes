using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class MetalSlime
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
        SlimeDefinition quantumSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.QUANTUM_SLIME);
        SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(quantumSlimeDefinition);
        slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
        slimeDefinition.Diet.Produces = new Identifiable.Id[1]
        {
            ModdedIds.metalIds.METAL_PLORT
        };
        slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[2]
        {
            SlimeEat.FoodGroup.VEGGIES,
            SlimeEat.FoodGroup.MEAT
        };
        slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[3]
        {
            ModdedIds.metalIds.METAL_PLORT,
            Identifiable.Id.ROCK_SLIME,
            itemIds.MATERIAL_SQUEEZE_CRAFT
        };
        slimeDefinition.Diet.Favorites = new Identifiable.Id[1]
        {
            itemIds.MATERIAL_SQUEEZE_CRAFT
        };
        slimeDefinition.Diet.EatMap?.Clear();
        slimeDefinition.CanLargofy = false;
        slimeDefinition.FavoriteToys = new Identifiable.Id[1];
        slimeDefinition.Name = "Metal Slime";
        slimeDefinition.IdentifiableId = ModdedIds.metalIds.METAL_SLIME;
        // OBJECT
        GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
        slimeObject.name = "slimeMetal";
        slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<Identifiable>().id = ModdedIds.metalIds.METAL_SLIME;
        // slimeObject.AddComponent<PuddleSlimeScoot>();
        slimeObject.AddComponent<SlimeHover>();
        UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
        // APPEARANCE
        SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(quantumSlimeDefinition.AppearancesDefault[0]);
        slimeDefinition.AppearancesDefault[0] = slimeAppearance;
        SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
        foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
        {
            Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
            if (defaultMaterials != null && defaultMaterials.Length != 0)
            {
                Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.QUANTUM_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                material.SetColor("_TopColor", Color.grey);
                material.SetColor("_MiddleColor", Color.black);
                material.SetColor("_BottomColor", Color.grey);
                material.SetColor("_SpecColor", Color.black);
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
                slimeExpressionFace.Mouth.SetColor("_MouthMid", Color.black);
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
        slimeAppearance.Icon = CreateSprite(LoadImage("Assets.Slimes.Metal.metal_slime.png"));
        slimeAppearance.Face.OnEnable();
        slimeAppearance.ColorPalette = new SlimeAppearance.Palette
        {
            Top = Color.grey,
            Middle = Color.black,
            Bottom = Color.grey,
            Ammo = Color.grey
        };
        PediaRegistry.RegisterIdEntry(ModdedIds.metalIds.METAL_ENTRY, CreateSprite(LoadImage("Assets.Slimes.Metal.metal_slime.png")));
        slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
        return (slimeDefinition, slimeObject);
    }
}