using System;
using SRML.Utils;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SRML.SR;

class PlasticSlime
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
        SlimeDefinition tabbySlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME);
        SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(tabbySlimeDefinition);
        slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
        slimeDefinition.Diet.Produces = new Identifiable.Id[1]
        {
            ModdedIds.plasticIds.PLASTIC_PLORT
        };
        slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[1]
        {
            SlimeEat.FoodGroup.FRUIT
        };
        slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[3]
        {
            ModdedIds.glueIds.GLUE_PLORT,
            Identifiable.Id.BRIAR_HEN,
            itemIds.MATERIAL_SQUEEZE_CRAFT
        };
        slimeDefinition.Diet.Favorites = new Identifiable.Id[3]
        {
            Identifiable.Id.CUBERRY_FRUIT,
            Identifiable.Id.MANGO_FRUIT,
            itemIds.MATERIAL_SQUEEZE_CRAFT
        };
        slimeDefinition.Diet.EatMap?.Clear();
        slimeDefinition.CanLargofy = false;
        slimeDefinition.FavoriteToys = new Identifiable.Id[1];
        slimeDefinition.Name = "Plastic Slime";
        slimeDefinition.IdentifiableId = ModdedIds.plasticIds.PLASTIC_SLIME;
        // OBJECT
        GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.TABBY_SLIME));
        slimeObject.name = "slimePlastic";
        slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<Identifiable>().id = ModdedIds.plasticIds.PLASTIC_SLIME;
        slimeObject.AddComponent<SlimeStealth>();
        UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
        // APPEARANCE
        SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(tabbySlimeDefinition.AppearancesDefault[0]);
        slimeDefinition.AppearancesDefault[0] = slimeAppearance;
        SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
        foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
        {
            Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
            if (defaultMaterials != null && defaultMaterials.Length != 0)
            {
                Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                material.SetColor("_TopColor", new Color32(255, 254, 247, 255));
                material.SetColor("_MiddleColor", new Color32(255, 250, 250, 255));
                material.SetColor("_BottomColor", new Color32(255, 254, 247, 255));
                material.SetColor("_SpecColor", new Color32(255, 250, 250, 255));
                material.SetFloat("_Shininess", 0.870f);
                material.SetFloat("_Gloss", 0.870f);
                slimeAppearanceStructure.DefaultMaterials[0] = material;
            }
        }
        SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
        for (int k = 0; k < expressionFaces.Length; k++)
        {
            SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
            if ((bool)slimeExpressionFace.Mouth)
            {
                slimeExpressionFace.Mouth.SetColor("_MouthBot", new Color32(255, 255, 255, 255));
                slimeExpressionFace.Mouth.SetColor("_MouthMid", new Color32(255, 255, 255, 255));
                slimeExpressionFace.Mouth.SetColor("_MouthTop", new Color32(255, 255, 255, 255));
            }
            if ((bool)slimeExpressionFace.Eyes)
            {   /*
                slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(205, 190, 255, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(182, 170, 226, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(182, 170, 205, 255));
                */
                slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(255, 255, 255, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(255, 255, 255, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(255, 255, 255, 255));
            }
        }
        slimeAppearance.Icon = CreateSprite(LoadImage("Assets.Slimes.Plastic.plastic_slime.png"));
        slimeAppearance.Face.OnEnable();
        slimeAppearance.ColorPalette = new SlimeAppearance.Palette
        {
            Top = new Color32(255, 254, 247, 255),
            Middle = new Color32(255, 250, 250, 255),
            Bottom = new Color32(255, 254, 247, 255),
            Ammo = new Color32(255, 250, 250, 255)
        };
        PediaRegistry.RegisterIdEntry(ModdedIds.plasticIds.PLASTIC_ENTRY, CreateSprite(LoadImage("Assets.Slimes.Plastic.plastic_slime.png")));
        slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
        return (slimeDefinition, slimeObject);
    }
}
